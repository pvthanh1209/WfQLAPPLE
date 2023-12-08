
namespace LKMT.GUI
{
    partial class fReportSP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.rpViewerSP = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(357, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO SẢN PHẨM ";
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(489, 119);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(176, 52);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "Tạo Báo Cáo";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // rpViewerSP
            // 
            this.rpViewerSP.Location = new System.Drawing.Point(35, 195);
            this.rpViewerSP.Name = "rpViewerSP";
            this.rpViewerSP.ServerReport.BearerToken = null;
            this.rpViewerSP.Size = new System.Drawing.Size(1121, 565);
            this.rpViewerSP.TabIndex = 2;
            // 
            // fReportSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rpViewerSP);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label1);
            this.Name = "fReportSP";
            this.Size = new System.Drawing.Size(1414, 786);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReport;
        private Microsoft.Reporting.WinForms.ReportViewer rpViewerSP;
    }
}
