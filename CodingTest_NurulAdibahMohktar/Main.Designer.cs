namespace CodingTest_NurulAdibahMohktar
{
    partial class Main
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
            this.lblInstruction = new System.Windows.Forms.Label();
            this.tbInputNumber = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(74, 41);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(143, 13);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Please enter numbers below:";
            // 
            // tbInputNumber
            // 
            this.tbInputNumber.Location = new System.Drawing.Point(41, 67);
            this.tbInputNumber.Name = "tbInputNumber";
            this.tbInputNumber.Size = new System.Drawing.Size(209, 20);
            this.tbInputNumber.TabIndex = 1;
            this.tbInputNumber.Text = "eg: 1 + 1";
            this.tbInputNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(108, 102);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(74, 29);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Result:";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(113, 151);
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(100, 20);
            this.tbResult.TabIndex = 4;
            this.tbResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 182);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.tbInputNumber);
            this.Controls.Add(this.lblInstruction);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Sum Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox tbInputNumber;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbResult;
    }
}

