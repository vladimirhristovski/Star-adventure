using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Star_Adventure
{
    public partial class HighscoresForms : Form
    {
        public HighscoresForms(List<int> scores)
        {
            InitializeComponent();

            foreach (var score in scores.OrderByDescending(s => s))
            {
                listBox1.Items.Add(score);
            }

        }

       
    }
}
