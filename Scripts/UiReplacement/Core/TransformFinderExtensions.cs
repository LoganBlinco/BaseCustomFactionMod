using UnityEngine;

namespace BaseCustomFactions.Core
{
    public static class TransformFinderExtensions
    {
        public static Transform? GetChildWithNameContains(this Transform parant, string targetName)
        {
            int childCount = parant.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform workingChild = parant.GetChild(i);
                if (workingChild.name.Contains(targetName))
                {
                    return workingChild;
                }
            }
            return null;
        }
        
        public static Transform? GetChild(this Transform parant, string targetName)
        {
            return parant.GetChildWithNameContains(targetName);
        }
    }
}