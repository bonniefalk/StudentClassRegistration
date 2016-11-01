
/***********************************************
 * CIST 2342
 * Bonnie Falk
 * Lab 2 The Form class to test the buttons for(Address, Course, Section) 9/8/16
 * Lab 3 we added 3 new buttons (Person, Student, Instructor) 9/16/16
 * 
 * Lab 4 we added schedule and changed some things
 * in the privious classes due 9/22/16
 * 
 * Lab 5 Data Base Access, adding select, insert, update and delete
 * functions for 4 tables: Course, Section, Instructor, Student
 * 
 ***************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentClassRegistration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //---------------------address test button----------------------
        private void btnAddress_Click(object sender, EventArgs e)
        {
            Address a1;
            a1 = new Address("126 stonewood drive", "Los Banos", "Calf", 93401);

            a1.display();
        }
        //---------------course test button-----------------
        private void btnCourse_Click(object sender, EventArgs e)
        {
            //this one is to test the select in lab 5
          //Course c2;
          //c2 = new Course();
          // c2.SelectDB("CIST 1220");   //this is for lab 5 
          // c2.display();

            //this is to test the insert button  in lab 5 

          // Console.WriteLine("***********adding a new course************");
           // Course c1;
           // c1 = new Course("CIST 1314", "Intro to Python", "this is a beginning class", 4);
           // c1.InsertDB();
           // c1.display();

            //testing the delete
           // Console.WriteLine("**********deleteing a course*********");
           // Course c3;
           // c3 = new Course();
           // c3.SelectDB("CIST 1220");
           // c3.deleteDB();
            
            //testing the update
            Console.WriteLine("**********updating a course********");
            Course c4;
            c4 = new Course("CIST 2342");
            c4.SelectDB("CIST 2342");
            c4.setCourseName("Python Programming");
            c4.updateDB();
            c4.display();
        }
        //-----------------section test button-------------------

        private void btnSection_Click(object sender, EventArgs e)
        {
            
           // Section s1;
            //s1 = new Section("30101", "CIST 2341", "2", "MW 1-3", "F1149");       //this was lab 2
           // s1 = new Section();
           // s1.SelectDB("30105");       //this is for lab 5 testing the select
           // s1.display();

           // Console.WriteLine("-----------adding a new section----------");
            //this is part of lab 5
           // Section s1;
           // s1 = new Section("30118", "CIST 1331", "MW6-9", "S1149", "1");
            //s1.InsertDB();
            //s1.display();

            //adding another section just to try
           // Console.WriteLine("-------a new section------");
            //Section s2;
           // s2 = new Section("44444", "MIC 1221", "MT1-3", "S1134", "1");
           // s2.InsertDB();
           // s2.display();

            //------deleting a section-------
           // Console.WriteLine("---------delete a section--------");
            //Section s3;
            //s3 = new Section();
            //s3.SelectDB("31107");           //first I deleted crn 44444  trying another one
           // s3.deleteDB();
            //s3.display();

            //--------------------updating a section---------
            Console.WriteLine("--------updating section changing instructor-----");
            Section s4;
            s4 = new Section("30102");
            s4.SelectDB("30102");
            s4.setInstructor("6");
            s4.updateDB();
            s4.display();
        }//end section test button

        
        //---------------------test person button changed a little for lab 4----------------------

        //----------changed again for lab 5 took out containment since we don't have an address table in db

        private void btnPerson_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--------------adding a new person---------");
            Person p1;
            //this was from a past lab just keeping for notes
            //p1 = new Person(new Address("123 Stonewood Drive", "Dallas","Ga","30115"), "Bill", "Clinton", "404 - 444 - 5555", "bt@Yahoo.com");

            //------------------this was for lab 4-------------------------------
           // p1 = new Person("Bill", "Clinton", new Address("123 Stonewood Drive", "Dallas", "GA", 30115), "bt@Yaoo.com");
           // p1 = new Person("Bill","Clinton", "123 happy place", "Dallas", "GA", 30157,"BT@yahoo.com");
           // p1.display();


        }

        //---------------testing the student button-----------------------
        private void btnStudent_Click(object sender, EventArgs e)
        {

            //Console.WriteLine("----------adding a new student and section---------");
            
            //this is how we changed things for lab #4
          // Student st1;
           //st1 = new Student(1001, "Mary", "Jane", new Address("123 Stonewood Drive", "Dallas", "Ga", 30115), "bt@hotmail", 4.00);        
          // st1.addSection(new Section("30101", "CIST 2341", "2", "MW 1-3", "F1149"));
          // st1.addSection(new Section("30155", "CIST 2345", "3", "TTH1-3", "F1148"));
           // st1.display();

            //trying to do another student 

            //Console.WriteLine("--------adding another student and section  lab 4--------");
           // Student st2;
           // st2 = new Student(1002, "Sally", "Field", new Address("125 Stonewood Drive", "Dallas", "Ga", 30115), "sf@hotmail", 4.00);
           // st2.addSection(new Section("30101", "CIST 2341", "2", "MW 1-3", "F1149"));
           // st2.addSection(new Section("30155", "CIST 2345", "3", "TTH1-3", "F1148"));
           // st2.display();

           // Student st2;  //this was how it was done for lab #3
          //  st2 = new Student("223 wix rd. dallas ga", "Sally", "Fields", "678-333-5555", "s@hotmail.com", 1221, "Sql", 3.88);
          //  st2.display();
 
            //-------this is for lab 5 data base access display select student------
          //  Console.WriteLine("------this is to test the select student--------");
         //   Student st1;
           // st1 = new Student();
          //  st1.SelectDB(2);
          //  st1.display();

           // Console.WriteLine("------trying another select for student------");
          //  Student st2;
          //  st2 = new Student();
          //  st2.SelectDB(8);
           // st2.display();

            //------------------------testing the insert button for lab 5 Student----------------

            Console.WriteLine("--------lab 5 testing insert for student------------");
           // Student st3;
           // st3 = new Student(20, "Mary", "Potter", new Address ("1313 mockingbird lane", "Dallas", "GA", 30157), "hp@hotmail.com", 4.0);
           // st3.InsertDB();
           // st3.display();

           // Student st8;
            //st8 = new Student(21, "Sally", "Fields", new Address("13 Wade lane", "Dallas", "GA", 30157), "sf@hotmail.com", 3.0);
            //st8.InsertDB();
           // st8.display();
            
            // testing another insert 

           // Student st9;
           // st9 = new Student(25, "David", "Greg", new Address("12 holly lane", "Hiram", "Ga", 30156), "dg&yahoo.com", 3.0);
           // st9.InsertDB();
           // st9.display();
            //-----------------------------testing the delete for Student lab 5-------------------------

            //Console.WriteLine("-----------------testing the delete for student------------");
            //Student st4;
           // st4 = new Student();
           // st4.SelectDB(14);
           // st4.deleteDB();
           // st4.display();


            //---------------------testing the update for Student lab 5-----------------------

          //  Console.WriteLine("-------------------------testing the update for student------------------");
          //  Student st5;
          //  st5 = new Student(15);
           // st5.SelectDB(15);
            //st5.setCity("Hiram");
           // st5.addr.setCity("Hiram");
            //st5.updateDB();
          //  st5.display();
       
           //Console.WriteLine("------------testing another update for student--------");
           // Student st5;
           // st5 = new Student(7);
           // st5.SelectDB(7);
            //st5.setLastName("Jean");
           // st5.updateDB();
            //st5.display();

            //---------------testing for lab 6 adding a student schedule----------
            Console.WriteLine("-------adding student schedule------");
            Student st6;
            st6 = new Student();
            st6.SelectDB(6);
            st6.display();

            Console.WriteLine("-------adding student schedule------");
            Student st7;
            st7 = new Student();
            st7.SelectDB(11);
            st7.display();

        }//end btnStudent


        //-------------------test instructor button---------------------

        private void btnInstructor_Click(object sender, EventArgs e)
        {
           // Console.WriteLine("------adding instructor and section-------");
            //Instructor i1 = new Instructor(23, "David", "Bowie", "db@yahoo.com", "f1150", new Address("202 Spring Rd", "dallas", "ga", "30111"));
           // i1.addSection(new Section("30101", "CIST 2341", "2", "MW 1-3", "F1149"));
           // i1.display();

           // Console.WriteLine("---------adding another insturctor and section-------");
           // Instructor i2;
           // i2 = new Instructor(45, "Mary", "Jane", "m@gmail.com", "f1149", new Address("75 lisa Lane", "dallas", "ga", "30111"));
           // i2.addSection(new Section("31112", "MU 1122", "2", "W 4-6", "A124"));
           // i2.display();

            //------------Lab 5 testing the instructor button data access---------------------------------

            //---------------testing the select method for Instructor-----------------------

           // Console.WriteLine("---------testing the select for instructor------------------");
           // Instructor i1;
          //  i1 = new Instructor();
           // i1.SelectDB(5);
          //  i1.display();

          //  Console.WriteLine("-------------testing the select again for instructor---------");
          //  Instructor i2;
          //  i2 = new Instructor();
          //  i2.SelectDB(2);
           // i2.display();
                
            //----------------------testing the Insert for Instructor--------------

            //Console.WriteLine("-----------testing the insert for instructor-----------------");
            // Instructor i3;
           //  i3 = new Instructor(7, "Mary", "Potter", new Address ("1313 mockingbird lane", "Dallas", "GA", 30157),"A1122","hp@hotmail.com");
           //  i3.InsertDB();
           //  i3.display();

            //-------------------testing a second insert for instructor--------------

           // Console.WriteLine("-----------testing the insert for instructor-----------------");
          // Instructor i4;
          //  i4 = new Instructor(8, "Sally", "Fields", new Address("13 Lisa lane", "Dallas", "GA", 30157), "A1124", "sf2@hotmail.com");
          //  i4.InsertDB();
           // i4.display();

            //------------------testing the delete function in Instructor----------------------

           // Console.WriteLine("------------testing the delete function for Instructor-----------");
           // Instructor i5;
           // i5 = new Instructor();
           // i5.SelectDB(2);
           // i5.deleteDB();
           // i5.display();

            //Instructor i6;
           // i6 = new Instructor();
           // i6.SelectDB(8);
           // i6.deleteDB();
          //  i6.display();

            //------------------testing the update function in Instructor------------------------

            Console.WriteLine("------------testing update function for Instructor----------");
           // Instructor i7;
           // i7 = new Instructor(1);
           // i7.SelectDB(1);
           // i7.setLastName("Tomlinson");
           // i7.updateDB();
           // i7.display();

           // Instructor i8;
           // i8 = new Instructor(3);
           // i8.SelectDB(3);
           // i8.setLastName("Hill");
           // i8.addr.setCity("Hiram");       //this is how you would change something in address 
           // i8.updateDB();
           // i8.display();

            Instructor i9;
            i9 = new Instructor(77);
            i9.SelectDB(77);
            i9.addr.setStreet("122 Hope Lane");
            i9.addr.setCity("Kennesaw");
            i9.addr.setState("GA");
            i9.addr.setZip(30158);
            i9.updateDB();
            i9.display();


               
        }//end instructor

        //-------------------testing the schedule--------------------

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--------Adding a section--------");
            Schedule sc1;
            sc1 = new Schedule();
            sc1.addSection(new Section("30101", "CIST 2341", "2", "MW 1-3", "F1149"));
            sc1.addSection(new Section("30102", "CIST 234", "3", "THR 1-2", "F1150"));
        
            sc1.display();
            

        }
    }
}
