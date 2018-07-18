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
    public partial class 新增房间 : Form
    {
        public 新增房间()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbCommand sqlstr = 窗口.conn.CreateCommand();
                sqlstr.CommandText = " select * from 房间 where 房号='" + textBox1.Text + "'";
                OleDbDataReader reader = sqlstr.ExecuteReader();
                if (!reader.Read())
                {
                    string sql = "insert into 房间 (房号,房间类型,姓名) values ('" + textBox1.Text + "','" + comboBox1.Text + "','');";
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
                    MessageBox.Show("房间已存在");
                }
            }
            else
            {
                MessageBox.Show("请填写空白处！");
            }
        }

        private void 新增房间_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "标准间";
        }

        private void 新增房间_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
            {
                if (comboBox1.Text == "双人间")
                {
                    comboBox1.Text = "标准间";
                }
                else
                {
                    comboBox1.Text = "双人间";
                }
            }
        }
    }
}
