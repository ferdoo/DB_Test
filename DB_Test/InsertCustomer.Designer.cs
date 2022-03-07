
namespace DB_Test
{
    partial class InsertCustomer
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
            this.CompanyName_textBox = new System.Windows.Forms.TextBox();
            this.ContactName_textBox = new System.Windows.Forms.TextBox();
            this.Phone_textBox = new System.Windows.Forms.TextBox();
            this.BtnInsertCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CompanyName_textBox
            // 
            this.CompanyName_textBox.Location = new System.Drawing.Point(26, 35);
            this.CompanyName_textBox.Name = "CompanyName_textBox";
            this.CompanyName_textBox.Size = new System.Drawing.Size(245, 20);
            this.CompanyName_textBox.TabIndex = 0;
            // 
            // ContactName_textBox
            // 
            this.ContactName_textBox.Location = new System.Drawing.Point(26, 82);
            this.ContactName_textBox.Name = "ContactName_textBox";
            this.ContactName_textBox.Size = new System.Drawing.Size(245, 20);
            this.ContactName_textBox.TabIndex = 1;
            // 
            // Phone_textBox
            // 
            this.Phone_textBox.Location = new System.Drawing.Point(26, 133);
            this.Phone_textBox.Name = "Phone_textBox";
            this.Phone_textBox.Size = new System.Drawing.Size(245, 20);
            this.Phone_textBox.TabIndex = 2;
            // 
            // BtnInsertCustomer
            // 
            this.BtnInsertCustomer.Location = new System.Drawing.Point(23, 188);
            this.BtnInsertCustomer.Name = "BtnInsertCustomer";
            this.BtnInsertCustomer.Size = new System.Drawing.Size(75, 23);
            this.BtnInsertCustomer.TabIndex = 3;
            this.BtnInsertCustomer.Text = "Insert";
            this.BtnInsertCustomer.UseVisualStyleBackColor = true;
            this.BtnInsertCustomer.Click += new System.EventHandler(this.BtnInsertCustomer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "CompanyName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ContactName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phone:";
            // 
            // InsertCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 244);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnInsertCustomer);
            this.Controls.Add(this.Phone_textBox);
            this.Controls.Add(this.ContactName_textBox);
            this.Controls.Add(this.CompanyName_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vlozenie Zaznamu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CompanyName_textBox;
        private System.Windows.Forms.TextBox ContactName_textBox;
        private System.Windows.Forms.TextBox Phone_textBox;
        private System.Windows.Forms.Button BtnInsertCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}