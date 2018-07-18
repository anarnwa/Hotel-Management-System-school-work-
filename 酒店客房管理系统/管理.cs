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
    public partial class 管理 : Form
    {
       public static  string A = "";
        public 管理(string a)
        {
            A = a;
            InitializeComponent();
        }

        private void 管理_Load(object sender, EventArgs e)
        {
        }
        private void 管理_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Visible == true)
            {
                Application.Exit();
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            窗口.登录.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            新增管理员 新增管理员 = new 新增管理员();
            新增管理员.Show();
        }

        private void 管理_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape )
            {
                button10_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                button1_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                button2_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                button3_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                button4_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                button5_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                button6_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                button7_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                button8_Click(null, null);
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                button9_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            新增前台 新增前台 = new 新增前台();
            新增前台.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            新增房间 新增房间 = new 新增房间();
            新增房间.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            删除房间 删除房间 = new 删除房间();
            删除房间.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            查询客人 查询客人 = new 查询客人();
            查询客人.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            删除管理员 删除管理员 = new 删除管理员();
            删除管理员.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            删除前台 删除前台 = new 删除前台();
            删除前台.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            调整房间 调整房间 = new 调整房间();
            调整房间.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            房间 房间 = new 房间();
            房间.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            修改密码 修改密码 = new 修改密码(A, "管理");
            修改密码.Show();
        }
    }
}
