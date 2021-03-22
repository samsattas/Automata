using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automata
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
            //numericOutputs.Enabled = false;
            //Console.WriteLine(numericOutputs.Value);
            textBoxStates.Width = 20 + (30 * (Convert.ToInt32(Math.Round(numericOutputs.Value, 0))));
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            numericOutputs.Enabled = false;
            textBoxStates.Width = 20 + (30 * (Convert.ToInt32(Math.Round(numericOutputs.Value, 0))));
        }
    }
}
