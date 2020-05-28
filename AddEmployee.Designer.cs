namespace _1045_BarsanescuDiana_Proiect
{
    partial class AddEmployee
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployee));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbF = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpE = new System.Windows.Forms.DateTimePicker();
            this.cbAge = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "First name";
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tbID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbID.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbID.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(255, 99);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(89, 32);
            this.tbID.TabIndex = 2;
            this.tbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbName_KeyPress);
            // 
            // tbF
            // 
            this.tbF.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tbF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbF.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbF.Location = new System.Drawing.Point(255, 145);
            this.tbF.Name = "tbF";
            this.tbF.Size = new System.Drawing.Size(291, 32);
            this.tbF.TabIndex = 3;
            this.tbF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbID_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("GT Walsheim Pro Trial Md", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label3.Location = new System.Drawing.Point(166, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Add new employee";
            // 
            // tbL
            // 
            this.tbL.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tbL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbL.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL.Location = new System.Drawing.Point(255, 192);
            this.tbL.Name = "tbL";
            this.tbL.Size = new System.Drawing.Size(291, 32);
            this.tbL.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(183, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "Age";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "Last name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 31);
            this.label7.TabIndex = 10;
            this.label7.Text = "Employment date";
            // 
            // dtpE
            // 
            this.dtpE.CalendarMonthBackground = System.Drawing.Color.PaleTurquoise;
            this.dtpE.CalendarTitleBackColor = System.Drawing.Color.MediumTurquoise;
            this.dtpE.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpE.Location = new System.Drawing.Point(255, 288);
            this.dtpE.Name = "dtpE";
            this.dtpE.Size = new System.Drawing.Size(291, 39);
            this.dtpE.TabIndex = 13;
            // 
            // cbAge
            // 
            this.cbAge.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cbAge.Font = new System.Drawing.Font("GTWalsheimProRegular", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAge.FormattingEnabled = true;
            this.cbAge.Items.AddRange(new object[] {
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40"});
            this.cbAge.Location = new System.Drawing.Point(255, 237);
            this.cbAge.Name = "cbAge";
            this.cbAge.Size = new System.Drawing.Size(89, 39);
            this.cbAge.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(344, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 51);
            this.button2.TabIndex = 15;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::_1045_BarsanescuDiana_Proiect.Properties.Resources.plus;
            this.button1.Location = new System.Drawing.Point(255, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 58);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddEmployee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(648, 419);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbAge);
            this.Controls.Add(this.dtpE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbF);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("GTWalsheimProRegular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightCyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add employee";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAge;
        private System.Windows.Forms.Button button2;
    }
}