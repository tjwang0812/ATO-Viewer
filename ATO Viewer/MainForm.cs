using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATO_Viewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            redraw();
        }


        private void redraw()
        {
            td1.DrawCurveArea();
        }

        private void toolStripButton_refresh_Click(object sender, EventArgs e)
        {
            redraw();
        }
    }
}
