using System.Collections.Generic;

namespace MorphicSymplexis.CSharp
{
    // General definition of a category (as an Interface)
    public interface ICategory<TObj>
    {
        IEnumerable<TObj> Objects { get; }

        // <-- Axiom 1: Existence of identity morphism -->
        // Returns the identity morphism for an object X
        IMorphism<TObj> Identity(TObj obj);

        // <-- Axiom 2: Existence of other morphisms -->
        // Returns all morphisms from X to Y
        IEnumerable<IMorphism<TObj>> Morphisms(TObj from, TObj to);

        // <-- Axiom 3: Existence of composition of morphisms -->
        // Returns compositions f and g
        IMorphism<TObj> Compose(IMorphism<TObj> f, IMorphism<TObj> g); 
    }
}
