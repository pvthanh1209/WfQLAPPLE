using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKMT.GUI
{
    public partial class fReportSP : UserControl
    {
        public fReportSP()
        {
            InitializeComponent();
        }
       
        private string constr = ConfigurationManager.ConnectionStrings["QLAPPLE"].ConnectionString;
        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (SqlCommand command = new SqlCommand("Sp_ReportSanPham", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Tạo một DataTable để lưu trữ kết quả
                DataTable dataTable = new DataTable();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }

                // Set the report data source
                rpViewerSP.LocalReport.DataSources.Clear();
                ReportDataSource source = new ReportDataSource("QLStoreDataset", dataTable);
                rpViewerSP.LocalReport.ReportPath = "ReportSP.rdlc";
                rpViewerSP.LocalReport.DataSources.Add(source);
                // Refresh the report
                rpViewerSP.RefreshReport();
            }
        }
    }
}
