using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.ClassTest
{
    public class clsBase
    {
        public virtual  void met1 ()
        {
            MessageBox.Show("clsBase:met1");
        }
        public virtual  void met2()
        {
            MessageBox.Show("clsBase:met2");
        }
    }
}
