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
using MySql.Data;
using System.Net.NetworkInformation;
using System.Net;
namespace Notifications
{
    public partial class Form1 : Form
    {
        public MySqlConnection db = new MySqlConnection("Server=localhost;Database=notify;Uid=root;Pwd='';");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter adtr;
        public MySqlDataReader dr;
        public DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }
        void Login(String username, String userpass)
        {
            try
            {
                db.Close();
                db.Open();
                cmd = new MySqlCommand("Select *From users where username  ='" + username + "'", db);
                dr = cmd.ExecuteReader();
                if (username.Trim() != "" && userpass.Trim() != "")
                {
                    Ping ping = new Ping();
                    PingReply pingStatus = ping.Send(IPAddress.Parse("216.58.209.14"));
                    if (pingStatus.Status == IPStatus.Success)
                    {
                        if (dr.Read())
                        {
                            if (username.ToString() == dr["username"].ToString())
                            {
                                if (userpass.ToString() == dr["password"].ToString())
                                {
                                    String id = dr["id"].ToString();
                                    Properties.Settings.Default.uid = Convert.ToInt16(dr["id"]);
                                    Properties.Settings.Default.Save();

                                    db.Close();
                                    cmd = new MySqlCommand();
                                    db.Open();
                                    cmd.Connection = db;
                                    cmd.CommandText = "Update users set online='" + 1 + "' where id=" + id + "";
                                    cmd.ExecuteNonQuery();
                                    db.Close();
                                    Main frmHome = new Main();
                                    frmHome.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Şifreniz eksik veya hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    db.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adınız eksik veya hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                db.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Böyle kullanıcı bulunmamakta.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("İnternet bağlantınızı kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        db.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        //https://www.instagram.com/canasikk/
        private void button1_Click(object sender, EventArgs e)
        {
            Login(textBox1.Text, textBox2.Text);
        }
    }
}
