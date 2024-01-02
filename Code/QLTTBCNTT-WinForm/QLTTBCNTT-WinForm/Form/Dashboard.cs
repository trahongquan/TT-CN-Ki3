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
        #endregion
        #region nút chức năng
        private void btnBRG_DB_Click(object sender, EventArgs e)
        {
            string s = "select TB.TenTB, LTB.loai, QN.Ten, DV.Doi, DV.TieuDoan, DV.LuDoan " +
                            "From DM_ThietBi As TB, DM_LoaiThietBi As LTB, DM_Quannhan As QN, DM_Donvi As DV " +
                            "WHERE TB.idLoaiTB = LTB.IdLoaiTB And TB.idQuannhan = QN.IDQuannhan and TB.idDonvi = DV.IdDonvi ";
            dtgvDashboard.DataSource = QueryDB.getDS(s);
        }

        
        #endregion
    }
}
