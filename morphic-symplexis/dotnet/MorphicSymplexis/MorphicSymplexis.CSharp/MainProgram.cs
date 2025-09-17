using System;
using System.Linq;

namespace MorphicSymplexis.CSharp
{

    public class MainProgram
    {
        // A concrete subclass for a free category over strings
        public class MyFreeCategory : FreeCategory<string, string> { }

        public static void Main()
        {
            // Instantiate a free category (as an Object of a Class)
            var C = new MyFreeCategory();

            // Define objects
            var X = "X";
            var Y = "Y";
            var Z = "Z";
            var W = "W";

            // Define generating morphisms (edges of the graph)
            C.AddMorphism(X, Y, "f");
            C.AddMorphism(Y, Z, "g");
            C.AddMorphism(Z, W, "h");

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

            // Axiom 1: Identity morphism
            var idX = C.Identity(X);
            Console.WriteLine($"\nIdentity on X: {idX}");

            var idY = C.Identity(Y);
            Console.WriteLine($"Identity on Y: {idY}");

            // Axiom 2: All morphisms X → W
            var morphismsXW = C.Morphisms(X, W);
            Console.WriteLine("\nAll morphisms X → W:");
            foreach (var m in morphismsXW)
                Console.WriteLine($"  {m}");

            // Axiom 3: Compose f : X → Y and g : Y → Z
            var f = C.Morphisms(X, Y).First(m => m.ToString().Contains('f'));
            var g = C.Morphisms(Y, Z).First(m => m.ToString().Contains('g'));
            var g_f = C.Compose(f, g);
            Console.WriteLine($"\nComposition g ∘ f = {g_f}");

            // Identity morphism acting as a right or left identity on f
            Console.WriteLine($"\nIdentity morphism acting as a right or left identity on f:");
            var idX_f = C.Compose(idX, f);
            Console.WriteLine($"\nComposition id_X ∘ f = {idX_f}");
            var f_idY = C.Compose(f, idY);
            Console.WriteLine($"Composition f ∘ id_Y = {f_idY}");

        }
    }
}
