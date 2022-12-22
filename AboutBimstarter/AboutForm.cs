using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AboutBimstarter
{
    public partial class AboutForm : Form
    {
        public AboutForm(int version)
        {
            InitializeComponent();

            if (version > 0)
                labelVersion.Text = version.ToString();
            else
                labelVersion.Text = "NULL";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process procMail = new System.Diagnostics.Process();
            procMail.StartInfo.FileName = "mailto:info@bim-starter.com?subject=Вопрос_по_Bim-Starter";
            procMail.Start();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://bim-starter.com");
        }
    }
}
