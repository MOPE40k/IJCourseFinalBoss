using System.Collections.Generic;

namespace Runtime.Utils
{
    public static class RemoveElementFromBuffer<T> where T : class
    {
        public static void Remove(T collider, Buffer<T> buffer)
        {
            int indexToRemove = -1;

            for (int i = 0; i < buffer.Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(buffer.Items[i], collider))
                {
                    indexToRemove = i;

                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                buffer.Items[indexToRemove] = buffer.Items[buffer.Count - 1];
                buffer.Count--;
                buffer.Items[buffer.Count] = null;
            }
        }
    }
}