namespace SupCustom
{
    partial class frmSaveMasCt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaveMasCt));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.pb = new System.Windows.Forms.PictureBox();
            this.lsvSearch = new k.libary.kListView(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtid = new System.Windows.Forms.TextBox();
            this.gbMem = new System.Windows.Forms.GroupBox();
            this.radVIP = new System.Windows.Forms.RadioButton();
            this.radMem = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPointExpire = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.LbShow = new System.Windows.Forms.Label();
            this.SEX_comboBox = new System.Windows.Forms.ComboBox();
            this.ENTRYDATE = new System.Windows.Forms.DateTimePicker();
            this.SaveData = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.AGE = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CARDID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PEOPLEID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ADDR_EMAIL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ADDR_PROVINCE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ADDR_ROW2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ADDR_MOBILE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ADDR_ROW1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FULLNAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TITLE = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmdBrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Type_ComboBox = new System.Windows.Forms.ComboBox();
            this.button_Select = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.BIRTHDATE = new k.libary.kDateTimePicker(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.panel2.SuspendLayout();
            this.gbMem.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1041, 42);
            this.toolStrip1.TabIndex = 217;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(158, 39);
            this.toolStripButton1.Text = "โหลดข้อมูลบัตรประชาชน";
            this.toolStripButton1.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(96, 39);
            this.toolStripButton2.Text = "ปิดหน้าต่าง";
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.White;
            this.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb.Image = ((System.Drawing.Image)(resources.GetObject("pb.Image")));
            this.pb.Location = new System.Drawing.Point(83, 261);
            this.pb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(236, 195);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb.TabIndex = 224;
            this.pb.TabStop = false;
            this.pb.Visible = false;
            // 
            // lsvSearch
            // 
            this.lsvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsvSearch.FullRowSelect = true;
            this.lsvSearch.GridLines = true;
            this.lsvSearch.Location = new System.Drawing.Point(5, 194);
            this.lsvSearch.Name = "lsvSearch";
            this.lsvSearch.Size = new System.Drawing.Size(404, 342);
            this.lsvSearch.TabIndex = 221;
            this.lsvSearch.UseCompatibleStateImageBehavior = false;
            this.lsvSearch.View = System.Windows.Forms.View.Details;
            this.lsvSearch.DoubleClick += new System.EventHandler(this.lsvSearch_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BIRTHDATE);
            this.panel2.Controls.Add(this.txtid);
            this.panel2.Controls.Add(this.gbMem);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.LbShow);
            this.panel2.Controls.Add(this.SEX_comboBox);
            this.panel2.Controls.Add(this.ENTRYDATE);
            this.panel2.Controls.Add(this.SaveData);
            this.panel2.Controls.Add(this.Cancel);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.AGE);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.CARDID);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.PEOPLEID);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.ADDR_EMAIL);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.ADDR_PROVINCE);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.ADDR_ROW2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.ADDR_MOBILE);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ADDR_ROW1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.FULLNAME);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TITLE);
            this.panel2.Location = new System.Drawing.Point(417, 43);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 493);
            this.panel2.TabIndex = 220;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(187, 399);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(100, 23);
            this.txtid.TabIndex = 246;
            this.txtid.Visible = false;
            // 
            // gbMem
            // 
            this.gbMem.Controls.Add(this.radVIP);
            this.gbMem.Controls.Add(this.radMem);
            this.gbMem.Enabled = false;
            this.gbMem.Location = new System.Drawing.Point(15, 322);
            this.gbMem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbMem.Name = "gbMem";
            this.gbMem.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbMem.Size = new System.Drawing.Size(261, 70);
            this.gbMem.TabIndex = 245;
            this.gbMem.TabStop = false;
            this.gbMem.Text = "สมาชิก";
            // 
            // radVIP
            // 
            this.radVIP.AutoSize = true;
            this.radVIP.Location = new System.Drawing.Point(27, 45);
            this.radVIP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radVIP.Name = "radVIP";
            this.radVIP.Size = new System.Drawing.Size(57, 20);
            this.radVIP.TabIndex = 1;
            this.radVIP.TabStop = true;
            this.radVIP.Text = "V.I.P.";
            this.radVIP.UseVisualStyleBackColor = true;
            // 
            // radMem
            // 
            this.radMem.AutoSize = true;
            this.radMem.Location = new System.Drawing.Point(27, 22);
            this.radMem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radMem.Name = "radMem";
            this.radMem.Size = new System.Drawing.Size(64, 20);
            this.radMem.TabIndex = 0;
            this.radMem.TabStop = true;
            this.radMem.Text = "สมาชิก";
            this.radMem.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPointExpire);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(298, 254);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(275, 55);
            this.groupBox2.TabIndex = 244;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "แต้มที่จะหมดอายุสิ้นปี";
            // 
            // lblPointExpire
            // 
            this.lblPointExpire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointExpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPointExpire.ForeColor = System.Drawing.Color.Red;
            this.lblPointExpire.Location = new System.Drawing.Point(2, 22);
            this.lblPointExpire.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPointExpire.Name = "lblPointExpire";
            this.lblPointExpire.Size = new System.Drawing.Size(271, 30);
            this.lblPointExpire.TabIndex = 0;
            this.lblPointExpire.Text = "0";
            this.lblPointExpire.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPoint);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(298, 195);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(275, 55);
            this.groupBox1.TabIndex = 243;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "แต้มคงเหลือ";
            // 
            // lblPoint
            // 
            this.lblPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPoint.ForeColor = System.Drawing.Color.Green;
            this.lblPoint.Location = new System.Drawing.Point(2, 22);
            this.lblPoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(271, 30);
            this.lblPoint.TabIndex = 0;
            this.lblPoint.Text = "0";
            this.lblPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LbShow
            // 
            this.LbShow.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LbShow.ForeColor = System.Drawing.Color.Red;
            this.LbShow.Location = new System.Drawing.Point(301, 322);
            this.LbShow.Name = "LbShow";
            this.LbShow.Size = new System.Drawing.Size(275, 70);
            this.LbShow.TabIndex = 241;
            this.LbShow.Text = "*กดดึงสมาชิกเพื่อรับส่งข้อมูลจากสำนักงานมายังหน้าร้าน";
            // 
            // SEX_comboBox
            // 
            this.SEX_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SEX_comboBox.FormattingEnabled = true;
            this.SEX_comboBox.Location = new System.Drawing.Point(402, 108);
            this.SEX_comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.SEX_comboBox.Name = "SEX_comboBox";
            this.SEX_comboBox.Size = new System.Drawing.Size(168, 24);
            this.SEX_comboBox.TabIndex = 212;
            // 
            // ENTRYDATE
            // 
            this.ENTRYDATE.Enabled = false;
            this.ENTRYDATE.Location = new System.Drawing.Point(402, 166);
            this.ENTRYDATE.Name = "ENTRYDATE";
            this.ENTRYDATE.Size = new System.Drawing.Size(168, 23);
            this.ENTRYDATE.TabIndex = 240;
            // 
            // SaveData
            // 
            this.SaveData.BackColor = System.Drawing.Color.ForestGreen;
            this.SaveData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaveData.Location = new System.Drawing.Point(484, 411);
            this.SaveData.Margin = new System.Windows.Forms.Padding(4);
            this.SaveData.Name = "SaveData";
            this.SaveData.Size = new System.Drawing.Size(88, 47);
            this.SaveData.TabIndex = 238;
            this.SaveData.Text = "บันทึก";
            this.SaveData.UseVisualStyleBackColor = false;
            this.SaveData.Click += new System.EventHandler(this.SaveData_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.Red;
            this.Cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cancel.Location = new System.Drawing.Point(388, 411);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 47);
            this.Cancel.TabIndex = 212;
            this.Cancel.Text = "ยกเลิก";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.Location = new System.Drawing.Point(294, 168);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 20);
            this.label15.TabIndex = 237;
            this.label15.Text = "วันที่สมัคร";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(294, 139);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 20);
            this.label14.TabIndex = 235;
            this.label14.Text = "วันเกิด";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(296, 107);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 20);
            this.label13.TabIndex = 233;
            this.label13.Text = "เพศ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(299, 51);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 20);
            this.label12.TabIndex = 231;
            this.label12.Text = "อายุ";
            // 
            // AGE
            // 
            this.AGE.Location = new System.Drawing.Point(402, 51);
            this.AGE.Margin = new System.Windows.Forms.Padding(4);
            this.AGE.Name = "AGE";
            this.AGE.Size = new System.Drawing.Size(168, 23);
            this.AGE.TabIndex = 230;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(294, 25);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 20);
            this.label11.TabIndex = 229;
            this.label11.Text = "รหัสบัตรสมาชิก";
            // 
            // CARDID
            // 
            this.CARDID.Location = new System.Drawing.Point(402, 23);
            this.CARDID.Margin = new System.Windows.Forms.Padding(4);
            this.CARDID.Name = "CARDID";
            this.CARDID.ReadOnly = true;
            this.CARDID.Size = new System.Drawing.Size(168, 23);
            this.CARDID.TabIndex = 228;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(11, 289);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 227;
            this.label10.Text = "รหัสประชาชน";
            // 
            // PEOPLEID
            // 
            this.PEOPLEID.Location = new System.Drawing.Point(108, 290);
            this.PEOPLEID.Margin = new System.Windows.Forms.Padding(4);
            this.PEOPLEID.Name = "PEOPLEID";
            this.PEOPLEID.Size = new System.Drawing.Size(168, 23);
            this.PEOPLEID.TabIndex = 226;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(11, 259);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.TabIndex = 225;
            this.label9.Text = "อีเมล";
            // 
            // ADDR_EMAIL
            // 
            this.ADDR_EMAIL.Location = new System.Drawing.Point(108, 260);
            this.ADDR_EMAIL.Margin = new System.Windows.Forms.Padding(4);
            this.ADDR_EMAIL.Name = "ADDR_EMAIL";
            this.ADDR_EMAIL.Size = new System.Drawing.Size(168, 23);
            this.ADDR_EMAIL.TabIndex = 224;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(11, 201);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 223;
            this.label8.Text = "จังหวัด";
            // 
            // ADDR_PROVINCE
            // 
            this.ADDR_PROVINCE.Location = new System.Drawing.Point(108, 202);
            this.ADDR_PROVINCE.Margin = new System.Windows.Forms.Padding(4);
            this.ADDR_PROVINCE.Name = "ADDR_PROVINCE";
            this.ADDR_PROVINCE.Size = new System.Drawing.Size(168, 23);
            this.ADDR_PROVINCE.TabIndex = 222;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(294, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 20);
            this.label7.TabIndex = 221;
            this.label7.Text = "ที่อยู่";
            // 
            // ADDR_ROW2
            // 
            this.ADDR_ROW2.Location = new System.Drawing.Point(402, 80);
            this.ADDR_ROW2.Margin = new System.Windows.Forms.Padding(4);
            this.ADDR_ROW2.Name = "ADDR_ROW2";
            this.ADDR_ROW2.Size = new System.Drawing.Size(168, 23);
            this.ADDR_ROW2.TabIndex = 220;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(11, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 219;
            this.label6.Text = "เบอร์โทรศัพท์";
            // 
            // ADDR_MOBILE
            // 
            this.ADDR_MOBILE.Location = new System.Drawing.Point(108, 232);
            this.ADDR_MOBILE.Margin = new System.Windows.Forms.Padding(4);
            this.ADDR_MOBILE.Name = "ADDR_MOBILE";
            this.ADDR_MOBILE.Size = new System.Drawing.Size(168, 23);
            this.ADDR_MOBILE.TabIndex = 218;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(11, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 217;
            this.label5.Text = "ที่อยู่";
            // 
            // ADDR_ROW1
            // 
            this.ADDR_ROW1.Location = new System.Drawing.Point(108, 81);
            this.ADDR_ROW1.Margin = new System.Windows.Forms.Padding(4);
            this.ADDR_ROW1.Multiline = true;
            this.ADDR_ROW1.Name = "ADDR_ROW1";
            this.ADDR_ROW1.Size = new System.Drawing.Size(168, 116);
            this.ADDR_ROW1.TabIndex = 216;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(11, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 215;
            this.label4.Text = "ชื่อ-นามสกุล";
            // 
            // FULLNAME
            // 
            this.FULLNAME.Location = new System.Drawing.Point(108, 51);
            this.FULLNAME.Margin = new System.Windows.Forms.Padding(4);
            this.FULLNAME.Name = "FULLNAME";
            this.FULLNAME.Size = new System.Drawing.Size(168, 23);
            this.FULLNAME.TabIndex = 214;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(11, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 213;
            this.label3.Text = "คำนำหน้า";
            // 
            // TITLE
            // 
            this.TITLE.Location = new System.Drawing.Point(108, 22);
            this.TITLE.Margin = new System.Windows.Forms.Padding(4);
            this.TITLE.Name = "TITLE";
            this.TITLE.Size = new System.Drawing.Size(168, 23);
            this.TITLE.TabIndex = 212;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblBrand);
            this.panel1.Controls.Add(this.cmdBrand);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Type_ComboBox);
            this.panel1.Controls.Add(this.button_Select);
            this.panel1.Controls.Add(this.SearchText);
            this.panel1.Location = new System.Drawing.Point(5, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 150);
            this.panel1.TabIndex = 219;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBrand.Location = new System.Drawing.Point(63, 15);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(52, 20);
            this.lblBrand.TabIndex = 212;
            this.lblBrand.Text = "แบรนด์";
            // 
            // cmdBrand
            // 
            this.cmdBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdBrand.FormattingEnabled = true;
            this.cmdBrand.Location = new System.Drawing.Point(119, 15);
            this.cmdBrand.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBrand.Name = "cmdBrand";
            this.cmdBrand.Size = new System.Drawing.Size(237, 24);
            this.cmdBrand.TabIndex = 213;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(38, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 211;
            this.label2.Text = "รายละเอียด";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(48, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ค้นหาจาก";
            // 
            // Type_ComboBox
            // 
            this.Type_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type_ComboBox.FormattingEnabled = true;
            this.Type_ComboBox.Location = new System.Drawing.Point(119, 47);
            this.Type_ComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.Type_ComboBox.Name = "Type_ComboBox";
            this.Type_ComboBox.Size = new System.Drawing.Size(237, 24);
            this.Type_ComboBox.TabIndex = 210;
            // 
            // button_Select
            // 
            this.button_Select.Location = new System.Drawing.Point(119, 110);
            this.button_Select.Margin = new System.Windows.Forms.Padding(4);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(114, 28);
            this.button_Select.TabIndex = 209;
            this.button_Select.Text = "ค้นหา";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(119, 79);
            this.SearchText.Margin = new System.Windows.Forms.Padding(4);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(237, 23);
            this.SearchText.TabIndex = 0;
            this.SearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchText_KeyPress);
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // BIRTHDATE
            // 
            this.BIRTHDATE.DisplayThai = true;
            this.BIRTHDATE.Location = new System.Drawing.Point(402, 137);
            this.BIRTHDATE.Name = "BIRTHDATE";
            this.BIRTHDATE.Size = new System.Drawing.Size(168, 23);
            this.BIRTHDATE.TabIndex = 247;
            // 
            // frmSaveMasCt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 540);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lsvSearch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSaveMasCt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "สมาชิก";
            this.Load += new System.EventHandler(this.frmSaveMasCt_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbMem.ResumeLayout(false);
            this.gbMem.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        internal System.Windows.Forms.PictureBox pb;
        private k.libary.kListView lsvSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbMem;
        private System.Windows.Forms.RadioButton radVIP;
        private System.Windows.Forms.RadioButton radMem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPointExpire;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Label LbShow;
        private System.Windows.Forms.ComboBox SEX_comboBox;
        private System.Windows.Forms.DateTimePicker ENTRYDATE;
        private System.Windows.Forms.Button SaveData;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox AGE;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CARDID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PEOPLEID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ADDR_EMAIL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ADDR_PROVINCE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ADDR_ROW2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ADDR_MOBILE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ADDR_ROW1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FULLNAME;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TITLE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmdBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Type_ComboBox;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.TextBox SearchText;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.TextBox txtid;
        private k.libary.kDateTimePicker BIRTHDATE;
    }
}