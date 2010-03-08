namespace ParcelDeliverySystem
{
    partial class Local_OverseasPostageRates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Local_OverseasPostageRates));
            this.lorBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lorBox
            // 
            this.lorBox.Image = ((System.Drawing.Image)(resources.GetObject("lorBox.Image")));
            this.lorBox.Location = new System.Drawing.Point(2, -3);
            this.lorBox.Name = "lorBox";
            this.lorBox.Size = new System.Drawing.Size(686, 2000);
            this.lorBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lorBox.TabIndex = 0;
            this.lorBox.TabStop = false;
            // 
            // Local_OverseasPostageRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(726, 521);
            this.Controls.Add(this.lorBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Local_OverseasPostageRates";
            this.Text = "Local_OverseasPostageRates";
            this.Resize += new System.EventHandler(this.Local_OverseasPostageRates_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.lorBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox lorBox;



    }
}