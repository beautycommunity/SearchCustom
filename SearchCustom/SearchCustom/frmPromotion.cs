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

    public partial class frmPromotion : frmReportCondition
    {
        string strconn;
        TextBox txtbl;
        TextBox txtPro;

        public frmPromotion()
        {
            InitializeComponent();

            strconn = "";
            txtbl.Text = "false";
            txtPro.Text = "";
        }

        public frmPromotion(string _strconn ,TextBox _txtbl,ref TextBox _txtPro)
        {
            InitializeComponent();

            strconn = "";
            txtbl = _txtbl;
            txtPro = _txtPro;
        }
    }
}
