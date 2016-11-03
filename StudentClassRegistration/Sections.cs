/*************
 * Bonnie Falk
 * C#2 Lab 8
 * this is the code behind the
 * sections design button that is 
 * suppose to be a student schedule
 * so a student can view their schedule
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
        Student student;

        TextBox[] txtBoxesForCRN;
        TextBox[] txtBoxesForCourseIDs;
        TextBox[] txtBoxesForTimeDays;
        TextBox[] txtBoxesForRoomNbs;
        TextBox[] txtBoxesForInstructors;

        private  void  initArrays()
        {

            txtBoxesForCRN = new TextBox[5]
            {
                txtBoxCrn,
                txtBox2Crn,
                txtBox3Crn,
                txtBox4Crn,
                txtBox5Crn
            };

            txtBoxesForCourseIDs = new TextBox[]
            {
                txtBoxCourseID,
                txtBox2CourseID,
                txtBox3CourseID,
                txtBox4CourseID,
                txtBox5CourseID
            };

            txtBoxesForTimeDays = new TextBox[]
            {
                txtBoxTimeDays,
                txtBox2TimeDays,
                txtBox3TimeDays,
                txtBox4TimeDays,
                txtBox5TimeDays
            };


            txtBoxesForRoomNbs = new TextBox[]
            {
                txtBoxRoomNo,
                txtBox2RoomNo,
                txtBox3RoomNo,
                txtBox4RoomNo,
                txtBox5RoomNo
            };

            txtBoxesForInstructors = new TextBox[]
            {               
                txtBoxInstructor,
                txtBox2Instructor,
                txtBox3Instructor,
                txtBox4Instructor,
                txtBox5Instructor
            };
        }


        /*public Sections()
        {
            InitializeComponent();
            initArrays();
        }*/
         
        public Sections(Student s)
        {
            student = s;
            InitializeComponent();
            initArrays();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            // this does not work yet
           
            Section sec1;
            sec1 = new Section();
            sec1.SelectDB(txtBoxCrn.Text);
           // sec1.setCourseID(txtBoxCourseID.Text);
           // sec1.setTimeDay(txtBoxTimeDays.Text);
          //  sec1.setRoomNo(txtBoxRoomNo.Text);
          //  sec1.setInstructor(txtBoxInstructor.Text);
            txtBoxDrop.Text = sec1.getCrn();
            txtBoxCrn.Text = sec1.getCrn();
            txtBoxCourseID.Text = sec1.getCourseID();
            txtBoxTimeDays.Text = sec1.getTimeDay();
            txtBoxRoomNo.Text = sec1.getRoomNo();
            txtBoxInstructor.Text = sec1.getInstructor();

            sec1.InsertDB();
            sec1.display();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //this wont work because I don't have a delete method
           // keeping it here needs more code 
           // Section sec1;
          //  string crn;
          //  crn = txtBoxDrop.Text;
          //  sec1 = new Section(crn);
          //  crn = sec1.getCrn();
            
        }

        //this allows you to view the student schedule which 
        //I called section
        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            Section sec1;
            string crn;

            
            sec1 = new Section();   //initialize object
            sec1 = student.getSchedule().sections[0];         //this is from the array in studentSchedule class
            
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

            student.display();

            //Schedule sc1;       //trying to pull up the student schedule in Sections here
            // sc1 = new Schedule();
            
        }

        private void txtBoxCrn_TextChanged(object sender, EventArgs e)
        {

        }

        //this is to populate the student schedule of sections
        //and show up in the text boxes
        //I only coded the first 2 rows of text boxes so far

        private void Sections_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Section section in student.getSchedule().sections)
            {
                try
                {
                    //
                     TextBox crnBox = txtBoxesForCRN[1];
                      crnBox.Text = section.getCrn();

                    //
                    TextBox courseIDBox = txtBoxesForCourseIDs[i];
                    courseIDBox.Text = section.getCourseID();

                    //
                    TextBox timedaysBox = txtBoxesForTimeDays[i];
                    txtBoxTimeDays.Text = section.getTimeDay();

                    //
                    TextBox roomNbBox = txtBoxesForRoomNbs[i];
                    string rn = section.getRoomNo();
                    roomNbBox.Text = rn;

                    //
                    TextBox instructorBox = txtBoxesForInstructors[i];
                    string inst = section.getInstructor();
                    instructorBox.Text = inst;
                }
                catch (Exception ex)
                {
                }
                i++;
            }
       
            student.display();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
