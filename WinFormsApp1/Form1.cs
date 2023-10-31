using Microsoft.Data.Sqlite;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Text.Json;
using WinFormsApp1.ClassTest;
using WinFormsApp1.Properties;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static TestAppSettings ustawienia = new();
        private static ResourceManager rm;

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
            if (ustawienia.jezyk.Equals("En", StringComparison.InvariantCultureIgnoreCase))
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
            this.Text = rm.GetString("text_etykieta");
            groupBox2.Text = rm.GetString("text_groupBox2");
            button4.Text = rm.GetString("text_button4");
            //this.Text = "Forma 12";
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.ShowDialog();
        }

        private void jezykToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            clsSQLLite clsSQLLite = new clsSQLLite();
            clsSQLLite.initBaze(); //rozpoczenie


            /*
            //przyklad dodawanie 
            plyty plyta = new();
            plyta.nazwaAlbumu = "plyta1";
            plyta.nazwaArtysty = "lol";
            plyta.iloscPiosenek = 16;
            clsSQLLite.dodajPlyte(plyta);

            plyta.nazwaAlbumu = "plyta2";
            plyta.nazwaArtysty = "koza";
            plyta.iloscPiosenek = 12;
            clsSQLLite.dodajPlyte(plyta);

            plyta.nazwaAlbumu = "plyta4";
            plyta.nazwaArtysty = "yjykuyk";
            plyta.iloscPiosenek = 5;
            clsSQLLite.dodajPlyte(plyta);
            */


            listViewControl.Items.Clear();

            //przyklad odczytclsSQLLiteanie
            List<plyty> plytyList = clsSQLLite.listaPlyt();

            foreach (var plyty in plytyList)
            {
                ListViewItem lvi = new ListViewItem(plyty.idZbiorPlyty.ToString());
                lvi.SubItems.Add(plyty.nazwaAlbumu);
                lvi.SubItems.Add(plyty.nazwaArtysty);
                lvi.SubItems.Add(plyty.iloscPiosenek.ToString());

                listViewControl.Items.Add(lvi);

            }


        }
    }
}
