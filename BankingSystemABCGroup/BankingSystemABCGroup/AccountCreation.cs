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
    public partial class AccountCreation : Form
    {
        public AccountCreation()
        {
            InitializeComponent();
        }


        MySqlConnection con = new MySqlConnection("server = localhost; database = abcbank; username = root; password=;");  //Creates connection with abcbank table using MYSQL

        public void customerid()
        {
            con.Open();
            string query = "select max(customerid) from customer ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString(); //Reads the first entry of the customer database
                if(val == "")
                {
                    label10.Text = "10000";  //If there is no value in the database, it means that the customer id will start from 10000

                }
                else
                {
                    int a;

                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    label10.Text = a.ToString(); //To increment the customer id value so that everyone has a unique ID.
                }
                con.Close();
            }


        }








        private void AccountCreation_Load(object sender, EventArgs e)
        {
            customerid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            button4.BackColor = ColorTranslator.FromHtml("Teal");
            button5.BackColor = ColorTranslator.FromHtml("DarkSlateGray");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            button5.BackColor = ColorTranslator.FromHtml("Teal");
            button4.BackColor = ColorTranslator.FromHtml("DarkSlateGray");
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string cid, fname, lname, street, city, state, phone, date, email, accno, acctype, des, bal;

            cid = label10.Text;
            fname = txtfname.Text;
            lname = txtlname.Text;
            street = txtstreet.Text;
            city = txtcity.Text;
            state = txtstate.Text;
            phone = txtphone.Text;
            date = txtdate.Text;
            email = txtemail.Text;
            accno = txtacc.Text;
            acctype = txtacctype.Text;
            des = txtdesc.Text;
            bal = txtbal.Text;

            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction;

            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;



            try
            {

                cmd.CommandText = "insert into customer(customerid,firstname,lastname,street,city,state,phone,date,email) values('" + cid + "','" + fname + "','" + lname + "','" + street + "','" + city + "','" + state + "','" + phone + "','" + date + "','" + email + "')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into account(accountid,customerid,acctype,description,balance) values('" + accno + "','" + cid + "','" + acctype + "','" + des + "', '" + bal + "')";
                cmd.ExecuteNonQuery();
                //Attempt to commit the transaction
                transaction.Commit();
                MessageBox.Show("Record Added.");
            }
            catch(Exception ex)
            {
                //Attempt to rollback the transaction
                transaction.Rollback();
                MessageBox.Show(ex.ToString());
            }

            finally
                {
                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
