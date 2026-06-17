using Godot;
using System.Collections.Generic;
using System.Linq;

namespace Game.Extensions
{
    public static class NodeExtension
    {
        public static T GetComponentInChildren<T>(this Node source) 
            where T : Node
        {
            return GetComponentsInChildren<T>(source)
                .FirstOrDefault();
        }

        public static IEnumerable<T> GetComponentsInChildren<T>(this Node source) 
            where T : Node
        {
            return source
                .GetChildren()
                .OfType<T>();
        }
    }
}
