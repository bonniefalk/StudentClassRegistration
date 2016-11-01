/***************************
 * C#2 CIST 2342
 * Bonnie Falk
 * Lab #3 More Business Classes
 * Thurs Sept. 16, 2016
 * 
 * this is the person class
 * 
 * Lab #4 Containment 
 ********************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassRegistration
{
   public class Person
    {
        //---------------------------properties--------------------------
        //private string address;     //Note:  this will become an object in another lab to hold the address's objectLab 3
       
        private string firstName;
        private string lastName;
        public Address addr = new Address();   //this is new for lab#4 containment part 1
        private string eMail;
       
        //constructors with no arguments
        public Person()
        {
            //setAddress(a);        //this was from a privious lab 2 or 3
            setFirstName("");
            setLastName("");
            setEmail("");
        }

        //--------------------constructors with arguments--------------

       //for lab 4 we took out string address and put Address a

        //public Person(Address a, string fn, string ln, string pn, string em)  //this was lab 3

        //public Person(string fn, string ln, string em, Address a)   //this is for lab 4 containment

       //Note: for lab 5 I made zip code and interger because it's a number in the db
       //it is still a string in the address class might change it at a later date.
       public Person(string fn, string ln, Address a, string em)      //lab 4 made address and object

      // public Person(string fn, string ln, string st, string ci, string sta, int zi, string em)
        {
            //setAddress(add);  //take out for lab 4 this was how we had it prior to lab 4
                   
            setFirstName(fn);
            setLastName(ln);  
            setEmail(em);
            addr = a;  //this is what we added for lab 4 Containment 
           
        }

        //behaviors set and get methods
       
        public void setFirstName(string fn)
        {
            firstName = fn;
        }
        public string getFirstName()
        {
            return firstName;
        }

        public void setLastName(string ln)
        {
            lastName = ln;
        }
        public string getLastName()
        {
            return lastName;
        }

        
        public void setAddress(Address a)       //this is for lab 4 containment
        {
            addr = a;
        }

        public Address getAddress()
        {
            return addr;
        }
       
        public void setEmail(string em)
        {
            eMail = em;
        }
        public string getEmail()
        {
            return eMail;
        }
      
        //---------------------display---------------------------
        public void display()
        {
            //Console.WriteLine(getAddress());      //this was for lab 3
            
            Console.WriteLine(getFirstName());
            Console.WriteLine(getLastName());
            addr.display();
            Console.WriteLine(getEmail());
            //addr.display(); //this is for lab 4  note took out for lab 5 unless mr. Enz says otherwise
        }


    }//end class
}//end name space
