using System;
using System.Windows.Forms;

namespace MifareTool
{
    public partial class FormInfo : Form
    {
        public FormInfo(FormMain form)
        {
            InitializeComponent();

            this.Width = form.Width;
            this.Height = form.Height;

            ucINFO1.tsBtnExit_Event += UcINFO1_tsBtnExit_Event;
        }

        private void UcINFO1_tsBtnExit_Event(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInfo_Activated(object sender, EventArgs e)
        {

        }

        private void FormInfo_Deactivate(object sender, EventArgs e)
        {

        }
    }
}
