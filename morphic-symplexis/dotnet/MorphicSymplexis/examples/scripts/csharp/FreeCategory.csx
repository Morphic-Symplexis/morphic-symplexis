// === Load the compiled library ===
#r "../../../MorphicSymplexis.CSharp/bin/Debug/net6.0/MorphicSymplexis.CSharp.dll"

using MorphicSymplexis.CSharp;
using System;
using System.Collections.Generic;

// === Helper function to construct objects and morphisms ===
void ConstructFreeCategory(int n)
{
    if (n < 2)
    {
        Console.WriteLine("You need at least 2 objects to create morphisms.");
        return;
    }

    // Instantiate a free category (as an Object of a Class)
    var C = new MyFreeCategory();

    // Define objects
    var objects = new List<string>();
    for (int i = 0; i < n; i++)
    {
        objects.Add($"X{i}");
    }

    // Define generating morphisms (edges of the graph) between successive objects (nodes)
    Console.WriteLine("\nAdding morphisms:");
    for (int i = 0; i < n - 1; i++)
    {
        string from = objects[i];
        string to = objects[i + 1];
        string label = $"m_{i}";

        C.AddMorphism(from, to, label);

        Console.WriteLine($"  {label}: {from} → {to}");
    }

    Console.WriteLine("\nAll objects:");

    // Print all objects
    foreach (var obj in C.Objects)
    {
        Console.WriteLine($"Object: {obj}");
    }

    Console.WriteLine("\nAll morphisms:");

    // Print all morphisms
    foreach (var morph in C.GetMorphisms())
    {
        Console.WriteLine($"Morphism: {morph}");
    }

    var X = objects[0];
    var Y = objects[1];
    var f = C.Morphisms(X, Y).First(m => m.ToString().Contains("m_0"));
    
    // Axiom 1: Identity morphism
    var idX = C.Identity(X);
    Console.WriteLine($"\nIdentity on X: {idX}");

    var idY = C.Identity(Y);
    Console.WriteLine($"Identity on Y: {idY}");

    // Axiom 2: All morphisms X → Y
    var morphismsXW = C.Morphisms(X, Y);
    Console.WriteLine("\nAll morphisms X0 → X1:");
    foreach (var m in morphismsXW)
        Console.WriteLine($"  {m}");
    
    if (n >= 3)
    {
        var Z = objects[2];

        // Axiom 3: Compose f : X → Y and g : Y → Z
        var g = C.Morphisms(Y, Z).First(m => m.ToString().Contains("m_1"));
        var g_f = C.Compose(f, g);
        Console.WriteLine($"\nComposition m_1 ∘ m_0 = {g_f}");
    }

    // Identity morphism acting as a right or left identity on f
    Console.WriteLine("\nIdentity morphism acting as a right or left identity on m_0:");
    var idX_f = C.Compose(idX, f);
    Console.WriteLine($"Composition id_X ∘ m_0 = {idX_f}");
    var f_idY = C.Compose(f, idY);
    Console.WriteLine($"Composition m_0 ∘ id_Y = {f_idY}");

}

Console.WriteLine("\nCalling C# library from a stand-alone script ...");

// A concrete subclass (implementing an abstract class) for a free category over strings
public class MyFreeCategory : FreeCategory<string, string> { }

// int n_objects = Args.Count > 0 ? int.Parse(Args[0]) : 4;

var flags = ArgParser.Parse(Args);
int n_objects = ArgParser.Get(flags, "n_obj", 4);
bool verbose = ArgParser.Get(flags, "verbose", false);

if (verbose)
    Console.WriteLine($"\n[DEBUG] Parsed n_obj = {n_objects}");

// === Run main ===
ConstructFreeCategory(n_objects);
