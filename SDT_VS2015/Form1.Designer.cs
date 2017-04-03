namespace WindowsFormsApplication4
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
            this.PFieldValue = new System.Windows.Forms.ComboBox();
            this.Field1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PFieldValue
            // 
            this.PFieldValue.AllowDrop = true;
            this.PFieldValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PFieldValue.FormattingEnabled = true;
            this.PFieldValue.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.PFieldValue.Location = new System.Drawing.Point(183, 35);
            this.PFieldValue.Name = "PFieldValue";
            this.PFieldValue.Size = new System.Drawing.Size(121, 21);
            this.PFieldValue.TabIndex = 0;
            // 
            // Field1
            // 
            this.Field1.AutoSize = true;
            this.Field1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Field1.Location = new System.Drawing.Point(31, 36);
            this.Field1.Name = "Field1";
            this.Field1.Size = new System.Drawing.Size(132, 15);
            this.Field1.TabIndex = 1;
            this.Field1.Text = "Primary Field Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 557);
            this.Controls.Add(this.Field1);
            this.Controls.Add(this.PFieldValue);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PFieldValue;
        private System.Windows.Forms.Label Field1;
    }
}

