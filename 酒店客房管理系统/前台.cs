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
    public partial class 前台 : Form
    {
       public static  string A = "";
        private Timer Timer; 
        public 前台(string a)
        {
            A  = a;
            InitializeComponent();
        }
        private void 前台_Load(object sender, EventArgs e)
        {
            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Tick += new EventHandler(timer1_Tick);
            Timer.Start();
            label2.Text = A;
            this.label3.Text = DateTime.Now.ToString("HH:mm:ss");
            string sqlstr = "SELECT 房间类型,count(*) AS 数量 FROM 房间 WHERE 退房时间 <='"+ DateTime.Now.ToString("d")+"' or 退房时间 is NULL GROUP BY 房间类型;";
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlstr, 窗口.conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            if(dt.Rows.Count==1)
            {
                if (dt.Rows[0][0].ToString() == "双人间")
                {
                    label4.Text = "剩余标准间0       剩余双人间" + dt.Rows[0][1].ToString();
                }
                else
                {
                    label4.Text= "剩余标准间" + dt.Rows[0][1].ToString() + "         剩余双人间0" ;
                }
            }
            else if(dt.Rows.Count==2)
            {
                label4.Text = "剩余" +dt.Rows[0][0].ToString()+ dt.Rows[0][1].ToString() + "         剩余"+dt.Rows[1][0].ToString()+dt.Rows[1][1].ToString();
            }
            else
            {
                label4.Text = "剩余标准间0         剩余双人间0";
            }
        }

        private void 前台_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Visible==true )
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label3.Text = DateTime.Now.ToString("HH:mm:ss");
            string sqlstr = "SELECT 房间类型,count(*) AS 数量 FROM 房间 WHERE 退房时间 <='" + DateTime.Now.ToString("d") + "' or 退房时间 is NULL GROUP BY 房间类型;";
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlstr, 窗口.conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][0].ToString() == "双人间")
                {
                    label4.Text = "剩余标准间0       剩余双人间" + dt.Rows[0][1].ToString();
                }
                else
                {
                    label4.Text = "剩余标准间" + dt.Rows[0][1].ToString() + "         剩余双人间0";
                }
            }
            else if (dt.Rows.Count == 2)
            {
                label4.Text = "剩余" + dt.Rows[0][0].ToString() + dt.Rows[0][1].ToString() + "         剩余" + dt.Rows[1][0].ToString() + dt.Rows[1][1].ToString();
            }
            else
            {
                label4.Text = "剩余标准间0         剩余双人间0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            窗口.登录.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            开房 B  = new 开房( A );
            B.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            退房 退房 = new 退房( A );
            退房.Show();
        }

        private void 前台_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape )
            {
                button3_Click(null, null);
            }
            if(e.KeyCode == Keys.NumPad1)
            {
                button1_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                button2_Click(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            修改密码 修改密码 = new 修改密码(A, "前台");
            修改密码.Show();
        }
    }
}
