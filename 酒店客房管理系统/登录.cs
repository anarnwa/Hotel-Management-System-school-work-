using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace 酒店客房管理系统
{
    public partial class 登录 : Form
    {
        public 登录()
        {
            InitializeComponent();
        }
        private void 登录_Load(object sender, EventArgs e)
        {
            窗口.conn.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\1.accdb";
            窗口.登录 = this;
            窗口.conn.Open();
            comboBox1.Text = "前台";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = 窗口.conn.CreateCommand();
            if (comboBox1.Text.ToString()== "前台")
                {             
                cmd.CommandText = " select * from 前台 where 工号='" + textBox1.Text.Trim() + "'and 密码='" + textBox2.Text.Trim() + "'";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) 
                   {
                    MessageBox.Show("用户名或密码错误");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                   {
                    前台 A = new 前台(textBox1.Text.Trim());
                    A.Show();
                    窗口.登录.Hide();
                    }
                }
            else
            {
                cmd.CommandText = " select 姓名 from 管理 where 工号='" + textBox1.Text.Trim() + "'and 密码='" + textBox2.Text.Trim() + "'";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("用户名或密码错误");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    管理 A = new 管理(textBox1.Text.Trim());
                    A.Show();
                    窗口.登录.Hide();
                }
            }
            textBox2.Text = "";
            this.textBox1.Focus();
         
        }

        private void 登录_FormClosed(object sender, FormClosedEventArgs e)
        {
            窗口.conn.Close();
        }

        private void 登录_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
            if (e.KeyCode==Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 )
            {
                if (comboBox1.Text == "前台")
                {
                    comboBox1.Text = "管理";
                }
                else
                {
                    comboBox1.Text = "前台";
                }
            }
        }
    }
}
