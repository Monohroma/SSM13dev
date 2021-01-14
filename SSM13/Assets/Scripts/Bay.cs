using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bay
{


    public class Bay
    {
        public string Name { get; private set; }
        public int Consumption { get; set; }
        public bool Bought { get; set; }
        public Bay(string Name, bool Bought, int Consumption)
        {
            this.Name = Name;
            this.Bought = Bought;
            this.Consumption = Consumption;
        }

    }
}