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
    public partial class FormQN : Form
    {
        QueryQuannhan QueryQN = new QueryQuannhan();
        public FormQN()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void FormQN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTTBCNTTDataSet.DM_Donvi' table. You can move, or remove it, as needed.
            this.dM_DonviTableAdapter.Fill(this.qLTTBCNTTDataSet.DM_Donvi);
            Reload();
            dtgvQN.Columns[0].HeaderText = "IDQN";
            dtgvQN.Columns[1].HeaderText = "CMTQĐ";
            dtgvQN.Columns[2].HeaderText = "Tên";
            dtgvQN.Columns[3].HeaderText = "Cấp bậc";
            dtgvQN.Columns[4].HeaderText = "Chức vụ";
            dtgvQN.Columns[5].HeaderText = "ID Đơn vị";
        }

        

        #region Bổ trợ

        private Quannhan GetQN()
        {
            int idDV = int.Parse(cbbDonvi.Text);
            Quannhan QN = new Quannhan(txtCMTQD.Text, txtTen.Text, cbbCapbac.Text, cbbChucvu.Text, idDV);
            return QN;
        }
        private bool Input()
        {
            if (txtCMTQD.Text == "" || txtTen.Text == "" || cbbCapbac.Text == "" || cbbChucvu.Text == "" || cbbDonvi.Text == "") { 
                MessageBox.Show("Bạn cần nhập đủ các trường");
                return false; }
            return true;
        }
        private void Clear()
        {
            txtCMTQD.Text = "";
            txtTen.Text = "";
            labDV.Text = "";
            cbbCapbac.GetItemText(0);
            cbbChucvu.GetItemText(0);
            cbbDonvi.Text = "";
        }

        private void Reload()
        {
            Clear();
            try
            {
                dtgvQN.DataSource = QueryQN.getDS_Quannhan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

    }
}
