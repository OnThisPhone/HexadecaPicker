namespace HexadecaPicker
{
    partial class formZoom
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
            this.pctZoom = new System.Windows.Forms.PictureBox();
            this.pctTarget = new System.Windows.Forms.PictureBox();
            this.pctCurrentColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCurrentColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pctZoom
            // 
            this.pctZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctZoom.Location = new System.Drawing.Point(0, 0);
            this.pctZoom.Name = "pctZoom";
            this.pctZoom.Size = new System.Drawing.Size(120, 120);
            this.pctZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctZoom.TabIndex = 0;
            this.pctZoom.TabStop = false;
            // 
            // pctTarget
            // 
            this.pctTarget.BackColor = System.Drawing.Color.Transparent;
            this.pctTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctTarget.InitialImage = null;
            this.pctTarget.Location = new System.Drawing.Point(64, 62);
            this.pctTarget.Name = "pctTarget";
            this.pctTarget.Size = new System.Drawing.Size(1, 1);
            this.pctTarget.TabIndex = 1;
            this.pctTarget.TabStop = false;
            // 
            // pctCurrentColor
            // 
            this.pctCurrentColor.BackColor = System.Drawing.Color.IndianRed;
            this.pctCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctCurrentColor.Location = new System.Drawing.Point(0, 0);
            this.pctCurrentColor.Name = "pctCurrentColor";
            this.pctCurrentColor.Size = new System.Drawing.Size(20, 20);
            this.pctCurrentColor.TabIndex = 2;
            this.pctCurrentColor.TabStop = false;
            // 
            // formZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(120, 120);
            this.Controls.Add(this.pctCurrentColor);
            this.Controls.Add(this.pctTarget);
            this.Controls.Add(this.pctZoom);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formZoom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Zoom";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pctZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCurrentColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctZoom;
        private System.Windows.Forms.PictureBox pctTarget;
        private System.Windows.Forms.PictureBox pctCurrentColor;
    }
}