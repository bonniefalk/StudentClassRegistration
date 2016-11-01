/***************************
 * C#2 CIST 2342
 * Lab #3 More Business Classes
 * 
 * Bonnie Falk
 * 
 * Thurs Sept. 16, 2016
 * this is the Instructor class
 * lab #4 containment added schedule property Thurs Sept 22, 2016
 * 
 * lab 5 data base access, Due Oct. 6 2016
 * 
 * 
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassRegistration
{
     public class Instructor:Person
    {
        //-----------------------properties------------------------
         private int id;
         private string office;
         private Schedule sch = new Schedule(); //this is for lab 4 add schedule to property

         //----------------------constructors with no arguments--------------------------

         public Instructor() : base()       //:base() is how you inherite   //need to put public in front of instructor of lab 5
         {
             setId(0);
             setOffice("");
            
         }

         //--------------------constructors with arguments---------------------

         //--------lab 4 we changed string add to Address add-----------

          public Instructor(int iId, string fn, string ln, Address add,  string off, string em)
           : base(fn, ln, add, em)

         {
             setId(iId);
             setOffice(off);
             InsertDB();
         }

         //-----------------------------behaviors set and get methods---------------------------
         public void setId(int iId)
         {
             id = iId;
         }
         public int getID()
         {
             return id;
         }
         public void setOffice(string off)
         {
             office = off;
         }
         public string getOffice()
         {
             return office;
         }

         //---------------------method for lab 4 to add a section---------------------------
         public void addSection(Section s)
         {
             sch.addSection(s);
             display();
             sch.display();
         }

         //-------------------------lab 5 data base access----------------------------
         
         public Instructor(int iID)
         {
             SelectDB(iID);
         }
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
 
         public void SelectDB(int iId)
         {

             DBSetup();
             cmd = "Select * From Instructors where ID = " + iId;
             OleDbDataAdapter2.SelectCommand.CommandText = cmd;
             OleDbDataAdapter2.SelectCommand.Connection = OleDbConnection2;
             Console.WriteLine(cmd);
             try
             {
                 OleDbConnection2.Open();
                 System.Data.OleDb.OleDbDataReader dr;
                 dr = OleDbDataAdapter2.SelectCommand.ExecuteReader();

                 dr.Read();
                 id = iId;
                 setFirstName(dr.GetValue(1) + "");
                 setLastName(dr.GetValue(2) + "");
                 Address a1 = new Address();
                 a1.setStreet(dr.GetValue(3) + "");
                 a1.setCity(dr.GetValue(4) + "");
                 a1.setState(dr.GetValue(5) + "");
                 a1.setZip(Int32.Parse(dr.GetValue(6) + ""));     // note: zip is an int in the person class for the db access, but a string in address class
                 setAddress(a1);
                 setOffice(dr.GetValue(7) + "");
                 setEmail(dr.GetValue(8) + "");
                
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

         //----------------------insert method-------------------------

         public void InsertDB()
         {
             DBSetup();
             cmd = "INSERT into Instructors values(" + getID() + "," +      //a number in db
                 "'" + getFirstName() + "'," +              //a text in db 
                 "'" + getLastName() + "'," +               //text
                 "'" + addr.getStreet() + "'," +            //text
                 "'" + addr.getCity() + "'," +              //text
                 "'" + addr.getState() + "'," +             //text
                      addr.getZip() + "," +                 //number in db
                 "'" + getOffice() + "'," +                 //text
                 "'" + getEmail() + "')";                   //text
                

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

         //---------------------delete instructor method------------------------

         public void deleteDB()
         {
             cmd = "Delete from Instructors where ID = " + getID();
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
         }//end deleteDB()

         //-------------------------update Instructor method----------------------------

         public void updateDB()
         {
             cmd = "Update Instructors set FirstName = '" + getFirstName() + "'," +
                "LastName = '" + getLastName() + "'," +
                "Street = '" + addr.getStreet() + "'," +
                "City = '" + addr.getCity() + "'," +
                "State = '" + addr.getState() + "'," +
                "Zip = " + addr.getZip() + "," +
                "Office = '" + getOffice() + "'," +
                "Email = '" + getEmail() + "'" +
                " where ID = " + getID();

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

         //--------------------display method--------------------------------------------
         public void display()
         {
             base.display();
             Console.WriteLine("id" + getID());
             Console.WriteLine("office" + getOffice());
             sch.display();
         }

    }//end class
}//end namespace
