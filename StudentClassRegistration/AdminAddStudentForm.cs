/**********
 * Bonnie Falk
 * C#2 Lab #8
 * This is the Admin Add Student Page
 * allowing the admin to add a new student
 * or update a student and or view a student profile
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

        //setting fields for the text boxes
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

            try
            {
                Student stu1;
                stu1 = parseStudentFromFields();

                stu1.InsertDB();
                stu1.display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //updating a student info in case you made a mistake
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                Student stu1 = parseStudentFromFields();

                stu1.updateDB();
                stu1.display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //making a method to extract getting a student from the fields
        //throws exception if fields aren't all filled in
        Student parseStudentFromFields()
        {
            Student stu1;
            stu1 = new Student();
            stu1.SelectDB(int.Parse(txtBoxID.Text));

            String fName = getTextBoxValue(txtBoxFirstName);
            stu1.setFirstName(fName);

            String lName = getTextBoxValue(txtBoxLastName) ;
            stu1.setLastName(lName);

            String street = getTextBoxValue(txtBoxStreet);
            stu1.addr.setStreet(street);

            //Same thing as above but in a shorter way
            stu1.addr.setCity(getTextBoxValue(txtboxCity));

            //Same thing as above but in a shorter way (and spread over several lines)
            stu1.addr.setState(
                getTextBoxValue(txtboxState)
            );


            int zip= int.Parse(getTextBoxValue(txtboxZip)); 
            stu1.addr.setZip(zip);


            String email = getTextBoxValue(txtboxEmail);
            stu1.setEmail(email);

            double gpa = double.Parse(getTextBoxValue(txtboxGpa));
            stu1.setGpa(gpa);


            return stu1;
        }

        //this closes the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //this is to view a student
        //enter a student ID and hit the get box
        private void btnGet_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            stu.SelectDB(int.Parse(txtBoxID.Text));
            setFields(stu);
        }

        //This'll throw an exception if the field is empty, null, or whitespace
        //Make sure to souround code using this method with a try catch block
        String getTextBoxValue(TextBox textBox) 
        {
            String text = textBox.Text;

            if (string.IsNullOrWhiteSpace(text)) 
            {
                throw new Exception("Fields must contain valid text");
            }

            return text;
        }

        //to clear the text boxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxID.Text = "";
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxStreet.Text = "";
            txtboxCity.Text = "";
            txtboxState.Text = "";
            txtboxZip.Text = "";
            txtboxEmail.Text = "";
            txtboxGpa.Text = "";
            txtBoxID.Focus();
        }
    }
}
