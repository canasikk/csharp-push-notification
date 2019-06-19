using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;
namespace Notifications
{
    public partial class Main : Form
    {
         
        public MySqlConnection db = new MySqlConnection("Server=localhost;Database=notify;Uid=root;Pwd='';");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter adtr;
        public MySqlDataReader dr;
        public DataSet ds;
        public Main()
        {
            InitializeComponent();
            //https://www.instagram.com/canasikk/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            db.Close();
            cmd = new MySqlCommand();
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "Update users set online='" + 0 + "' where id=" + Properties.Settings.Default.uid + "";
            cmd.ExecuteNonQuery();
            db.Close();*/
            Application.Exit();
        }

        private void getNotification() {
            db.Close();
            try {
                db.Close();
                db.Open();
                cmd.Connection = db;
                cmd.CommandText = "SELECT * FROM notifycation Where status = 1";
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    notification not = new notification();
                    not.label1.Text = dr["message"].ToString();
                    not.ShowDialog();
                }

                db.Dispose();             
                db.Close();
                Thread threadim = new Thread(getNotification);
                threadim.Start();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Thread threadim = new Thread(getNotification);
            threadim.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //notification not = new notification();
            //not.Show();

        }

        
    }
}
