using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BankingSystemABCGroup
{
    public partial class Form1 : Form
    {

        MySqlConnection con = new MySqlConnection("server = localhost; database = abcbank; username = root; password =;");
        int i;
        public Form1()
        {
            InitializeComponent();
        }

       
        

        int count;

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from register where username = '" + txtuser.Text + "' and password = '" + txtpass.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if(i == 0)
            {
                label4.Text = "Invalid Username and Password";
            }
            else
            {
                progbar pr = new progbar(); 
                this.Hide();        //To close Form1
                pr.Show();          //To open the progress bar

            }


            


           

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "";
            //To display the text at label14 for a limited time
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }
    }
}
