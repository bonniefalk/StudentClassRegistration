/****************************************
 * C# 2 CIST 2342
 * Lab #4 Containment Properties: an aray of sections and count
 * Constructors only a default is needed
 * behaviors add() and display() drop() is optional
 * Bonnie Falk
 * Thurs Sept. 22, 2016
 * 
 * *****************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassRegistration
{
    public class Schedule
    {
        //properties
    public    Section[] sched = new Section[10];
    public    int count = 0;


        //method to add to the schedule
        public void addSection(Section s1)
        {
            sched[count] = s1;
            count++;
        }

        public void dropSection(Section s1)
        {
            sched[count] = s1;
            count--;
        }
        //display method 
        public void display()
        {
            for (int i = 0; i <= (count - 1); i++) 
            sched[i].display();
        }
    }//end class
}//end name space
