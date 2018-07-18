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
    public partial class 调整房间 : Form
    {
        string fang;
        public 调整房间()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fang != "")
            {
                string sqll = "select * from 房间 where 房号='" + textBox1.Text + "' and 姓名<>''";
                OleDbCommand cm = 窗口.conn.CreateCommand();
                cm.CommandText = sqll;
                OleDbDataReader rea = cm.ExecuteReader();
                if (!rea.Read())
                {
                    string sql = "update 房间 set 房间类型='" + fang + "' where 房号='" + textBox1.Text + "';";
                    OleDbCommand cmd = new OleDbCommand(sql, 窗口.conn);
                    int res = cmd.ExecuteNonQuery();
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
                else
                {
                    MessageBox.Show("当前房间有客人");
                }
            }
            else
            {
                MessageBox.Show("房号不存在！！");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbCommand sql1 = 窗口.conn.CreateCommand();
            sql1.CommandText = "select 房间类型 from 房间 where 房号='" + textBox1.Text + "';";
            OleDbDataReader rea = sql1.ExecuteReader();
            if (rea.Read())
            {
                if (rea.GetString(0) == "标准间")
                {
                    label1.Text = "当前房间类型为标准间\n是否修改为双人间？";
                    fang = "双人间";
                }
                else
                {
                    label1.Text = "当前房间类型为双人间\n是否修改为标准间？";
                    fang = "标准间";
                }
            }
            else
            {
                label1.Text = "房间不存在";
                fang = "";
            }
        }

        private void 调整房间_Load(object sender, EventArgs e)
        {
            label1.Text = "请输入房号";
        }

        private void 调整房间_KeyDown(object sender, KeyEventArgs e)
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
