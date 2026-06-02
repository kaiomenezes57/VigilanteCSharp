using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Game.Extensions
{
    public static class CollectionsExtension
    {
        public static T GetRandom<T>(this IEnumerable<T> source)
        {
            if (source.Count() == 1)
                return source.First();

            var randomIndex = GD.RandRange(0, source.Count() - 1);
            return source.ElementAt(randomIndex);
        }
    }
}
