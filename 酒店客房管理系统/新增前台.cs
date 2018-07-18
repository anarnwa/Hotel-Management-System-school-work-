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
    public partial class 新增前台 : Form
    {
        public 新增前台()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                OleDbCommand sqlstr = 窗口.conn.CreateCommand();
                sqlstr.CommandText = " select * from 前台 where 工号='" + textBox1.Text + "'";
                OleDbDataReader reader = sqlstr.ExecuteReader();
                if (!reader.Read())
                {
                    string sql = "insert into 前台 values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "');";
                    OleDbCommand cmd = new OleDbCommand(sql, 窗口.conn);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("添加数据成功！");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
                else
                {
                    MessageBox.Show("用户已存在");
                }
            }
            else
            {
                MessageBox.Show("请填写空白处！");
            }
        }

        private void 新增前台_KeyDown(object sender, KeyEventArgs e)
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

        private void 新增前台_Load(object sender, EventArgs e)
        {

        }
    }
}
