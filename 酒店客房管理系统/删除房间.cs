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
    public partial class 删除房间 : Form
    {
        public 删除房间()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbCommand cmd = 窗口.conn.CreateCommand();
                cmd.CommandText = " select * from 房间 where 房号='" + textBox1.Text + "'";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("房号错误");
                }
                else
                {
                    string sqll="select * from 房间 where 房号='" + textBox1.Text + "' and 姓名<>''";
                    OleDbCommand cm = 窗口.conn.CreateCommand();
                    cm.CommandText = sqll;
                    OleDbDataReader rea = cm.ExecuteReader();
                    if (!rea.Read())
                    {
                        string sql = "delete from 房间 where 房号='" + textBox1.Text + "';";
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
                    else
                    {
                        MessageBox.Show("当前房间有客人");
                    }
                }
            }
            else
            {
                MessageBox.Show("请填写空白处");
            }
        }
        private void 删除房间_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbCommand sql1 = 窗口.conn.CreateCommand();
            sql1.CommandText = "select 房间类型 from 房间 where 房号='" + textBox1.Text + "';";
            OleDbDataReader rea = sql1.ExecuteReader();
            if (rea.Read())
            {
                label2.Text = "当前房间为" + rea.GetString(0);
            }
            else
            {
                label2.Text = "房间不存在";
            }
        }
    }
}
