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
            this.StartPosition = FormStartPosition.CenterScreen;

            foreach (int item in scores.OrderByDescending(s => s))
            {
                if (!listBox1.Items.Contains(item))
                {
                    listBox1.Items.Add(item);
                }
                
            }

            if (listBox1.Items.Count > 0)
            {
                int highestScore = (int)listBox1.Items[0];
                listBox1.Items[0] = $"{highestScore} Highest Score";
            }
           
        }
 
    }
}
