using System.Configuration;
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
            var property = new SettingsProperty("test2");
            property.Name = "<dynamicSettingName>";
            property.DefaultValue = "ccc";
            Settings.Default.Properties.Add(property);
            Settings.Default.Save(); 
            
            //test gig2
                
                
            var x = Properties.Settings.Default.Properties["<Test>"];
            var xw = Properties.Settings.Default.Properties["<dynamicSettingName>"];
        }
    }
}