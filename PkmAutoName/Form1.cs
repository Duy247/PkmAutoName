using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PkmAutoName
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = PkmAutoName.Properties.Resources.Derp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string url = Clipboard.GetText();
                if (url.Contains("/regular/") && url.Contains(".png"))
                {
                    int comma_pos = url.LastIndexOf("/regular/") + "/regular/".Length;
                    int dot_pos = url.LastIndexOf(".png");
                    string item_number_str = url.Substring(comma_pos, dot_pos - comma_pos);
                    int item_number = int.Parse(item_number_str);

                    string[] lines = PkmAutoName.Properties.Resources.PKM.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    if (item_number >= 1 && item_number <= lines.Length)
                    {
                        string line = lines[item_number - 1];
                        int comma_pos2 = line.IndexOf(",");
                        if (comma_pos2 > 0)
                        {
                            string item_name = line.Substring(comma_pos2 + 1);
                            lblResult.Text =  item_name;
                            Clipboard.SetText(item_name);
                            string[] csvLines = PkmAutoName.Properties.Resources.Evolutions.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                            string item_evo = Array.Find(csvLines, l => l.Contains(item_name));
                            if (item_evo != null)
                            {
                                    textBox1.Text = item_evo;
                            }
                            else
                            {
                                textBox1.Text = "Item name not found in CSV file.";
                            }
                        }
                        else
                        {
                            lblResult.Text = "Invalid item format in items.txt";
                        }
                    }
                    else
                    {
                        lblResult.Text = "Invalid item number: " + item_number;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string item_name = lblResult.Text;
            item_name = item_name.Replace(' ', '-');
            string webpageUrl = "https://pokemondb.net/pokedex/" + item_name;
            System.Diagnostics.Process.Start(webpageUrl);
        }
        private void MadeByLinFang_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
