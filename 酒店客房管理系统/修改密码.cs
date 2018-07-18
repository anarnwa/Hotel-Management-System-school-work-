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
    public partial class 修改密码 : Form
    {
        string id;
        string n;
        public 修改密码(string a ,string b)
        {
            InitializeComponent();
            id = a;
            n = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!="")
            {
                if(textBox2.Text==textBox3.Text)
                {
                    OleDbCommand cmd = 窗口.conn.CreateCommand();
                    cmd.CommandText = " select * from "+n+" where 工号='" + id+ "'and 密码='" + textBox1.Text + "'";
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        MessageBox.Show("密码错误");
                    }
                    else
                    {
                        string sql = "update "+n+" set 密码='" + textBox2.Text + "' where 工号='" +id+ "';";
                        OleDbCommand cm = new OleDbCommand(sql, 窗口.conn);
                        int res = cm.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("修改成功");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("修改失败");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("新密码与确认密码不匹配");
                }

            }
            else
            {
                MessageBox.Show("请填写空白处");
            }
        }

        private void 修改密码_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                button2_Click(null, null);
            }
        }
    }
}
