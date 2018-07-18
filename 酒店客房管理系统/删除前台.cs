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
    public partial class 删除前台 : Form
    {
        public 删除前台()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbCommand cmd = 窗口.conn.CreateCommand();
                cmd.CommandText = " select * from 前台 where 工号='" + textBox1.Text + "'";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("工号错误");
                }
                else
                {
                    string sql = "delete from 前台 where 工号='" + textBox1.Text + "';";
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
                MessageBox.Show("请填写空白处");
            }
        }

        private void 删除前台_KeyDown(object sender, KeyEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
