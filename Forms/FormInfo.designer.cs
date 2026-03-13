namespace MifareTool
{
    partial class FormInfo
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
            this.ucINFO1 = new MifareTool.Controls.ucINFO();
            this.SuspendLayout();
            // 
            // ucINFO1
            // 
            this.ucINFO1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucINFO1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucINFO1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucINFO1.Location = new System.Drawing.Point(0, 0);
            this.ucINFO1.Margin = new System.Windows.Forms.Padding(4);
            this.ucINFO1.Name = "ucINFO1";
            this.ucINFO1.Size = new System.Drawing.Size(1697, 750);
            this.ucINFO1.TabIndex = 0;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1697, 750);
            this.ControlBox = false;
            this.Controls.Add(this.ucINFO1);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormInfo";
            this.Activated += new System.EventHandler(this.FormInfo_Activated);
            this.Deactivate += new System.EventHandler(this.FormInfo_Deactivate);
            this.Load += new System.EventHandler(this.FormInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MifareTool.Controls.ucINFO ucINFO1;
    }
}