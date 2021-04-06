using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab_TA_4.Model
{
    class LinkedList<T> : IEnumerable
    {
        public Item<T> Head { get; private set; }

        public Item<T> Tail { get; private set; }

        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            SetHeadAndTail(item);

        }
        public void Add(T data)
        {
            var item = new Item<T>(data);
            if(Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(item);
            }
        }
        public void Delete(T data)
        {
            var item = new Item<T>(data);
            if(Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count++;
                    return;
                }
                var current = Head.Next;
                var previous = Head;
                while(current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                }
            }
            else
            {
                SetHeadAndTail(item);
            }

        }
        private void SetHeadAndTail(Item<T> item)
        {
            
            Head = item;
            Tail = item;
            Count = 1;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }

        }
        public override string ToString()
        {
            return "Linked List: " + Count + "elements";
        }

        public override bool Equals(object obj)
        {
            return obj is LinkedList<T> list &&
                   EqualityComparer<Item<T>>.Default.Equals(Head, list.Head) &&
                   EqualityComparer<Item<T>>.Default.Equals(Tail, list.Tail) &&
                   Count == list.Count;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Head, Tail, Count);
        }
        public void DeleteAll()
        {
            Head = default;
            Tail = default;
            Count = 0;
        }
        
        public void AppendStart(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }       
        public void AppendAfter(T aim, T data)
        {
            var item = new Item<T>(data);
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    
                    if (current.Data.Equals(aim))
                    {
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }          
        }
    }
}
