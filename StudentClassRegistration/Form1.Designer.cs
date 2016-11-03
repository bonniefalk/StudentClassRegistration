namespace StudentClassRegistration
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddress = new System.Windows.Forms.Button();
            this.btnCourse = new System.Windows.Forms.Button();
            this.btnSection = new System.Windows.Forms.Button();
            this.btnPerson = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnInstructor = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(0, -3);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(117, 56);
            this.btnAddress.TabIndex = 0;
            this.btnAddress.Text = "btnAddress";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // btnCourse
            // 
            this.btnCourse.Location = new System.Drawing.Point(0, 78);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(117, 43);
            this.btnCourse.TabIndex = 1;
            this.btnCourse.Text = "btnCourse";
            this.btnCourse.UseVisualStyleBackColor = true;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // btnSection
            // 
            this.btnSection.Location = new System.Drawing.Point(0, 151);
            this.btnSection.Name = "btnSection";
            this.btnSection.Size = new System.Drawing.Size(117, 49);
            this.btnSection.TabIndex = 2;
            this.btnSection.Text = "btnSection";
            this.btnSection.UseVisualStyleBackColor = true;
            this.btnSection.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // btnPerson
            // 
            this.btnPerson.Location = new System.Drawing.Point(280, 12);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(131, 57);
            this.btnPerson.TabIndex = 3;
            this.btnPerson.Text = "btnPerson";
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(292, 139);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(119, 61);
            this.btnStudent.TabIndex = 4;
            this.btnStudent.Text = "btnStudent";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnInstructor
            // 
            this.btnInstructor.Location = new System.Drawing.Point(292, 245);
            this.btnInstructor.Name = "btnInstructor";
            this.btnInstructor.Size = new System.Drawing.Size(119, 62);
            this.btnInstructor.TabIndex = 5;
            this.btnInstructor.Text = "btnInstructor";
            this.btnInstructor.UseVisualStyleBackColor = true;
            this.btnInstructor.Click += new System.EventHandler(this.btnInstructor_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(0, 245);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(117, 48);
            this.btnSchedule.TabIndex = 6;
            this.btnSchedule.Text = "btnSchedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 447);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.btnInstructor);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.btnPerson);
            this.Controls.Add(this.btnSection);
            this.Controls.Add(this.btnCourse);
            this.Controls.Add(this.btnAddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Button btnCourse;
        private System.Windows.Forms.Button btnSection;
        private System.Windows.Forms.Button btnPerson;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnInstructor;
        private System.Windows.Forms.Button btnSchedule;
    }
}

