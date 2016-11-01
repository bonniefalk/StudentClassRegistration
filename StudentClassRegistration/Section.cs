/***********************************************
 * CIST 2342 
 * 
 * Bonnie Falk
 * 
 * Lab 2 The Section class
 * Lab 5 Data Base Access  Due Oct 6, 2016
 * 
 * **************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassRegistration
{
   public class Section
    {
        //--------------------properties---------------------------
        private string crn;
        private string courseID;
        private string timeDay;
        private string roomNo;
        private string instructor;

        //--------------------------constructors with no arguments-----------------------------
        public Section()
        {
            setCrn("");
            setCourseID("");
            setTimeDay("");
            setRoomNo("");
            setInstructor("");

        }

        //-------------------------construtors with arguments------------------------------
        public Section(string crn_, string cid, string td, string rn, string instr)
        {

            setCrn(crn_);
            setCourseID(cid);
            setTimeDay(td);
            setRoomNo(rn);
            setInstructor(instr);

            //-------------------for lab 5 InsertDB()-----------------------
            InsertDB();
        }

        //-----------------------------behaviors set and get methods-------------------------
        public void setCrn(string crn_)
        {
            crn = crn_;
        }

        public string getCrn()
        {
            return crn;
        }

        public void setCourseID(string cid)
        {
            courseID = cid;
        }
        public string getCourseID()
        {
            return courseID;
        }     

        public void setTimeDay(string td)
        {
            timeDay = td;
        }
        public string getTimeDay()
        {
            return timeDay;
        }

        public void setRoomNo(string rn)
        {
            roomNo = rn;
        }
        public string getRoomNo()
        {
            return roomNo;
        }
        public void setInstructor(string instr)
        {
            instructor = instr;
        }
        public string getInstructor()
        {
            return instructor;
        }

       //We are adding Data Base Access this is part of lab 5
       public Section(string crn)
       {
            SelectDB(crn);
       }

        //---------------------this is the beginning part of lab 5-----------------------------
        //--------------------Data Base Elements------------------------- 
        //--------------------Behaviors-------------------------
        public System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter2;
        public System.Data.OleDb.OleDbCommand OleDbSelectCommand2;
        public System.Data.OleDb.OleDbCommand OleDbInsertCommand2;
        public System.Data.OleDb.OleDbCommand OleDbUpdateCommand2;
        public System.Data.OleDb.OleDbCommand OleDbDeleteCommand2;
        public System.Data.OleDb.OleDbConnection OleDbConnection2;
        public string cmd;

        public void DBSetup()
        {
            //-----------------DB Setup Funcions------------------

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

            //----------------------data base connection string--------------------

            OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Reg" +
                "istry Path=;Jet OLEDB:Database L" +
                "ocking Mode=1;Data Source=C:\\Users\\Bonnie\\Documents\\C2Labs\\RegistrationMDB.mdb;J" +
                "et OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System datab" +
                "ase=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=S" +
                "hare Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet " +
                "OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repai" +
                "r=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";

        }//end DBSetup()

       //-----------------Select-------------------------

        public void SelectDB(string crn_)
        {
            DBSetup();
            cmd = "Select * from Sections where crn = " + crn_;     //this is an number(int) in the db
            OleDbDataAdapter2.SelectCommand.CommandText = cmd;
            OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
            Console.WriteLine(cmd);
            try
            {
                OleDbConnection2.Open();
                System.Data.OleDb.OleDbDataReader dr;
                dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

                dr.Read();
                crn = crn_;
                setCourseID(dr.GetValue(1) + "");
                setTimeDay(dr.GetValue(2) + "");
                setRoomNo(dr.GetValue(3) + "");
                setInstructor(dr.GetValue(4) + "");
                         

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
        //to test change the code behind the btnSection in Form1.cs
        //Insert DB()

        public void InsertDB()
        {
            // -------------------------Insert--------------------

            DBSetup();
            cmd = "INSERT into Sections values(" + getCrn() + "," +         //this is for a number/int in db
                "'" + getCourseID() + "'," +                                //this represents a string in db
                "'" + getTimeDay() + "'," +                                 //this is a string in db
                "'" + getRoomNo() + "',"+                                   //this is a string in db
                getInstructor() + ")";                                      //this is a number/int in the db

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

       //----------------the delete method--------------------------

        public void deleteDB()
        {
            cmd = "Delete from Sections where CRN = " + getCrn() ;     //this represents an int(number) in db 
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

       //------------------------update method--------------------------

        public void updateDB()
        {
            cmd = "Update Sections set CourseID = '" + getCourseID() + "'," +       //this is a string in db
                                 "TimeDays = '" + getTimeDay() + "'," +             //this is a string 
                                 "RoomNo = '" + getRoomNo() + "'," +                //this is a string
                                 "Instructor = " + getInstructor() +""+             //this is an (number)int in the db
                                 " where CRN = " + getCrn();                        //this represents (number) int in db
            

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


        //------------------------display method--------------------------
        public void display()
        {
            Console.WriteLine("crn:" + getCrn());
            Console.WriteLine("CourseID:" + getCourseID());
            Console.WriteLine("TimeDay:" + getTimeDay());
            Console.WriteLine("RoomNo:" + getRoomNo());
            Console.WriteLine("Instructor:" + getInstructor());
            Console.WriteLine("=====================================" );
        }

    }//end class
}//end namespace
