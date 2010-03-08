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
    public partial class EDTOutput : Form
    {
        public EDTOutput()
        {
            InitializeComponent();
        }
        // get all labels for output
        public Label getdslbl1
        {
            get { return this.dslbl1; }
            set { getdslbl1 = value; }
            
        }
        public Label getdslbl2
        {
            get { return this.dslbl2; }
            set { getdslbl2 = value; }

        }
        public Label getdslbl3
        {
            get { return this.dslbl3; }
            set { getdslbl3 = value; }

        }
        public Label getoclbl1
        {
            get { return this.oclbl1; }
            set { getoclbl1 = value; }

        }
        public Label getoclbl2
        {
            get { return this.oclbl2; }
            set { getoclbl2 = value; }

        }
        public Label getoclbl3
        {
            get { return this.oclbl3; }
            set { getoclbl1 = value; }

        }
        public Label getdclbl1
        {
            get { return this.dclbl1; }
            set { getdclbl1 = value; }

        }
        public Label getdclbl2
        {
            get { return this.dclbl2; }
            set { getdclbl2 = value; }

        }
        public Label getdclbl3
        {
            get { return this.dclbl3; }
            set { getdclbl3 = value; }

        }
        public Label getsdlbl1
        {
            get { return this.sdlbl1; }
            set { getsdlbl1 = value; }

        }
        public Label getsdlbl2
        {
            get { return this.sdlbl2; }
            set { getsdlbl2 = value; }

        }
        public Label getsdlbl3
        {
            get { return this.sdlbl3; }
            set { getsdlbl3 = value; }

        }
        public Label getedlbl1
        {
            get { return this.edlbl1; }
            set { getedlbl1 = value; }

        }
        public Label getedlbl2
        {
            get { return this.edlbl2; }
            set { getedlbl2 = value; }

        }
        public Label getedlbl3
        {
            get { return this.edlbl3; }
            set { getedlbl3 = value; }

        }
        public Label getwdlbl1
        {
            get { return this.wdlbl1; }
            set { getwdlbl1 = value; }

        }
        public Label getwdlbl2
        {
            get { return this.wdlbl2; }
            set { getwdlbl2 = value; }

        }
        public Label getwdlbl3
        {
            get { return this.wdlbl3; }
            set { getwdlbl3 = value; }

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(); //clear application memory storage
        }
    }
}
