namespace Runtime.Utils
{
    public class Buffer<T>
    {
        // Runtime
        public T[] Items = null;
        public int Count = 0;

        public Buffer(int initialSize)
            => Items = new T[initialSize];
    }
}