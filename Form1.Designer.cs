namespace HexadecaPicker
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnCopyColorHex = new System.Windows.Forms.Button();
            this.btnPick = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCopyColorRgb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopyColorHsl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblColorType = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ntf = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnOptionsMenu = new System.Windows.Forms.Button();
            this.pctCurrentColor = new System.Windows.Forms.PictureBox();
            this.chkLowerCase = new System.Windows.Forms.CheckBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.btnZoomWindow = new System.Windows.Forms.Button();
            this.chkAutoZoom = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCurrentColor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCopyColorHex
            // 
            this.btnCopyColorHex.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCopyColorHex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyColorHex.Location = new System.Drawing.Point(38, 3);
            this.btnCopyColorHex.Name = "btnCopyColorHex";
            this.btnCopyColorHex.Size = new System.Drawing.Size(188, 25);
            this.btnCopyColorHex.TabIndex = 0;
            this.btnCopyColorHex.TabStop = false;
            this.btnCopyColorHex.Text = "#FFFFFF";
            this.btnCopyColorHex.UseVisualStyleBackColor = true;
            this.btnCopyColorHex.Click += new System.EventHandler(this.btnCopyColorHex_Click);
            // 
            // btnPick
            // 
            this.btnPick.Location = new System.Drawing.Point(49, 168);
            this.btnPick.Margin = new System.Windows.Forms.Padding(0);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(153, 38);
            this.btnPick.TabIndex = 2;
            this.btnPick.Text = "Pick Color";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnCopyColorRgb, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCopyColorHsl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCopyColorHex, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblColorType, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(233, 95);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnCopyColorRgb
            // 
            this.btnCopyColorRgb.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCopyColorRgb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyColorRgb.Location = new System.Drawing.Point(38, 65);
            this.btnCopyColorRgb.Name = "btnCopyColorRgb";
            this.btnCopyColorRgb.Size = new System.Drawing.Size(188, 25);
            this.btnCopyColorRgb.TabIndex = 5;
            this.btnCopyColorRgb.TabStop = false;
            this.btnCopyColorRgb.Text = "(255,255,100)";
            this.btnCopyColorRgb.UseVisualStyleBackColor = true;
            this.btnCopyColorRgb.Click += new System.EventHandler(this.btnCopyColorRgb_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "RGB";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCopyColorHsl
            // 
            this.btnCopyColorHsl.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCopyColorHsl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyColorHsl.Location = new System.Drawing.Point(38, 34);
            this.btnCopyColorHsl.Name = "btnCopyColorHsl";
            this.btnCopyColorHsl.Size = new System.Drawing.Size(188, 25);
            this.btnCopyColorHsl.TabIndex = 3;
            this.btnCopyColorHsl.TabStop = false;
            this.btnCopyColorHsl.Text = "(270, 100, 20)";
            this.btnCopyColorHsl.UseVisualStyleBackColor = true;
            this.btnCopyColorHsl.Click += new System.EventHandler(this.btnCopyColorHsl_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "HSL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblColorType
            // 
            this.lblColorType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColorType.AutoSize = true;
            this.lblColorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorType.Location = new System.Drawing.Point(3, 9);
            this.lblColorType.Name = "lblColorType";
            this.lblColorType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblColorType.Size = new System.Drawing.Size(28, 13);
            this.lblColorType.TabIndex = 1;
            this.lblColorType.Text = "HEX";
            this.lblColorType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(0, 211);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(258, 23);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ntf
            // 
            this.ntf.Icon = ((System.Drawing.Icon)(resources.GetObject("ntf.Icon")));
            this.ntf.Text = "Hexadeca Picker";
            this.ntf.Visible = true;
            // 
            // btnOptionsMenu
            // 
            this.btnOptionsMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOptionsMenu.BackgroundImage = global::HexadecaPicker.Properties.Resources.more_horiz;
            this.btnOptionsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOptionsMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOptionsMenu.FlatAppearance.BorderSize = 0;
            this.btnOptionsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptionsMenu.Location = new System.Drawing.Point(233, 211);
            this.btnOptionsMenu.Name = "btnOptionsMenu";
            this.btnOptionsMenu.Size = new System.Drawing.Size(24, 22);
            this.btnOptionsMenu.TabIndex = 7;
            this.btnOptionsMenu.UseVisualStyleBackColor = false;
            this.btnOptionsMenu.Click += new System.EventHandler(this.btnOptionsMenu_Click);
            // 
            // pctCurrentColor
            // 
            this.pctCurrentColor.BackColor = System.Drawing.Color.IndianRed;
            this.pctCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctCurrentColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctCurrentColor.Location = new System.Drawing.Point(12, 173);
            this.pctCurrentColor.Name = "pctCurrentColor";
            this.pctCurrentColor.Size = new System.Drawing.Size(28, 28);
            this.pctCurrentColor.TabIndex = 1;
            this.pctCurrentColor.TabStop = false;
            this.pctCurrentColor.Click += new System.EventHandler(this.pctCurrentColor_Click);
            // 
            // chkLowerCase
            // 
            this.chkLowerCase.AutoSize = true;
            this.chkLowerCase.Checked = global::HexadecaPicker.Properties.Settings.Default.LowerCase;
            this.chkLowerCase.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::HexadecaPicker.Properties.Settings.Default, "LowerCase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkLowerCase.Location = new System.Drawing.Point(49, 123);
            this.chkLowerCase.Name = "chkLowerCase";
            this.chkLowerCase.Size = new System.Drawing.Size(82, 17);
            this.chkLowerCase.TabIndex = 6;
            this.chkLowerCase.Text = "Lower Case";
            this.chkLowerCase.UseVisualStyleBackColor = true;
            this.chkLowerCase.CheckedChanged += new System.EventHandler(this.chkLowerCase_CheckedChanged);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Checked = global::HexadecaPicker.Properties.Settings.Default.AutoStart;
            this.chkAutoStart.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::HexadecaPicker.Properties.Settings.Default, "AutoStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAutoStart.Location = new System.Drawing.Point(50, 146);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(164, 17);
            this.chkAutoStart.TabIndex = 4;
            this.chkAutoStart.Text = "Auto Start App with Windows";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // btnZoomWindow
            // 
            this.btnZoomWindow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoomWindow.BackgroundImage")));
            this.btnZoomWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomWindow.Location = new System.Drawing.Point(205, 168);
            this.btnZoomWindow.Name = "btnZoomWindow";
            this.btnZoomWindow.Size = new System.Drawing.Size(38, 38);
            this.btnZoomWindow.TabIndex = 8;
            this.btnZoomWindow.UseVisualStyleBackColor = true;
            this.btnZoomWindow.Click += new System.EventHandler(this.btnZoomWindow_Click);
            // 
            // chkAutoZoom
            // 
            this.chkAutoZoom.AutoSize = true;
            this.chkAutoZoom.Checked = global::HexadecaPicker.Properties.Settings.Default.AutoZoom;
            this.chkAutoZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoZoom.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::HexadecaPicker.Properties.Settings.Default, "AutoZoom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAutoZoom.Location = new System.Drawing.Point(138, 123);
            this.chkAutoZoom.Name = "chkAutoZoom";
            this.chkAutoZoom.Size = new System.Drawing.Size(78, 17);
            this.chkAutoZoom.TabIndex = 9;
            this.chkAutoZoom.Text = "Auto Zoom";
            this.chkAutoZoom.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 234);
            this.Controls.Add(this.chkAutoZoom);
            this.Controls.Add(this.btnZoomWindow);
            this.Controls.Add(this.btnOptionsMenu);
            this.Controls.Add(this.chkLowerCase);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pctCurrentColor);
            this.Controls.Add(this.btnPick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hexadeca Picker";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCurrentColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCopyColorHex;
        private System.Windows.Forms.PictureBox pctCurrentColor;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblColorType;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Button btnCopyColorRgb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCopyColorHsl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkLowerCase;
        private System.Windows.Forms.Button btnOptionsMenu;
        private System.Windows.Forms.NotifyIcon ntf;
        private System.Windows.Forms.Button btnZoomWindow;
        private System.Windows.Forms.CheckBox chkAutoZoom;
    }
}

