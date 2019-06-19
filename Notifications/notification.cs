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
 
namespace Notifications
{
    public partial class notification : Form
    {
        public notification()
        {
            InitializeComponent();
        }
        int a = 10;
        Random r = new Random();
        int x, y;
        public MySqlConnection db = new MySqlConnection("Server=localhost;Database=notify;Uid=root;Pwd='';");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter adtr;
        public MySqlDataReader dr;
        public DataSet ds;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //https://www.instagram.com/canasikk/
            db.Close();
            cmd = new MySqlCommand();
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "Update notifycation set status='" + 0 + "' where id=" + 1 + "";
            cmd.ExecuteNonQuery();
            db.Close();
            label1.Text = "";
           
            this.Close();
        }

       

        private void notification_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width,
                           Screen.PrimaryScreen.WorkingArea.Height - this.Height);
           
 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = a.ToString();
            if (a == 0)
            {
                timer1.Stop();
                db.Close();
                cmd = new MySqlCommand();
                db.Open();
                cmd.Connection = db;
                cmd.CommandText = "Update notifycation set status='" + 0 + "' where id=" + 1 + "";
                cmd.ExecuteNonQuery();
                db.Close();
                label1.Text = "";

                this.Close();
            }
            else {
                a--; 
 
            }
           
            
        }
    }
}
