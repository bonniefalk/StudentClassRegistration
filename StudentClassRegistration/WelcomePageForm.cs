/*****************
 * Bonnie Falk
 * C#2 Lab #8
 * Welcome Form page
 * right now this is a log in page but might change it later
 * 
 * *******/



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
    public partial class WelcomePageForm : Form
    {
        public WelcomePageForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //this was a test don't need any more
            //this is for admin make a sepearte button and put this in a different button
           // if (txtBoxID.Text == "admin")
           // {
                //we need to create admin forms
                //placeholder code for admin form
                //make admin form
                //admin.show();
               // this.Hide();
          //  }
           // else
            {

                // we need this code to be able to pull from the text boxes
                int id;

                String unparsedInteger = txtBoxID.Text;     //id is and int need to turn into a string

                try
                {
                    id = int.Parse(unparsedInteger);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("only numbers allowed for ID");
                    return;
                }

                //trying to bring up a student profile
                //I am not sure if this code is doing anything
                Student st2;
                st2 = new Student();
                st2.SelectDB(id);
                st2.display();

                /*     the for loop is to pull up multiple students at a time we don't need
                 *     just keeping to know how to do it.
                 * 
                 * for (int i = 0; i < 8; i++)     //this calls student 1 to 8 that is in the db
                           {
                               Student stu = new Student();
                               stu.SelectDB(i);
                               StudentProfile gui = new StudentProfile(stu);
                               gui.Show();
                           }*/


                //this shows the student profile page 
                //each page needs a button to go to the next page or page you want
                StudentProfile st1;
                st1 = new StudentProfile(st2);
               // this.Hide();      // this hides the welcome screen if you leave open can call other id's
                st1.Show();
                // st1.Select();       //do we need this ?
            }
            


            
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxID.Text = "";
            txtBoxID.Focus();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
             //this is for admin make a sepearte button and put this in a different button
            if (txtBoxID.Text == "admin")
            {
                //we need to create admin forms
                //placeholder code for admin form
                //make admin form
                //admin.show();
                this.Hide();
            }
            //else
           // {

            // trying to call up the adminAddStudentForm
            AdminAddStudentForm admin1;
            admin1 = new AdminAddStudentForm();
            admin1.Show();
            
        }
    }
}
