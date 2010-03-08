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
        // get generated UI design
        public PDS()
        {
            InitializeComponent();
        }
        // Load the Application front page
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
        // stop moving from orign postal code control to next control such as moving caret around and checking as well
        private void opcTxtBox_TextChanged(object sender, System.EventArgs e)
        {
                            //check whether some chars or string is in textbox
            int integer;
            string str = opcTxtBox.Text.Trim();
            bool isNum = int.TryParse(str, out integer);
            if (isNum)
            {
                switch (OrigCountryCombo.SelectedItem.ToString())
                {
                    case "SIN":
                        if (opcTxtBox.Text != "" && opcTxtBox.TextLength == 6)
                        {
                            int[] getSinPostalCode = txtFile.sinPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getSinPostalCode[i])
                                {
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Not matched with SIN postal codes in database!");
                                }
                        }
                        else
                        {
                            errorPC.BlinkRate = 1000;
                            errorPC.SetError(this.opcTxtBox, "Not matched with SIN postal codes in database!");
                        }
                        break;
                    case "MAS":
                        if (opcTxtBox.Text != "" && opcTxtBox.TextLength == 6)
                        {
                            int[] getMasPostalCode = txtFile.masPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getMasPostalCode[i])
                                {
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Not matched with SIN postal codes in database!");
                                }
                        }
                        else
                        {
                            errorPC.BlinkRate = 1000;
                            errorPC.SetError(this.opcTxtBox, "Not matched with SIN postal codes in database!");
                        }
                        break;
                    case "USA":
                        if (opcTxtBox.Text != "" && opcTxtBox.TextLength == 6)
                        {
                            int[] getUSPostalCode = txtFile.usPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getUSPostalCode[i])
                                {
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Not matched with SIN postal codes in database!");
                                }
                        }
                        else
                        {
                            errorPC.BlinkRate = 1000;
                            errorPC.SetError(this.opcTxtBox, "Not matched with SIN postal codes in database!");
                        }
                        break;
                }
            }
            else
            {
                errorPC.BlinkRate = 1000;
                errorPC.SetError(this.opcTxtBox, "Pls enter numbers only!");
            }
        }
        // stop moving from destination postal code control to next control such as moving caret around and checking as well
        private void dpcTxtBox_TextChanged(object sender, System.EventArgs e)
        {
            //check whether some chars or string is in textbox
            int integer;
            string str = dpcTxtBox.Text.Trim();
            bool isNum = int.TryParse(str, out integer);
            if (isNum)
            {
                switch (OrigCountryCombo.SelectedItem.ToString())
                {
                    case "SIN":
                        if (dpcTxtBox.Text != "" && dpcTxtBox.TextLength == 6)
                        {
                            int[] getSinPostalCode = txtFile.sinPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getSinPostalCode[i])
                                {
                                    errorDPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Not matched with SIN postal codes in database!");
                                }
                        }
                        else
                        {
                            errorDPC.BlinkRate = 1000;
                            errorDPC.SetError(this.dpcTxtBox, "Not matched with SIN postal codes in database!");
                        }
                        break;
                    case "MAS":
                        if (dpcTxtBox.Text != "" && dpcTxtBox.TextLength == 6)
                        {
                            int[] getMasPostalCode = txtFile.masPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getMasPostalCode[i])
                                {
                                    errorDPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Not matched with SIN postal codes in database!");
                                }
                        }
                        else
                        {
                            errorDPC.BlinkRate = 1000;
                            errorDPC.SetError(this.dpcTxtBox, "Not matched with SIN postal codes in database!");
                        }
                        break;
                    case "USA":
                        if (dpcTxtBox.Text != "" && dpcTxtBox.TextLength == 6)
                        {
                            int[] getUSPostalCode = txtFile.usPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getUSPostalCode[i])
                                {
                                    errorDPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Not matched with SIN postal codes in database!");
                                }
                        }
                        else
                        {
                            errorDPC.BlinkRate = 1000;
                            errorDPC.SetError(this.dpcTxtBox, "Not matched with SIN postal codes in database!");
                        }
                        break;
                }
            }
            else
            {
                errorDPC.BlinkRate = 1000;
                errorDPC.SetError(this.dpcTxtBox, "Pls enter numbers only!");
            }
        }
        // check whether Origin Postal Code is matched in text file in key events only
        private void opcTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                //check whether some chars or string is in textbox
                int integer;
                string str = opcTxtBox.Text.Trim();
                bool isNum = int.TryParse(str, out integer);
                if (isNum)
                {
                    switch (OrigCountryCombo.SelectedItem.ToString())
                    {
                        case "SIN":
                            int[] getSinPostalCode = txtFile.sinPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getSinPostalCode[i])
                                {
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Pls enter correct postal code.");
                                }
                            break;
                        case "MAS":
                            int[] getMasPostalCode = txtFile.masPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getMasPostalCode[i])
                                {
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Pls enter correct postal code.");
                                }
                            break;
                        case "USA":
                            int[] getUSPostalCode = txtFile.usPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(opcTxtBox.Text) == getUSPostalCode[i])
                                {
                                    errorPC.SetError(this.opcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorPC.BlinkRate = 1000;
                                    errorPC.SetError(this.opcTxtBox, "Pls enter correct postal code.");
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
        // check whether Destination Postal Code is matched in text file in key events only
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
                    switch (OrigCountryCombo.SelectedItem.ToString())
                    {
                        case "SIN":
                            int[] getSinPostalCode = txtFile.sinPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getSinPostalCode[i])
                                {
                                    errorDPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Pls enter correct postal code.");
                                }
                            break;
                        case "MAS":
                            int[] getMasPostalCode = txtFile.masPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getMasPostalCode[i])
                                {
                                    errorDPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Pls enter correct postal code.");
                                }
                            break;
                        case "USA":
                            int[] getUSPostalCode = txtFile.usPostalCode();
                            for (int i = 0; i < 37; i++)
                                if (int.Parse(dpcTxtBox.Text) == getUSPostalCode[i])
                                {
                                    errorDPC.SetError(this.dpcTxtBox, "");
                                    break;
                                }
                                else
                                {
                                    errorDPC.BlinkRate = 1000;
                                    errorDPC.SetError(this.dpcTxtBox, "Pls enter correct postal code.");
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
        // Calculate the estimated delivery time
        private void calBtn_Click(object sender, EventArgs e)
        {
            // create the instance of the result of Estimated delivery Time
            EDTOutput edtOutput = new EDTOutput();
            if (this.errorDate.GetError(this.datePicker) == "" && this.errorDPC.GetError(this.dpcTxtBox) == "" &&
                this.errorPC.GetError(this.opcTxtBox) == "")
            {                                
                string[] dsresult = txtFile.threeDeliveryService();
                edtOutput.getdslbl1.Text = dsresult[0];
                edtOutput.getdslbl2.Text = dsresult[1];
                edtOutput.getdslbl3.Text = dsresult[2];

                string[] getAvailabledays = txtFile.availableDaysOrigin_3DestDHL();

                switch (OrigCountryCombo.SelectedItem.ToString())
                {
                    case "SIN":
                        int[] getWorkingDaysSIN_DHL = txtFile.workingDaysSIN_DHL();
                        int[] getWorkingDaysSIN_Fedex = txtFile.workingDaysSIN_Fedex();
                        int[] getWorkingDaysSIN_SpeedPost = txtFile.workingDaysSIN_SpeedPost();
                        switch (DestCountryCombo.SelectedItem.ToString())
                        {
                            case "SIN":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}",this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}",this.datePicker.Value.Month) + "/" + 
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n"+ "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysSIN_DHL[0].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysSIN_Fedex[0].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysSIN_SpeedPost[0].ToString();

                                if (getAvailabledays[0].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_DHL[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_Fedex[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_SpeedPost[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[0]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_DHL[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_Fedex[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_SpeedPost[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }

                                break;
                            case "MAS":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysSIN_DHL[1].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysSIN_Fedex[1].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysSIN_SpeedPost[1].ToString();
                                
                                if(getAvailabledays[1].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_DHL[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_Fedex[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_SpeedPost[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[1]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_DHL[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_Fedex[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_SpeedPost[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }
                                break;
                            case "USA":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysSIN_DHL[2].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysSIN_Fedex[2].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysSIN_SpeedPost[2].ToString();

                                if (getAvailabledays[2].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_DHL[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_Fedex[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_SpeedPost[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[2]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_DHL[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_Fedex[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysSIN_SpeedPost[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }

                                break;
                        }
                        break;
                    case "MAS":
                    int[] getWorkingDaysMAS_DHL = txtFile.workingDaysMAS_DHL();
                    int[] getWorkingDaysMAS_Fedex = txtFile.workingDaysMAS_Fedex();
                    int[] getWorkingDaysMAS_SpeedPost = txtFile.workingDaysMAS_SpeedPost();

                    switch (DestCountryCombo.SelectedItem.ToString())
                        {
                         case "MAS":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}",this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}",this.datePicker.Value.Month) + "/" + 
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n"+ "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysMAS_DHL[0].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysMAS_Fedex[0].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysMAS_SpeedPost[0].ToString();

                                if (getAvailabledays[0].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_DHL[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_Fedex[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_SpeedPost[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[0]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_DHL[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_Fedex[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_SpeedPost[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }

                                break;
                            case "SIN":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysMAS_DHL[1].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysMAS_Fedex[1].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysMAS_SpeedPost[1].ToString();

                                if (getAvailabledays[1].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_DHL[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_Fedex[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_SpeedPost[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[1]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_DHL[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_Fedex[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_SpeedPost[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }
                                break;
                            case "USA":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysMAS_DHL[2].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysMAS_Fedex[2].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysMAS_SpeedPost[2].ToString();

                                if (getAvailabledays[2].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_DHL[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_Fedex[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_SpeedPost[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[2]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_DHL[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_Fedex[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysMAS_SpeedPost[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }

                                break;

                        }
                        break;
                    case "USA":
                        int[] getWorkingDaysUSA_DHL = txtFile.workingDaysUSA_DHL();
                        int[] getWorkingDaysUSA_Fedex = txtFile.workingDaysUSA_Fedex();
                        int[] getWorkingDaysUSA_SpeedPost = txtFile.workingDaysUSA_SpeedPost();

                        switch (DestCountryCombo.SelectedItem.ToString())
                        {
                            case "USA":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysUSA_DHL[0].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysUSA_Fedex[0].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysUSA_SpeedPost[0].ToString();

                                if(getAvailabledays[0].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_DHL[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_Fedex[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_SpeedPost[0] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[0].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[0]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_DHL[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_Fedex[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_SpeedPost[0] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }

                                break;
                            case "SIN":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysUSA_DHL[1].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysUSA_Fedex[1].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysUSA_SpeedPost[1].ToString();

                                if(getAvailabledays[1].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_DHL[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_Fedex[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_SpeedPost[1] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[1].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[1]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_DHL[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_Fedex[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_SpeedPost[1] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }

                                break;
                            case "MAS":
                                edtOutput.getoclbl1.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl2.Text = this.OrigCountryCombo.SelectedItem.ToString();
                                edtOutput.getoclbl3.Text = this.OrigCountryCombo.SelectedItem.ToString();

                                edtOutput.getdclbl1.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl2.Text = this.DestCountryCombo.SelectedItem.ToString();
                                edtOutput.getdclbl3.Text = this.DestCountryCombo.SelectedItem.ToString();

                                edtOutput.getsdlbl1.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl2.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";
                                edtOutput.getsdlbl3.Text = (String.Format("{0:00}", this.datePicker.Value.Day) + "/" +
                                    String.Format("{0:00}", this.datePicker.Value.Month) + "/" +
                                    String.Format("{0:0000}", this.datePicker.Value.Year)) + "\n" + "(" +
                                    this.timeCombo.SelectedItem.ToString() + ")";

                                edtOutput.getwdlbl1.Text = getWorkingDaysUSA_DHL[2].ToString();
                                edtOutput.getwdlbl2.Text = getWorkingDaysUSA_Fedex[2].ToString();
                                edtOutput.getwdlbl3.Text = getWorkingDaysUSA_SpeedPost[2].ToString();

                                if(getAvailabledays[2].StartsWith("All"))
                                {
                                    if (this.datePicker.Value.Minute != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                    }
                                    if (this.datePicker.Value.Hour != int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                    {
                                        this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                        this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                            int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                    }
                                    edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_DHL[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_Fedex[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                    edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_SpeedPost[2] * 24)
                                        .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                }
                                else if (getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                                    getAvailabledays[2].StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
                                {
                                    string[] getdays = txtFile.daysEachDayConverter(getAvailabledays[2]);

                                    for (int i = 0; i < getdays.Length; i++)
                                    {
                                        if (this.datePicker.Value.ToString("ddd") == getdays[i])
                                        {
                                            if (this.datePicker.Value.Minute !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddMinutes(-this.datePicker.Value.Minute +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(3, 2)));
                                            }
                                            if (this.datePicker.Value.Hour !=
                                                int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)))
                                            {
                                                this.datePicker.Value = this.datePicker.Value.AddSeconds(-this.datePicker.Value.Second);
                                                this.datePicker.Value = this.datePicker.Value.AddHours(-this.datePicker.Value.Hour +
                                                    int.Parse(this.timeCombo.SelectedItem.ToString().Substring(0, 2)));
                                            }
                                            edtOutput.getedlbl1.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_DHL[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl2.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_Fedex[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            edtOutput.getedlbl3.Text = this.datePicker.Value.AddHours(getWorkingDaysUSA_SpeedPost[2] * 24)
                                                .ToString("dd/MM/yyyy" + "\n" + "(HH:mm)");
                                            break;
                                        }
                                        else
                                        {
                                            edtOutput.getedlbl1.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl2.Text = "Not Available day for delivery";
                                            edtOutput.getedlbl3.Text = "Not Available day for delivery";
                                        }
                                    }
                                }

                                break;

                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("There are some errors here. Pls correct them. Thank you.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            edtOutput.Show();
        }
        // Reset all inputs to default ones.
        private void rstBtn_Click(object sender, EventArgs e)
        {
            //Reset all textboxes
            this.opcTxtBox.Text = "";
            this.dpcTxtBox.Text = "";

            //Reset all comboboxes
            this.OrigCountryCombo.Text = "SIN";
            this.DestCountryCombo.Text = "SIN";
            this.timeCombo.Text = "0:00";

            //Reset datepicker to present day
            this.datePicker.Value = DateTime.Today;

            //Remove all ErrorMessages
            this.errorDate.SetError(this.datePicker, "");
            this.errorDPC.SetError(this.dpcTxtBox, "");
            this.errorPC.SetError(this.opcTxtBox, "");
        }
        // Close the application
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(); //clear application memory storage
        }
    }
}
