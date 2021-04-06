using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_TA_4.Model
{
    class ItStack<T>
    {
        public T Data { get; set; }
        public ItStack<T> Previous { get; set; }

        public ItStack(T data)
        {
            Data = data;
        }
    }
}
