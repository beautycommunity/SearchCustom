using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using k.libary;
using ThaiNationalIDCard;

using ค้นหาข้อมูลสมาชิกลืมพกบัตร;
using SearchCustom;

namespace Save_Log_CT
{
    public partial class Save_Log : frmSub 
    {
        public string IDCARD; 
        public string CTNAME;
        public string CT_ID;

        public string IDCARD_local; 
        public string CTNAME_local;
        public string CT_ID_local;

        public string Status;
        public string new_sex;
        public string _STCODE;
        public string _WHCODE;
        public string _Local_CMDFX;
        public string _Local_COMSUP;
        public string _Server_CMDFX;
        public string _Sever_COMSUP;
        public string _Sever_Point;
        //public string link_Server;
        //public string DNS;
        string Seach;
        string Type;
        string chkBrand;
        DataSet Table;
        DataSet TableMEM;
        //DataSet Table2;
        DataSet DsShop;
        DataSet DsServer;
        DataSet DsUnion;
        kListView _lsvSearch = new kListView();

        bool pr1000_500 = true;

        bool prHBD = false;
        bool prOnline = false;
        bool prVip = false;
        bool prOth = false;
        bool CHBD = false;

        TextBox txtbl = new TextBox();
        TextBox txtID = new TextBox();

        BackgroundWorker bgWorker = new BackgroundWorker();
        BackgroundWorker bgWorkermember = new BackgroundWorker();

        public bool closedOK = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        public Save_Log()
        {
            InitializeComponent();

            _STCODE = "8063";
            _WHCODE = "5093";

            //_Local_CMDFX = @"Data Source=fash2.DYNDNS.INFO,1401;Initial Catalog=CMD-FX;User ID=sa;Password=0000";
            //_Local_COMSUP = @"Data Source=fash2.DYNDNS.INFO,1401;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0000";

            //_Local_CMDFX = @"Data Source=(local)\sqlexpress;Initial Catalog=CMD-FX_old;User ID=sa;Password=0000";
            //_Local_COMSUP = @"Data Source=(local)\sqlexpress;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0000";

            _Local_CMDFX = @"Data Source=BCTPY.DYNDNS.INFO,1801;Initial Catalog=CMD-FX;User ID=sa;Password=0000";
            _Local_COMSUP = @"Data Source=BCTPY.DYNDNS.INFO,1801;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0000";
            //_Local_CMDFX = @"Data Source=.;Initial Catalog=CMD-FX;User ID=sa;Password=1Q2w3e4r@";
            //_Local_COMSUP = @"Data Source=.;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=1Q2w3e4r@";
            //_Sever_CMDFX = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //_Sever_COMSUP = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //string strconn = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=CMD-BX;User ID=sa;Password=0211";

            _Server_CMDFX = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            _Sever_COMSUP = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            _Sever_Point = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=dbBeautybuffetpoint;User ID=sa;Password=0211";
            //link_Server = "5COSMEDA.HOMEUNIX.COM,1433";
            //DNS = "[" + link_Server + "].[CMD-BX].dbo.";

            string SELECT_WH = @"select 
                                case when substring(whcode,1,1) = 1 then 'BB'
                                when substring(whcode,1,1) = 3 then 'BB'
                                when substring(whcode,1,1) = 5 then 'BC'
                                else 'BM' end as brand  
                                from mas_wh where id = (select wh_id from def_local)";

            //string SELECT_WH = @"select 
            //                    case when substring(whcode,1,1) = 1 then 'BB'
            //                    when substring(whcode,1,1) = 3 then 'BB'
            //                    when substring(whcode,1,1) = 5 then 'BC'
            //                    else 'BM' end as brand  
            //                    from mas_wh where id = 4";

            //MessageBox.Show(_Local_CMDFX);
            DataSet ds = k.libary.cData.getDataSetWithSqlCommand(_Local_CMDFX, SELECT_WH, 1000, true);

            string check = ds.Tables[0].Rows[0]["Brand"].ToString();
            //string check = "BB";
           
            //chkBrand = "BB";
            //chkBrand = "BC";
            //chkBrand = "BM";

            chkBrand = check;

            //if (check == "BB")
            //{
            //    //_Sever_CMDFX = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //    //_Sever_COMSUP = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //    //_Sever_Point = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=dbBeautybuffetpoint;User ID=sa;Password=0211";
            //    //DNS = "[5cosmeda.homeunix.com,1433].[CMD-BX].dbo.";
            //    DNS = _Sever_CMDFX.supstring(13, _Sever_CMDFX. )
            //}
            //else if (check == "BC")
            //{
            //    //_Sever_CMDFX = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //    //_Sever_COMSUP = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //    //_Sever_Point = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=dbBeautycottagepoint;User ID=sa;Password=0211";
            //    DNS = "[5cosmeda.homeunix.com,1833].[CMD-BX].dbo.";
            //}
            //else if (check == "BM")
            //{
            //    //_Sever_CMDFX = @"Data Source=5COSMEDA.HOMEUNIX.COM,1733;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //    //_Sever_COMSUP = @"Data Source=5COSMEDA.HOMEUNIX.COM,1733;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //    //_Sever_Point = @"Data Source=5COSMEDA.HOMEUNIX.COM,1733;Initial Catalog=dbBeautymarketpoint;User ID=sa;Password=0211";
            //    DNS = "[5cosmeda.homeunix.com,1733].[CMD-BX].dbo.";
            //}

            //_Sever_CMDFX = @"Data Source=192.168.1.10,1533;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //_Sever_COMSUP = @"Data Source=192.168.1.10,1533;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //_Sever_Point = @"Data Source=192.168.1.10,1533;Initial Catalog=dbBeautybuffetpoint;User ID=sa;Password=0211";
            //DNS = "[192.168.1.10,1533].[CMD-BX].dbo.";
        }

        public Save_Log(string STCODE,string WHCODE,string Local_CMD,string Local_COMSUP, string Sever_CMDFX, string Sever_COMSUP , string Sever_Point, string LinkSever)
        {
            InitializeComponent();

            _STCODE = STCODE;
            _WHCODE = WHCODE;
            _Local_CMDFX = Local_CMD;
            _Local_COMSUP = Local_COMSUP;
            _Server_CMDFX=Sever_CMDFX;
            _Sever_COMSUP = Sever_COMSUP;
            _Sever_Point = Sever_Point;
            //link_Server = LinkSever;
            //DNS = "[" + link_Server + "].[CMD-BX].dbo.";

            //string strconn = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //string strconn = @"Data Source=192.168.1.10,1533;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //string SELECT_WH = "WITH ANS AS( SELECT * FROM NV_MAS_WH UNION SELECT * FROM [192.168.1.24,1833].[CMD-BX].dbo.NV_MAS_WH UNION SELECT * FROM [192.168.1.53,1733].[CMD-BX].dbo.NV_MAS_WH) SELECT Brand FROM ANS WHERE WHCODE = '" + WHCODE + "'";

            string SELECT_WH = @"select 
                                case when substring(whcode,1,1) = 1 then 'BB'
                                when substring(whcode,1,1) = 3 then 'BB'
                                when substring(whcode,1,1) = 5 then 'BC'
                                else 'BM' end as brand  
                                from mas_wh where id = (select wh_id from def_local)";


            DataSet ds = k.libary.cData.getDataSetWithSqlCommand(_Local_CMDFX, SELECT_WH, 1000, true);

            string check = ds.Tables[0].Rows[0]["Brand"].ToString();
            chkBrand = check;



            //if (check == "BB")
            //{
            //    //_Sever_CMDFX = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //    //_Sever_COMSUP = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //    //_Sever_Point = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=dbBeautybuffetpoint;User ID=sa;Password=0211";
            //    DNS = "["+link_Server+"].[CMD-BX].dbo.";
            //}
            //else if (check == "BC")
            //{
            //    //_Sever_CMDFX = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //    //_Sever_COMSUP = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //    //_Sever_Point = @"Data Source=5COSMEDA.HOMEUNIX.COM,1833;Initial Catalog=dbBeautycottagepoint;User ID=sa;Password=0211";
            //    DNS = "[" + link_Server + "].[CMD-BX].dbo.";

            //}
            //else if (check == "BM")
            //{
            //    //_Sever_CMDFX = @"Data Source=5COSMEDA.HOMEUNIX.COM,1733;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //    //_Sever_COMSUP = @"Data Source=5COSMEDA.HOMEUNIX.COM,1733;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //    //_Sever_Point = @"Data Source=5COSMEDA.HOMEUNIX.COM,1733;Initial Catalog=dbBeautymarketpoint;User ID=sa;Password=0211";
            //    //DNS = "[" + link_Server + "].[CMD-BX].dbo.";
            //}

            //_Sever_CMDFX = @"Data Source=192.168.1.10,1533;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            //_Sever_COMSUP = @"Data Source=192.168.1.10,1533;Initial Catalog=dbBeautyCommSupport;User ID=sa;Password=0211";
            //_Sever_Point = @"Data Source=192.168.1.10,1533;Initial Catalog=dbBeautybuffetpoint;User ID=sa;Password=0211";

        }

        private void Save_Log_Load(object sender, EventArgs e)
        {
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);

            bgWorkermember.WorkerReportsProgress = true;
            bgWorkermember.WorkerSupportsCancellation = true;
            bgWorkermember.DoWork += new DoWorkEventHandler(bgWorkermember_DoWork);
            bgWorkermember.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bbgWorkermember_RunWorkerCompleted);
            bgWorkermember.ProgressChanged += new ProgressChangedEventHandler(bgWorkermember_ProgressChanged);

            //string linqstr = Con
            Type_ComboBox.Items.Add("กรุณาเลือก...");
            Type_ComboBox.Items.Add("รหัสบัตรสมาชิก");
            Type_ComboBox.Items.Add("ชื่อลูกค้า");
            Type_ComboBox.Items.Add("เบอร์โทรศัพท์");
            Type_ComboBox.Items.Add("บัตรประชาชน");
            //comboBox1.Items.Add("เบอร์โทรศัพท์");

            SEX_comboBox.Items.Add("ชาย");
            SEX_comboBox.Items.Add("หญิง");

            lsvSearch.LabelWrap = true;
            // Add Columns   
            //lsvSearch.Columns.Add("ลำดับ", 50, HorizontalAlignment.Right);    
            lsvSearch.Columns.Add("สถานะ", 70, HorizontalAlignment.Left);
            lsvSearch.Columns.Add("รหัสบัตรสมาชิก", 100, HorizontalAlignment.Left);
            lsvSearch.Columns.Add("ชื่อสมาชิก", 130, HorizontalAlignment.Left);
            /****************************************************************************/
            lsvSearch.Columns.Add("ไอดี", 120, HorizontalAlignment.Left);
            lsvSearch.Columns.Add("อัพเดตล่าสุด", 130, HorizontalAlignment.Left);

            SaveData.Enabled = false;
            Cancel.Enabled = false;
            SaveTo.Enabled = false;

            Type_ComboBox.SelectedIndex = 0;

    

            //string days = cDateTime.getDateTimeWithDayOnly();

//--------------------------------set radio promotion ---------------------------------------------
            int dd = Convert.ToInt32( cDateTime.getDateTimeWithDayOnly());
            int mm = Convert.ToInt32(cDateTime.getDateTimeWithMonthOnly());
            int yy = Convert.ToInt32(cDateTime.getDateTimeWithYearOnly());

            //if (mm >= 10)
            //{
            //    prHBD = true;
            //}

            if (dd >= 15 && mm == 11)
            {
               prOnline = true;
            }
            else
            {
                if ( mm == 12)
                {
                    prOnline = true;
                }


            }

            if (dd == 23 && mm== 10)
            {
                prOth = true;
            }
            // ---------------------------------------------------------------------
            if (chkBrand == "BB" )
            {
                //if (dd == 23 || dd == 24)
                //{
                    prOnline = true;

                //}
                //groupBox3.Visible = true;
                //setLabel(ref radOther, prOth);
                setLabel(ref radProV8, prOnline);

                
            }
            else if(chkBrand == "BM")
            {

                //groupBox3.Visible = true;
                setLabel(ref radProV8, prOnline);
            }
            else
            {
               
                //if (dd >= 18)
                //{
                //groupBox3.Visible = true;
                    setLabel(ref radProV8, prOnline);
                //}

            }
           // ---------------------------------------------------------------------
            if (chkBrand == "BC")
            {
                if(dd<16)
                {
                    radProV8.Text = "Online ซื้อ 1000 จ่าย 700";
                    radProV8.Enabled = false;
                }
                else
                {
                    radProV8.Text = "Online ซื้อ 1000 จ่าย 700";
                }
                
            }
            else if (chkBrand == "BM")
            {
                
                    radProV8.Enabled = false;

            }
            else
            {
               
                radProV8.Text = "ชั่วโมงทองชั่วโมงถูก 17:00 -20:00";
            }

            getProV8();
            setlabel();

        }

        private void setLabel(ref RadioButton radHBD, bool prHBD)
        {
            

            if (prHBD)
            {

                radHBD.Enabled = true;
            }
            else
            {
                radHBD.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Procss_Run();
        }

        private void Procss_Run()
        {
            clear_DATA();
            button_Select.Enabled = false;
            Seach = SeachText.Text;
            Type = Type_ComboBox.Text;
            pb.Visible = true;
            bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do Work
            Seach_Data();
        }

        // This event handler updates the progress.
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update Progress Status to UI
        }

        // This event handler deals with the results of the background operation.
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Finish
            pb.Visible = false;
            try
            {
                lsvSearch.addDataWithDataset(Table, false, false);

                button_Select.Enabled = true;
            }
            catch
            {
                button_Select.Enabled = true;
            }

        }

        private void bgWorkermember_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do Work
            GetMembersum();
        }

        private void bgWorkermember_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update Progress Status to UI
        }

        // This event handler deals with the results of the background operation.
        private void bbgWorkermember_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Finish
            pictureBox1.Visible = false;
            try
            {
                listViewMember.Items.Clear();
                //listViewMember.addDataWithDataset(Table, false, false);
                for (int i = 0; i <= TableMEM.Tables["tbl"].Rows.Count - 1; i++)
                {
                    ListViewItem lst = new ListViewItem();
                    lst = listViewMember.Items.Add(TableMEM.Tables["tbl"].Rows[i]["CARDID"].ToString());
                    lst.SubItems.Add(DateTime.Parse(TableMEM.Tables["tbl"].Rows[i]["S_COUNT"].ToString()).ToString("dd/MM/yyyy"));
                    lst.SubItems.Add(DateTime.Parse(TableMEM.Tables["tbl"].Rows[i]["E_COUNT"].ToString()).ToString("dd/MM/yyyy"));
                    lst.SubItems.Add(DateTime.Parse(TableMEM.Tables["tbl"].Rows[i]["UPDATEDT"].ToString()).ToString("dd/MM/yyyy"));
                    lst.SubItems.Add(TableMEM.Tables["tbl"].Rows[i]["LOST"].ToString());
                    lst.SubItems.Add(TableMEM.Tables["tbl"].Rows[i]["NET"].ToString());
                    //lst.SubItems.Add(ds.Tables["tbl"].Rows[i]["MEMBERTYPE"].ToString());
                    lst.SubItems.Add(TableMEM.Tables["tbl"].Rows[i]["MEMBERNAME"].ToString());
                    lst.SubItems.Add(TableMEM.Tables["tbl"].Rows[i]["UPLEVEL"].ToString());
                    lst.SubItems.Add(TableMEM.Tables["tbl"].Rows[i]["DOWNLEVEL"].ToString());
                }
                listViewMember.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewMember.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewMember.FullRowSelect = true;
                button_Select.Enabled = true;
            }
            catch
            {
                button_Select.Enabled = true;
            }

        }

        private void Seach_Data()
        {
            try
            {
                //string Seach = SeachText.Text;
                //string Type = Type_ComboBox.Text;
                DateTime thisDay = DateTime.Today;

                if (Seach == "")
                {
                    MessageBox.Show("กรุณากรอกข้อมูล");
                    SeachText.Focus();
                    lsvSearch.Items.Clear();

                }
                else if (Type == "" || Type == "กรุณาเลือก..." )
                {
                    MessageBox.Show("กรุณาเลือกการค้นหา");
                    Type_ComboBox.Focus();
                    lsvSearch.Items.Clear();
                }
                else
                {
                    //lsvSearch_local.Items.Clear();
                    lsvSearch.Items.Clear();

                    //using (cWaitIndicator cw = new cWaitIndicator())
                    //{
                        //Thread.Sleep(50);

                        string sql = "";
                        string sql_local = "";
                        try
                        {
                            if (Type == "รหัสบัตรสมาชิก")
                            {
                                //sql_local = @"SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.ADDR_MOBILE,A.PEOPLEID 
                                //,A.TITLE, A.ADDR_ROW1, A.ADDR_ROW2, ADDR_PROVINCE, ADDR_EMAIL, BIRTHDATE, AGE, SEX, ENTRYDATE 
                                //FROM MAS_CT A (NOLOCK)      
                                //LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE CARDID = '" + Seach + @"' 
                                //AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') ORDER BY B.CARDID";

                                //sql = @"SELECT 'สำนักงาน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.ADDR_MOBILE,A.PEOPLEID 
                                //,A.TITLE, A.ADDR_ROW1, A.ADDR_ROW2, ADDR_PROVINCE, ADDR_EMAIL, BIRTHDATE, AGE, SEX, ENTRYDATE  
                                //FROM MAS_CT A (NOLOCK) 
                                //LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE CARDID = '" + Seach + @"' 
                                //AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') ORDER BY B.CARDID";

                                //--------------------- new ------------------------------

                                sql_local = @"SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.CT_STATUS
                                            FROM MAS_CT A (NOLOCK)      
                                            LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE CARDID = '" + Seach + @"' 
                                            AND B.CT_ID IS NOT NULL AND a.CT_STATUS = 'A' ORDER BY B.CARDID";

                                sql = @"SELECT 'สำนักงาน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.CT_STATUS
                                        FROM MAS_CT A (NOLOCK) 
                                        LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE CARDID = '" + Seach + @"' 
                                        AND B.CT_ID IS NOT NULL  ORDER BY B.CARDID";

                                //--------------------- new ------------------------------

                                DsShop = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql_local, 1000, true);
                                DsServer = cData.getDataSetWithSqlCommand(_Server_CMDFX, sql, 1000, true);

                                DataTable dt = DsShop.Tables[0];
                                DataTable dt2 = DsServer.Tables[0];



                            if (dt.Rows.Count == 0)
                            {
                                IEnumerable<DataRow> query = (from qq in dt2.AsEnumerable()
                                                              select qq);

                                DataTable boundTable = query.CopyToDataTable<DataRow>();
                                boundTable.TableName = "Ans";
                                DataSet Ans = new DataSet();
                                Ans.Tables.Add(boundTable);
                                Table = Ans;
                            }
                            else
                            {


                                //string sql_Union = @"SELECT Status,CARDID,FULLNAME,ID,MAX(UPDATEDT) AS UPDATEDT FROM (
                                //                    SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                //                    FROM MAS_CT A (NOLOCK)      
                                //                    LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE CARDID = '" + Seach + @"' 
                                //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') 
                                //                    UNION
                                //                    SELECT 'สำนักงาน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                //                    FROM " + DNS + @"MAS_CT A (NOLOCK) 
                                //                    LEFT JOIN " + DNS + @"MAS_CT_CD B ON B.CT_ID = A.ID WHERE CARDID = '" + Seach + @"'    
                                //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') 
                                //                    AND ID NOT IN (SELECT ID
                                //                    FROM MAS_CT A (NOLOCK)      
                                //                    LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE CARDID = '" + Seach + @"'  
                                //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') ) 
                                //                    ) A
                                //                    GROUP BY Status,CARDID,FULLNAME,ID
                                //                    ORDER BY Status DESC";

                                string sql_Union = @"SELECT Status,CARDID,FULLNAME,ID,MAX(UPDATEDT) AS UPDATEDT FROM (
                                                            SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                                            FROM MAS_CT A (NOLOCK)      
                                                            LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE CARDID = '" + Seach + @"' 
                                                            AND B.CT_ID IS NOT NULL AND a.CT_STATUS = 'A' 
                                                            ) A
                                                            GROUP BY Status,CARDID,FULLNAME,ID
                                                            ORDER BY Status DESC";

                                DsUnion = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql_Union, 1500, true);
                                DataTable dn = DsUnion.Tables[0];
                                IEnumerable<DataRow> query = (from qq in dn.AsEnumerable() select qq);

                                DataTable boundTable = query.CopyToDataTable<DataRow>();
                                boundTable.TableName = "Ans";
                                DataSet Ans = new DataSet();
                                Ans.Tables.Add(boundTable);
                                Table = Ans;
                            }

                            SqlConnection sqlConnection1 = new SqlConnection(_Sever_COMSUP);

                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "INSERT INTO LOG_CT (TYPE,LOG_DATA,SEARCH,WORKDATE,STCODE,WHCODE,FLAG) VALUES('1','SELECT FROM CARDID','" + Seach + "','" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "','" + _STCODE + "','" + _WHCODE + "','0')";
                                cmd.Connection = sqlConnection1;

                                sqlConnection1.Open();
                                cmd.ExecuteNonQuery();
                                sqlConnection1.Close();

                            }
                            else if (Type == "ชื่อลูกค้า")
                            {
                                
                                sql_local = @"SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.CT_STATUS
                                            FROM MAS_CT A (NOLOCK)      
                                            LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE FULLNAME LIKE '%" + Seach + @"%'
                                            AND B.CT_ID IS NOT NULL AND a.CT_STATUS = 'A' ORDER BY B.CARDID";

                                sql = @"SELECT 'สำนักงาน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.CT_STATUS
                                        FROM MAS_CT A (NOLOCK) 
                                        LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE FULLNAME LIKE '%" + Seach + @"%' 
                                        AND B.CT_ID IS NOT NULL   ORDER BY B.CARDID";

                                DsShop = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql_local, 1000, true);
                                DsServer = cData.getDataSetWithSqlCommand(_Server_CMDFX, sql, 1000, true);

                                DataTable dt = DsShop.Tables[0];
                                DataTable dt2 = DsServer.Tables[0];

                                if (dt.Rows.Count == 0)
                                {
                                    IEnumerable<DataRow> query = (from qq in dt2.AsEnumerable()
                                                                  select qq);

                                    DataTable boundTable = query.CopyToDataTable<DataRow>();
                                    boundTable.TableName = "Ans";
                                    DataSet Ans = new DataSet();
                                    Ans.Tables.Add(boundTable);
                                    Table = Ans;

                                }
                                else
                                {

                                    //string sql_Union = @"SELECT Status,CARDID,FULLNAME,ID,MAX(UPDATEDT) AS UPDATEDT FROM (
                                    //                    SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                    //                    FROM MAS_CT A (NOLOCK)      
                                    //                    LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE FULLNAME LIKE '%" + Seach + @"%'
                                    //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') 
                                    //                    UNION
                                    //                    SELECT 'สำนักงาน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                    //                    FROM " + DNS + @"MAS_CT A (NOLOCK) 
                                    //                    LEFT JOIN " + DNS + @"MAS_CT_CD B ON B.CT_ID = A.ID WHERE FULLNAME LIKE '%" + Seach + @"%' 
                                    //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') 
                                    //                    AND ID NOT IN (SELECT ID
                                    //                    FROM MAS_CT A (NOLOCK)      
                                    //                    LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE FULLNAME LIKE '%" + Seach + @"%' 
                                    //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') ) 
                                    //                    ) A
                                    //                    GROUP BY Status,CARDID,FULLNAME,ID
                                    //                    ORDER BY Status DESC";

                                string sql_Union = @"SELECT Status,CARDID,FULLNAME,ID,MAX(UPDATEDT) AS UPDATEDT FROM (
                                                        SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                                        FROM MAS_CT A (NOLOCK)      
                                                        LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE FULLNAME LIKE '%" + Seach + @"%'
                                                        AND B.CT_ID IS NOT NULL AND a.CT_STATUS = 'A' 
                                                        ) A
                                                        GROUP BY Status,CARDID,FULLNAME,ID
                                                        ORDER BY Status DESC";

                                DsUnion = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql_Union, 1500, true);
                                    DataTable dn = DsUnion.Tables[0];
                                    IEnumerable<DataRow> query = (from qq in dn.AsEnumerable() select qq);

                                    DataTable boundTable = query.CopyToDataTable<DataRow>();
                                    boundTable.TableName = "Ans";
                                    DataSet Ans = new DataSet();
                                    Ans.Tables.Add(boundTable);
                                    Table = Ans;
                                }

                                SqlConnection sqlConnection1 = new SqlConnection(_Sever_COMSUP);

                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "INSERT INTO LOG_CT (TYPE,LOG_DATA,SEARCH,WORKDATE,STCODE,WHCODE,FLAG) VALUES('1','SELECT FROM CARDID','" + Seach + "','" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "','" + _STCODE + "','" + _WHCODE + "','0')";
                                cmd.Connection = sqlConnection1;

                                sqlConnection1.Open();
                                cmd.ExecuteNonQuery();
                                sqlConnection1.Close();
                            }
                            else if (Type == "เบอร์โทรศัพท์")
                            {
                               

                                sql_local = @"SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.CT_STATUS
                                            FROM MAS_CT A (NOLOCK)      
                                            LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE A.ADDR_MOBILE = '" + Seach + @"' 
                                            AND B.CT_ID IS NOT NULL AND a.CT_STATUS = 'A' ORDER BY B.CARDID";

                                sql = @"SELECT 'สำนักงาน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.CT_STATUS
                                        FROM MAS_CT A (NOLOCK) 
                                        LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE A.ADDR_MOBILE = '" + Seach + @"' 
                                        AND B.CT_ID IS NOT NULL   ORDER BY B.CARDID";

                                DsShop = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql_local, 1000, true);
                                DsServer = cData.getDataSetWithSqlCommand(_Server_CMDFX, sql, 1000, true);

                                DataTable dt = DsShop.Tables[0];
                                DataTable dt2 = DsServer.Tables[0];

                                if (dt.Rows.Count == 0)
                                {
                                    IEnumerable<DataRow> query = (from qq in dt2.AsEnumerable()
                                                                  select qq);

                                    DataTable boundTable = query.CopyToDataTable<DataRow>();
                                    boundTable.TableName = "Ans";
                                    DataSet Ans = new DataSet();
                                    Ans.Tables.Add(boundTable);
                                    Table = Ans;
                                }
                                else
                                {
                                    //string sql_Union = @"SELECT Status,CARDID,FULLNAME,ID,MAX(UPDATEDT) AS UPDATEDT FROM (
                                    //                    SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                    //                    FROM MAS_CT A (NOLOCK)      
                                    //                    LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE A.ADDR_MOBILE = '" + Seach + @"' 
                                    //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') 
                                    //                    UNION
                                    //                    SELECT 'สำนักงาน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                    //                    FROM " + DNS + @"MAS_CT A (NOLOCK) 
                                    //                    LEFT JOIN " + DNS + @"MAS_CT_CD B ON B.CT_ID = A.ID WHERE A.ADDR_MOBILE = '" + Seach + @"' 
                                    //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') 
                                    //                    AND ID NOT IN (SELECT ID
                                    //                    FROM MAS_CT A (NOLOCK)      
                                    //                    LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE A.ADDR_MOBILE = '" + Seach + @"'  
                                    //                    AND B.CT_ID IS NOT NULL AND (A.FLAGS IS NULL OR A.FLAGS = '0') ) 
                                    //                    ) A
                                    //                    GROUP BY Status,CARDID,FULLNAME,ID
                                    //                    ORDER BY Status DESC";
                                string sql_Union = @"SELECT Status,CARDID,FULLNAME,ID,MAX(UPDATEDT) AS UPDATEDT FROM (
                                                        SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                                        FROM MAS_CT A (NOLOCK)      
                                                        LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE A.ADDR_MOBILE = '" + Seach + @"' 
                                                        AND B.CT_ID IS NOT NULL AND a.CT_STATUS = 'A' 
                                                        ) A
                                                        GROUP BY Status,CARDID,FULLNAME,ID
                                                        ORDER BY Status DESC";

                                DsUnion = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql_Union, 1500, true);
                                    DataTable dn = DsUnion.Tables[0];
                                    IEnumerable<DataRow> query = (from qq in dn.AsEnumerable() select qq);

                                    DataTable boundTable = query.CopyToDataTable<DataRow>();
                                    boundTable.TableName = "Ans";
                                    DataSet Ans = new DataSet();
                                    Ans.Tables.Add(boundTable);
                                    Table = Ans;
                                }
                                SqlConnection sqlConnection1 = new SqlConnection(_Sever_COMSUP);
                                
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "INSERT INTO LOG_CT (TYPE,LOG_DATA,SEARCH,WORKDATE,STCODE,WHCODE,FLAG) VALUES('1','SELECT FROM MOBILE','" + Seach + "','" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "','" + _STCODE + "','" + _WHCODE + "','0')";
                                cmd.Connection = sqlConnection1;

                                sqlConnection1.Open();
                                cmd.ExecuteNonQuery();
                                sqlConnection1.Close();

                            }
                            else if (Type == "บัตรประชาชน")
                            {
                        
                                sql_local = @"SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.CT_STATUS
                                            FROM MAS_CT A (NOLOCK)      
                                            LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE A.PEOPLEID = '" + Seach + @"' 
                                            AND B.CT_ID IS NOT NULL AND a.CT_STATUS = 'A' ORDER BY B.CARDID";

                                sql = @"SELECT 'สำนักงาน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT,A.CT_STATUS
                                        FROM MAS_CT A (NOLOCK) 
                                        LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE A.PEOPLEID = '" + Seach + @"'
                                        AND B.CT_ID IS NOT NULL   ORDER BY B.CARDID";

                                DsShop = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql_local, 1000, true);
                                DsServer = cData.getDataSetWithSqlCommand(_Server_CMDFX, sql, 1000, true);
                            DataTable dt = DsShop.Tables[0];
                                DataTable dt2 = DsServer.Tables[0];

                                if (dt.Rows.Count == 0)
                                {
                                    IEnumerable<DataRow> query = (from qq in dt2.AsEnumerable()
                                                                  select qq);

                                    DataTable boundTable = query.CopyToDataTable<DataRow>();
                                    boundTable.TableName = "Ans";
                                    DataSet Ans = new DataSet();
                                    Ans.Tables.Add(boundTable);
                                    Table = Ans;
                                }
                                else
                                {
                               
                                    string sql_Union = @"SELECT Status,CARDID,FULLNAME,ID,MAX(UPDATEDT) AS UPDATEDT FROM (
                                                        SELECT 'หน้าร้าน' AS Status,B.CARDID,A.FULLNAME,A.ID,A.UPDATEDT
                                                        FROM MAS_CT A (NOLOCK)      
                                                        LEFT JOIN MAS_CT_CD (NOLOCK) B ON B.CT_ID = A.ID WHERE A.PEOPLEID = '" + Seach + @"' 
                                                        AND B.CT_ID IS NOT NULL AND a.CT_STATUS = 'A'
                                                        ) A
                                                        GROUP BY Status,CARDID,FULLNAME,ID
                                                        ORDER BY Status DESC";

                                    DsUnion = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql_Union, 1500, true);
                                    DataTable dn = DsUnion.Tables[0];
                                    IEnumerable<DataRow> query = (from qq in dn.AsEnumerable() select qq);

                                    DataTable boundTable = query.CopyToDataTable<DataRow>();
                                    boundTable.TableName = "Ans";
                                    DataSet Ans = new DataSet();
                                    Ans.Tables.Add(boundTable);
                                    Table = Ans;
                                }
                                SqlConnection sqlConnection1 = new SqlConnection(_Sever_COMSUP);

                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "INSERT INTO LOG_CT (TYPE,LOG_DATA,SEARCH,WORKDATE,STCODE,WHCODE,FLAG) VALUES('1','SELECT FROM PROPLEID','" + Seach + "','" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "','" + _STCODE + "','" + _WHCODE + "','0')";
                                cmd.Connection = sqlConnection1;

                                sqlConnection1.Open();
                                cmd.ExecuteNonQuery();
                                sqlConnection1.Close();

                            }
                            else
                            {
                                MessageBox.Show("กรุณาเลือกประเภท");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("ไม่พบข้อมูล");
                            lsvSearch.Items.Clear();
                        }
                   // }
                }

                if (Table.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("ไม่พบข้อมูล");
                    lsvSearch.Items.Clear();
                }


                return;
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                lsvSearch.Items.Clear();
            }
        }

        static void CompareRows(DataTable table1, DataTable table2)
        {
            foreach (DataRow row1 in table1.Rows)
            {
                foreach (DataRow row2 in table2.Rows)
                {
                    var array1 = row1.ItemArray;
                    var array2 = row2.ItemArray;

                    if (array1.SequenceEqual(array2))
                    {
                        Console.WriteLine("Equal: {0} {1}",
                            row1["Drug"], row2["Drug"]);
                    }
                    else
                    {
                        Console.WriteLine("Not equal: {0} {1}",
                            row1["Drug"], row2["Drug"]);
                    }
                }
            }
        }

        private void GetGoto()
        {
            
            string sql = "SELECT A.CARDID,B.TITLE,B.FULLNAME,B.ADDR_ROW1,B.ADDR_ROW2,ADDR_PROVINCE,B.ADDR_MOBILE,ADDR_EMAIL,B.PEOPLEID,BIRTHDATE,AGE,SEX,ENTRYDATE,A.CARDLV,B.CT_STATUS FROM MAS_CT_CD A LEFT JOIN MAS_CT B ON A.CT_ID = B.ID WHERE A.CT_ID = '" + CT_ID + "'";

            string connect = "";
            if (Status == "สำนักงาน")
            {
                connect = _Server_CMDFX;
                //DsSelect = DsServer;
            }
            else if (Status == "หน้าร้าน")
            {
                connect = _Local_CMDFX;
                //DsSelect = DsShop;
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
                txtCardLV.Text = " ";
                textStatus.Text = " ";
            }

            //cMessage.ErrorNoData();

            TITLE.Text = ds.Tables[0].Rows[0]["TITLE"].ToString();
            FULLNAME.Text = ds.Tables[0].Rows[0]["FULLNAME"].ToString();
            ADDR_ROW1.Text = ds.Tables[0].Rows[0]["ADDR_ROW1"].ToString();
            ADDR_MOBILE.Text = ds.Tables[0].Rows[0]["ADDR_MOBILE"].ToString();
            ADDR_ROW2.Text = ds.Tables[0].Rows[0]["ADDR_ROW2"].ToString();
            ADDR_PROVINCE.Text = ds.Tables[0].Rows[0]["ADDR_PROVINCE"].ToString();
            ADDR_EMAIL.Text = ds.Tables[0].Rows[0]["ADDR_EMAIL"].ToString();
            PEOPLEID.Text = ds.Tables[0].Rows[0]["PEOPLEID"].ToString();
            string cardlvtext = ds.Tables[0].Rows[0]["CARDLV"].ToString();
            if (cardlvtext == "101" || cardlvtext == "501" || cardlvtext == "701")
            {
                if (cardlvtext == "101") txtCardLV.Text = "Pink Member";
                else if (cardlvtext == "501") txtCardLV.Text = "Silver Member";
                else txtCardLV.Text = "ไม่มีระดับสมาชิก";
            }
            else if (cardlvtext == "102" || cardlvtext == "502" || cardlvtext == "702")
            {
                if (cardlvtext == "102") txtCardLV.Text = "Rosegold Member";
                else if (cardlvtext == "502") txtCardLV.Text = "Gold Member";
                else txtCardLV.Text = "ไม่มีระดับสมาชิก";
            }
            else txtCardLV.Text = "ไม่มีระดับสมาชิก";

            string stmember = ds.Tables[0].Rows[0]["CT_STATUS"].ToString();
            if (stmember == "A")
            {
                textStatus.Text = "ใช้งาน";
            }
            else if (stmember == "N")
            {
                textStatus.Text = "ยกเลิก";
            }  
            CARDID.Text = ds.Tables[0].Rows[0]["CARDID"].ToString();
            CARDID.ReadOnly = true;
            AGE.Text = ds.Tables[0].Rows[0]["AGE"].ToString();
            AGE.ReadOnly = true;
            if (ds.Tables[0].Rows[0]["SEX"].ToString() == "M")
            {
                SEX_comboBox.Text = "ชาย";
            }
            else if(ds.Tables[0].Rows[0]["SEX"].ToString() == "F")
            {
                SEX_comboBox.Text = "หญิง";
            }
            BIRTHDATE.Text = ds.Tables[0].Rows[0]["BIRTHDATE"].ToString();
           
            BIRTHDATE.Enabled = false;
            ENTRYDATE.Text = ds.Tables[0].Rows[0]["ENTRYDATE"].ToString();
            ENTRYDATE.Enabled = false;

        }

        private void GetSelectItems()
        {
            try
            {
                IDCARD = lsvSearch.SelectedItems[0].SubItems[1].Text.ToString();
                CTNAME = lsvSearch.SelectedItems[0].SubItems[2].Text.ToString();
                CT_ID = lsvSearch.SelectedItems[0].SubItems[3].Text.ToString();
                Status = lsvSearch.SelectedItems[0].SubItems[0].Text.ToString();

                closedOK = true;
            }
            catch
            {
                closedOK = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    Procss_Run();
                    break;
                default:
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SAVE_DATA();           
        }

        private void SAVE_DATA()
        {
            //GetSelectItems();
            DialogResult dialogResult = MessageBox.Show("คุณต้องการที่จะบันทึกหรือไม่", "Save", MessageBoxButtons.YesNo);
            DateTime thisDay = DateTime.Today;
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string connect = "";
                    //string CT = "";
                    //string CARD = "";
                    if (Status == "สำนักงาน")
                    {
                        connect = _Server_CMDFX;
                        //CT = CT_ID;
                        //CARD = IDCARD;
                    }
                    else if (Status == "หน้าร้าน")
                    {
                        connect = _Local_CMDFX;
                    }

                    SqlConnection sqlConnection1 = new SqlConnection(connect);
                    SqlConnection sqlConnection2 = new SqlConnection(_Sever_COMSUP);


                    if (SEX_comboBox.Text == "ชาย")
                    {
                        new_sex = "M";
                    }
                    else if (SEX_comboBox.Text == "หญิง")
                    {
                        new_sex = "F";
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE MAS_CT SET ";
                    cmd.CommandText += "TITLE = '" + TITLE.Text + "', ";
                    cmd.CommandText += "FULLNAME = '" + FULLNAME.Text + "', ";
                    cmd.CommandText += "ADDR_ROW1 = '" + ADDR_ROW1.Text + "', ";
                    cmd.CommandText += "ADDR_MOBILE = '" + ADDR_MOBILE.Text + "', ";
                    cmd.CommandText += "ADDR_ROW2 = '" + ADDR_ROW2.Text + "', ";
                    cmd.CommandText += "ADDR_PROVINCE = '" + ADDR_PROVINCE.Text + "', ";
                    cmd.CommandText += "ADDR_EMAIL = '" + ADDR_EMAIL.Text + "', ";
                    cmd.CommandText += "PEOPLEID = '" + PEOPLEID.Text + "', ";
                    cmd.CommandText += "AGE = '" + AGE.Text + "', ";
                    cmd.CommandText += "SEX = '" + new_sex + "', ";
                    cmd.CommandText += "UPDATEDT = getdate() ";
                    //cmd.CommandText += "UPDATEDT = '" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "' ";
                    cmd.CommandText += "WHERE ID = '" + CT_ID + "'";
                    cmd.Connection = sqlConnection1;

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.Text;
                    //cmd3.CommandText = "UPDATE MAS_CT_CD SET UPDATEDT = '" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "' ";
                    cmd3.CommandText = "UPDATE MAS_CT_CD SET UPDATEDT = getdate() ";
                    cmd3.CommandText += "WHERE CT_ID = '" + CT_ID + "'";
                    cmd3.Connection = sqlConnection1;

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO LOG_CT (TYPE,LOG_DATA,CARD_ID,CT_ID,WORKDATE,STCODE,WHCODE,FLAG) VALUES('2','UPDATE DATA','" + IDCARD + "','" + CT_ID + "','" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "','" + _STCODE + "','" + _WHCODE + "','0')";
                    cmd2.Connection = sqlConnection2;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    sqlConnection1.Close();
                    sqlConnection2.Open();
                    cmd2.ExecuteNonQuery();
                    sqlConnection2.Close();
                }
                catch
                {

                }

                //Save_DATA();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CANCEL_DATE();         
        }

        private void CANCEL_DATE()
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการจะยกเลิกรหัสนี้หรือไม่", "Cancel", MessageBoxButtons.YesNo);
            DateTime thisDay = DateTime.Today;
            if (dialogResult == DialogResult.Yes)
            {
                if (CT_ID != null)
                {
                    string connect = "";

                    if (Status == "สำนักงาน")
                    {
                        connect = _Server_CMDFX;
                    }
                    else if (Status == "หน้าร้าน")
                    {
                        connect = _Local_CMDFX;
                    }

                    SqlConnection sqlConnection1 = new SqlConnection(connect);
                    SqlConnection sqlConnection2 = new SqlConnection(_Sever_COMSUP);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE MAS_CT SET FLAGS = '1',UPDATEDT = '" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "' WHERE ID = '" + CT_ID + "'";
                    cmd.Connection = sqlConnection1;

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "UPDATE MAS_CT_CD SET UPDATEDT = '" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "' ";
                    cmd3.CommandText += "WHERE ID = '" + CT_ID + "'";
                    cmd3.Connection = sqlConnection1;

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO LOG_CT (TYPE,LOG_DATA,CARD_ID,CT_ID,WORKDATE,STCODE,WHCODE,FLAG) VALUES('3','CANCEL DATA','" + IDCARD + "','" + CT_ID + "','" + thisDay.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("en-US")) + "','" + _STCODE + "','" + _WHCODE + "','0')";
                    cmd2.Connection = sqlConnection2;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    sqlConnection2.Open();
                    cmd2.ExecuteNonQuery();
                    sqlConnection2.Close();


                }
                else
                {

                }
                clear_DATA();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
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
            txtCardLV.Text = " ";
            textStatus.Text = " ";

            BIRTHDATE.Text = DateTime.Today.ToString();
            ENTRYDATE.Text = DateTime.Today.ToString();

            IDCARD = "";
            CTNAME = "";
            CT_ID = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //string WHCODE = _WHCODE;
            //string Server = _Sever_COMSUP;
            InsertToServer.InsertToServer frm = new InsertToServer.InsertToServer(_WHCODE, _Sever_COMSUP);
            frm.ShowDialog();
        }

        private void lsvSearch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                BIRTHDATE.Value = DateTime.Now.Date;
                GetSelectItems();
                
                GetGoto();
                SaveData.Enabled = true;
                Cancel.Enabled = true;
                if (Status == "สำนักงาน")
                {
                    SaveTo.Enabled = true;
                    Cancel.Enabled = false;
                }
                else
                {
                    Cancel.Enabled = true;
                    SaveTo.Enabled = false;
                }
                getVIP();
                pictureBox1.Visible = true;
                bgWorkermember.RunWorkerAsync();
                //GetMembersum();
                GetPromotion();

                if(getHBD())
                {
                    radHBD.Enabled = true;
                }
                else
                {
                    if(CHBD )
                    {
                        radHBD.Enabled = true;
                    }
                    else
                    {
                        radHBD.Enabled = false;
                    }
                   
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด\n" + ex.Message);
            }
           
        }

        private void btnProV8_Click(object sender, EventArgs e)
        {
            setProV8();
        }

        private void btnVIP_Click(object sender, EventArgs e)
        {

            setMember();
            //SqlConnection conn = new SqlConnection(_Local_CMDFX);
            //try
            //{
            //    if (radMem.Checked)
            //    {
            //        string CT_CARDID = CARDID.Text;
            //        string sql = "delete from mas_ct_cd_vp where cardid = '" + CT_CARDID + "'";

            //        SqlCommand comm = new SqlCommand();

            //        comm.CommandText = sql;
            //        comm.CommandTimeout = 10000;
            //        comm.Connection = conn;

            //        if (conn.State == ConnectionState.Closed)
            //        {
            //            conn.Open();
            //        }

            //        comm.ExecuteNonQuery();
            //        gbMem.Enabled = true;
            //        MessageBox.Show("แก้ไขสิทธิสำเร็จ");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("เกิดข้อผิดพลาด" + ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}

        }

        private void setMember()
        {
            SqlConnection conn = new SqlConnection(_Local_CMDFX);
            try
            {
                if (radMem.Checked)
                {
                    string CT_CARDID = CARDID.Text;
                    string sql = "delete from mas_ct_cd_vp where cardid = '" + CT_CARDID + "'";

                    SqlCommand comm = new SqlCommand();

                    comm.CommandText = sql;
                    comm.CommandTimeout = 10000;
                    comm.Connection = conn;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    comm.ExecuteNonQuery();
                    gbMem.Enabled = false;
                    MessageBox.Show("แก้ไขสิทธิสำเร็จ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void CARDID_TextChanged(object sender, EventArgs e)
        {

        }

        private void SEX_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mnuExcel_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (CARDID.Text == "")
            {
                MessageBox.Show("กรุณาเลือกสมาชิกที่ต้องการดึง");
            }
            else
            {
                using (new cWaitIndicator())
                {
                    ThaiIDCard idcard = new ThaiIDCard();
                    Personal personal = idcard.readAll();
                    if (personal != null)
                    {
                        //SeachText.Text = personal.Citizenid;
                        TITLE.Text = personal.Th_Prefix;
                        FULLNAME.Text = personal.Th_Firstname + ' ' + personal.Th_Lastname;
                        ADDR_ROW1.Text = personal.Address;
                        ADDR_PROVINCE.Text = personal.addrProvince;
                        PEOPLEID.Text = personal.Citizenid;
                        //int age = DateTime.Now.Year - Int32.Parse(personal.BirthdayYearString);
                        int age = DateTime.Now.Year - Int32.Parse(personal.Birthday.ToString());

                        AGE.Text = age.ToString();
                        //AGE.Text = 
                        if (personal.Sex == "1")
                        {
                            SEX_comboBox.Text = "ชาย";
                        }
                        else
                        {
                            SEX_comboBox.Text = "หญิง";
                        }
                        BIRTHDATE.Text = personal.Birthday.ToString();

                    }
                    else if (idcard.ErrorCode() > 0)
                    {
                        MessageBox.Show(idcard.Error());
                    }
                }
            }
        }

        public void SaveToServer(string _WHCODE, string _Server_COMSUP)
        {
            SqlConnection sqlConnection1 = new SqlConnection(_Server_COMSUP);
            SqlConnection sqlConnection2 = new SqlConnection(_Server_COMSUP);
            try
            {

                //string strconn = _Sever_CMDFX;
                //string check = chkBrand;


                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "INSERT INTO [" + link_Server + "].[dbBeautyCommSupport].[dbo].LOG_CT ([TYPE],[LOG_DATA],[SEARCH],[CARD_ID],[CT_ID],[WORKDATE],[STCODE],[WHCODE],[FLAG]) SELECT[TYPE],[LOG_DATA],[SEARCH],[CARD_ID],[CT_ID],[WORKDATE],[STCODE],[WHCODE],[FLAG] FROM LOG_CT WHERE FLAG = '0'";

                //cmd.Connection = sqlConnection1;
                //sqlConnection1.Open();
                //cmd.ExecuteNonQuery();

                //SqlCommand cmd2 = new SqlCommand();
                //cmd2.CommandType = CommandType.Text;
                //cmd2.CommandText = "UPDATE LOG_CT SET FLAG = '1' WHERE FLAG = '0'";

                //cmd2.Connection = sqlConnection2;
                //sqlConnection2.Open();
                //cmd2.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด\n" + ex.Message);
            }
            finally
            {
                sqlConnection1.Close();
                sqlConnection2.Close();
            }

        }

        private void SaveTo_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(_Local_CMDFX);
            try
            {
                //using (new cWaitIndicator())
                //{


                //    string check = chkBrand;
                //    SqlCommand cmd = new SqlCommand();
                //    cmd.CommandType = CommandType.Text;
                //    cmd.CommandText = @"INSERT INTO MAS_CT
                //                SELECT * FROM [" + link_Server + "].[CMD-BX].dbo.MAS_CT WHERE ID = '" + CT_ID + @"'
                //                INSERT INTO MAS_CT_CD
                //                SELECT * FROM [" + link_Server + "].[CMD-BX].dbo.MAS_CT_CD WHERE CT_ID = '" + CT_ID + @"'";
                //    cmd.Connection = sqlConnection;

                //    sqlConnection.Open();
                //    cmd.ExecuteNonQuery();

                //    lsvSearch.SelectedItems[0].SubItems[0].Text = "หน้าร้าน";
                //}
                //MessageBox.Show("ดึงข้อมูลเรียบร้อย");

            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด\n" + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private void GetMembersum()
        {
            

            string CT_CARDID = CARDID.Text;
            string strSearch = CT_CARDID.Trim();

            string sqlquery = @"exec WP_SUMMEMBER " + " " + strSearch;
            SqlConnection conn = new SqlConnection(_Server_CMDFX);
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, conn);
            TableMEM = new DataSet();
            da.Fill(TableMEM, "tbl");
            //for (int i = 0; i <= ds.Tables["tbl"].Rows.Count - 1; i++)
            //{
            //    ListViewItem lst = new ListViewItem();
            //    lst = listViewMember.Items.Add(ds.Tables["tbl"].Rows[i]["CARDID"].ToString());
            //    lst.SubItems.Add(DateTime.Parse(ds.Tables["tbl"].Rows[i]["S_COUNT"].ToString()).ToString("MM/dd/yyyy"));
            //    lst.SubItems.Add(DateTime.Parse(ds.Tables["tbl"].Rows[i]["E_COUNT"].ToString()).ToString("MM/dd/yyyy"));
            //    lst.SubItems.Add(DateTime.Parse(ds.Tables["tbl"].Rows[i]["UPDATEDT"].ToString()).ToString("MM/dd/yyyy"));
            //    lst.SubItems.Add(ds.Tables["tbl"].Rows[i]["LOST"].ToString());
            //    lst.SubItems.Add(ds.Tables["tbl"].Rows[i]["NET"].ToString());
            //    //lst.SubItems.Add(ds.Tables["tbl"].Rows[i]["MEMBERTYPE"].ToString());
            //    lst.SubItems.Add(ds.Tables["tbl"].Rows[i]["MEMBERNAME"].ToString());
            //    lst.SubItems.Add(ds.Tables["tbl"].Rows[i]["UPLEVEL"].ToString());
            //    lst.SubItems.Add(ds.Tables["tbl"].Rows[i]["DOWNLEVEL"].ToString());
            //}
            //listViewMember.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //listViewMember.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //listViewMember.FullRowSelect = true;
        }

            private void GetPromotion()
        {
            string CT_CARDID = CARDID.Text;
            string CT_HBDmt = GetThMonth(BIRTHDATE.Value.Month);
            string CT_Name = FULLNAME.Text;
            int CT_Point = 0;
            int EX_Point = 0;
            string strSearch = CT_CARDID.Trim();
            DataSet dspro = new DataSet();

            string _dns = "";

            _dns = _Sever_Point.Substring(13, 17);


            clsServDataDataContext Cls_Serv = new clsServDataDataContext(_Sever_Point);
            clsHBDDataContext Cls_HBD = new clsHBDDataContext("data source=5cosmeda.homeunix.com,1433; initial catalog=dbmona;Integrated Security=false;User id=sa;Password=0211");
            int chbd = 0;

            if (chbd>0)
            {
                CHBD = true;
                ListViewItem lst = new ListViewItem();
                lst = lsvPromotion.Items.Add((lsvPromotion.Items.Count + 1).ToString());
                lst.SubItems.Add("Happy Birthday");
            }
            else
            {
                if (strSearch.Length > 0)
                {
                    using (cWaitIndicator cw = new cWaitIndicator())
                    {

                        int RPoint = 0;

                        lsvPromotion.Items.Clear();

                        if (BIRTHDATE.Value.Date != DateTime.Now.Date)
                        {
                            if (BIRTHDATE.Value.Month == DateTime.Now.Month)
                            {
                                if (_dns == "5cosmeda.homeunix.com")
                                {
                                    int cnt = Cls_HBD.MK_DOC_HBDs.Where(s => s.cardno == CT_CARDID && s.workdate.Year == DateTime.Now.Year).Count();

                                    if (cnt == 0 || chbd > 0)
                                    {
                                        CHBD = true;
                                        ListViewItem lst = new ListViewItem();
                                        lst = lsvPromotion.Items.Add((lsvPromotion.Items.Count + 1).ToString());
                                        lst.SubItems.Add("Happy Birthday");

                                    }

                                }
                                

                            }
                        }

                        var spoint = Cls_Serv.MV_POS_POINTs.Where(s => s.CARDID == CT_CARDID).FirstOrDefault();

                        var epoint = Cls_Serv.PV_EPOINTs.Where(s => s.CT_CARDID == CT_CARDID).FirstOrDefault();

                        if (epoint != null)
                        {
                            EX_Point = Convert.ToInt32(epoint.epoint);
                        }

                        if (spoint != null)
                        {
                            RPoint = Convert.ToInt32(spoint.RPOINT);
                            CT_Point = RPoint;

                            var ProCC = Cls_Serv.PR_POINTs.Where(s => s.CFLAG == 0 && s.S_DATE <= DateTime.Now && s.E_DATE >= DateTime.Now && s.UPOINT <= RPoint);

                            var fndData = ProCC.Select(s => new { s.PNAME, s.UPOINT, s.S_NO, s.E_NO, s.CTYPE, s.PCODE });

                            foreach (var item in fndData)
                            {

                                ListViewItem lst = new ListViewItem();
                                lst = lsvPromotion.Items.Add((lsvPromotion.Items.Count + 1).ToString());
                                lst.SubItems.Add(item.PNAME);

                            }
                        }

                        //string sql = "select PRNAME from pr_setdate where (TIMELIMIT = 'F' or (TIMELIMIT = 'T' and convert(varchar(10),getdate(),102) between S_DATE and E_date)) and MEMBERONLY = 'T' and prtype not in ( 'V9','V3','V10')";
                        string sqlchekcard = "";
                        if (txtCardLV.Text == "Pink Member" || txtCardLV.Text == "Silver Member")
                        {
                            if(chkBrand == "BB") sqlchekcard = " AND B.CARDLV= '101'";
                            else if (chkBrand == "BC") sqlchekcard = " AND B.CARDLV= '501'";
                            else if (chkBrand == "BM") sqlchekcard = " AND B.CARDLV= '701'";

                        }
                        else if (txtCardLV.Text == "Rosegold Member" || txtCardLV.Text == "Gold Member")
                        {
                            if (chkBrand == "BB") sqlchekcard = " AND B.CARDLV= '102'";
                            else if (chkBrand == "BC") sqlchekcard = " AND B.CARDLV= '502'";
                            else if (chkBrand == "BM") sqlchekcard = " AND B.CARDLV= '702'";
                        }

                        string sql = @"select A.PRNAME from pr_setdate A
                                            left join PR_LV B ON A.PRCODE=B.PRCODE
                                            where (A.TIMELIMIT = 'F' or (A.TIMELIMIT = 'T' and convert(varchar(10),getdate(),102) between A.S_DATE and A.E_date)) 
                                            and A.MEMBERONLY = 'T' 
                                            and A.prtype not in ( 'V9','V3','V10')" + sqlchekcard;
                                            

                        if (getVIP())
                        {
                            sql = sql + @" select A.PRNAME from pr_setdate A 
                                            left join PR_LV B ON A.PRCODE=B.PRCODE
                                            where (A.TIMELIMIT = 'F' or (A.TIMELIMIT = 'T' and convert(varchar(10),getdate(),102) between A.S_DATE and A.E_date)) 
                                            and A.MEMBERONLY = 'T' 
                                            and A.prtype in ('V9','V10')" + sqlchekcard;
                                           
                        }

                        SqlConnection conn = new SqlConnection(_Local_CMDFX);
                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                        DataSet ds = new DataSet();

                        da.Fill(ds, "tbl");

                        for (int i = 0; i <= ds.Tables["tbl"].Rows.Count - 1; i++)
                        {
                            ListViewItem lst = new ListViewItem();
                            lst = lsvPromotion.Items.Add((lsvPromotion.Items.Count + 1).ToString());
                            lst.SubItems.Add(ds.Tables["tbl"].Rows[i]["prname"].ToString());
                        }

                        lblPoint.Text = Convert.ToDecimal(CT_Point).ToString("#,##0");
                        lblPointExpire.Text = Convert.ToDecimal(EX_Point).ToString("#,##0");
                    }
                }
            }
            
        }

        public string GetThMonth(int _month)
        {
            string mt;
            switch (_month)
            {
                case 1:
                    mt = "มกราคม";
                    break;
                case 2:
                    mt = "กุมภาพันธ์";
                    break;
                case 3:
                    mt = "มีนาคม";
                    break;
                case 4:
                    mt = "เมษายน";
                    break;
                case 5:
                    mt = "พฤษภาคม";
                    break;
                case 6:
                    mt = "มิถุนายน";
                    break;
                case 7:
                    mt = "กรกฎาคม";
                    break;
                case 8:
                    mt = "สิงหาคม";
                    break;
                case 9:
                    mt = "กันยายน";
                    break;
                case 10:
                    mt = "ตุลาคม";
                    break;
                case 11:
                    mt = "พฤศจิกายน";
                    break;
                case 12:
                    mt = "ธันวาคม";
                    break;
                default:
                    mt = "";
                    break;


            }

            return mt;

        }

        private bool getVIP()
        {
            bool bl = false;
            string CT_CARDID = CARDID.Text;
            string sql = "select count(*) cnt from mas_ct_cd_vp where cardid = '"+ CT_CARDID + "'";

            SqlConnection conn = new SqlConnection(_Local_CMDFX);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tbl");

            if (Convert.ToInt32( ds.Tables["tbl"].Rows[0]["cnt"]) >0 )
            {
                if(chkBrand=="BB")
                {
                    radVIP.Checked = true;
                    gbMem.Enabled = true;
                    bl = true;
                }
                else if(chkBrand == "BC")
                {
                    int dd = Convert.ToInt32(cDateTime.getDateTimeWithDayOnly());
                    int mm = Convert.ToInt32(cDateTime.getDateTimeWithMonthOnly());
                    int yy = Convert.ToInt32(cDateTime.getDateTimeWithYearOnly());

                    if (dd >= 18)
                    {
                        radVIP.Checked = true;
                        gbMem.Enabled = true;
                        bl = true;
                    }
                    else if (mm > 10)
                    {
                        radVIP.Checked = true;
                        gbMem.Enabled = true;
                        bl = true;
                    }
                    else
                    {
                        radVIP.Checked = true;
                        gbMem.Enabled = true;
                        bl = true;
                    }

                }
                else
                {
                    radVIP.Checked = true;
                    gbMem.Enabled = true;
                    bl = true;
                }

               
            }
               
            else
            {
                radMem.Checked = true;
                gbMem.Enabled = false;
                bl = false;
            }

            return bl;
          
        }

       private void getProV8()
        {
            string sql;
            
            sql = "select count(*) cnt from pr_std_us where prcode Like 'V8%' and cflag = 0";
           

            SqlConnection conn = new SqlConnection(_Local_CMDFX);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tbl");

            if (Convert.ToInt32(ds.Tables["tbl"].Rows[0]["cnt"]) > 0)
            {
                if(pr1000_500)
                {
                    ChangToPr1000_500();
                }
                radProV8.Checked = true;
            }

            else
            {
                if(chkBrand == "BB")
                {
                    sql = "select count(*) cnt from pr_std_us where prcode Like 'Q9%' and cflag = 0";

                }
                else if (chkBrand == "BC")
                {
                    sql = "select count(*) cnt from pr_std_us where prcode Like 'Q9%' and cflag = 0";

                }
                else
                {
                    sql = "select count(*) cnt from pr_std_us where prcode = 'V818090001' and cflag = 0";
                }
                    
                SqlConnection conn1 = new SqlConnection(_Local_CMDFX);
                SqlDataAdapter da1 = new SqlDataAdapter(sql, conn1);

                DataSet ds1 = new DataSet();

                da1.Fill(ds1, "tbl");

                if (Convert.ToInt32(ds1.Tables["tbl"].Rows[0]["cnt"]) > 0)
                {
                    radHBD.Checked = true;
                }
                else if (chkBrand == "BB")
                {

                    sql = "select count(*) cnt from pr_std_us where prcode = 'Q218100003' and cflag = 0";


                    SqlDataAdapter da2 = new SqlDataAdapter(sql, conn1);

                    DataSet ds2 = new DataSet();

                    da1.Fill(ds2, "tbl");
                    if (Convert.ToInt32(ds1.Tables["tbl"].Rows[0]["cnt"]) > 0)
                    {
                       
                            radOther.Checked = true;
                                               
                    }
                    else
                    {
                        radProGen.Checked = true;
                    }
                    
                }
                else
                {
                    radProGen.Checked = true;
                }


            }

            
        }

        private void ChangToPr1000_500()
        {
            string sql;

            SqlConnection conn = new SqlConnection(_Local_CMDFX);
           

            try
            {
                sql = "update [cmd-fx]..pr_std_us set cflag = 1 where prcode = 'V818090001'; ";
                sql = sql + " update [cmd-fx]..pr_std_us set cflag = 0 where prcode = 'V818090002';";

                SqlCommand comm = new SqlCommand();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                comm.Connection = conn;
                comm.CommandTimeout = 100000;
                comm.CommandText = sql;

                comm.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                MessageBox.Show(" ไม่สามารถแก้ไขโปรโมชั่นได้\n" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
           
        }

        private void setProV8()
        {
            SqlConnection conn = new SqlConnection(_Local_CMDFX);
       
            string sql = "";
            try
            {
                if (radProV8.Checked)
                {
                    if (chkBrand == "BB")
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode = 'Q019020207'; ";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode <> 'Q019020207'";//MD18100001
                    }
                    else if (chkBrand == "BM")
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode = 'CC18100011'; ";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode <> 'CC18100011'";
                    }
                    else
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode = 'MD18100001'; ";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode <> 'MD18100001'";
                    }

                }
                else if (radHBD.Checked)
                {
                    if (chkBrand == "BB")
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode  like 'Q9%'; ";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode not like 'Q9%';";
                    }
                    else if (chkBrand == "BM")
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode  = 'V818090001'; ";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode <> 'V818090001';";
                    }
                    else
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode  like 'Q9%'; ";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode not like 'Q9%';";
                    }
                    radMem.Checked = true;
                    setMember();

                }
                else if (radOther.Checked)
                {
                    
                       sql = "update pr_std_us set  cflag = 0 where prcode  = 'Q218100003'; ";
                    sql = sql + "update pr_std_us set  cflag = 1 where prcode <> 'Q218100003';";

                    radMem.Checked = true;
                    setMember();

                }
                else if(radCancel.Checked)
                {
                    sql = "update pr_std_us set  cflag = 1 where prcode not like 'C%' and prcode not like 'M%' ; ";
                    sql = sql + " update pr_std_us set  cflag = 0 where  prcode = 'V1119020001';";
                    sql = sql + " update pr_std_us set  cflag = 0 where prcode  like 'V8%';";
                    sql = sql + " update pr_std_us set  cflag = 0 where prcode  like 'V9%';";
                    sql = sql + " update pr_std_us set  cflag = 0 where prcode  like 'V101%';";

                }
                else
                {
                    if (chkBrand == "BB")
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode not like 'V8%'; ";
                        sql = sql +  " update pr_std_us set  cflag = 1 where prcode like 'V8%';";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode like 'Q9%';";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode = 'MD18100001';";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode = 'Q218100003';";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode = 'V1119020001';";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode = 'Q019020207';";
                    }

                    else if (chkBrand == "BM")
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode <> 'CC18100011'; ";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode = 'CC18100011'";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode = 'V818090001'";
                    }
                    else
                    {
                        sql = "update pr_std_us set  cflag = 0 where prcode <> 'MD18100001'; ";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode = 'MD18100001';";
                        sql = sql + "update pr_std_us set  cflag = 1 where prcode like 'Q9%';";

                    }
                } 
                
                SqlCommand comm = new SqlCommand();

                comm.CommandText = sql;
                comm.CommandTimeout = 10000;
                comm.Connection = conn;

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                comm.ExecuteNonQuery();
                MessageBox.Show("แก้ไขโปรโมชั่นสำเร็จ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        private bool getHBD()
        {
            bool bl = false;

            if(BIRTHDATE.Value.Date != DateTime.Now.Date)
            {
                if (BIRTHDATE.Value.Month == DateTime.Now.Month)
                {
                    bl = true;
                }
            }


            return bl;
        }

        private void btnPromotion_Click(object sender, EventArgs e)
        {
            try
            {
                frmPromotion frm = new frmPromotion(_Local_COMSUP,CHBD,ref txtbl,ref txtsql,ref txtID);
                frm.ShowDialog();

                if(txtbl.Text=="true")
                {
                   if (update_td_us(txtsql.Text))
                    {
                        if(update_mas_promotion(txtID.Text))
                        {
                            if (setlabel())
                            {
                                MessageBox.Show("แก้ไขโปรโมชั่นสำเร็จ");
                            }
                        }
                       
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool setlabel()
        {
            bool bl = false;
            string sql = "";
            DataSet ds = new DataSet();
            sql = "select * from [dbbeautyCommsupport]..mas_promotion where cflag = '0' and uflag = 1"; 
            
            ds.Clear();
            ds = cData.getDataSetWithSqlCommand(_Local_CMDFX, sql, 1000, true);

           lblPromotion.Text = ds.Tables[0].Rows[0]["prname"].ToString();
            bl = true;

            return bl;
        }

        private bool update_td_us(string _sql)
        {
            bool bl = false;
            string sql = "";
            sql = _sql;

            SqlCommand comm = new SqlCommand();
            SqlConnection sconn = new SqlConnection(_Local_CMDFX); 

            comm.CommandText = sql;
            comm.CommandTimeout = 10000;
            comm.Connection = sconn;

            if (sconn.State == ConnectionState.Closed)
            {
                sconn.Open();
            }

            comm.ExecuteNonQuery();
            bl = true;

            return bl;
            //MessageBox.Show("แก้ไขโปรโมชั่นสำเร็จ");


        }

        private bool update_mas_promotion(string _id)
        {
            bool bl = false;
            string sql = "";
            sql = "update mas_promotion set uflag = 0 where id <> " + _id+ ";";
            sql = sql + " update mas_promotion set uflag = 1 where id = " + _id + ";";

            SqlCommand comm = new SqlCommand();
            SqlConnection sconn = new SqlConnection(_Local_COMSUP);

            comm.CommandText = sql;
            comm.CommandTimeout = 10000;
            comm.Connection = sconn;

            if (sconn.State == ConnectionState.Closed)
            {
                sconn.Open();
            }

            comm.ExecuteNonQuery();
            bl = true;

            return bl;
            //MessageBox.Show("แก้ไขโปรโมชั่นสำเร็จ");


        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            cls_send_mas_promotion.clsMain.clsSendMas(_Local_COMSUP, _Sever_COMSUP);
        }

        private void LsvPromotion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SeachText_TextChanged(object sender, EventArgs e)
        {

        }

        private void LsvSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
