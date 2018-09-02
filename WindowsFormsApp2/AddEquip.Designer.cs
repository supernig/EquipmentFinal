namespace WindowsFormsApp2
{
    partial class AddEquip
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtrdp1 = new System.Windows.Forms.DateTimePicker();
            this.dr = new System.Windows.Forms.Label();
            this.dddtp = new System.Windows.Forms.DateTimePicker();
            this.ddlbl = new System.Windows.Forms.Label();
            this.ownertb = new System.Windows.Forms.TextBox();
            this.owner = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Staging",
            "Lights",
            "Speakers",
            "Misc.",
            "Video",
            "LED Wall",
            "LCD"});
            this.comboBox1.Location = new System.Drawing.Point(103, 116);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(103, 143);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(225, 20);
            this.textBox2.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(103, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 55);
            this.button1.TabIndex = 13;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Description";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Permanent",
            "Temporary"});
            this.comboBox2.Location = new System.Drawing.Point(103, 49);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(137, 21);
            this.comboBox2.TabIndex = 18;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Status";
            // 
            // dtrdp1
            // 
            this.dtrdp1.Location = new System.Drawing.Point(103, 195);
            this.dtrdp1.Name = "dtrdp1";
            this.dtrdp1.Size = new System.Drawing.Size(225, 20);
            this.dtrdp1.TabIndex = 20;
            this.dtrdp1.Visible = false;
            // 
            // dr
            // 
            this.dr.AutoSize = true;
            this.dr.Location = new System.Drawing.Point(12, 195);
            this.dr.Name = "dr";
            this.dr.Size = new System.Drawing.Size(68, 13);
            this.dr.TabIndex = 21;
            this.dr.Text = "Date Rented";
            this.dr.Visible = false;
            // 
            // dddtp
            // 
            this.dddtp.Location = new System.Drawing.Point(103, 221);
            this.dddtp.Name = "dddtp";
            this.dddtp.Size = new System.Drawing.Size(225, 20);
            this.dddtp.TabIndex = 22;
            this.dddtp.Visible = false;
            // 
            // ddlbl
            // 
            this.ddlbl.AutoSize = true;
            this.ddlbl.Location = new System.Drawing.Point(13, 221);
            this.ddlbl.Name = "ddlbl";
            this.ddlbl.Size = new System.Drawing.Size(53, 13);
            this.ddlbl.TabIndex = 23;
            this.ddlbl.Text = "Date Due";
            this.ddlbl.Visible = false;
            // 
            // ownertb
            // 
            this.ownertb.Location = new System.Drawing.Point(103, 248);
            this.ownertb.Name = "ownertb";
            this.ownertb.Size = new System.Drawing.Size(225, 20);
            this.ownertb.TabIndex = 24;
            this.ownertb.Visible = false;
            // 
            // owner
            // 
            this.owner.AutoSize = true;
            this.owner.Location = new System.Drawing.Point(13, 251);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(38, 13);
            this.owner.TabIndex = 25;
            this.owner.Text = "Owner";
            this.owner.Visible = false;
            // 
            // AddEquip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 392);
            this.Controls.Add(this.owner);
            this.Controls.Add(this.ownertb);
            this.Controls.Add(this.ddlbl);
            this.Controls.Add(this.dddtp);
            this.Controls.Add(this.dr);
            this.Controls.Add(this.dtrdp1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "AddEquip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEquip";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddEquip_FormClosed);
            this.Load += new System.EventHandler(this.AddEquip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtrdp1;
        private System.Windows.Forms.Label dr;
        private System.Windows.Forms.DateTimePicker dddtp;
        private System.Windows.Forms.Label ddlbl;
        private System.Windows.Forms.TextBox ownertb;
        private System.Windows.Forms.Label owner;
    }
}