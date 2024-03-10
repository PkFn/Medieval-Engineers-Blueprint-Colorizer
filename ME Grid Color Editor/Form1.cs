using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MEPaintedBlock;

namespace ME_Grid_Color_Editor
{
    public partial class Form1 : Form
    {
        XmlDocument xmlDoc;
        MyColorModifiers colorModifiers;
        public Form1()
        {
            InitializeComponent();
        }


        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(openFileDialog1.FileName);
            colorModifiers = new MyColorModifiers(xmlDoc);
            colorModifiers.updateAffectedSubtypes(xmlDoc);

            affectedBlockCount.Items.Clear();

            foreach(MyColorNode node in colorModifiers.colorNodes)
            {
                affectedBlockCount.Items.Add(node.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (MyColorNode node in colorModifiers.colorNodes)
            {
                if(node.isMyString(affectedBlockCount.SelectedItem.ToString()))
                {
                    MyMeHsv hsv = node.getColor();

                    affectedBlockNames.Items.Clear();
                    foreach(string name in node.affectedObjectsSubtypes)
                    {
                        affectedBlockNames.Items.Add(name);
                    }

                    fileColorPanel.BackColor = Color.FromArgb(0xFF, ColorFromHSV(hsv.h, 0.01 * hsv.s, 1));
                    fileColorPanel.Update();
                    return;
                }
            }
        }
    }
}
