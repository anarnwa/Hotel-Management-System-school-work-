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
    public partial class 房间 : Form
    {
        public 房间()
        {
            InitializeComponent();
        }

        private void 房间_Load(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("select 房号,房间类型 from 房间", 窗口.conn);//执行数据连接  
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];//数据源  
            this.dataGridView1.AutoGenerateColumns = false;//不自动  
        }

        private void 房间_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
