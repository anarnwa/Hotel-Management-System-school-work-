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
    public partial class 删除管理员 : Form
    {
        public 删除管理员()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" &&textBox2.Text!="")
            {
                if (textBox1.Text != 管理.A)
                {
                    MessageBox.Show("    ");
                    OleDbCommand cmd = 窗口.conn.CreateCommand();
                    cmd.CommandText = " select * from 管理 where 工号='" + textBox1.Text + "'and 密码='" + textBox2.Text + "'";
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        MessageBox.Show("用户名或密码错误");
                    }
                    else
                    {
                        string sql = "delete from 管理 where 工号='" + textBox1.Text + "' and 密码='" + textBox2.Text + "';";
                        OleDbCommand cmdd = new OleDbCommand(sql, 窗口.conn);
                        int res = cmdd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("删除成功");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("失败");
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("无法删除自身");
                }
            }
            else
            {
                MessageBox.Show("请填写空白处");
            }
        }

        private void 删除管理员_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button1_Click(null, null);
            }
            if (e.KeyCode==Keys.Escape)
            {
                button2_Click(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 删除管理员_Load(object sender, EventArgs e)
        {

        }
    }
}
