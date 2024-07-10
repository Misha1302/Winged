using System;

namespace View
{
    [Serializable]
    public class Pair<T>
    {
        public T item1;
        public T item2;

        public Pair(T item1, T item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T this[int i] =>
            i switch
            {
                0 => item1,
                1 => item2,
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}