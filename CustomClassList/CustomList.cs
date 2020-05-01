﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassList
{
    public class CustomList<T>
    {
        // member variables (HAS A)
        private T[] items;
        private int capacity;
        public int Count;
        // constructor (SPAWNER)
        public CustomList()
        {
            items = new T[4];
            capacity = 4;
            Count = 0;
        }

        // member methods (CAN DO)
        public void Add(T item)
        {
            // check if current array has an empty spot
            // if we find a spot put the item there, if we get to the of the array with no empty spots,
            // double the size and add the item to the next created spot.

            if (Count == capacity)
            {
                DoubleCapacity();
            }
            for (int i = 0; i < capacity; i++)
            {
                if (items[i].Equals(default(T))) //if the spot in items array is null then setting that spot to the item that is being passed in.
                {
                    items[i] = item; //setting the item thats being passed in
                    Count++;   //increasing the count to keep track of the items in the array
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
            for (int i = 0; i < capacity; i++) //looping through the array, checking per say
            {
                if (items[i].Equals(item)) //if items at said index is equal to the item that is passed in
                {
                    items[i] = default(T); //set it to "null" or default(T)
                    Count--;
                    return true;
                }
            }

            return false;
        }
        public void RemoveAll(T item)
        {
            for (int i = 0; i < capacity; i++) //looping through the array, checking per say
            {
                if (items[i].Equals(item)) //if items at said index is equal to the item that is passed in
                {
                    items[i] = default(T); //set it to "null" or default(T)
                    Count--;
                    
                }
            }

            return;
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
            for (int i = 0; i < items.Length; i++)
            {
                if (!items[i].Equals(default(T)))
                {
                    tempString += items[i].ToString();
                    if (i + 1 != items.Length)
                        tempString += ",";
                }
            }
            return tempString;
        }

        public static CustomList<T> operator +(CustomList<T> one, CustomList<T> two)
        {
            CustomList<T> temp = new CustomList<T>();
            for (int i = 0; i < one.Count; i++)
            {
                temp.Add(one[i]);
            }
            for (int i = 0; i < two.Count; i++)
            {
                temp.Add(two[i]);
            }
            return temp;
        }
        public static  CustomList<T> ZIPO (CustomList<T> one, CustomList<T> two)
        {
            CustomList<T> temp = new CustomList<T>();
         if(one.Count >= two.Count)
            {
                for (int i = 0; i < one.Count; i++)
                {
                    temp.Add(one[i]);
                    if(i<two.Count)
                        temp.Add(two[i]);
                }
            }
            else
            {
                for (int i = 0; i < two.Count; i++)
                {
                   
                    if (i < one.Count)
                        temp.Add(one[i]);

                    temp.Add(two[i]);
                }
            }
            return temp;
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
            
            for (int j = 0; j < two.Count; j++)
            {
                for (int k = 0; k < one.Count; k++)
                {
              
                    if(two[j].Equals(one[k]))
                    {
                        one.RemoveAll(one[k]); //any number from list two gets removed from list one
                    }
                }
                
            }
            return one;
        }
    }
}
