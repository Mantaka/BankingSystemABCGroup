using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystemABCGroup
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AccountCreation account = new AccountCreation();
            account.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            withdraw w = new withdraw();
            w.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            deposit d = new deposit();
            d.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Transfer t = new Transfer();
            t.Show();
        }
    }
}
