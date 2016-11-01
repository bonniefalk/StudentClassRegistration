/*************
 * Bonnie Falk
 * C#2 Lab 8
 * this is the code behind the
 * sections design button that is 
 * suppose to be a student schedule
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
    public partial class Sections : Form
    {
        Student s1;
        

        public Sections()
       // public Sections(Student s)
        {
            
           // s1 = s;
            InitializeComponent();
        }
         
        public Sections(Student s)
        {

            s1 = s;
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // this does not work yet keeping it for admin if needed!
            Section sec1;
            string crn;
            crn = txtBoxAdd.Text;
            sec1 = new Section(crn);
            crn = sec1.getCrn();
            s1.addSection(sec1);
            s1.InsertDB();//i am getting an error???

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //this wont work because I don't have a delete method
           // keeping it here needs more code 
            Section sec1;
            string crn;
            crn = txtBoxDrop.Text;
            sec1 = new Section(crn);
            crn = sec1.getCrn();
            
        }

        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            Section sec1;
            string crn;

            
            sec1 = new Section();   //initialize object
            sec1 = s1.sch.sched[0];
            
            sec1.SelectDB(txtBoxCrn.Text);
            crn = sec1.getCrn();
            txtBoxCrn.Text = crn;

            string courseid;
            courseid = sec1.getCourseID();
            txtBoxCourseID.Text = courseid;

            string timedays;
            timedays = sec1.getTimeDay();
            txtBoxTimeDays.Text = timedays;

            string rn;
            rn = sec1.getRoomNo();
            txtBoxRoomNo.Text = rn;

            string inst;
            inst = sec1.getInstructor();
            txtBoxInstructor.Text = inst;

            s1.display();

            //Schedule sc1;       //trying to pull up the student schedule in Sections here
            // sc1 = new Schedule();
            
        }

        private void txtBoxCrn_TextChanged(object sender, EventArgs e)
        {

        }

        //this is to populate the student schedule of sections

        private void Sections_Load(object sender, EventArgs e)
        {
            //first row of text boxes for crn
            Section sec1;
            string crn;

            sec1 = new Section();   //initialize object
            sec1 = s1.sch.sched[0];

            sec1.SelectDB(txtBoxCrn.Text);
            crn = sec1.getCrn();
            txtBoxCrn.Text = crn;

            Section sec2;
            sec2 = new Section();
            sec2 = s1.sch.sched[1];

            //trying to populate second row of text boxes for crn
            sec2.SelectDB(txtBox2Crn.Text);
            crn = sec2.getCrn();
            txtBox2Crn.Text = crn;

            //first row of text boxes for course ID
            string courseid;
            courseid = sec1.getCourseID();
            txtBoxCourseID.Text = courseid;

            //2nd row of text boxes for course ID
            courseid = sec2.getCourseID();
            txtBox2CourseID.Text = courseid;

            //first row of text boxes for time days
            string timedays;
            timedays = sec1.getTimeDay();
            txtBoxTimeDays.Text = timedays;

            //second row of text boxes for time days
            timedays = sec2.getTimeDay();
            txtBox2TimeDays.Text = timedays;

            //first row of text boxes for roomNo
            string rn;
            rn = sec1.getRoomNo();
            txtBoxRoomNo.Text = rn;

            //2nd row of text boxes for roomNo
            rn = sec2.getRoomNo();
            txtBox2RoomNo.Text = rn;

            //first row of text boxes for instructor
            string inst;
            inst = sec1.getInstructor();
            txtBoxInstructor.Text = inst;

            //2nd row of text boxes for instructor
            inst = sec2.getInstructor();
            txtBox2Instructor.Text = inst;

            s1.display();
 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
