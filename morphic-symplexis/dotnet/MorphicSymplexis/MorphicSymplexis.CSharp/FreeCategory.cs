using System;
using System.Collections.Generic;
using System.Linq;

namespace MorphicSymplexis.CSharp
{
    //  Definition of a free category (as an Abstract Class)
    public abstract class FreeCategory<TObj, TLabel> : ICategory<TObj>
    {
        protected readonly HashSet<TObj> _objects = new();
        protected readonly List<(TObj From, TObj To, TLabel Label)> _generators =
            new();
    
        // Enumerate all morphisms in the category
        public IEnumerable<TObj> Objects => _objects;

        // User-defined generator: adds a morphism generator (edge)
        public void AddMorphism(TObj from, TObj to, TLabel label)
        {
            _objects.Add(from);
            _objects.Add(to);
            _generators.Add((from, to, label));
        }

        // Enumerate all unique morphisms in the category, which includes:
        // - identities
        // - generators
        // - compositions (up to a depth)
        public IEnumerable<IMorphism<TObj>> GetMorphisms()
        {
            var morphisms = new HashSet<string>(); // to avoid duplicates
            var results = new List<IMorphism<TObj>>();

            foreach (var from in _objects)
            {
                foreach (var to in _objects)
                {
                    foreach (var m in Morphisms(from, to))
                    {
                        // Use ToString() as a unique identifier
                        if (m is FreeMorphism<TObj, TLabel> fm)
                        {
                            var key = fm.ToString();
                            if (morphisms.Add(key))
                                results.Add(fm);
                        }
                    }
                }
            }

            return results;
        }

        // Axiom 1: Identity morphism for every object
        public IMorphism<TObj> Identity(TObj obj)
        {
            if (!_objects.Contains(obj))
                throw new InvalidOperationException($"Object '{obj}' not in category.");
            return new FreeMorphism<TObj, TLabel>(obj);
        }

        // Axiom 2: All morphisms from X to Y, which includes:
        //  - identity
        //  - generators
        //  - all possible compositions (up to a limit)
        public IEnumerable<IMorphism<TObj>> Morphisms(TObj from, TObj to)
        {
            const int maxLength = 10; // avoid infinite recursion — can be tuned
            var results = new List<FreeMorphism<TObj, TLabel>>();

            // Identity
            if (EqualityComparer<TObj>.Default.Equals(from, to))
                results.Add(new FreeMorphism<TObj, TLabel>(from));

            // Start BFS from `from` to collect paths to `to`
            var queue = new Queue<(TObj Current, List<(TObj, TObj, TLabel)> Path)>();
            foreach (var edge in _generators.Where(e => EqualityComparer<TObj>.Default.Equals(e.From, from)))
            {
                queue.Enqueue((edge.To, new List<(TObj, TObj, TLabel)> { edge }));
            }

            while (queue.Count > 0)
            {
                var (current, path) = queue.Dequeue();
                if (path.Count > maxLength) continue;

                if (EqualityComparer<TObj>.Default.Equals(current, to))
                    results.Add(new FreeMorphism<TObj, TLabel>(new List<(TObj, TObj, TLabel)>(path)));

                foreach (var edge in _generators.Where(e => EqualityComparer<TObj>.Default.Equals(e.From, current)))
                {
                    var newPath = new List<(TObj, TObj, TLabel)>(path) { edge };
                    queue.Enqueue((edge.To, newPath));
                }
            }

            return results;
        }

        // Axiom 3: Composition of two morphisms
        public IMorphism<TObj> Compose(IMorphism<TObj> f, IMorphism<TObj> g)
        {
            // g ∘ f is defined only when f: X → Y and g: Y → Z
            if (!EqualityComparer<TObj>.Default.Equals(f.Codomain, g.Domain))
                throw new InvalidOperationException("Cannot compose: codomain of f must match domain of g.");

            if (f is not FreeMorphism<TObj, TLabel> fm || g is not FreeMorphism<TObj, TLabel> gm)
                throw new InvalidOperationException("Expected morphisms to be of type FreeMorphism<TObj, TLabel>.");

            // Compose: g ∘ f : X → Z
            var composedPath = fm.Path.Concat(gm.Path).ToList();

            if (composedPath.Count == 0)
                return new FreeMorphism<TObj, TLabel>(f.Domain); // identity morphism

            return new FreeMorphism<TObj, TLabel>(composedPath);
        }
    }
}
