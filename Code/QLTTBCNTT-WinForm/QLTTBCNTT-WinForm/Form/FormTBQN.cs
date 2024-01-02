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
    public partial class FormTBQN : Form
    {
        public FormTBQN()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        QueryTBQN QueryTBQN = new QueryTBQN();

        private void FormTBQN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTTBCNTTDataSet.DM_ThietBi' table. You can move, or remove it, as needed.
            this.dM_ThietBiTableAdapter.Fill(this.qLTTBCNTTDataSet.DM_ThietBi);
            // TODO: This line of code loads data into the 'qLTTBCNTTDataSet.DM_QuanNhan' table. You can move, or remove it, as needed.
            this.dM_QuanNhanTableAdapter.Fill(this.qLTTBCNTTDataSet.DM_QuanNhan);
            Reload();
            dtgvTBQN.Columns[0].HeaderText = "IDTBQN";
            dtgvTBQN.Columns[1].HeaderText = "ID Quân nhân";
            dtgvTBQN.Columns[2].HeaderText = "ID Thiết bị";
            dtgvTBQN.Columns[3].HeaderText = "Ngày biên chế";
            dtgvTBQN.Columns[4].HeaderText = "Ngày trả biên chế";

        }

        private void Reload()
        {
            Clear();
            try
            {
                dtgvTBQN.DataSource = QueryTBQN.getDS_TBQN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear()
        {
            //txtQN.Text = "";
            cbbIDQN.Text = "";
            //txtTB.Text = "";
            cbbIDTB.Text = "";
        }

    }
}
