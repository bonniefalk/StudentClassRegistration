namespace StudentClassRegistration
{
    partial class StudentScheduleForm
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
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtBoxStudentID = new System.Windows.Forms.TextBox();
            this.lblCRN = new System.Windows.Forms.Label();
            this.txtBoxCRN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(82, 72);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(87, 20);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Student ID";
            // 
            // txtBoxStudentID
            // 
            this.txtBoxStudentID.Location = new System.Drawing.Point(69, 104);
            this.txtBoxStudentID.Name = "txtBoxStudentID";
            this.txtBoxStudentID.Size = new System.Drawing.Size(100, 26);
            this.txtBoxStudentID.TabIndex = 1;
            // 
            // lblCRN
            // 
            this.lblCRN.AutoSize = true;
            this.lblCRN.Location = new System.Drawing.Point(274, 72);
            this.lblCRN.Name = "lblCRN";
            this.lblCRN.Size = new System.Drawing.Size(43, 20);
            this.lblCRN.TabIndex = 2;
            this.lblCRN.Text = "CRN";
            // 
            // txtBoxCRN
            // 
            this.txtBoxCRN.Location = new System.Drawing.Point(251, 104);
            this.txtBoxCRN.Name = "txtBoxCRN";
            this.txtBoxCRN.Size = new System.Drawing.Size(100, 26);
            this.txtBoxCRN.TabIndex = 3;
            // 
            // StudentScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 569);
            this.Controls.Add(this.txtBoxCRN);
            this.Controls.Add(this.lblCRN);
            this.Controls.Add(this.txtBoxStudentID);
            this.Controls.Add(this.lblStudentID);
            this.Name = "StudentScheduleForm";
            this.Text = "StudentScheduleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtBoxStudentID;
        private System.Windows.Forms.Label lblCRN;
        private System.Windows.Forms.TextBox txtBoxCRN;
    }
}