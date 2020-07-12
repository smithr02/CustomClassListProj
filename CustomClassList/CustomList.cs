using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassList
{
    public class CustomList<T> : IEnumerable
    {
        // member variables (HAS A)
        private T[] items;
        private int capacity;
        private int count;
        public int Capacity { get => capacity; }
        public int Count { get => count; }
        // constructor (SPAWNER)
        public CustomList()
        {
            items = new T[4];
            capacity = 4;
            count = 0;
        }

        // member methods (CAN DO)
        public void Add(T item)
        {
            // check if current array has an empty spot
            // if we find a spot put the item there, if we get to the of the array with no empty spots,
            // double the size and add the item to the next created spot.

            if (count == capacity)
            {
                DoubleCapacity();
            }
            for (int i = 0; i < capacity; i++)
            {
                if (items[i].Equals(default(T))) //if the spot in items array is null then setting that spot to the item that is being passed in.
                {
                    items[i] = item; //setting the item thats being passed in
                    count++;   //increasing the count to keep track of the items in the array
                    break;
                }
            }

        }

        private void DoubleCapacity()
        {
            T[] temp = new T[capacity * 2]; //creating a new generic array with capacity times 2

            for (int i = 0; i < capacity; i++)
            {
                temp[i] = items[i]; // temps first spot is being replaced by items first spot value.
            }
            capacity = capacity * 2;
            items = temp; //replace items with the new array called temp
        }

        public bool Remove(T item)
        {
            bool removed = false;
            for (int i = 0; i < capacity; i++) //looping through the array, checking per say
            {
                if (items[i].Equals(item)) //if items at said index is equal to the item that is passed in
                {
                    items[i] = default(T); //set it to "null" or default(T)
                    count--;
                    RemoveNull();
                    removed =true;
                    break;
                }
            }

            return removed;
        }
        public bool RemoveAll(T item)
        {
            bool removed = false;
            for (int i = 0; i < capacity; i++) //looping through the array, checking per say
            {
                if (items[i].Equals(item)) //if items at said index is equal to the item that is passed in
                {
                    items[i] = default(T); //set it to "null" or default(T)
                    count--;
                    RemoveNull();
                    removed = true;
                }
            }

            return removed;
        }

        private void RemoveNull()
        {
            T[] temp = new T[capacity];
            int i = 0;
            int p = 0;
            while (i < capacity)
            {
                if (!items[i].Equals(default(T)))
                {
                    temp[p] = items[i];
                    i++;
                    p++;
                }
                else
                {
                    i++; 
                }
            }
            items = temp;
        }


        public T this[int index]
        {
            get
            {
                if (index < 0 && index >= items.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                return items[index];
            }

            set
            {
                if (index < 0 || index >= items.Length)
                    throw new IndexOutOfRangeException("Index out of range");
                items[index] = value;
            }
        }

        public override string ToString()
        {
            string tempString = "";
            for (int i = 0; i < count; i++)
            {
                tempString += items[i].ToString();
                if (i + 1 != count)
                    tempString += ",";               
            }
            return tempString;
        }

        public static CustomList<T> operator +(CustomList<T> one, CustomList<T> two)
        {
            CustomList<T> temp = new CustomList<T>();
            for (int i = 0; i < one.count; i++)
            {
                temp.Add(one[i]);
            }
            for (int i = 0; i < two.count; i++)
            {
                temp.Add(two[i]);
            }
            return temp;
        }
        public  CustomList<T> ZIP (CustomList<T> one, CustomList<T> two)
        {
            int index = 0;
            CustomList<T> temp = new CustomList<T>();

            while (index < one.Count || index < two.Count)
            {
                if (index < one.Count)
                {
                    temp.Add(one[index]);
                }

                if (index < two.Count)
                {
                    temp.Add(two[index]);
                }

                index++;
            }
           
            return temp;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        /// <summary>
        ///  Runs through list two and deletes all references in one
        ///  EX. Two{2,1,6} One {1,3,5} result One {3,5}
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns CustomList></returns>
        public static CustomList<T> operator -(CustomList<T> one, CustomList<T> two)
        {
            
            for (int j = 0; j < two.count; j++)
            {                                    
               one.Remove(one[j]); // number from list two gets removed from list one               
            }
            return one;
        }
    }
}
