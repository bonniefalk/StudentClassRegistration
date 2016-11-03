/***************************
 * C#2 CIST 2342
 * Lab 3 More Business Classes
 * Bonnie Falk
 * Thurs Sept. 16, 2016
 * this is the Student class
 * Lab 4 Containment, add a schedule property
 * 
 * Lab 5 Data Base Access Due Oct 6th 2016
 * 
 * Lab 6 DB Access Schedule class adding to student
 * to select from the student schedule table Due 10/13/16
 * 
 ********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassRegistration
{
    public class Student:Person 
    {

        //---------------properties-------------------

        private int id;
        private double gpa;
        private Schedule sch = new Schedule();      //this is for lab 4 adding schedule to student

        //-----------------constructors no aruguments----------------------

        public Student():base()
    {
        setId(0);
        setGpa(0.00);
    }

    //----------------constructors with aruguments--------------------
        //lab 4 we changed string address to Address add

        public Student(int stid, string fn, string ln,Address add, string em, double g)
            : base(fn, ln, add, em )

        //------------this is for lab 5 data base access these are the data types in the db-------------------
      //  public Student(int stid, string fn, string ln, string st, string ci, string sta, int zi, string em, double g)
           // :base(fn, ln, st, ci, sta, zi, em)      //inheritance from parent class person
            //I am keeping the above for my notes on the different steps
    {
        setId(stid);
        setGpa(g);

        InsertDB();     //lab 5
         
            
    }      

    //------------------behaviors set and get methods-----------------

    public void setId(int stid)
    {
        id = stid;
    }
    public int getId()
    {
        return id;
    }

    public void setGpa(double g)
    {
        gpa = g;
    }

    public double getGpa()
   
    {
        return gpa;
    }

    public Schedule getSchedule()
    {
        return sch;
    }

        //---------------method for lab 4  to add a section--------------

        public void addSection (Section s)
        {
            sch.addSection(s);
             
        }

        //-----------------lab 5 data base access---------------------

        //public Student(int stid)      //note this was for lab 5 took it out for lab 6 
        //{                             // Mr. Enz said we don't need this 
           // SelectDB(stid);
       // }
              
        //-------------------------Data Base Elements------------------- 
        //--------------------------Behaviors---------------------------

        public System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter2;
        public System.Data.OleDb.OleDbCommand OleDbSelectCommand2;
        public System.Data.OleDb.OleDbCommand OleDbInsertCommand2;
        public System.Data.OleDb.OleDbCommand OleDbUpdateCommand2;
        public System.Data.OleDb.OleDbCommand OleDbDeleteCommand2;
        public System.Data.OleDb.OleDbConnection OleDbConnection2;
        public string cmd;

        //-----------------------data base set up------------------------------

        public void DBSetup()
        {
            //DB Setup Funcions
            //This DBSetup() method instantiates all the DB objects needed to access a DB,
            //includeing OleDBDataAdapter, which contains 4 other objects (OlsDBSelectCommand,
            //oleDbIsertCommand, oleDbUpdateCommand, oleDbDeleteCommand) and each
            //command object contains a Connection object and an SQL string object
            OleDbDataAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
            OleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            OleDbConnection2 = new System.Data.OleDb.OleDbConnection();

            OleDbDataAdapter2.DeleteCommand = OleDbDeleteCommand2;
            OleDbDataAdapter2.InsertCommand = OleDbInsertCommand2;
            OleDbDataAdapter2.SelectCommand = OleDbSelectCommand2;
            OleDbDataAdapter2.UpdateCommand = OleDbUpdateCommand2;

            //----------------------------data base connection------------------------------

            OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Reg" +
                "istry Path=;Jet OLEDB:Database L" +
                "ocking Mode=1;Data Source=C:\\Users\\Bonnie\\Documents\\C2Labs\\RegistrationMDB.mdb;J" +
                "et OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System datab" +
                "ase=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=S" +
                "hare Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet " +
                "OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repai" +
                "r=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";

        }//end DBSetup()


        //-------------------------Select statement------------------------------------- 

        public void SelectDB(int stid)
        {
           
            DBSetup();
            cmd = "Select * From Students where ID = " + stid;         
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

                dr.Read();
                id = stid;     
                setFirstName(dr.GetValue(1) + "");
                setLastName(dr.GetValue(2) + "");
                Address a1 = new Address();
                a1.setStreet(dr.GetValue(3) + "");
                a1.setCity(dr.GetValue(4) + "");
                a1.setState(dr.GetValue(5) + "");
                a1.setZip(Int32.Parse(dr.GetValue(6) + ""));     //you parse to turn object to a string
                setAddress(a1);
                setEmail(dr.GetValue(7) + "");
                setGpa(double.Parse(dr.GetValue(8) + ""));
                
                                   

            }//end try
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }//end catch
            finally
            {
                OleDbConnection2.Close();
            }//end finally

            DBLoadSchedule();          //for lab 6 building a new method to get the student schedule

        }//end SelectDB

        /**************************
        //-----------this is for lab 6 db access  student schedule class----------------------
        //adding db access code for schedule to our student class to select
        // from the studentSchedule table.
        ********************************/

        public void DBLoadSchedule()
        {
            
            cmd = "Select crn From StudentSchedule where StudentID = " + id;         
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

               
                Section sec1;
              
                int crn;
                while (dr.Read())
                {
                    crn = Int32.Parse(dr.GetValue(0)+"");
                    Console.WriteLine("this is for getting the student schedule"+crn);
                    sec1 = new Section();
                    sec1.SelectDB(crn.ToString());
                   addSection(sec1);     //took out for lab 8
                }//end while
              


            }//end try
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }//end catch
            finally
            {
                OleDbConnection2.Close();
            }//end finally
            

        }//end getSchedule



       

        //----------------------insert method-------------------------

        public void InsertDB()
        {
            DBSetup();
            cmd = "INSERT into Students values(" + getId() + "," +
                "'" + getFirstName() + "'," +
                "'" + getLastName() + "'," +           
                "'" + addr.getStreet() + "'," +
                "'" + addr.getCity() + "'," +
                "'" + addr.getState() + "'," +
                addr.getZip() + "," +
                "'" + getEmail() + "'," +
                getGpa() + ")";

            OleDbDataAdapter2.InsertCommand.CommandText = cmd;
            OleDbDataAdapter2.InsertCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.InsertCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Inserted");
                else
                    Console.WriteLine("ERROR Inserting The Data");
            }//end try

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
                                    
        }//end InsertDB()

        //---------------------------------delete method----------------------------------

        public void deleteDB()
        {
              
            cmd = "Delete from Students where ID =" + getId();          //this represents an int(number) in db 
            OleDbDataAdapter2.DeleteCommand.CommandText = cmd;
            OleDbDataAdapter2.DeleteCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.DeleteCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Deleted");
                else
                    Console.WriteLine("ERROR Deleted Data");
            }//end try
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }
        }//end DeleteDB

        //----------------------begin update method-------------------------

        public void updateDB()
        {
            cmd = "Update Students set FirstName = '" + getFirstName() + "'," +
                "LastName = '" + getLastName() + "'," +
                "Street = '" + addr.getStreet() + "'," +
                "City = '" + addr.getCity() + "'," +
                "State = '" + addr.getState() + "'," +
                "Zip = " + addr.getZip() +","+ 
                "Email = '" + getEmail() + "'," +
                "Gpa = " + getGpa() +
                " where ID = " + getId();

            OleDbDataAdapter2.DeleteCommand.CommandText = cmd;
            OleDbDataAdapter2.DeleteCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.DeleteCommand.ExecuteNonQuery();
                if (n == 1)
                    Console.WriteLine("Data Updated");
                else
                    Console.WriteLine("ERROR Updating Data");
            }//end try
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                OleDbConnection2.Close();
            }

        }//end updateDB

    //----------------------------- display method-----------------------

    public void display()
    {
        base.display();
        Console.WriteLine(getId());
        Console.WriteLine(getGpa());
        sch.display();
    }//end display


    }//end class
}//end namespace
