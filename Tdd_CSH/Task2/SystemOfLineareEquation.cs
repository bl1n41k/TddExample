﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SystemOfLinearEquation
    {
        private List<LinearEquation> system = new List<LinearEquation>();
        private int n;

        public SystemOfLinearEquation(int n)
        {
            this.n = n;
        }
        public LinearEquation this[int index] // Доступ к уравнению 
        {
            get
            {
                if (index >= 0 && index < Size) return system[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Size) system[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public int Size => system.Count; // Размер СЛУ

        public void StepUp() // Приводим систему к ступенчатому виду
        {
            int c, z;
            double p1, p2;
            for (int i = 0; i < Size; i++)
            {
                z = i;
                if (this[i][z] == 0)
                {
                    while (this[i][z] == 0 && z < n) z++;
                    c = 1;
                    while ((i + c) < Size && this[i + c][z] == 0) 
                        c++;
                    if ((i + c) == Size) //Если СЛУ ступенчатого вида
                    {
                        return;
                    }
                    Swap(this[i], this[i + c]); //меняем уравнения местами таким образом, чтобы наибольшее кол-во не 0-вых элементов было в 1-ой строке, а наименьшее в последней
                }
                for (int j = i + 1; j < Size; j++)
                {
                    p1 = this[i][z];
                    p2 = this[j][z];
                    this[j] = this[j] * p1 - this[i] * p2;
                }
            }
        }

        public double[] Solve() // Решаем уравнение
        {
            while (this[Size - 1].IsNull()) this.Delete(Size - 1); // Удаляем пустые строки
            if (this[Size - 1])
            {
                if (Size == n)
                {
                    double[] solve = new double[n];
                    for (int i = Size - 1; i >= 0; i--)
                    {
                        solve[i] = this[i][n];
                        for (int j = i + 1; j < n; j++)
                        {
                            solve[i] -= this[i][j] * solve[j];
                        }
                        solve[i] /= this[i][i];
                    }
                    return solve;
                }
                else throw new ArgumentException("Множество решений!");
            }
            else throw new ArgumentException("Нет решений!");
        }

        private void Swap(LinearEquation a, LinearEquation b) 
        {
            LinearEquation temp = new LinearEquation(a);
            b.Copy(a);
            temp.Copy(b);
        }

        public void Add(LinearEquation a) // Добавляем уравнение в СЛУ
        {
            if (a.Size == n + 1)
                system.Add(a);
            else throw new ArgumentException();
        }

        public void Delete(int index) // Удаляем уравнение из СЛУ
        {
            system.RemoveAt(index);
        }

        public override string ToString() 
        {
            string result = "";
            for (int i = 0; i < Size; i++)
            {
                result += this[i].ToString() + '\n';
            }
            return result;
        }
    }
}
