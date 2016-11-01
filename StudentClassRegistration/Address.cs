/***********************************************
 * CIST 2342
 * Bonnie Falk
 * Lab 2 The Address class
 * code to test the address button
 * 
 * **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassRegistration
{
   public class Address
    {
         //--------------------properties------------------------
        private string street;
        private string city;
        private string state;
        private int zip;         //might need to change this to an int later due to db in person's it's an int

        //------------------------constructors with no aruguments-------------------------
        public Address()
        {

            setStreet("");
            setCity("");
            setState("");
            setZip(0);
        }
        //------------------------constructors with arguments-------------------------------
        public Address(string st, string ci, string sta, int zi)
        {
            setStreet(st);
            setCity(ci);
            setState(sta);
            setZip(zi);
        }
        //-----------------------behaviors set and get methods-----------------------
        public void setStreet(string st)
        {
            street = st;
        }
        public string getStreet()
        {
            return street;
        }
        public void setCity(string ci)
        {
            city = ci;
        }
        public string getCity()
        {
            return city;

        }

        public void setState(string sta)
        {
            state = sta;
        }
        public string getState()
        {
            return state;
        }
        public void setZip(int zi)
        {
            zip = zi;
        }
        public int getZip()
        {
            return zip;
        }
        //---------------------display Method----------------------
        public void display()
        {
            Console.WriteLine(getStreet());
            Console.WriteLine(getCity());
            Console.WriteLine(getState());
            Console.WriteLine(getZip());
        }
        


    }//end class

}//end namespace
