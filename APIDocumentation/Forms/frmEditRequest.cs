using APIDocumentation.UserDefinedControl.EditRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIDocumentation.Forms
{
    public partial class frmEditRequest : Form
    {
        private UCRequestMain uCRequestMain;
        private UCRequestHeader uCRequestHeader;
        private EnumPanelControls enumPanelControls;

        private enum EnumPanelControls
        {
            Main = 0,
            Header = 1
        }

        public frmEditRequest()
        {
            InitializeComponent();

            enumPanelControls = EnumPanelControls.Main;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel?", "Cancel Request", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmEditRequest_Load(object sender, EventArgs e)
        {
            loadPanelControl();
        }

        private void loadPanelControl()
        {
            switch (enumPanelControls)
            {
                case EnumPanelControls.Main:
                    uCRequestMain = new UCRequestMain();
                    panelContent.Controls.Add(uCRequestMain);
                    btnPrevious.Enabled = false;
                    btnNext.Visible = true;
                    btnSubmit.Visible = false;
                    break;

                case EnumPanelControls.Header:
                    uCRequestHeader = new UCRequestHeader();
                    panelContent.Controls.Add(uCRequestHeader);
                    btnPrevious.Enabled = true;
                    btnNext.Visible = false;
                    btnSubmit.Visible = true;
                    break;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            switch (enumPanelControls)
            {
                case EnumPanelControls.Header:
                    panelContent.Controls.Remove(uCRequestHeader);
                    enumPanelControls = EnumPanelControls.Main;
                    break;
            }

            loadPanelControl();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (enumPanelControls)
            {
                case EnumPanelControls.Main:
                    panelContent.Controls.Remove(uCRequestMain);
                    enumPanelControls = EnumPanelControls.Header;
                    break;
            }

            loadPanelControl();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
