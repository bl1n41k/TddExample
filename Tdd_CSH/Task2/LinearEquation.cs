using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public class LinearEquation
    {
        private List<double> coefficient = new List<double>();

        public LinearEquation(double[] coefficient)
        {
            this.coefficient = coefficient.ToList();
        }

        public LinearEquation(List<double> coefficient)
        {
            this.coefficient = coefficient.ToList();
        }
        public LinearEquation(IEnumerable<double> coefficient)
        {
            this.coefficient = coefficient.ToList();
        }

        public LinearEquation(string _coefficient)
        {
            string[] coefficient = Regex.Split(_coefficient, @"[^\d.-]");
            for (int i = 0; i < coefficient.Length; i++)
            {
                if (coefficient[i] != "")
                {
                    coefficient[i] = coefficient[i].Replace('.', ',');
                    this.coefficient.Add(double.Parse(coefficient[i]));
                }
            }
        }

        public LinearEquation(int n)
        {
            if (n > 0)
            {
                coefficient = new List<double>();
                for (int i = 0; i <= n; i++) coefficient.Add(0);
            }
            else throw new ArgumentException();
        }

        public int Size
        {
            get => coefficient.Count;
        }

        public void RandomInitialization()
        {
            Random rand = new Random();
            for (int i = 0; i < Size; i++) coefficient[i] = rand.Next(35) / 10;
        }

        public void SameInitialization(double value)
        {
            for (int i = 0; i < Size; i++) coefficient[i] = value;
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < Size) return coefficient[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Size) coefficient[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public override string ToString()
        {
            string result = "";
            int i;
            for (i = 0; i < Size - 2; i++)
            {
                result += (coefficient[i + 1] >= 0) ? (coefficient[i].ToString() + 'x' + (i + 1).ToString() + '+') : (coefficient[i].ToString() + 'x' + (i + 1).ToString());
            }
            result += (coefficient[i].ToString() + 'x' + (i + 1).ToString());
            result += '=' + coefficient[Size - 1].ToString();
            return result;
        }
        public static LinearEquation operator +(LinearEquation a, LinearEquation b)
        {
            var result = a.coefficient.Zip(b.coefficient, (first, second) => first + second);
            return new LinearEquation(result);
        }
        public static LinearEquation operator -(LinearEquation a, LinearEquation b)
        {
            var result = a.coefficient.Zip(b.coefficient, (first, second) => first - second);
            return new LinearEquation(result);
        }

        public static LinearEquation operator *(LinearEquation a, double r)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Size; i++)
                result.Add(a[i] * r);
            return new LinearEquation(result);
        }

        public static LinearEquation operator -(LinearEquation a)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Size; i++) result.Add(-a[i]);
            return new LinearEquation(result);
        }

        public static LinearEquation operator *(double r, LinearEquation a)
        {
            return a * r;
        }

        public static bool operator ==(LinearEquation a, LinearEquation b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(LinearEquation a, LinearEquation b)
        {
            return !(a == b);
        }

        public static implicit operator double[](LinearEquation a)
        {
            return a.coefficient.ToArray();
        }

        public static bool operator false(LinearEquation a)
        {
            if (a) return false;
            else return true;
        }

        public static bool operator true(LinearEquation a)
        {
            for (int i = 0; i < a.Size - 1; i++)
                if (a[i] != 0) return true; 
            return (a[a.Size - 1] != 0) ? false : true;
        }

        public void Copy(LinearEquation b)
        {
            b.coefficient = coefficient.ToList();
        }

        public bool IsNull()
        {
            for (int i = 0; i < Size; i++)
                if (this[i] != 0) return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            LinearEquation b = (LinearEquation)obj;
            for (int i = 0; i < Size; i++)
            {
                if (Math.Abs(this[i] - b[i]) > 1e-9) return false;
            }
            return true;
        }
    }
}

