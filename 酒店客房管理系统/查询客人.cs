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
    public partial class 查询客人 : Form
    {
        public 查询客人()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = 窗口.conn.CreateCommand();
            if (textBox1.Text!=""&&textBox2.Text!="")
            {
                cmd.CommandText = " select * from 房间 where 姓名='" + textBox1.Text + "'and 身份证号='" + textBox2.Text + "'";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("无此住户");
                }
                else
                {
                    MessageBox.Show("此客户住于" + reader.GetString(0) + "号房");
                }
            }
            else
            {
                MessageBox.Show("请填写空白处");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 查询客人_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                button1_Click(null, null);
            }
            if (e.KeyCode==Keys.Escape)
            {
                button2_Click(null, null);
            }
        }
    }
}
