using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using QLTTBCNTT_WinForm.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTTBCNTT_WinForm.suport
{
    internal class QueryTK
    {
        private SqlDataAdapter dataAdapter;
        private SqlCommand sqlCMD;

        public QueryTK() { }
        
        public DataTable FindByUser(string userLogin)
        {
            DataTable accountTab = new DataTable();
            string query = "select KindOfAcc, userLogin from AccLogin WHERE Active = 1 and userLogin = '" + userLogin + "'";

            try
            {
                using (SqlConnection sqlConnection = ConnectionString.getConnection())
                {
                    sqlConnection.Open();
                    //sqlCMD.Parameters.Add("@UserLogin", SqlDbType.NVarChar).Value = userLogin;
                    dataAdapter = new SqlDataAdapter(query, sqlConnection);
                    dataAdapter.Fill(accountTab);
                    sqlConnection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối đến Cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return accountTab;
        }

        public void Insert(Account user)
        {
            SqlConnection sqlConnection = ConnectionString.getConnection();
            string query = "Insert into AccLogin values (@IDQuannhan, @UserLogin, @PassLogin, 1, @KindOfAcc, @TenQN, @CMTQD)";

            try
            {
                sqlConnection.Open();

                sqlCMD = new SqlCommand(query, sqlConnection);

                sqlCMD.Parameters.Add("@IDQuannhan", SqlDbType.Int).Value = user.IDQuannhan1;
                sqlCMD.Parameters.Add("@UserLogin", SqlDbType.NVarChar).Value = user.UserLogin1;
                sqlCMD.Parameters.Add("@PassLogin", SqlDbType.NVarChar).Value = user.PassLogin1;
                sqlCMD.Parameters.Add("@KindOfAcc", SqlDbType.Int).Value = user.KindOfAcc1;
                sqlCMD.Parameters.Add("@TenQN", SqlDbType.NVarChar).Value = user.TenQN1;
                sqlCMD.Parameters.Add("@CMTQD", SqlDbType.NVarChar).Value = user.CMTQD1;


                sqlCMD.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        

        public bool isTruePassword(string user, string password)
        {
            try
            {
                SqlConnection adminCnt = ConnectionString.getConnection();
                adminCnt.Open();

                string query = "select Active from AccLogin WHERE UserLogin = '" + user + "'and PassLogin = '" + password + "' and Active = 1";

                SqlCommand cmd = new SqlCommand(query, adminCnt);

                SqlDataReader data = cmd.ExecuteReader();

                bool b = data.Read();
               

                adminCnt.Close();

                return b;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến Cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

    }
}
