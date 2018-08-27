using System;
using System.Collections;
using Microsoft.SPOT;

namespace SSwHost.Infrastructure
{
    class PowerTable
    {
        ArrayList myList = new ArrayList();

        public void AddPower(Power power)
        {

        }
        public void TestExample()
        {
            myList.Add("Hello");
            myList.Add("World");
            myList.Add("!");
            //Display the properties and values of the ArrayList.
            Debug.Print("myAL");
            Debug.Print("      Count:  "+ myList.Count);

        }
    }
}

