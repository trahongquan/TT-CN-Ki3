using QLTTBCNTT_WinForm.Object;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTTBCNTT_WinForm.suport
{
    internal class QueryDashBoard
    {
        #region Cac thuoc tinh
        SqlDataAdapter dataAdapter;     // xuat du lieu vao bang
        SqlCommand sqlCMD;              // truy van, cap nhat CSDL
        #endregion

        #region Các phương thức
        public DataTable getDSTB()
        {
            DataTable bangXM = new DataTable();
            string query = "select * from DM_ThietBi";// * se lay tat ca cac cot
            try
            {
                using (SqlConnection sqlConnection = ConnectionString.getConnection())
                {
                    sqlConnection.Open();
                    dataAdapter = new SqlDataAdapter(query, sqlConnection); //tao 1 ket noi CSDL moi
                    dataAdapter.Fill(bangXM);   // dien du lieu vao bang
                    sqlConnection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối đến Cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return bangXM;
        }
        #endregion

        public DataTable getDS(string s)
        {
            DataTable bangXM = new DataTable();

            string query = s;
            using (SqlConnection sqlConnection = ConnectionString.getConnection())
            {
                sqlConnection.Open();

                dataAdapter = new SqlDataAdapter(query, sqlConnection); //tao 1 ket noi CSDL moi

                dataAdapter.Fill(bangXM);   // dien du lieu vao bang
                sqlConnection.Close();
            }
            return bangXM;
        }

        #region Query Bảng rút gọn


        public DataTable getDSLTB()
        {
            DataTable bangXM = new DataTable();

            string query = "select * from DM_LoaiThietBi";
            using (SqlConnection sqlConnection = ConnectionString.getConnection())
            {
                sqlConnection.Open();

                dataAdapter = new SqlDataAdapter(query, sqlConnection); //tao 1 ket noi CSDL moi

                dataAdapter.Fill(bangXM);   // dien du lieu vao bang
                sqlConnection.Close();
            }
            return bangXM;
        }

        public DataTable Search(string col, string st)
        {
            DataTable bangXM = new DataTable();

            string query = "select TB.TenTB, LTB.loai, QN.Ten, DV.Doi, DV.TieuDoan, DV.LuDoan " +
                            "From DM_ThietBi As TB, DM_LoaiThietBi As LTB, DM_Quannhan As QN, DM_Donvi As DV " +
                            "WHERE TB.idLoaiTB = LTB.IdLoaiTB And TB.idQuannhan = QN.IDQuannhan and QN.idDonvi = DV.IdDonvi and ";

            query += col;
            query += " like N'%";
            query += st + "%'";

            using (SqlConnection sqlConnection = ConnectionString.getConnection())
            {
                sqlConnection.Open();

                dataAdapter = new SqlDataAdapter(query, sqlConnection); //tao 1 ket noi CSDL moi

                dataAdapter.Fill(bangXM);   // dien du lieu vao bang
                sqlConnection.Close();
            }
            return bangXM;
        }
        #endregion
    }
}
