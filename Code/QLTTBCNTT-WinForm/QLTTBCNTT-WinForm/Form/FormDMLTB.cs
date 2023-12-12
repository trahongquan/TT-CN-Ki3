using QLTTBCNTT_WinForm.suport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTTBCNTT_WinForm
{
    public partial class FormDMLTB : Form
    {
        SqlDataAdapter dataAdapter;
        public DataTable getTableAccount()
        {
            DataTable DMLTB = new DataTable();
            string query = "select * from DM_LoaiThietBi";

            try
            {
                using (SqlConnection sqlConnection = ConnectionString.getConnection())
                {
                    sqlConnection.Open();
                    dataAdapter = new SqlDataAdapter(query, sqlConnection);
                    dataAdapter.Fill(DMLTB);
                    sqlConnection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối đến Cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return DMLTB;
        }
        public FormDMLTB()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void FormDMLTB_Load(object sender, EventArgs e)
        {
            dtgvDMLTB.DataSource = getTableAccount();
        }
    }
}
