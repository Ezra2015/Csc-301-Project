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
        // Parsing the text file in current directory
        TextParse txtFile = new TextParse();
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
                    errorDate.SetError(this.datePicker, "");
                    if (this.datePicker.Value.Month >= MonthNow)
                    {
                        if (this.datePicker.Value.Month == MonthNow)
                        {
                            if (this.datePicker.Value.Day >= DayNow)
                            {
                                errorDate.SetError(this.datePicker, "");
                            }
                            else
                            {
                                MessageBox.Show("Pls enter the present day or later!", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                errorDate.SetError(this.datePicker, "Pls enter the present day or later!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pls enter the present month or later!", "Error", MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        errorDate.SetError(this.datePicker, "Pls enter the present month or later!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Pls enter the present year or later!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorDate.BlinkRate = 5000;
                errorDate.SetError(this.datePicker, "Pls enter the present year or later!");
            }
        }

        //Overridden the Tab pressed
        protected override bool ProcessDialogKey(Keys keyData)
        {
            base.ProcessDialogKey(keyData);
            return false;
        }
        // check whether Origin Postal Code is matched in text file
        private void opcTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab))
            {
                this.Cursor = Cursors.No;
                //check whether some chars or string is in textbox
                int integer;
                string str = opcTxtBox.Text.Trim();
                bool isNum = int.TryParse(str, out integer);
                if (isNum)
                {
                    Boolean statusFound = false;
                    switch (OrigCountryCombo.SelectedItem.ToString())
                    {
                        case "SIN":
                            int[] getSinPostalCode = txtFile.sinPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getSinPostalCode[i])
                                {
                                    statusFound = true;
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    statusFound = false;
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Pls enter correct postal code.");
                                }
                            if (statusFound == true)
                            {
                                MessageBox.Show(opcTxtBox.Text + " is matched.", "FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show(opcTxtBox.Text + "is not matched.", "NOT FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            break;
                        case "MAS":
                            int[] getMasPostalCode = txtFile.masPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getMasPostalCode[i])
                                {
                                    statusFound = true;
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    statusFound = false;
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Pls enter correct postal code.");
                                }
                            if (statusFound == true)
                            {
                                MessageBox.Show(opcTxtBox.Text + " is matched.", "FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show(opcTxtBox.Text + "is not matched.", "NOT FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            break;
                        case "USA":
                            int[] getUSPostalCode = txtFile.usPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getUSPostalCode[i])
                                {
                                    statusFound = true;
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    statusFound = false;
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Pls enter correct postal code.");
                                }
                            if (statusFound == true)
                            {
                                MessageBox.Show(opcTxtBox.Text + " is matched.", "FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show(opcTxtBox.Text + "is not matched.", "NOT FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Pls enter the number only", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        // check whether Destination Postal Code is matched in text file
        private void dpcTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab))
            {
                //check whether some chars or string is in textbox
                int integer;
                string str = dpcTxtBox.Text.Trim();
                bool isNum = int.TryParse(str, out integer);
                if (isNum)
                {
                    Boolean statusFound = false;
                    switch (OrigCountryCombo.SelectedItem.ToString())
                    {
                        case "SIN":
                            int[] getSinPostalCode = txtFile.sinPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getSinPostalCode[i])
                                {
                                    statusFound = true;
                                    errorPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    statusFound = false;
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Pls enter correct postal code.");
                                }
                            if (statusFound == true)
                            {
                                MessageBox.Show(dpcTxtBox.Text + " is matched.", "FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show(dpcTxtBox.Text + "is not matched.", "NOT FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            break;
                        case "MAS":
                            int[] getMasPostalCode = txtFile.masPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getMasPostalCode[i])
                                {
                                    statusFound = true;
                                    errorDPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    statusFound = false;
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Pls enter correct postal code.");
                                }
                            if (statusFound == true)
                            {
                                MessageBox.Show(dpcTxtBox.Text + " is matched.", "FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show(dpcTxtBox.Text + "is not matched.", "NOT FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            break;
                        case "USA":
                            int[] getUSPostalCode = txtFile.usPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getUSPostalCode[i])
                                {
                                    statusFound = true;
                                    errorDPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    statusFound = false;
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Pls enter correct postal code.");
                                }
                            if (statusFound == true)
                            {
                                MessageBox.Show(dpcTxtBox.Text + " is matched.", "FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            else
                            {
                                MessageBox.Show(dpcTxtBox.Text + "is not matched.", "NOT FOUND", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Pls enter the number only", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void calBtn_Click(object sender, EventArgs e)
        {

        }
    }
    //public class MyTextBox : TextBox
    //{
    //    const int WM_LBUTTONDOWN = 0x0201;

    //    protected override void WndProc(ref System.Windows.Forms.Message m)
    //    {
    //        if (m.Msg == WM_LBUTTONDOWN)
    //            return;
    //        base.WndProc(ref m);
    //    }
    //} 
}
