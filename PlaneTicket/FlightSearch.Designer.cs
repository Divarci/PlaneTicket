namespace PlaneTicket
{
    partial class FlightSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightSearch));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.rbOneway = new System.Windows.Forms.RadioButton();
            this.rbReturn = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDep = new System.Windows.Forms.DateTimePicker();
            this.dtpReturn = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFindCheapFlight = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numGuest = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGuest)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 296);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(418, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "FROM :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "TO :";
            // 
            // cmbFrom
            // 
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(140, 48);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(253, 26);
            this.cmbFrom.TabIndex = 3;
            this.cmbFrom.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(140, 82);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(253, 26);
            this.cmbTo.TabIndex = 4;
            // 
            // rbOneway
            // 
            this.rbOneway.AutoSize = true;
            this.rbOneway.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOneway.Location = new System.Drawing.Point(162, 12);
            this.rbOneway.Name = "rbOneway";
            this.rbOneway.Size = new System.Drawing.Size(87, 20);
            this.rbOneway.TabIndex = 5;
            this.rbOneway.TabStop = true;
            this.rbOneway.Text = "ONE WAY";
            this.rbOneway.UseVisualStyleBackColor = true;
            this.rbOneway.CheckedChanged += new System.EventHandler(this.rbOneway_CheckedChanged);
            // 
            // rbReturn
            // 
            this.rbReturn.AutoSize = true;
            this.rbReturn.Font = new System.Drawing.Font("Berlin Sans FB", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReturn.Location = new System.Drawing.Point(280, 12);
            this.rbReturn.Name = "rbReturn";
            this.rbReturn.Size = new System.Drawing.Size(75, 20);
            this.rbReturn.TabIndex = 6;
            this.rbReturn.TabStop = true;
            this.rbReturn.Text = "RETURN";
            this.rbReturn.UseVisualStyleBackColor = true;
            this.rbReturn.CheckedChanged += new System.EventHandler(this.rbReturn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "DEP. DATE :";
            // 
            // dtpDep
            // 
            this.dtpDep.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDep.Location = new System.Drawing.Point(140, 218);
            this.dtpDep.Name = "dtpDep";
            this.dtpDep.Size = new System.Drawing.Size(149, 25);
            this.dtpDep.TabIndex = 8;
            this.dtpDep.Value = new System.DateTime(2023, 3, 28, 21, 45, 3, 0);
            this.dtpDep.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dtpReturn
            // 
            this.dtpReturn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturn.Location = new System.Drawing.Point(140, 252);
            this.dtpReturn.Name = "dtpReturn";
            this.dtpReturn.Size = new System.Drawing.Size(149, 25);
            this.dtpReturn.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "RETURN DATE :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "GUEST :";
            // 
            // btnFindCheapFlight
            // 
            this.btnFindCheapFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindCheapFlight.ForeColor = System.Drawing.Color.White;
            this.btnFindCheapFlight.Location = new System.Drawing.Point(307, 124);
            this.btnFindCheapFlight.Name = "btnFindCheapFlight";
            this.btnFindCheapFlight.Size = new System.Drawing.Size(87, 153);
            this.btnFindCheapFlight.TabIndex = 13;
            this.btnFindCheapFlight.Text = "FIND CHEAP FLIGHT";
            this.btnFindCheapFlight.UseVisualStyleBackColor = true;
            this.btnFindCheapFlight.Click += new System.EventHandler(this.btnFindCheapFlight_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Berlin Sans FB", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1, 576);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "BH SOFTWARE DEVELOPMENT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Berlin Sans FB", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(286, 576);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "ALL RIGHTS RESERVED";
            // 
            // numGuest
            // 
            this.numGuest.Location = new System.Drawing.Point(141, 150);
            this.numGuest.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numGuest.Name = "numGuest";
            this.numGuest.Size = new System.Drawing.Size(108, 25);
            this.numGuest.TabIndex = 16;
            // 
            // FlightSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(409, 593);
            this.Controls.Add(this.numGuest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFindCheapFlight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpReturn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbReturn);
            this.Controls.Add(this.rbOneway);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FlightSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flight Search";
            this.Load += new System.EventHandler(this.FlightSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGuest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.RadioButton rbOneway;
        private System.Windows.Forms.RadioButton rbReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDep;
        private System.Windows.Forms.DateTimePicker dtpReturn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFindCheapFlight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numGuest;
    }
}

