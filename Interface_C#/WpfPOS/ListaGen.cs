﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{

    internal class ListaGen<T>
    {
        public class Nod
        {
            public ListaGen<T>.Nod Next { get; set; }
            public T Data { get; set; }

            public Nod(T t) { Next = null; Data = t; }
        }
        public uint Count { get; set; }
        private ListaGen<T>.Nod Inceput { get; set; }

        public ListaGen() { Inceput = null; Count = 0; }
        public void Add(T t)
        {
            Nod n = new Nod(t);
            n.Next = Inceput;
            Inceput = n;
            Count++;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Nod current = Inceput;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
