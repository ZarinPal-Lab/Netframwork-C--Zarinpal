using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zarinpal;
using zarinpal.ServiceReference;

namespace ZARINPAL_PARDAKHT
{
    public partial class Form1 : Form
    {
        zarinpal.pay shayan = new zarinpal.pay("9b9eef82-7cde-11e7-b794-000c295eb8fc", 100, "tozihat", "https://google.com/");
        public Form1()
        {
            InitializeComponent();
            shayan.OnPaymentAction += Shayan_OnPaymentAction;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Shayan_OnPaymentAction(object sender, pay.PayArgs e)
        {
            if (e.Status > 0)
            {
                this.Invoke(new Action(() =>
                {
                    panel1.BackColor = Color.Green;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    panel1.BackColor = Color.Red;
                }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(shayan.URL + shayan.StartPay());
        }
    }
}
