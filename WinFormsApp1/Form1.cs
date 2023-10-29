using Microsoft.VisualBasic;
using System;
using System.Configuration;
using System.Data.Common;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormsApp1.ClassTest;
using WinFormsApp1.Properties;
using System.Resources;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static TestAppSettings ustawienia = new();
        public static ResourceManager rm;
        public Form1()
        {
            if (Settings.Default.SettingObject != "")
            {
                ustawienia = JsonSerializer.Deserialize<TestAppSettings>(Settings.Default.SettingObject);
                if (ustawienia.jezyk == null)
                {
                    ustawienia.jezyk = "pl";
                }
            }
            InitializeComponent();
            UstawJezyk();
        }


        private void UstawJezyk()
        {
            if (ustawienia.jezyk.Equals("en", StringComparison.InvariantCultureIgnoreCase))
            {
                rm = new ResourceManager("WinFormsApp1.resource_en", Assembly.GetExecutingAssembly());
                rbEn.Checked = true;
            }
            else
            {
                rm = new ResourceManager("WinFormsApp1.resource_pl", Assembly.GetExecutingAssembly());
                rbPL.Checked = true;
            }

            btnJezykZmien.Text = rm.GetString("text_btnZmienjesyk");
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
            MessageBox.Show("Zapis poprawny", "Ustawienia", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            //rm.GetString("text_btnZmienjesyk");
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



        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btnJezykZmien_Click_1(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(rm.GetString("NapisJeden"), "przed ustawieniem jezyka");

                if (rbEn.Checked)
                {
                    ustawienia.jezyk = "en";
                }
                if (rbPL.Checked)
                {
                    ustawienia.jezyk = "pl";
                }
                UstawJezyk();
                MessageBox.Show(rm.GetString("TekstZmianaJezyk"), "i po....", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _ = ex.ToString();
                throw;
            }
        }


    }
}
