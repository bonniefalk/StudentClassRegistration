/************
 * Bonnie Falk
 * C#2 Lab #8 Student Presentation class
 * for the student profile form
 * Nov 3 2016
 * 
 * ****/

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
    public partial class StudentProfile : Form
    {
        //populating the text boxes with student info

        Student student;
        public StudentProfile(Student s1)
        {
            student = s1;
            InitializeComponent();
            txtBoxID.Text = student.getId().ToString();
            txtBoxFirstName.Text = student.getFirstName();
            txtBoxLastName.Text = student.getLastName();
            txtBoxStreet.Text = student.getAddress().getStreet();
            txtboxCity.Text = student.getAddress().getCity();
            txtboxState.Text = student.getAddress().getState();
            txtboxZip.Text = student.getAddress().getZip().ToString();
            txtboxEmail.Text = student.getEmail();
            txtboxGpa.Text = student.getGpa().ToString();


        }

        //pulling up the section gui
        private void btnViewSection_Click(object sender, EventArgs e)
        {
            //tring to bring up the sections design form page
            Sections sect1;
            sect1 = new Sections(student);
            this.Hide();
            sect1.Show();

             

           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

        //updateing student profile information
        //students can update fn,ln, address and email only

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine("-------------------------testing the update for student------------------");
             Student students;
              students = new Student();
              students.SelectDB(int.Parse(txtBoxID.Text));
              students.setFirstName(txtBoxFirstName.Text);
              students.setLastName(txtBoxLastName.Text);
              students.addr.setStreet(txtBoxStreet.Text);
              students.addr.setCity(txtboxCity.Text);
              students.addr.setState(txtboxState.Text);
              students.addr.setZip(int.Parse(txtboxZip.Text));
              students.setEmail(txtboxEmail.Text);
            
              students.updateDB();
              students.display();
              
            
        }

    }
}
