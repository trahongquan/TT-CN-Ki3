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

    }
}
