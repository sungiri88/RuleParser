namespace RuleParser
{
    partial class RuleParser
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
            this.rtxtBox_JSON = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CSVPath = new System.Windows.Forms.Button();
            this.btn_ProcessRule = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxtBox_JSON
            // 
            this.rtxtBox_JSON.Location = new System.Drawing.Point(131, 22);
            this.rtxtBox_JSON.Name = "rtxtBox_JSON";
            this.rtxtBox_JSON.Size = new System.Drawing.Size(604, 121);
            this.rtxtBox_JSON.TabIndex = 0;
            this.rtxtBox_JSON.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter JSON";
            // 
            // btn_CSVPath
            // 
            this.btn_CSVPath.Location = new System.Drawing.Point(183, 165);
            this.btn_CSVPath.Name = "btn_CSVPath";
            this.btn_CSVPath.Size = new System.Drawing.Size(185, 23);
            this.btn_CSVPath.TabIndex = 2;
            this.btn_CSVPath.Text = "Upload CSV";
            this.btn_CSVPath.UseVisualStyleBackColor = true;
            this.btn_CSVPath.Click += new System.EventHandler(this.btn_CSVPath_Click);
            // 
            // btn_ProcessRule
            // 
            this.btn_ProcessRule.Location = new System.Drawing.Point(452, 165);
            this.btn_ProcessRule.Name = "btn_ProcessRule";
            this.btn_ProcessRule.Size = new System.Drawing.Size(196, 23);
            this.btn_ProcessRule.TabIndex = 3;
            this.btn_ProcessRule.Text = "Submit";
            this.btn_ProcessRule.UseVisualStyleBackColor = true;
            this.btn_ProcessRule.Visible = false;
            this.btn_ProcessRule.Click += new System.EventHandler(this.btn_ProcessRule_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(131, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(604, 213);
            this.dataGridView1.TabIndex = 4;
            // 
            // RuleParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 477);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_ProcessRule);
            this.Controls.Add(this.btn_CSVPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxtBox_JSON);
            this.Name = "RuleParser";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtBox_JSON;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CSVPath;
        private System.Windows.Forms.Button btn_ProcessRule;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

