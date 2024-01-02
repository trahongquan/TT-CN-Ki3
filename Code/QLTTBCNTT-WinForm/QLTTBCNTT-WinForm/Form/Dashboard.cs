using QLTTBCNTT_WinForm.Object;
using QLTTBCNTT_WinForm.suport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTTBCNTT_WinForm
{
    public partial class Dashboard : Form
    {
        QueryDashBoard QueryDB = new QueryDashBoard();
        public Dashboard()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        #region Bổ trợ
        private void Dashboard_Load(object sender, EventArgs e)
        {
            Clear();
            RB_Doi.Checked = true;
            btnBRG_DB_Click(sender, e);
        }
        private void Clear()
        {
            txtSearchTenTB.Text = "";
            txtSearchTenQN.Text = "";
            txtSearchDV.Text = "";
        }

        private int Count()
        {
            int count = 0;
            if (txtSearchTenTB.Text != "") return count += QueryDB.Search("TenTB", txtSearchTenTB.Text).Rows.Count;
            if (txtSearchTenQN.Text != "") return count += QueryDB.Search("Ten", txtSearchTenQN.Text).Rows.Count;
            if (txtSearchDV.Text != "")
            {
                if (RB_Doi.Checked) return count += QueryDB.Search("Doi", txtSearchDV.Text).Rows.Count;
                if (RB_TieuDoan.Checked) return count += QueryDB.Search("TieuDoan", txtSearchDV.Text).Rows.Count;
                if (RB_LuDoan.Checked) return count += QueryDB.Search("LuDoan", txtSearchDV.Text).Rows.Count;
            }
            return count;
        }


        #endregion
        #region nút chức năng
        private void btnBRG_DB_Click(object sender, EventArgs e)
        {
            string s = "select TB.TenTB, LTB.loai, QN.Ten, DV.Doi, DV.TieuDoan, DV.LuDoan " +
                            "From DM_ThietBi As TB, DM_LoaiThietBi As LTB, DM_Quannhan As QN, DM_Donvi As DV " +
                            "WHERE TB.idLoaiTB = LTB.IdLoaiTB And TB.idQuannhan = QN.IDQuannhan and TB.idDonvi = DV.IdDonvi ";
            dtgvDashboard.DataSource = QueryDB.getDS(s);
        }

        private void btnTBQN_DB_Click(object sender, EventArgs e)
        {
            string s = "select TB.TenTB, LTB.loai, QN.Ten, DV.Doi, DV.TieuDoan, TBQN.DateBorrow, TBQN.DateReturn " +
                            "From DM_ThietBi As TB, DM_LoaiThietBi As LTB, DM_Quannhan As QN, TB_QN As TBQN, DM_Donvi As DV " +
                            "WHERE TBQN.idThietbi=TB.IdThietBi and TBQN.idQuannhan=QN.IDQuannhan and TB.idLoaiTB=LTB.IdLoaiTB and QN.idDonvi=DV.IdDonvi";
            dtgvDashboard.DataSource = QueryDB.getDS(s);
        }

        private void btnTBDV_DB_Click(object sender, EventArgs e)
        {
            string s = "select TB.TenTB, LTB.loai, DV.Doi, DV.TieuDoan, TBDV.DateBorrow, TBDV.DateReturn " +
                            "From DM_ThietBi As TB, DM_LoaiThietBi As LTB, TB_Donvi As TBDV, DM_Donvi As DV " +
                            "WHERE TBDV.idThietbi=TB.IdThietBi and TBDV.idDonvi=DV.IdDonvi and TB.idLoaiTB=LTB.IdLoaiTB";
            dtgvDashboard.DataSource = QueryDB.getDS(s);
        }
        #endregion
    }
}
