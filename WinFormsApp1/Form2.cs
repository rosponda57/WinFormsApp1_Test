using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //123 456 xxxxxx
        }

        private void btnJezykZmien_Click(object sender, EventArgs e)
        {
            if (rbEn.Checked)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en");
            }
            if (rbPL.Checked)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("pl");
            }
            //MessageBox.Show(Properties.Resources.TekstZmianaJezyk);
        }
    }
}
