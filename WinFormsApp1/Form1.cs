using Microsoft.VisualBasic;
using System;
using System.Configuration;
using System.Data.Common;
using WinFormsApp1.ClassTest;
using WinFormsApp1.Properties;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsBase clsBase;
            //123 456
            if (radioButton1.Checked) //db
            {
                clsBase = new clsDb1();
            }
            else if (radioButton2.Checked) //mono
            {
                clsBase = new clsDbMono();
            }
            else
            {
                clsBase = new clsBase();
            }

            clsBase.met1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var xw = Properties.Settings.Default.Properties["dynamicSettingName"];


            string xw = Properties.Settings.Default.SettingUser;

            var xd = Settings.Default.Properties["dynamicSettingName"];

            MessageBox.Show($"ustawienie: {xw} i dynamioczne: {xd}");


            Settings.Default.SettingUser = "koza";
            Settings.Default.Save();

            var _x = Settings.Default.Properties.Count;


            //}
            //else
            //{
            //    MessageBox.Show(xw.DefaultValue.ToString());
            //}
            ////test gig2
            //xw = Properties.Settings.Default.Properties["SettingUser"];


            //var x = Properties.Settings.Default.Properties["<Test>"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/32989100/how-to-make-multi-language-app-in-winforms
            var p = new SettingsProperty("dynamicSettingName");

            p.PropertyType = typeof( string );
            p.Attributes.Add(typeof(UserScopedSettingAttribute),new UserScopedSettingAttribute());
            p.Provider = Settings.Default.Providers["LocalFileSettingsProvider"];
            p.DefaultValue = "xxxxx";
            p.IsReadOnly = false;
            p.SerializeAs = SettingsSerializeAs.Xml;
            //SettingsPropertyValue v = new SettingsPropertyValue( p );
            Settings.Default.Properties.Add(p);
            Settings.Default["dynamicSettingName"] = "dynamicSettingName  test";
            Settings.Default.Save();
            Settings.Default.Reload();
        }
    }
}
