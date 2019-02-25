using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using k.libary;

namespace SupCustom
{
    public partial class frmSaveMasCt : frmSub
    {
        string strconn_bb;
        string strconn_bc;
        string strconn_bm;
        string sms;
        string stcode;
        string strBrand;
        string strType;
        string strSearch;

        bool combl;

        public frmSaveMasCt()
        {
            InitializeComponent();

            strconn_bb = "Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            strconn_bc = "Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            strconn_bm = "Data Source=5COSMEDA.HOMEUNIX.COM,1733;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            stcode = "6401";
        }

        private void frmSaveMasCt_Load(object sender, EventArgs e)
        {
           
            //string linqstr = Con
            Type_ComboBox.Items.Add("กรุณาเลือก...");
            Type_ComboBox.Items.Add("รหัสบัตรสมาชิก");
            Type_ComboBox.Items.Add("ชื่อลูกค้า");
            Type_ComboBox.Items.Add("เบอร์โทรศัพท์");
            Type_ComboBox.Items.Add("บัตรประชาชน");
            //comboBox1.Items.Add("เบอร์โทรศัพท์");

            SEX_comboBox.Items.Add("ชาย");
            SEX_comboBox.Items.Add("หญิง");

            cmdBrand.Items.Add(new { Text = "กรุณาเลือก", Value = "" });
            cmdBrand.Items.Add(new { Text = "BB", Value = "BB" });
            cmdBrand.Items.Add(new { Text = "BC", Value = "BC" });
            cmdBrand.Items.Add(new { Text = "BM", Value = "BM" });
            cmdBrand.DisplayMember = "Text";
            cmdBrand.ValueMember = "Value";

            lsvSearch.LabelWrap = true;
            // Add Columns   
            //lsvSearch.Columns.Add("ลำดับ", 50, HorizontalAlignment.Right);    
            lsvSearch.Columns.Add("รหัสบัตรสมาชิก", 70, HorizontalAlignment.Left);
            lsvSearch.Columns.Add("ไอดี", 100, HorizontalAlignment.Left);
            lsvSearch.Columns.Add("ชื่อสมาชิก", 150, HorizontalAlignment.Left);
            /****************************************************************************/
            //lsvSearch.Columns.Add("ไอดี", 120, HorizontalAlignment.Left);
            //lsvSearch.Columns.Add("อัพเดตล่าสุด", 130, HorizontalAlignment.Left);

            //SaveData.Enabled = false;
            //Cancel.Enabled = false;
           
            Type_ComboBox.SelectedIndex = 0;
            cmdBrand.SelectedIndex = 0;

            bgw.WorkerReportsProgress = true;
            CheckForIllegalCrossThreadCalls = false;



        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            clear_DATA();
            pb.Visible = true;
            strBrand = cmdBrand.Text;
            strType = Type_ComboBox.Text;
            strSearch = SearchText.Text;
            bgw.RunWorkerAsync();

        }

        private void clear_DATA()
        {
            lsvSearch.Items.Clear();

            TITLE.Text = " ";
            FULLNAME.Text = " ";
            ADDR_ROW1.Text = " ";
            ADDR_MOBILE.Text = " ";
            ADDR_ROW2.Text = " ";
            ADDR_PROVINCE.Text = " ";
            ADDR_EMAIL.Text = " ";
            PEOPLEID.Text = " ";
            CARDID.Text = " ";
            AGE.Text = " ";

            BIRTHDATE.Text = DateTime.Today.ToString();
            ENTRYDATE.Text = DateTime.Today.ToString();

            radVIP.Checked = false;
            radMem.Checked = false;

        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            combl = Seach_Data();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pb.Visible = false;
            if (combl)
            {
                MessageBox.Show("สำเร็จ");
            }
        }

        private bool Seach_Data()
        {
            bool bl = false;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet  ds = new DataSet();

            try
            {
                string brand;
                string sql="";
                //bool vbl = false;
                string strsearch = "";
                string strtype = "";

                if (strBrand == "กรุณาเลือก" || strBrand == "")
                {
                    MessageBox.Show("กรุณาเลือก แบรนด์");
                    bl = false;
                }
                else if (strType == "กรุณาเลือก..." || strType == "")
                {
                    MessageBox.Show("กรุณาเลือก ประเภท");
                    bl = false;
                }
                else if (SearchText.Text == "")
                {
                    MessageBox.Show("กรุณากรอกข้อมูล");
                    bl = false;

                }
                else
                {
                    //vbl = true;
                    brand = strBrand;
                    strsearch = strSearch;
                    strtype = strType;
                    string strconn = "";

                    if (strtype== "รหัสบัตรสมาชิก")
                    {
                        sql = "select cardid,ct_id,fullname from mv_ct_cd where cardid = '"+strsearch+"'";
                    }
                    else if (strtype == "ชื่อลูกค้า")
                    {
                        sql = "select cardid,ct_id,fullname from mv_ct_cd where fullname like '%" + strsearch + "%'";
                    }
                    else if (strtype == "เบอร์โทรศัพท์")
                    {
                        sql = "select cardid,ct_id,fullname from mv_ct_cd where addr_mobile = '" + strsearch + "'";
                    }
                    else if(strtype == "บัตรประชาชน")
                    {
                        sql = "select cardid,ct_id,fullname from mv_ct_cd where peopleid = '" + strsearch + "'";
                    }
                    

                    if(strBrand== "BB")
                    {
                        strconn = strconn_bb;
                    }
                    else if (strBrand == "BC")
                    {
                        strconn = strconn_bc;
                    }
                    else
                    {
                        strconn = strconn_bm;
                    }

                    ds = cData.getDataSetWithSqlCommand(strconn,sql,100000,true);


                    lsvSearch.addDataWithDataset(ds, false, false);

                    bl = true;
                }

 

               
            }
            catch(Exception ex)
            {
                sms = ex.Message;
                bl = false;
            }
           

            return bl;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            clear_DATA();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            if(SAVE_DATA())
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
            }
        }

        private bool SAVE_DATA()
        {
            string strconn = "";
            if (strBrand == "BB")
            {
                strconn = strconn_bb;
            }
            else if (strBrand == "BC")
            {
                strconn = strconn_bc;
            }
            else
            {
                strconn = strconn_bm;
            }

            bool bl = false;
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand comm = new SqlCommand();

            //GetSelectItems();
            DialogResult dialogResult = MessageBox.Show("คุณต้องการที่จะบันทึกหรือไม่", "Save", MessageBoxButtons.YesNo);
            DateTime thisDay = DateTime.Today;
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string new_sex;
                    string sql;

                    if (SEX_comboBox.Text == "ชาย")
                    {
                        new_sex = "M";
                    }
                    else 
                    {
                        new_sex = "F";
                    }
                   
                   sql = "UPDATE MAS_CT SET ";
                    sql += "TITLE = '" + TITLE.Text + "', ";
                    sql += "FULLNAME = '" + FULLNAME.Text + "', ";
                    sql += "ADDR_ROW1 = '" + ADDR_ROW1.Text + "', ";
                    sql += "ADDR_MOBILE = '" + ADDR_MOBILE.Text + "', ";
                    sql += "ADDR_ROW2 = '" + ADDR_ROW2.Text + "', ";
                    sql += "ADDR_PROVINCE = '" + ADDR_PROVINCE.Text + "', ";
                    sql += "ADDR_EMAIL = '" + ADDR_EMAIL.Text + "', ";
                    sql += "PEOPLEID = '" + PEOPLEID.Text + "', ";

                    if(BIRTHDATE.Value != DateTime.Now.Date)
                    {
                        sql += "BIRTHDATE = '" + BIRTHDATE.getDateOnlyForSql() + "', ";
                    }

                    sql += "AGE = '" + AGE.Text + "', ";
                    sql += "SEX = '" + new_sex + "', ";
                    sql += "UPDATEDT = getdate() ";
                    sql += "WHERE ID = '" + txtid.Text + "'; ";


                   sql += " UPDATE MAS_CT_CD SET UPDATEDT = getdate() WHERE CT_ID = '" + txtid.Text + "'; ";

                    sql += " INSERT INTO [dbbeautycommsupport]..log_mas_ct_sup (createdate,stcode,cardid,ct_id,remark) VALUES(getdate(),'"+stcode+"','" + CARDID.Text + "','" + txtid.Text + "','UPDATE DATA CT_ID : "+ txtid.Text + " CARDID : "+ CARDID.Text + "');";
                   
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    comm.Connection = conn;
                    comm.CommandTimeout = 100000;
                    comm.CommandText = sql;

                    comm.ExecuteNonQuery();
                    bl = true;
                }
                catch(Exception ex)
                {
                    bl = false;
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                
            }
            else 
            {
                bl = false;
            }
            return bl;
        }

        private void lsvSearch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               
               
                GetGoto(lsvSearch.SelectedItems[0].SubItems[1].Text);
                         

            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด\n" + ex.Message);
            }
        }

        private void GetGoto(string strctid)
        {
            //string strconn;
            //strconn = @"Data Source=" + _Sever + ";Initial Catalog=CMD-FX;Integrated Security=True";
            //strconn = @"Data Source=" + _Sever + ";Initial Catalog=CMD-FX;User ID=sa;Password=0000";

            string sql = @"SELECT b.ID,A.CARDID,B.TITLE,B.FULLNAME,B.ADDR_ROW1,B.ADDR_ROW2,ADDR_PROVINCE,B.ADDR_MOBILE,ADDR_EMAIL,B.PEOPLEID,BIRTHDATE,AGE,SEX,ENTRYDATE,
                            case when isnull(c.ct_id,'')= '' then 0 else 1 end vip
                             FROM MAS_CT_CD A LEFT JOIN MAS_CT B ON A.CT_ID = B.ID left join MAS_CT_CD_VP c on b.id = c.CT_ID WHERE A.CT_ID = '" + strctid + "'";

            string connect = "";
            if (strBrand == "BB")
            {
                connect = strconn_bb;
            }
            else if (strBrand == "BC")
            {
                connect = strconn_bc;
            }
            else
            {
                connect = strconn_bm;
            }

            //DsSelect.Tables[0].Select("CT_ID = '" + CT_ID + "'").CopyToDataTable();

            DataSet ds = k.libary.cData.getDataSetWithSqlCommand(connect, sql, 1000, true);

            if (ds.Tables[0].Rows.Count <= 0)
            {
                TITLE.Text = " ";
                FULLNAME.Text = " ";
                ADDR_ROW1.Text = " ";
                ADDR_MOBILE.Text = " ";
                ADDR_ROW2.Text = " ";
                ADDR_PROVINCE.Text = " ";
                ADDR_EMAIL.Text = " ";
                PEOPLEID.Text = " ";
                CARDID.Text = " ";
                AGE.Text = " ";
            }
            else
            {
                TITLE.Text = ds.Tables[0].Rows[0]["TITLE"].ToString();
                FULLNAME.Text = ds.Tables[0].Rows[0]["FULLNAME"].ToString();
                ADDR_ROW1.Text = ds.Tables[0].Rows[0]["ADDR_ROW1"].ToString();
                ADDR_MOBILE.Text = ds.Tables[0].Rows[0]["ADDR_MOBILE"].ToString();
                ADDR_ROW2.Text = ds.Tables[0].Rows[0]["ADDR_ROW2"].ToString();
                ADDR_PROVINCE.Text = ds.Tables[0].Rows[0]["ADDR_PROVINCE"].ToString();
                ADDR_EMAIL.Text = ds.Tables[0].Rows[0]["ADDR_EMAIL"].ToString();
                PEOPLEID.Text = ds.Tables[0].Rows[0]["PEOPLEID"].ToString();

                CARDID.Text = ds.Tables[0].Rows[0]["CARDID"].ToString();

                AGE.Text = ds.Tables[0].Rows[0]["AGE"].ToString();

                if (ds.Tables[0].Rows[0]["SEX"].ToString() == "M")
                {
                    SEX_comboBox.Text = "ชาย";
                }
                else if (ds.Tables[0].Rows[0]["SEX"].ToString() == "F")
                {
                    SEX_comboBox.Text = "หญิง";
                }
                BIRTHDATE.Text = ds.Tables[0].Rows[0]["BIRTHDATE"].ToString();
                ENTRYDATE.Text = ds.Tables[0].Rows[0]["ENTRYDATE"].ToString();
                txtid.Text = ds.Tables[0].Rows[0]["ID"].ToString();

                if (ds.Tables[0].Rows[0]["vip"].ToString()=="0")
                {
                    radMem.Checked= true;
                }
                else
                {
                    radVIP.Checked = true;
                }
            }


        }

        private void SearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                clear_DATA();
                pb.Visible = true;
                strBrand = cmdBrand.Text;
                strType = Type_ComboBox.Text;
                strSearch = SearchText.Text;
                bgw.RunWorkerAsync();
            }
        }
    }

}
