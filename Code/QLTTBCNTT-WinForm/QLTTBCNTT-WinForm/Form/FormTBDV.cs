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
    public partial class FormTBDV : Form
    {
        public FormTBDV()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        QueryTBDonvi QueryTBDV = new QueryTBDonvi();

        private void FormTBDV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTTBCNTTDataSet.DM_ThietBi' table. You can move, or remove it, as needed.
            this.dM_ThietBiTableAdapter.Fill(this.qLTTBCNTTDataSet.DM_ThietBi);
            // TODO: This line of code loads data into the 'qLTTBCNTTDataSet.DM_Donvi' table. You can move, or remove it, as needed.
            this.dM_DonviTableAdapter.Fill(this.qLTTBCNTTDataSet.DM_Donvi);
        }

        #region Button Funcion
        private void AddTBDV_Click(object sender, EventArgs e)
        {
            if (CheckIDTB_TBDV())
            {
                if (Input())
                {
                    QueryTBDV.Insert(GetTBDV());
                    Reload();
                    dtgvTBDV.Refresh();
                }
            }
            else { return; }

        }
        private void ModifyTBDV_Click(object sender, EventArgs e)
        {

        }

        private void DelTBDV_Click(object sender, EventArgs e)
        {

        }

        #endregion

        

        private void dtgvTBDV_MouseClick(object sender, MouseEventArgs e)
        {
        }
        private void ccbidDV_TextChanged(object sender, EventArgs e)
        {
        }

        #region Bổ trợ

        private TBDonvi GetTBDV()
        {
            int idDV = int.Parse(cbbIDDV.Text);
            int idTB = int.Parse(cbbIDTB.SelectedValue.ToString());
            //int idTB = int.Parse(cbbIDTB.Text);
            TBDonvi TBDV = new TBDonvi(idDV, idTB, DateBorrow.Value.ToString(), DateReturn.Value.ToString());
            return TBDV;
        }
        private bool Input()
        {
            if (cbbIDDV.Text == "" || cbbIDTB.Text == "")
            {
                MessageBox.Show("Không được để trống trường đơn vị và thiết bị");
                return false;
            }
            return true;
        }
        private void Clear()
        {
            cbbIDDV.Text = "";
            cbbIDTB.Text = "";
            txtSearchTBDV.Text = "";
        }

        private void Reload()
        {
            Clear();
            try
            {
                dtgvTBDV.DataSource = QueryTBDV.getDS_TBDonvi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Display()
        {
            var TBDV = dtgvTBDV.SelectedRows[0];
            cbbIDDV.Text = TBDV.Cells[1].Value.ToString();
            cbbIDTB.SelectedValue = TBDV.Cells[2].Value;
            DateBorrow.Value = Convert.ToDateTime(TBDV.Cells[3].Value.ToString());
            DateReturn.Value = Convert.ToDateTime(TBDV.Cells[4].Value.ToString());
        }

        private Boolean CheckIDTB_TBDV()
        {
            string ds = QueryTBDV.getTBDV_idTB_check(cbbIDTB.SelectedValue.ToString()) /*+ new QueryTBQN().getTBQN_idTB_check(cbbIDTB.SelectedValue.ToString())*/;
            if (ds.Equals(""))
            {
                MessageBox.Show("Thiết bị hợp lệ, chưa được biên chế hoặc cho mượn");
                return true;
            }
            else
            {
                MessageBox.Show("Thiết bị đã được biên chế hoặc được cho mượn. Xin vui lòng chọn thiết bị khác!");
                cbbIDTB.Text = "";
                return false;
            }
        }
        #endregion

    }
}
