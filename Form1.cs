using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ParcelDeliverySystem
{
    public partial class PDS : Form
    {
        public PDS()
        {
            InitializeComponent();
        }

        private void PDS_Load(object sender, EventArgs e)
        {

        }
        // Clicking on Local/Overseas Postage Rates button to show the detail in pdf format
        private void rateCost_Click(object sender, EventArgs e)
        {
            Local_OverseasPostageRates alternativeForm = new Local_OverseasPostageRates();
            try
            {
                alternativeForm.Show();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Missing File is found.", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        // To check whether picking date is match with present day or later
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            int YearNow = DateTime.Now.Year;
            int MonthNow = DateTime.Now.Month;
            int DayNow = DateTime.Now.Day;

            if (this.datePicker.Value.Year >= YearNow)
            {
                if (this.datePicker.Value.Year == YearNow)
                {
                    errorMessage.SetError(this.datePicker, "");
                    if (this.datePicker.Value.Month >= MonthNow)
                    {
                        if (this.datePicker.Value.Month == MonthNow)
                        {
                            if (this.datePicker.Value.Day >= DayNow)
                            {
                                errorMessage.SetError(this.datePicker, "");
                            }
                            else
                            {
                                MessageBox.Show("Pls enter the present day or later!", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                errorMessage.SetError(this.datePicker, "Pls enter the present day or later!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pls enter the present month or later!", "Error", MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        errorMessage.SetError(this.datePicker, "Pls enter the present month or later!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Pls enter the present year or later!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorMessage.BlinkRate = 5000;
                errorMessage.SetError(this.datePicker, "Pls enter the present year or later!");
            }
        }

        private void calBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
