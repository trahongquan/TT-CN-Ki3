﻿using QLTTBCNTT_WinForm.Object;
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
    public partial class FormDV : Form
    {
        QueryDonvi QueryDV = new QueryDonvi();
        public FormDV()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        private void FormDV_Load(object sender, EventArgs e)
        {
            Reload();
            dtgvDV.Columns[0].HeaderText = "IDDV";
            dtgvDV.Columns[1].HeaderText = "Đội";
            dtgvDV.Columns[2].HeaderText = "Tiểu đoàn";
            dtgvDV.Columns[3].HeaderText = "Lữ đoàn";
        }




        #region Bổ trợ

        private Donvi GetDV()
        {
            Donvi DV = new Donvi(cbbDoi.Text, cbbTieudoan.Text, cbbLudoan.Text);
            return DV;
        }
        private bool Input()
        {
            if (cbbLudoan.Text == "") { 
                MessageBox.Show("Không được để trống cấp Lữ đoàn");
                return false; }
            return true;
        }
        private void Clear()
        {
            cbbDoi.GetItemText(0);
            cbbTieudoan.GetItemText(0);
            cbbLudoan.GetItemText(0);
        }

        private void Reload()
        {
            Clear();
            try
            {
                dtgvDV.DataSource = QueryDV.getDS_Donvi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        #endregion
    }

}