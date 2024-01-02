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

        

    }
}
