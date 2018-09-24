//using kBeautyLibrary;
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

namespace InsertToServer
{
    public partial class InsertToServer : k.libary.frmReportCondition
    {

        public string _WHCODE;
        public string _Server_COMSUP;
        public string link_Server;

        public InsertToServer()
        {
            InitializeComponent();

        }

        public InsertToServer(string WHCODE,string Server)
        {
            InitializeComponent();

            _WHCODE = WHCODE;
            _Server_COMSUP = Server;
        }

        private void Save_Log_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveToServer(); 
        }

        private void SaveToServer(string _WHCODE, string _Server_COMSUP)
        {
            string strconn = @"Data Source=5COSMEDA.HOMEUNIX.COM,1433;Initial Catalog=CMD-BX;User ID=sa;Password=0211";
            string SELECT_WH = "WITH ANS AS( SELECT * FROM NV_MAS_WH UNION SELECT * FROM [192.168.1.24,1833].[CMD-BX].dbo.NV_MAS_WH UNION SELECT * FROM [192.168.1.53,1733].[CMD-BX].dbo.NV_MAS_WH) SELECT Brand FROM ANS WHERE WHCODE = '" + _WHCODE + "'";
            DataSet ds = k.libary.cData.getDataSetWithSqlCommand(strconn, SELECT_WH, 1000, true);

            string check = ds.Tables[0].Rows[0]["Brand"].ToString();

            if (check == "BB")
            {
                link_Server = "[5COSMEDA.HOMEUNIX.COM,1433]";
            }
            else if (check == "BC")
            {
                link_Server = "[5COSMEDA.HOMEUNIX.COM,1833]";
            }
            else if (check == "BM")
            {
                link_Server = "[5COSMEDA.HOMEUNIX.COM,1733]";
            }

            SqlConnection sqlConnection1 = new SqlConnection(_Server_COMSUP);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO " + link_Server + ".[dbBeautyCommSupport].[dbo].LOG_CT ([TYPE],[LOG_DATA],[SEARCH],[CARD_ID],[CT_ID],[WORKDATE],[STCODE],[WHCODE],[FLAG]) SELECT[TYPE],[LOG_DATA],[SEARCH],[CARD_ID],[CT_ID],[WORKDATE],[STCODE],[WHCODE],[FLAG] FROM LOG_CT WHERE FLAG = '0'";

            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();


            SqlConnection sqlConnection2 = new SqlConnection(_Server_COMSUP);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "UPDATE LOG_CT SET FLAG = '1' WHERE FLAG = '0'";

            cmd2.Connection = sqlConnection2;
            sqlConnection2.Open();
            cmd2.ExecuteNonQuery();
            sqlConnection2.Close();
        }
    }
}
