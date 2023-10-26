using Microsoft.VisualBasic;
using System;
using System.Configuration;
using System.Data.Common;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormsApp1.ClassTest;
using WinFormsApp1.Properties;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static TestAppSettings ustawienia = new();
        private static TestAppSettings ustawieniaG = new();

        public Form1()
        {
            InitializeComponent();
            if (Settings.Default.SettingObject != "")
            {
                ustawienia = JsonSerializer.Deserialize<TestAppSettings>(Settings.Default.SettingObject);
            }
            if (Settings.Default.SettingObjectGlobal != "")
            {
                ustawieniaG = JsonSerializer.Deserialize<TestAppSettings>(Settings.Default.SettingObjectGlobal);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsBase clsBase;
            //123 456  bbbbbbbbbbbbbbbbbbb
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
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  // the config that applies to all users
            AppSettingsSection appSettings = config.AppSettings;

            string xw = Properties.Settings.Default.SettingUser;
            MessageBox.Show($"ustawienie: {xw} \n\n "
                   + $" dynamioczne user : {Properties.Settings.Default.SettingObject} \n\n"
                   + $" ustawieniaG: {ConfigurationManager.AppSettings["AAA3"]}");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ustawienia.Ustawienie1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ustawienia.Etykieta = "Nowe ustawienie";

            Settings.Default.SettingObject = JsonSerializer.Serialize(ustawienia); ;
            ustawienia.Etykieta = "Nowe ustawienie Global";
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);  // the config that applies to all users
            AppSettingsSection appSettings = config.AppSettings;

            if (appSettings.IsReadOnly() == false)
            {
                if (ConfigurationManager.AppSettings["AAA3"] == null)
                {
                    appSettings.Settings.Add("AAA3", "BBB");
                }
                else
                {
                    config.AppSettings.Settings.Remove("AAA3");
                    config.AppSettings.Settings.Add("AAA3", "globalne w oliku");
                    //ConfigurationManager.AppSettings["AAA3"] = "globalne w oliku";
                }
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                MessageBox.Show("nie wolno zapisywaæ !");
            }
        }
    }
}
