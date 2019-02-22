using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using k.libary;


namespace SearchCustom
{

    public partial class frmPromotion : frmSub
        //public partial class frmPromotion : frmReportCondition
    {
        string strconn;
        TextBox txtbl;
        TextBox txtPro;
        TextBox txtID;
        bool hbd;
       

        public frmPromotion(string _strconn ,bool _hbd,ref TextBox _txtbl,ref TextBox _txtPro,ref TextBox _txtID)
        {
            InitializeComponent();

            strconn = _strconn;
            txtbl = _txtbl;
            txtPro = _txtPro;
            hbd = _hbd;
            txtID = _txtID;
        }

        private void frmPromotion_Load(object sender, EventArgs e)
        {
            
            
            string sql = "";
            DataSet ds = new DataSet();
            txtbl.Text = "false";
            try
            {
                if (hbd )
                {
                     sql = "select * from [dbbeautyCommsupport]..mas_promotion where cflag = '0' ";
                }
                else
                {
                    sql = " select * from [dbbeautyCommsupport]..mas_promotion where cflag = '0' and id <> '3' ";
                }

                ds.Clear();
                ds = cData.getDataSetWithSqlCommand(strconn, sql, 1000, true);

                cmbpro.DataSource = ds.Tables[0];
                cmbpro.DisplayMember = "prname";
                cmbpro.ValueMember = "id";

               
            }
            catch(Exception ex)
            {
                txtbl.Text = "false";
                MessageBox.Show(ex.Message);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                sql = "select * from [dbbeautyCommsupport]..mas_promotion where cflag = '0' and id = "+cmbpro.SelectedValue.ToString();
               

                ds.Clear();
                ds = cData.getDataSetWithSqlCommand(strconn, sql, 1000, true);

                txtbl.Text = "true";
                txtPro.Text = ds.Tables[0].Rows[0]["sqltext"].ToString();
                txtID.Text = ds.Tables[0].Rows[0]["id"].ToString();
                this.Close();

            }
            catch (Exception ex)
            {
                txtbl.Text = "false";
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtbl.Text = "false";
            this.Close();
        }
    }
}
