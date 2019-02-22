using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using k.libary;


namespace cls_send_mas_promotion
{
    public static class clsMain
    {
        private static string strserv;
        private static string strcli;
        private static DataSet ds = new DataSet();

        public static bool clsSendMas(string _local_commsup, string _sever_commsup)
        {
            bool bl = false;


            try
            {
                strserv = _sever_commsup;
                strcli = _local_commsup;
                getserv();
                setcli();

                bl = true;
            }
            catch (Exception ex)
            {
                bl = false;
                MessageBox.Show(ex.Message);
            }

            return bl;
        }

        public static bool getserv()
        {
            bool bl = false;
            ds.Clear();

            string sql = "select * from [dbbeautycommsupport]..mas_promotion";

            ds.Clear();
            ds = cData.getDataSetWithSqlCommand(strserv, sql, 10000, true);

           
            return bl;
        }

        public static bool setcli()
        {
            bool bl = false;
            string sql = "";

            sql = "delete from [dbbeautycommsupport]..mas_promotion";

            SqlCommand comm = new SqlCommand();
            SqlConnection sconn = new SqlConnection(strcli);
            if (sconn.State == ConnectionState.Closed)
            {
                sconn.Open();
            }
            comm.CommandText = sql;
            comm.CommandTimeout = 10000;
            comm.Connection = sconn;

            comm.ExecuteNonQuery();

            for (int i = 0;i<= ds.Tables[0].Rows.Count -1;i++ )
            {
                string sqltxt = ds.Tables[0].Rows[i]["sqltext"].ToString().Replace("'","''");
                sql = @"insert [dbbeautycommsupport]..mas_promotion(id, prname, sqltext, sort, uflag, cflag) 
                        values('" + ds.Tables[0].Rows[i]["id"].ToString() + "'," +
                        "'" + ds.Tables[0].Rows[i]["prname"].ToString() + "'," +
                        "'" + sqltxt + "'," +
                        "'" + ds.Tables[0].Rows[i]["sort"].ToString() + "'," +
                        "'" + ds.Tables[0].Rows[i]["uflag"].ToString() + "'," +
                        "'" + ds.Tables[0].Rows[i]["cflag"].ToString() + "') ";

                comm.CommandText = sql;

                comm.ExecuteNonQuery();
            }
            bl = true;
            return bl;
        }
    }
}
