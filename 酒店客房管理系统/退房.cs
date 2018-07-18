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
    public partial class 退房 : Form
    {
        string A;
        public 退房(string a)
        {
            InitializeComponent();
            A = a;
        }

        private void 退房_Load(object sender, EventArgs e)
        {
            label1.Text = A;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand sqlstr = 窗口.conn.CreateCommand();
            sqlstr.CommandText = " select * from 房间 where 身份证号='" + textBox1.Text + "'";
            OleDbDataReader reader = sqlstr.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("用户不存在");
            }
            else
            {
                string sql = "update 房间 set 姓名='', 操作员='' , 退房时间='' , 身份证号='' where 身份证号='" + textBox1.Text+ "';";
                OleDbCommand cmd = new OleDbCommand(sql, 窗口.conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("退房成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("失败");
                    this.Close();
                }
            }
        }

        private void 退房_KeyDown(object sender, KeyEventArgs e)
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
