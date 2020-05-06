using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Indexer
    {
        private double[] array;
        private int begin;
        private int length;
  
        public Indexer(double[] arr, int begin, int length)
        {
            if (begin < 0 || length < 0 || begin + length > arr.Length) throw new ArgumentException();
            else
            {
                this.array = arr;
                this.begin = begin;
                this.length = length;
            }
        }

        public int Length
        {
            get 
            { 
                return length; 
            }
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Length || index + begin >= array.Length) throw new IndexOutOfRangeException();
                else return array[index + begin];
            }
            set
            {
                if (index < 0 || index >= Length || index + begin >= array.Length) throw new IndexOutOfRangeException();
                else array[index + begin] = value;
            }
        }
    }
}
