using System;


namespace Lab_TA_4.Model
{
    class ArrayStack<T>
    {
        T[] items;

        
        private int current = -1;
        private readonly int size = 10;
        public ArrayStack(int size = 10)
        {
            items = new T[size];
            this.size = size;
        }
        public ArrayStack(T data, int size = 10) : this(size)
        {
           
            items[current] = data;
            current = 1;
        }
        public void Push(T data)
        {
            if(current < size)
            {
                items[current] = data;
                current++;
            }
            else
            {
                throw new StackOverflowException();
            }

        }
        public T Pop()
        {
            if(current >= 0)
            {
                var item = items[current];
                items[current] = default;
                current--;
                return item;
            }
            else
            {
                throw new StackOverflowException();
            }
        }
    }
}
