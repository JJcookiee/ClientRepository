using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRepository
{
    internal class Cat
    {
        public bool Selected { get; set; }

        public Category cat { get; set; }

        public enum Category
        {
            Software,
            Laptop_PCs,
            Games,
            Office_Tools,
            Accessories
        }
    }
}
