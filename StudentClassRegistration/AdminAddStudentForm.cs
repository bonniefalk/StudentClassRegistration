/**********
 * Bonnie Falk
 * C#2 Lab #8
 * This is the Admin Add Student Page
 * allowing the admin to add a new student
 * 
 * ***/

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
    public partial class AdminAddStudentForm : Form
    {
        public AdminAddStudentForm()
        {
            InitializeComponent();
        }


        public void setFields(Student stu)
        {
            txtBoxFirstName.Text = stu.getFirstName();
            txtBoxLastName.Text = stu.getLastName();
            txtBoxStreet.Text = stu.addr.getStreet();
            txtboxCity.Text = stu.addr.getCity();
            txtboxState.Text = stu.addr.getState();
            txtboxZip.Text = stu.addr.getZip().ToString();
            txtboxEmail.Text = stu.getEmail();
            txtboxGpa.Text = stu.getGpa().ToString();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            //this is to insert another student
            //this works
            
            Student stu1;
            stu1 = parseStudentFromFields();

            stu1.InsertDB();
            stu1.display();

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //making a method to extract getting a student from the fields
        Student parseStudentFromFields()
        {
            Student stu1;
            stu1 = new Student();
            stu1.SelectDB(int.Parse(txtBoxID.Text));
            stu1.setFirstName(txtBoxFirstName.Text);
            stu1.setLastName(txtBoxLastName.Text);
            stu1.addr.setStreet(txtBoxStreet.Text);
            stu1.addr.setCity(txtboxCity.Text);
            stu1.addr.setState(txtboxState.Text);
            stu1.addr.setZip(int.Parse(txtboxZip.Text));
            stu1.setEmail(txtboxEmail.Text);
            stu1.setGpa(double.Parse(txtboxGpa.Text));
            return stu1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //this does not work just was trying 
            Student stu1 = parseStudentFromFields();

        private void btnGet_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            stu.SelectDB(int.Parse(txtBoxID.Text));
            setFields(stu);
        }

            stu1.updateDB();
            stu1.display();
        }
    }
}
