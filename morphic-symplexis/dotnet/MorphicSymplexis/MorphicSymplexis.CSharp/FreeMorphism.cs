using System;
using System.Collections.Generic;
using System.Linq;

namespace MorphicSymplexis.CSharp
{
    // Definition of a morphism in a free category using a path (as a Class)
    public class FreeMorphism<TObj, TLabel> : IMorphism<TObj>
    {
        public TObj Domain { get; private set; }
        public TObj Codomain { get; private set; }

        // A list of labels representing the path
        public List<(TObj From, TObj To, TLabel Label)> Path { get;
            private set; }

        public bool IsIdentity => Path.Count == 0;

        public FreeMorphism(TObj obj)
        {
            Domain = obj;
            Codomain = obj;
            Path = new List<(TObj, TObj, TLabel)>(); // Identity morphism
        }

        public FreeMorphism(List<(TObj From, TObj To, TLabel Label)> path)
        {
            if (path.Count == 0)
                throw new ArgumentException(
                    "Non-identity morphisms must have at least one edge.");

            Path = path;
            Domain = path.First().From;
            Codomain = path.Last().To;
        }

        public override string ToString()
        {
            if (IsIdentity)
                return $"id_{Domain}";

            var labels = Path.AsEnumerable().Reverse().Select(p => p.Label?.ToString());
            var composition = string.Join(" ∘ ", labels);

            return $"{composition} : {Domain} → {Codomain}";
        }
    }
}
