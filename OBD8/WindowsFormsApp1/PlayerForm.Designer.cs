namespace WindowsFormsApp1
{
    partial class PlayerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Pl_Name = new System.Windows.Forms.TextBox();
            this.Pl_Position = new System.Windows.Forms.ComboBox();
            this.Pl_Age = new System.Windows.Forms.NumericUpDown();
            this.Cancel = new System.Windows.Forms.Button();
            this.Pl_OK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pl_Age)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Pl_OK);
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.Pl_Age);
            this.groupBox1.Controls.Add(this.Pl_Position);
            this.groupBox1.Controls.Add(this.Pl_Name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Age";
            // 
            // Pl_Name
            // 
            this.Pl_Name.Location = new System.Drawing.Point(134, 47);
            this.Pl_Name.Name = "Pl_Name";
            this.Pl_Name.Size = new System.Drawing.Size(205, 22);
            this.Pl_Name.TabIndex = 1;
            // 
            // Pl_Position
            // 
            this.Pl_Position.FormattingEnabled = true;
            this.Pl_Position.Items.AddRange(new object[] {
            "Goalkeeper",
            "Fullback",
            "Sweeper",
            "Derender"});
            this.Pl_Position.Location = new System.Drawing.Point(134, 84);
            this.Pl_Position.Name = "Pl_Position";
            this.Pl_Position.Size = new System.Drawing.Size(205, 24);
            this.Pl_Position.TabIndex = 2;
            // 
            // Pl_Age
            // 
            this.Pl_Age.Location = new System.Drawing.Point(134, 125);
            this.Pl_Age.Name = "Pl_Age";
            this.Pl_Age.Size = new System.Drawing.Size(205, 22);
            this.Pl_Age.TabIndex = 3;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(264, 173);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Pl_OK
            // 
            this.Pl_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Pl_OK.Location = new System.Drawing.Point(178, 173);
            this.Pl_OK.Name = "Pl_OK";
            this.Pl_OK.Size = new System.Drawing.Size(75, 23);
            this.Pl_OK.TabIndex = 5;
            this.Pl_OK.Text = "OK";
            this.Pl_OK.UseVisualStyleBackColor = true;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 226);
            this.Controls.Add(this.groupBox1);
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pl_Age)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.NumericUpDown Pl_Age;
        protected internal System.Windows.Forms.TextBox Pl_Name;
        private System.Windows.Forms.Button Pl_OK;
        private System.Windows.Forms.Button Cancel;
        protected internal System.Windows.Forms.ComboBox Pl_Position;
    }
}