namespace SearchCustom
{
    partial class frmPromotion
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
            this.cmbpro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnok = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbpro
            // 
            this.cmbpro.FormattingEnabled = true;
            this.cmbpro.Location = new System.Drawing.Point(72, 25);
            this.cmbpro.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbpro.Name = "cmbpro";
            this.cmbpro.Size = new System.Drawing.Size(272, 24);
            this.cmbpro.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "โปรโมชั่น";
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(219, 55);
            this.btnok.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(58, 26);
            this.btnok.TabIndex = 192;
            this.btnok.Text = "ตกลง";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(286, 55);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 26);
            this.btnCancel.TabIndex = 193;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 106);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbpro);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmPromotion";
            this.Text = "Promotion";
            this.Load += new System.EventHandler(this.frmPromotion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbpro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btnCancel;
    }
}