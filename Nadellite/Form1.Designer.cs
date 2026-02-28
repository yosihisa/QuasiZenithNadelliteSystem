namespace Nadellite
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnXP = new System.Windows.Forms.Button();
            this.btnXM = new System.Windows.Forms.Button();
            this.btnXPP = new System.Windows.Forms.Button();
            this.btnXMM = new System.Windows.Forms.Button();
            this.btnYMM = new System.Windows.Forms.Button();
            this.btnYPP = new System.Windows.Forms.Button();
            this.btnYM = new System.Windows.Forms.Button();
            this.btnYP = new System.Windows.Forms.Button();
            this.btnZPP = new System.Windows.Forms.Button();
            this.btnZP = new System.Windows.Forms.Button();
            this.btnZM = new System.Windows.Forms.Button();
            this.btnZMM = new System.Windows.Forms.Button();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.txtYPos = new System.Windows.Forms.TextBox();
            this.txtZPos = new System.Windows.Forms.TextBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnUdonMenu = new System.Windows.Forms.Button();
            this.btnXRM = new System.Windows.Forms.Button();
            this.btnXRP = new System.Windows.Forms.Button();
            this.btnYRM = new System.Windows.Forms.Button();
            this.btnZRM = new System.Windows.Forms.Button();
            this.btnYRP = new System.Windows.Forms.Button();
            this.btnZRP = new System.Windows.Forms.Button();
            this.btnPosReset = new System.Windows.Forms.Button();
            this.btnRotReset = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.qzss_connect = new System.Windows.Forms.Button();
            this.groupBox_UART = new System.Windows.Forms.GroupBox();
            this.vr_connect = new System.Windows.Forms.CheckBox();
            this.txt_R_Lon = new System.Windows.Forms.TextBox();
            this.txt_R_Lat = new System.Windows.Forms.TextBox();
            this.txt_L_Lon = new System.Windows.Forms.TextBox();
            this.txt_L_Lat = new System.Windows.Forms.TextBox();
            this.Calibration_R = new System.Windows.Forms.Button();
            this.Calibration_L = new System.Windows.Forms.Button();
            this.txtfix_mode = new System.Windows.Forms.TextBox();
            this.txtvacc = new System.Windows.Forms.TextBox();
            this.txthacc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAlt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pos_Z = new System.Windows.Forms.TextBox();
            this.pos_Y = new System.Windows.Forms.TextBox();
            this.pos_X = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1_UDP = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox_UART.SuspendLayout();
            this.groupBox1_UDP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(7, 27);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(79, 50);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "接続";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(7, 85);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(79, 50);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "切断";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnXP
            // 
            this.btnXP.Location = new System.Drawing.Point(7, 75);
            this.btnXP.Margin = new System.Windows.Forms.Padding(4);
            this.btnXP.Name = "btnXP";
            this.btnXP.Size = new System.Drawing.Size(80, 40);
            this.btnXP.TabIndex = 4;
            this.btnXP.Text = "X+100";
            this.btnXP.UseVisualStyleBackColor = true;
            this.btnXP.Click += new System.EventHandler(this.btnXP_Click);
            // 
            // btnXM
            // 
            this.btnXM.Location = new System.Drawing.Point(7, 158);
            this.btnXM.Margin = new System.Windows.Forms.Padding(4);
            this.btnXM.Name = "btnXM";
            this.btnXM.Size = new System.Drawing.Size(80, 40);
            this.btnXM.TabIndex = 5;
            this.btnXM.Text = "X-100";
            this.btnXM.UseVisualStyleBackColor = true;
            this.btnXM.Click += new System.EventHandler(this.btnXM_Click);
            // 
            // btnXPP
            // 
            this.btnXPP.Location = new System.Drawing.Point(7, 27);
            this.btnXPP.Margin = new System.Windows.Forms.Padding(4);
            this.btnXPP.Name = "btnXPP";
            this.btnXPP.Size = new System.Drawing.Size(80, 40);
            this.btnXPP.TabIndex = 6;
            this.btnXPP.Text = "X+500";
            this.btnXPP.UseVisualStyleBackColor = true;
            this.btnXPP.Click += new System.EventHandler(this.btnXPP_Click);
            // 
            // btnXMM
            // 
            this.btnXMM.Location = new System.Drawing.Point(7, 206);
            this.btnXMM.Margin = new System.Windows.Forms.Padding(4);
            this.btnXMM.Name = "btnXMM";
            this.btnXMM.Size = new System.Drawing.Size(80, 40);
            this.btnXMM.TabIndex = 7;
            this.btnXMM.Text = "X-500";
            this.btnXMM.UseVisualStyleBackColor = true;
            this.btnXMM.Click += new System.EventHandler(this.btnXMM_Click);
            // 
            // btnYMM
            // 
            this.btnYMM.Location = new System.Drawing.Point(95, 206);
            this.btnYMM.Margin = new System.Windows.Forms.Padding(4);
            this.btnYMM.Name = "btnYMM";
            this.btnYMM.Size = new System.Drawing.Size(80, 40);
            this.btnYMM.TabIndex = 11;
            this.btnYMM.Text = "Y-500";
            this.btnYMM.UseVisualStyleBackColor = true;
            this.btnYMM.Click += new System.EventHandler(this.btnYMM_Click);
            // 
            // btnYPP
            // 
            this.btnYPP.Location = new System.Drawing.Point(95, 27);
            this.btnYPP.Margin = new System.Windows.Forms.Padding(4);
            this.btnYPP.Name = "btnYPP";
            this.btnYPP.Size = new System.Drawing.Size(80, 40);
            this.btnYPP.TabIndex = 10;
            this.btnYPP.Text = "Y+500";
            this.btnYPP.UseVisualStyleBackColor = true;
            this.btnYPP.Click += new System.EventHandler(this.btnYPP_Click);
            // 
            // btnYM
            // 
            this.btnYM.Location = new System.Drawing.Point(95, 158);
            this.btnYM.Margin = new System.Windows.Forms.Padding(4);
            this.btnYM.Name = "btnYM";
            this.btnYM.Size = new System.Drawing.Size(80, 40);
            this.btnYM.TabIndex = 9;
            this.btnYM.Text = "Y-100";
            this.btnYM.UseVisualStyleBackColor = true;
            this.btnYM.Click += new System.EventHandler(this.btnYM_Click);
            // 
            // btnYP
            // 
            this.btnYP.Location = new System.Drawing.Point(95, 75);
            this.btnYP.Margin = new System.Windows.Forms.Padding(4);
            this.btnYP.Name = "btnYP";
            this.btnYP.Size = new System.Drawing.Size(80, 40);
            this.btnYP.TabIndex = 8;
            this.btnYP.Text = "Y+100";
            this.btnYP.UseVisualStyleBackColor = true;
            this.btnYP.Click += new System.EventHandler(this.btnYP_Click);
            // 
            // btnZPP
            // 
            this.btnZPP.Location = new System.Drawing.Point(183, 27);
            this.btnZPP.Margin = new System.Windows.Forms.Padding(4);
            this.btnZPP.Name = "btnZPP";
            this.btnZPP.Size = new System.Drawing.Size(80, 40);
            this.btnZPP.TabIndex = 12;
            this.btnZPP.Text = "Z+500";
            this.btnZPP.UseVisualStyleBackColor = true;
            this.btnZPP.Click += new System.EventHandler(this.btnZPP_Click);
            // 
            // btnZP
            // 
            this.btnZP.Location = new System.Drawing.Point(183, 75);
            this.btnZP.Margin = new System.Windows.Forms.Padding(4);
            this.btnZP.Name = "btnZP";
            this.btnZP.Size = new System.Drawing.Size(80, 40);
            this.btnZP.TabIndex = 13;
            this.btnZP.Text = "Z+100";
            this.btnZP.UseVisualStyleBackColor = true;
            this.btnZP.Click += new System.EventHandler(this.btnZP_Click);
            // 
            // btnZM
            // 
            this.btnZM.Location = new System.Drawing.Point(183, 158);
            this.btnZM.Margin = new System.Windows.Forms.Padding(4);
            this.btnZM.Name = "btnZM";
            this.btnZM.Size = new System.Drawing.Size(80, 40);
            this.btnZM.TabIndex = 14;
            this.btnZM.Text = "Z-100";
            this.btnZM.UseVisualStyleBackColor = true;
            this.btnZM.Click += new System.EventHandler(this.btnZM_Click);
            // 
            // btnZMM
            // 
            this.btnZMM.Location = new System.Drawing.Point(183, 206);
            this.btnZMM.Margin = new System.Windows.Forms.Padding(4);
            this.btnZMM.Name = "btnZMM";
            this.btnZMM.Size = new System.Drawing.Size(80, 40);
            this.btnZMM.TabIndex = 15;
            this.btnZMM.Text = "Z-500";
            this.btnZMM.UseVisualStyleBackColor = true;
            this.btnZMM.Click += new System.EventHandler(this.btnZMM_Click);
            // 
            // txtXPos
            // 
            this.txtXPos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtXPos.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtXPos.Location = new System.Drawing.Point(7, 123);
            this.txtXPos.Margin = new System.Windows.Forms.Padding(4);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.ReadOnly = true;
            this.txtXPos.Size = new System.Drawing.Size(80, 27);
            this.txtXPos.TabIndex = 16;
            this.txtXPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYPos
            // 
            this.txtYPos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtYPos.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYPos.Location = new System.Drawing.Point(95, 123);
            this.txtYPos.Margin = new System.Windows.Forms.Padding(4);
            this.txtYPos.Name = "txtYPos";
            this.txtYPos.ReadOnly = true;
            this.txtYPos.Size = new System.Drawing.Size(80, 27);
            this.txtYPos.TabIndex = 17;
            this.txtYPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtZPos
            // 
            this.txtZPos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtZPos.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtZPos.Location = new System.Drawing.Point(183, 123);
            this.txtZPos.Margin = new System.Windows.Forms.Padding(4);
            this.txtZPos.Name = "txtZPos";
            this.txtZPos.ReadOnly = true;
            this.txtZPos.Size = new System.Drawing.Size(80, 27);
            this.txtZPos.TabIndex = 18;
            this.txtZPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(7, 142);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(79, 69);
            this.btnMenu.TabIndex = 19;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnUdonMenu
            // 
            this.btnUdonMenu.Location = new System.Drawing.Point(7, 216);
            this.btnUdonMenu.Name = "btnUdonMenu";
            this.btnUdonMenu.Size = new System.Drawing.Size(79, 69);
            this.btnUdonMenu.TabIndex = 20;
            this.btnUdonMenu.Text = "Udon\r\nMenu";
            this.btnUdonMenu.UseVisualStyleBackColor = true;
            this.btnUdonMenu.Click += new System.EventHandler(this.btnUdonMenu_Click);
            // 
            // btnXRM
            // 
            this.btnXRM.Location = new System.Drawing.Point(379, 27);
            this.btnXRM.Margin = new System.Windows.Forms.Padding(4);
            this.btnXRM.Name = "btnXRM";
            this.btnXRM.Size = new System.Drawing.Size(80, 40);
            this.btnXRM.TabIndex = 25;
            this.btnXRM.Text = "X-5deg";
            this.btnXRM.UseVisualStyleBackColor = true;
            this.btnXRM.Click += new System.EventHandler(this.btnXRM_Click_1);
            // 
            // btnXRP
            // 
            this.btnXRP.Location = new System.Drawing.Point(291, 27);
            this.btnXRP.Margin = new System.Windows.Forms.Padding(4);
            this.btnXRP.Name = "btnXRP";
            this.btnXRP.Size = new System.Drawing.Size(80, 40);
            this.btnXRP.TabIndex = 24;
            this.btnXRP.Text = "X+5deg";
            this.btnXRP.UseVisualStyleBackColor = true;
            this.btnXRP.Click += new System.EventHandler(this.btnXRP_Click);
            // 
            // btnYRM
            // 
            this.btnYRM.Location = new System.Drawing.Point(379, 123);
            this.btnYRM.Margin = new System.Windows.Forms.Padding(4);
            this.btnYRM.Name = "btnYRM";
            this.btnYRM.Size = new System.Drawing.Size(80, 40);
            this.btnYRM.TabIndex = 27;
            this.btnYRM.Text = "Y-5deg";
            this.btnYRM.UseVisualStyleBackColor = true;
            this.btnYRM.Click += new System.EventHandler(this.btnYRM_Click_1);
            // 
            // btnZRM
            // 
            this.btnZRM.Location = new System.Drawing.Point(291, 75);
            this.btnZRM.Margin = new System.Windows.Forms.Padding(4);
            this.btnZRM.Name = "btnZRM";
            this.btnZRM.Size = new System.Drawing.Size(80, 40);
            this.btnZRM.TabIndex = 28;
            this.btnZRM.Text = "Z-5deg";
            this.btnZRM.UseVisualStyleBackColor = true;
            this.btnZRM.Click += new System.EventHandler(this.btnZRM_Click_1);
            // 
            // btnYRP
            // 
            this.btnYRP.Location = new System.Drawing.Point(291, 123);
            this.btnYRP.Margin = new System.Windows.Forms.Padding(4);
            this.btnYRP.Name = "btnYRP";
            this.btnYRP.Size = new System.Drawing.Size(80, 40);
            this.btnYRP.TabIndex = 29;
            this.btnYRP.Text = "Y+5deg";
            this.btnYRP.UseVisualStyleBackColor = true;
            this.btnYRP.Click += new System.EventHandler(this.btnYRP_Click);
            // 
            // btnZRP
            // 
            this.btnZRP.Location = new System.Drawing.Point(379, 75);
            this.btnZRP.Margin = new System.Windows.Forms.Padding(4);
            this.btnZRP.Name = "btnZRP";
            this.btnZRP.Size = new System.Drawing.Size(80, 40);
            this.btnZRP.TabIndex = 30;
            this.btnZRP.Text = "Z+5deg";
            this.btnZRP.UseVisualStyleBackColor = true;
            this.btnZRP.Click += new System.EventHandler(this.btnZRP_Click);
            // 
            // btnPosReset
            // 
            this.btnPosReset.Location = new System.Drawing.Point(291, 189);
            this.btnPosReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnPosReset.Name = "btnPosReset";
            this.btnPosReset.Size = new System.Drawing.Size(80, 57);
            this.btnPosReset.TabIndex = 31;
            this.btnPosReset.Text = "Pos\r\nReset";
            this.btnPosReset.UseVisualStyleBackColor = true;
            this.btnPosReset.Click += new System.EventHandler(this.btnPosReset_Click);
            // 
            // btnRotReset
            // 
            this.btnRotReset.Location = new System.Drawing.Point(379, 189);
            this.btnRotReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnRotReset.Name = "btnRotReset";
            this.btnRotReset.Size = new System.Drawing.Size(80, 57);
            this.btnRotReset.TabIndex = 32;
            this.btnRotReset.Text = "Rot\r\nReset";
            this.btnRotReset.UseVisualStyleBackColor = true;
            this.btnRotReset.Click += new System.EventHandler(this.btnRotReset_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(101, 20);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(121, 28);
            this.comboBoxPorts.TabIndex = 33;
            // 
            // qzss_connect
            // 
            this.qzss_connect.Location = new System.Drawing.Point(228, 19);
            this.qzss_connect.Name = "qzss_connect";
            this.qzss_connect.Size = new System.Drawing.Size(65, 29);
            this.qzss_connect.TabIndex = 34;
            this.qzss_connect.Text = "接続";
            this.qzss_connect.UseVisualStyleBackColor = true;
            this.qzss_connect.Click += new System.EventHandler(this.qzss_connect_Click);
            // 
            // groupBox_UART
            // 
            this.groupBox_UART.Controls.Add(this.vr_connect);
            this.groupBox_UART.Controls.Add(this.txt_R_Lon);
            this.groupBox_UART.Controls.Add(this.txt_R_Lat);
            this.groupBox_UART.Controls.Add(this.txt_L_Lon);
            this.groupBox_UART.Controls.Add(this.txt_L_Lat);
            this.groupBox_UART.Controls.Add(this.Calibration_R);
            this.groupBox_UART.Controls.Add(this.Calibration_L);
            this.groupBox_UART.Controls.Add(this.txtfix_mode);
            this.groupBox_UART.Controls.Add(this.txtvacc);
            this.groupBox_UART.Controls.Add(this.txthacc);
            this.groupBox_UART.Controls.Add(this.label8);
            this.groupBox_UART.Controls.Add(this.label7);
            this.groupBox_UART.Controls.Add(this.label6);
            this.groupBox_UART.Controls.Add(this.txtAlt);
            this.groupBox_UART.Controls.Add(this.label5);
            this.groupBox_UART.Controls.Add(this.txtLon);
            this.groupBox_UART.Controls.Add(this.txtLat);
            this.groupBox_UART.Controls.Add(this.label4);
            this.groupBox_UART.Controls.Add(this.label3);
            this.groupBox_UART.Controls.Add(this.label1);
            this.groupBox_UART.Controls.Add(this.qzss_connect);
            this.groupBox_UART.Controls.Add(this.comboBoxPorts);
            this.groupBox_UART.Location = new System.Drawing.Point(12, 12);
            this.groupBox_UART.Name = "groupBox_UART";
            this.groupBox_UART.Size = new System.Drawing.Size(444, 300);
            this.groupBox_UART.TabIndex = 36;
            this.groupBox_UART.TabStop = false;
            this.groupBox_UART.Text = "QZSS 受信設定";
            // 
            // vr_connect
            // 
            this.vr_connect.AutoSize = true;
            this.vr_connect.Location = new System.Drawing.Point(309, 22);
            this.vr_connect.Name = "vr_connect";
            this.vr_connect.Size = new System.Drawing.Size(143, 24);
            this.vr_connect.TabIndex = 57;
            this.vr_connect.Text = "モーション連携";
            this.vr_connect.UseVisualStyleBackColor = true;
            // 
            // txt_R_Lon
            // 
            this.txt_R_Lon.Location = new System.Drawing.Point(311, 186);
            this.txt_R_Lon.Name = "txt_R_Lon";
            this.txt_R_Lon.ReadOnly = true;
            this.txt_R_Lon.Size = new System.Drawing.Size(120, 27);
            this.txt_R_Lon.TabIndex = 56;
            this.txt_R_Lon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_R_Lat
            // 
            this.txt_R_Lat.Location = new System.Drawing.Point(185, 186);
            this.txt_R_Lat.Name = "txt_R_Lat";
            this.txt_R_Lat.ReadOnly = true;
            this.txt_R_Lat.Size = new System.Drawing.Size(120, 27);
            this.txt_R_Lat.TabIndex = 55;
            this.txt_R_Lat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_L_Lon
            // 
            this.txt_L_Lon.Location = new System.Drawing.Point(311, 154);
            this.txt_L_Lon.Name = "txt_L_Lon";
            this.txt_L_Lon.ReadOnly = true;
            this.txt_L_Lon.Size = new System.Drawing.Size(120, 27);
            this.txt_L_Lon.TabIndex = 54;
            this.txt_L_Lon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_L_Lat
            // 
            this.txt_L_Lat.Location = new System.Drawing.Point(185, 153);
            this.txt_L_Lat.Name = "txt_L_Lat";
            this.txt_L_Lat.ReadOnly = true;
            this.txt_L_Lat.Size = new System.Drawing.Size(120, 27);
            this.txt_L_Lat.TabIndex = 53;
            this.txt_L_Lat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Calibration_R
            // 
            this.Calibration_R.Location = new System.Drawing.Point(5, 185);
            this.Calibration_R.Name = "Calibration_R";
            this.Calibration_R.Size = new System.Drawing.Size(174, 29);
            this.Calibration_R.TabIndex = 52;
            this.Calibration_R.Text = "キャリブレーション 右";
            this.Calibration_R.UseVisualStyleBackColor = true;
            this.Calibration_R.Click += new System.EventHandler(this.Calibration_R_Click);
            // 
            // Calibration_L
            // 
            this.Calibration_L.Location = new System.Drawing.Point(5, 153);
            this.Calibration_L.Name = "Calibration_L";
            this.Calibration_L.Size = new System.Drawing.Size(174, 29);
            this.Calibration_L.TabIndex = 51;
            this.Calibration_L.Text = "キャリブレーション 左";
            this.Calibration_L.UseVisualStyleBackColor = true;
            this.Calibration_L.Click += new System.EventHandler(this.Calibration_L_Click);
            // 
            // txtfix_mode
            // 
            this.txtfix_mode.BackColor = System.Drawing.SystemColors.Control;
            this.txtfix_mode.Location = new System.Drawing.Point(311, 116);
            this.txtfix_mode.Name = "txtfix_mode";
            this.txtfix_mode.ReadOnly = true;
            this.txtfix_mode.Size = new System.Drawing.Size(120, 27);
            this.txtfix_mode.TabIndex = 50;
            this.txtfix_mode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtvacc
            // 
            this.txtvacc.Location = new System.Drawing.Point(311, 83);
            this.txtvacc.Name = "txtvacc";
            this.txtvacc.ReadOnly = true;
            this.txtvacc.Size = new System.Drawing.Size(120, 27);
            this.txtvacc.TabIndex = 49;
            this.txtvacc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txthacc
            // 
            this.txthacc.Location = new System.Drawing.Point(311, 54);
            this.txthacc.Name = "txthacc";
            this.txthacc.ReadOnly = true;
            this.txthacc.Size = new System.Drawing.Size(120, 27);
            this.txthacc.TabIndex = 48;
            this.txthacc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "測位状態";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "垂直誤差[m]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "水平誤差[m]";
            // 
            // txtAlt
            // 
            this.txtAlt.Location = new System.Drawing.Point(61, 116);
            this.txtAlt.Name = "txtAlt";
            this.txtAlt.ReadOnly = true;
            this.txtAlt.Size = new System.Drawing.Size(120, 27);
            this.txtAlt.TabIndex = 44;
            this.txtAlt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "高度";
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(61, 83);
            this.txtLon.Name = "txtLon";
            this.txtLon.ReadOnly = true;
            this.txtLon.Size = new System.Drawing.Size(120, 27);
            this.txtLon.TabIndex = 42;
            this.txtLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(61, 51);
            this.txtLat.Name = "txtLat";
            this.txtLat.ReadOnly = true;
            this.txtLat.Size = new System.Drawing.Size(120, 27);
            this.txtLat.TabIndex = 41;
            this.txtLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "経度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "緯度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "SerialPort";
            // 
            // pos_Z
            // 
            this.pos_Z.Location = new System.Drawing.Point(368, 262);
            this.pos_Z.Name = "pos_Z";
            this.pos_Z.ReadOnly = true;
            this.pos_Z.Size = new System.Drawing.Size(75, 27);
            this.pos_Z.TabIndex = 60;
            this.pos_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pos_Y
            // 
            this.pos_Y.Location = new System.Drawing.Point(287, 262);
            this.pos_Y.Name = "pos_Y";
            this.pos_Y.ReadOnly = true;
            this.pos_Y.Size = new System.Drawing.Size(75, 27);
            this.pos_Y.TabIndex = 59;
            this.pos_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pos_X
            // 
            this.pos_X.Location = new System.Drawing.Point(206, 262);
            this.pos_X.Name = "pos_X";
            this.pos_X.ReadOnly = true;
            this.pos_X.Size = new System.Drawing.Size(75, 27);
            this.pos_X.TabIndex = 58;
            this.pos_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(218, 20);
            this.label9.TabIndex = 57;
            this.label9.Text = "位置(左右,上下,前後)[m]";
            // 
            // groupBox1_UDP
            // 
            this.groupBox1_UDP.Controls.Add(this.groupBox1);
            this.groupBox1_UDP.Controls.Add(this.btnConnect);
            this.groupBox1_UDP.Controls.Add(this.btnDisconnect);
            this.groupBox1_UDP.Controls.Add(this.btnMenu);
            this.groupBox1_UDP.Controls.Add(this.btnUdonMenu);
            this.groupBox1_UDP.Location = new System.Drawing.Point(462, 12);
            this.groupBox1_UDP.Name = "groupBox1_UDP";
            this.groupBox1_UDP.Size = new System.Drawing.Size(576, 300);
            this.groupBox1_UDP.TabIndex = 37;
            this.groupBox1_UDP.TabStop = false;
            this.groupBox1_UDP.Text = "OpenVR UDP送信設定";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXPP);
            this.groupBox1.Controls.Add(this.btnRotReset);
            this.groupBox1.Controls.Add(this.btnXP);
            this.groupBox1.Controls.Add(this.btnPosReset);
            this.groupBox1.Controls.Add(this.btnZRP);
            this.groupBox1.Controls.Add(this.txtXPos);
            this.groupBox1.Controls.Add(this.btnYRP);
            this.groupBox1.Controls.Add(this.btnXM);
            this.groupBox1.Controls.Add(this.btnZRM);
            this.groupBox1.Controls.Add(this.btnXMM);
            this.groupBox1.Controls.Add(this.btnYRM);
            this.groupBox1.Controls.Add(this.btnYPP);
            this.groupBox1.Controls.Add(this.btnXRM);
            this.groupBox1.Controls.Add(this.btnYP);
            this.groupBox1.Controls.Add(this.btnXRP);
            this.groupBox1.Controls.Add(this.txtYPos);
            this.groupBox1.Controls.Add(this.btnYM);
            this.groupBox1.Controls.Add(this.btnYMM);
            this.groupBox1.Controls.Add(this.btnZPP);
            this.groupBox1.Controls.Add(this.btnZP);
            this.groupBox1.Controls.Add(this.btnZMM);
            this.groupBox1.Controls.Add(this.txtZPos);
            this.groupBox1.Controls.Add(this.btnZM);
            this.groupBox1.Location = new System.Drawing.Point(93, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 258);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原点位置調整[mm],角度調整[deg]";
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 921600;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 321);
            this.Controls.Add(this.groupBox1_UDP);
            this.Controls.Add(this.pos_Z);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pos_Y);
            this.Controls.Add(this.pos_X);
            this.Controls.Add(this.groupBox_UART);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Nadellite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_UART.ResumeLayout(false);
            this.groupBox_UART.PerformLayout();
            this.groupBox1_UDP.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnXP;
        private System.Windows.Forms.Button btnXM;
        private System.Windows.Forms.Button btnXPP;
        private System.Windows.Forms.Button btnXMM;
        private System.Windows.Forms.Button btnYMM;
        private System.Windows.Forms.Button btnYPP;
        private System.Windows.Forms.Button btnYM;
        private System.Windows.Forms.Button btnYP;
        private System.Windows.Forms.Button btnZPP;
        private System.Windows.Forms.Button btnZP;
        private System.Windows.Forms.Button btnZM;
        private System.Windows.Forms.Button btnZMM;
        private System.Windows.Forms.TextBox txtXPos;
        private System.Windows.Forms.TextBox txtYPos;
        private System.Windows.Forms.TextBox txtZPos;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnUdonMenu;
        private System.Windows.Forms.Button btnXRM;
        private System.Windows.Forms.Button btnXRP;
        private System.Windows.Forms.Button btnYRM;
        private System.Windows.Forms.Button btnZRM;
        private System.Windows.Forms.Button btnYRP;
        private System.Windows.Forms.Button btnZRP;
        private System.Windows.Forms.Button btnPosReset;
        private System.Windows.Forms.Button btnRotReset;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button qzss_connect;
        private System.Windows.Forms.GroupBox groupBox_UART;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAlt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtfix_mode;
        private System.Windows.Forms.TextBox txtvacc;
        private System.Windows.Forms.TextBox txthacc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Calibration_R;
        private System.Windows.Forms.Button Calibration_L;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_R_Lon;
        private System.Windows.Forms.TextBox txt_R_Lat;
        private System.Windows.Forms.TextBox txt_L_Lon;
        private System.Windows.Forms.TextBox txt_L_Lat;
        private System.Windows.Forms.TextBox pos_Z;
        private System.Windows.Forms.TextBox pos_Y;
        private System.Windows.Forms.TextBox pos_X;
        private System.Windows.Forms.GroupBox groupBox1_UDP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.CheckBox vr_connect;
    }
}

