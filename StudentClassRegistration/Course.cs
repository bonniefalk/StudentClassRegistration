
/***********************************************
 * CIST 2342
 * Bonnie Falk
 * Lab 2 The Course class
 * Lab 5 Data Base Access 
 * we will access the db 
 * adding select, insert, delete and update to the class
 * **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassRegistration
{
   public class Course
    {
        //---------------------properties-----------------------------

        private string courseID;
        private string courseName;
        private string description;
        private int creditHours;

        //------------------------constructors without arguments----------------------

        public Course()
        {
            setCourseID("");
            setCourseName("");
            setDescription("");
            setCreditHours(0);
        }
        //----------------------constructors with arguments---------------------

        public Course(string cid, string cn, string des, int ch)
        {
            setCourseID(cid);
            setCourseName(cn);
            setDescription(des);
            setCreditHours(ch);
            
            //this is for lab 5
           
            InsertDB();
            
        }
       

        //--------------------------------behaviors set and get methods----------------------

        public void setCourseID(string cid)
        {
            courseID = cid;
        }
        public string getCourseID()
        {
            return courseID;
        }
        public void setCourseName(string cn)
        {
            courseName = cn;
        }
        public string getCourseName()
        {
            return courseName;
        }
        public void setDescription(string des)
        {
            description = des;
        }
        public string getDescription()
        {
            return description;
        }
        public void setCreditHours(int ch)
        {
            creditHours = ch;
        }
        public int getCreditHours()
        {
            return creditHours;
        }

       //----------------this method is part of lab 5--------------------------
 
        public Course(String cid)
        {
            SelectDB(cid);
        }

       //--------------------this is the beginning part of lab 5--------------------
       //------------------------Data Base Elements----------------------------- 
       //---------------------Behaviors------------------------

        public System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter2;
        public System.Data.OleDb.OleDbCommand OleDbSelectCommand2;
        public System.Data.OleDb.OleDbCommand OleDbInsertCommand2;
        public System.Data.OleDb.OleDbCommand OleDbUpdateCommand2;
        public System.Data.OleDb.OleDbCommand OleDbDeleteCommand2;
        public System.Data.OleDb.OleDbConnection OleDbConnection2;
        public string cmd;

       //data base set up
        public void DBSetup()
        {
            //------------------------DB Setup Funcions-------------------------

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

            //------------------data base connection---------------------

            OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Reg"+
                "istry Path=;Jet OLEDB:Database L" +
                "ocking Mode=1;Data Source=C:\\Users\\Bonnie\\Documents\\C2Labs\\RegistrationMDB.mdb;J" +
                "et OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System datab" +
                "ase=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=S" +
                "hare Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet " +
                "OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repai" +
                "r=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";

        }//end DBSetup()

        //------------------------Select statement------------------------

        public void SelectDB(string cid)
        {
            
            DBSetup();
            cmd = "Select * From Courses where CourseID ='" + cid+"'";
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

                dr.Read();
                courseID = cid;
                setCourseName(dr.GetValue(1) + "");
                setDescription(dr.GetValue(2) + "");
                setCreditHours(Int32.Parse(dr.GetValue(3)+""));     //credit hours is an int so we need to Parse             

            }//end try
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }//end catch
            finally
            {
                OleDbConnection2.Close();
            }//end finally


        }//end SelectDB

       //this is also part of lab 5 adding a insertDB()
       //this function takes no arg's
       //take current data in course object and insert a new row into the db
       //to test change the code behind the btnCourse in Form1.cs
       //Insert DB()

        // -------------------------Insert--------------------

        public void InsertDB()
        {
           
            DBSetup();
            cmd = "INSERT into Courses values('"+ getCourseID() + "'," +        // the quotes are for a string or text in db
                "'" + getCourseName() + "'," +      //quotes for a string in the db
                "'" + getDescription() + "'," +     //quotes for a string in db
                getCreditHours() + ")";             //quotes for a number in the db properties it's and int

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
        }//end InsertDB

       //---------------Delete from data base---------------

        public void deleteDB()
        {
            cmd = "Delete from Courses where CourseID = '" + getCourseID()+"'";
            OleDbDataAdapter2.DeleteCommand.CommandText = cmd;
            OleDbDataAdapter2.DeleteCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                int n = OleDbDataAdapter2.DeleteCommand.ExecuteNonQuery();
                if (n==1)
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

       //--------------updating the data base-----------

        public void updateDB()
        {
            cmd = "Update Courses set CourseName = '" + getCourseName() + "'," +
                "Description = '" + getDescription() + "'," +
                "CreditHours = " + getCreditHours() + 
                " where CourseID = '" + getCourseID()+"'";

           
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

        }//end updateDB()

        //--------------------display method------------------------

        public void display()
        {
            Console.WriteLine("courseID" + getCourseID());
            Console.WriteLine("courseName" + getCourseName());
            Console.WriteLine("description" + getDescription());
            Console.WriteLine("creditHours" + getCreditHours());
        }

    }//end class
}//end namespace
