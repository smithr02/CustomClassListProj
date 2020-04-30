using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                doubleCapacity();
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

        private void doubleCapacity()
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
    }
}
