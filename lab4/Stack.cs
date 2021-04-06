using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab_TA_4.Model
{
    class Stack<T> : IEnumerable
    {
        public ItStack<T> Tail { get; private set; }

        public ItStack<T> Head { get; private set; }

        public int Count;

        public Stack()
        {
            Tail = default;
            Head = default;
            Count = 0;
        }
        public Stack(T data)
        {
            SetHeadAndTail(data);        
        }
        private void SetHeadAndTail(T data)
        {
            var item = new ItStack<T>(data);
            Head = item;
            Tail = item;
            Count++;
        }
        public void Push(T data)
        {
            var item = new ItStack<T>(data)
            {
                Previous = Head
            };
            Head = item;
            Count++;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
        public T Pop()
        {
            if (Count > 0)
            {
                var item = Head;
                Head = Head.Previous;
                Count--;
                return item.Data;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public bool IsEmpty()
        {
            return Head == null && Tail == null;
        }
        public void Clear()
        {
            Head = default;
            Tail = default;
            Count = 0;
        }
        public T Top()
        {
            if (Head != null) return Head.Data;
            throw new NullReferenceException();
        }
        public int Size()
        {
            return Count;
        }
        public void Swap()
        {
            var item = Head.Data;
            Head.Data = Head.Previous.Data;
            Head.Previous.Data = item;            
        }
       
    }
}
