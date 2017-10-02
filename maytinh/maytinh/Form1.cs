using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace maytinh
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool isTypingNumber = false;
        enum PhepToan { none,Cong, Tru, Nhan, Chia };
        PhepToan pheptoan;
        double nho;
        private void NhapSo(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            NhapSo(btn.Text);
        }

        private void NhapSo(String so)
        {
            if (isTypingNumber)
                lblDisplay.Text = lblDisplay.Text + so;
            else
            {
                lblDisplay.Text = so;
                isTypingNumber = true;
            }
        }
        
        private void NhapPhepToan(object sender, EventArgs e)
        {
            if(nho!=0)

            TinhKetQua();
            Button btn= (Button)sender;
            switch(btn.Text)
            { case "+": pheptoan=PhepToan.Cong;break;
                case "-": pheptoan=PhepToan.Tru;break;
                case "*": pheptoan=PhepToan.Nhan;break;
                case "/": pheptoan=PhepToan.Chia;break;
            }
            nho = double.Parse(lblDisplay.Text);
            isTypingNumber = false;
        }

        private void TinhKetQua()
        {
            double tam = double.Parse(lblDisplay.Text);
            double ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: ketqua = nho + tam; break;
                case PhepToan.Tru: ketqua = nho - tam; break;
                case PhepToan.Nhan: ketqua = nho * tam; break;
                case PhepToan.Chia: ketqua = nho / tam; break;
            }

            lblDisplay.Text = ketqua.ToString();
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
            nho = 0;
            pheptoan = PhepToan.none;
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    NhapSo("" + e.KeyChar);
                    break;
                case '+':
                    btnCong.PerformClick();
                    break;
                case '-':
                    btnTru.PerformClick();
                    break;
                case '*':
                    btnNhan.PerformClick();
                    break;
                case '/':
                    btnChia.PerformClick();
                    break;
                case '=':
                    btnBang.PerformClick();
                    break;
                default:
                    break;
               }

        }
        private void btnCan_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = (Math.Sqrt(Double.Parse(lblDisplay.Text))).ToString();
        }

        private void btnDoiGiau_click(object sender,EventArgs e)
        {
            lblDisplay.Text = (-1 * (double.Parse(lblDisplay.Text))).ToString();
        }

        private void btnphantram_click(object sender,EventArgs e)
        {
            lblDisplay.Text = ((double.Parse(lblDisplay.Text) / 100)).ToString();
        }

        private void btnXoaMotKiTu_click(object sender,EventArgs e)
        {
            if (lblDisplay.Text != "")
                lblDisplay.Text = (lblDisplay.Text).Substring(0, lblDisplay.Text.Length - 1);
        }

        private void btnXoaHet_click(object sender, EventArgs e)
        {
            nho = 0;
            lblDisplay.Text = "0.";
        }
         }
}
