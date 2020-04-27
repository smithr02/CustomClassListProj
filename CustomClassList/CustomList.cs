using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassList
{
    public class CustomList<T>
    {
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
    }
}
