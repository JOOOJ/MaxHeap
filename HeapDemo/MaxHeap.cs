﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapDemo
{
    public class MaxHeap<T> : ICollection<T>
        where T : IComparable
    {
        private T[] _array = null;
        private int _count = 0;

        public MaxHeap(int capacity)
        {
            _array = new T[capacity];
        }

        public MaxHeap(T[] array)
        {
            _array = new T[array.Length];
            Array.Copy(array, _array, array.Length);
            _count = array.Length;
            Create();
        }

        public void Sort()
        {
            if (_array != null)
            {
                int len = _array.Length;
                while (len > 0)
                {
                    len--;
                    Swap(0, len);
                    RebuildFromTop(len - 1);
                }
            }
        }

        public void Add(T item)
        {
            if (_array.Length > _count)
            {
                _array[_count + 1] = item;
            }
            else
            {
                T[] tempArray = new T[_array.Length];
                Array.Copy(_array, tempArray, _array.Length);
                _array = new T[_array.Length * 2];
                Array.Copy(tempArray, _array, tempArray.Length);
            }            
            _count++;
            RebuildFromBotton();
        }

        public void Clear()
        {
            _array = new T[_array.Length];
        }

        public bool Contains(T item)
        {
            if (_array != null)
            {
                foreach (T t in _array)
                {
                    if (item.Equals(t))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            int index = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].CompareTo(item)==0)
                {
                    index = i;
                }
            }
            for (int i = index; i < _array.Length-1; i++)
            {
                _array[i] = _array[i + 1];
            }
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count+1; i++)
            {
                yield return _array[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Print()
        {
            foreach (T item in _array)
            {
                Console.WriteLine(item);
            }
        }

        private void RebuildFromTop(int length)
        {
            int len = length / 2-1;
            int index = 0;
            while (index<=len)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                if (_array[index].CompareTo(_array[left]) > 0)
                {
                    if (_array[index].CompareTo(_array[right]) < 0)
                    {
                        Swap(index, right);
                        index = right;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (_array[left].CompareTo(_array[right]) > 0)
                    {
                        Swap(index, left);
                        index = left;
                    }
                    else
                    {
                        Swap(index, right);
                        index = right;
                    }
                }
            }
        }

        private void RebuildFromBotton()
        {

        }

        private void Create()
        {
            if (_array != null)
            {
                for (int i = _array.Length / 2 - 1; i >= 0; i--)
                {
                    int left = 2 * i + 1;
                    int right = 2 * i + 2;
                    if (right <= _array.Length)
                    {
                        if (_array[i].CompareTo(_array[left]) > 0)
                        {
                            if (_array[i].CompareTo(_array[right]) < 0)
                            {
                                Swap(i, right);
                            }
                        }
                        else
                        {
                            if (_array[left].CompareTo(_array[right]) > 0)
                            {
                                Swap(i, left);
                            }
                            else
                            {
                                Swap(i, right);
                            }
                        }
                    }
                    else if (left <= _array.Length)
                    {
                        if (_array[i].CompareTo(_array[left]) < 0)
                        {
                            Swap(i, left);
                        }
                    }
                }
            }
        }

        private void Swap(int indexA, int indexB)
        {
            T temp = _array[indexA];
            _array[indexA] = _array[indexB];
            _array[indexB] = temp;
        }



        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
    }
}
