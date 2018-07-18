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
    public partial class 开房 : Form
    {
        string A;
        public 开房(string a)
        {
            InitializeComponent();
            A = a;
        }

        private void 开房_Load(object sender, EventArgs e)
        {
            label1.Text = "操作员：" + A;
            comboBox1.Text = "标准间";
        }
        private void button1_Click(object sender, EventArgs e)
        {         
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string day = DateTime.Now.AddDays(Convert.ToInt32(textBox3.Text)).ToString("yyyy/MM/dd");//   day 为退房时间
                OleDbCommand sqlstr = 窗口.conn.CreateCommand();
                sqlstr.CommandText = " select * from 房间 where 身份证号='" + textBox2.Text + "'";
                OleDbDataReader reader = sqlstr.ExecuteReader();
                if (!reader.Read())
                {
                    OleDbCommand sql1 = 窗口.conn.CreateCommand();
                    sql1.CommandText = "select 房号 from 房间 where 房间类型='"+comboBox1.Text+"' and 姓名='';";
                    OleDbDataReader rea = sql1.ExecuteReader();
                    if (!rea.Read())
                    {
                        MessageBox.Show("此类房已住满");
                    }
                    else
                    {                 
                        string fang = rea.GetString(0);
                        string sql = "update 房间 set 姓名='" + textBox1.Text + "', 操作员='" + A + "' , 退房时间='" + day + "' , 身份证号='" + textBox2.Text + "' where 房号='" + fang + "';";
                        OleDbCommand cmd = new OleDbCommand(sql, 窗口.conn);
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            MessageBox.Show("添加成功，房号为" + fang);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("添加失败");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("客户已入住");
                }  
            }
            else
            {
                MessageBox.Show("请填写空白处！");
            }  
        }

        private void 开房_KeyDown(object sender, KeyEventArgs e)
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
