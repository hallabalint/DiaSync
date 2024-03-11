using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DiaSync
{
    public partial class StatusBar : Form
    {
        public StatusBar()
        {
            InitializeComponent();
        }

        public void SetMaximum(int max)
        {
            pb1.Maximum = max;
        }

        public void SetValue(int val)
        {
            pb1.Value = val;
        }
        public void SetStauts(string status)
        {
            label1.Text = status;
        }


    }
}
