using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParcelDeliverySystem
{
    public partial class Local_OverseasPostageRates : Form
    {
        public Local_OverseasPostageRates()
        {
            InitializeComponent();
        }

        //private void Local_OverseasPostageRates_Load(object sender, EventArgs e)
        //{
        //    lorBox.SizeMode = PictureBoxSizeMode.Zoom;

        //}

        private void Local_OverseasPostageRates_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            lorBox.Width = control.Width;
            //lorBox.Height = control.Height;

        }
    }
}
