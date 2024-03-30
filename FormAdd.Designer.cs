namespace lab3
{
    partial class FormAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxID = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxGender = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCLassName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxGrade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student &ID:";
            // 
            // tbxID
            // 
            this.tbxID.Location = new System.Drawing.Point(195, 36);
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(100, 28);
            this.tbxID.TabIndex = 1;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Location = new System.Drawing.Point(195, 109);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(100, 28);
            this.tbxFirstName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "&First Name:";
            // 
            // tbxLastName
            // 
            this.tbxLastName.Location = new System.Drawing.Point(195, 174);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(100, 28);
            this.tbxLastName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Last Name:";
            // 
            // tbxAge
            // 
            this.tbxAge.Location = new System.Drawing.Point(195, 232);
            this.tbxAge.Name = "tbxAge";
            this.tbxAge.Size = new System.Drawing.Size(100, 28);
            this.tbxAge.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Age:";
            // 
            // tbxGender
            // 
            this.tbxGender.Location = new System.Drawing.Point(195, 291);
            this.tbxGender.Name = "tbxGender";
            this.tbxGender.Size = new System.Drawing.Size(100, 28);
            this.tbxGender.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "&Gender";
            // 
            // tbxCLassName
            // 
            this.tbxCLassName.Location = new System.Drawing.Point(195, 345);
            this.tbxCLassName.Name = "tbxCLassName";
            this.tbxCLassName.Size = new System.Drawing.Size(100, 28);
            this.tbxCLassName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "&Class Name";
            // 
            // tbxGrade
            // 
            this.tbxGrade.Location = new System.Drawing.Point(195, 386);
            this.tbxGrade.Name = "tbxGrade";
            this.tbxGrade.Size = new System.Drawing.Size(100, 28);
            this.tbxGrade.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "&Grade";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(468, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(195, 49);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(468, 333);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(195, 49);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "E&xit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbxGrade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxCLassName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxGender);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxAge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxFirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxID);
            this.Controls.Add(this.label1);
            this.Name = "FormAdd";
            this.Text = "FormAdd";
            this.Load += new System.EventHandler(this.FormAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxAge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCLassName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxGrade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}