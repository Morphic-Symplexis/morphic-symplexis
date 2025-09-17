namespace MorphicSymplexis.CSharp
{
    // General definition of a morphism (as an Interface)
    public interface IMorphism<TObj>
    {
        TObj Domain { get; }
        TObj Codomain { get; }
        string ToString(); // for debugging
    }
}
