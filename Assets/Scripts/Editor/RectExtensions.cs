using UnityEngine;

namespace Editor
{
    public static class RectExtensions
    {
        public static Rect GetCopy(this Rect position, float overrideHeight, float widthMultiplier = 1.0f, 
            float xOffset = 0.0f)
        {
            var x = position.x + xOffset;
            var y = position.y;
            var width = (position.width - xOffset) * widthMultiplier;
            var height = overrideHeight;
            return new Rect(x, y, width, height);
        }

        public static Rect GetCopy(this Rect position)
        {
            return new Rect(position.x, position.y, position.width, position.height);
        }
    }
}