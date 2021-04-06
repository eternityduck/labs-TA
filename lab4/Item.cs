using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab_TA_4.Model
{
    class Item<T> 
    {
        private T data = default;
        public Item<T> Next = null;

        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                data = (value == null) ? throw new ArgumentNullException(nameof(value)) : value;
            }
        }
        public Item(T data)
        {
            Data = data;
        }

       
    }
}
