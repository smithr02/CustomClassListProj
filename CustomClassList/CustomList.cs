using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassList
{
    public class CustomList<T>
    {
        int Count = 0;

        // member variables (HAS A)
        private T[] items;

        // constructor (SPAWNER)
        public CustomList()
        {
            items = new T[4];
        }

        // member methods (CAN DO)
        public void Add(T item)
        {

        }

        public bool Remove(T item)
        {
            // if 'i' can be removed, do it, then return true, signaling that it was able to be done
            return true;
        }
    }
}
