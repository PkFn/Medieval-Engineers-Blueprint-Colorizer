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
        XmlTextReader xmlTextReader;
        MyColorModifiers colorModifiers;
        public Form1()
        {
            InitializeComponent();
        }


        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            if(hue > 359) hue = 359;
            if (saturation > 1) saturation = 1;
            if (value > 1) value = 1;
            if (value < 0) value = 0;


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

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        private void reloadXml()
        {
            xmlTextReader = new XmlTextReader(openFileDialog1.FileName);
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlTextReader);

            colorModifiers = new MyColorModifiers(xmlDoc);
            colorModifiers.updateAffectedSubtypes(xmlDoc);

            affectedBlockCount.Items.Clear();

            foreach (MyColorNode node in colorModifiers.colorNodes)
            {
                affectedBlockCount.Items.Add(node.ToString());
            }

            if (affectedBlockCount.Items.Count > 0)
            {
                affectedBlockCount.SelectedIndex = 0;
                reloadColor();
            }
        }

        private void reloadColor()
        {
            foreach (MyColorNode node in colorModifiers.colorNodes)
            {
                if (node.isMyString(affectedBlockCount.SelectedItem.ToString()))
                {
                    MyMeHsv hsv = node.getColor();

                    affectedBlockNames.Items.Clear();
                    foreach (string name in node.affectedObjectsSubtypes)
                    {
                        affectedBlockNames.Items.Add(name);
                    }

                    fileColorPanel.BackColor = Color.FromArgb(0xFF, ColorFromHSV(hsv.h, 0.01 * hsv.s, 0.01 * hsv.v));
                    fileColorPanel.Update();
                    return;
                }
            }
        }
        private void fileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            reloadXml();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(affectedBlockCount.SelectedItem == null)
            {
                return;
            }
            reloadColor();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            if (pendingColorPanel.BackColor != colorDialog1.Color)
            {
                pendingColorPanel.BackColor = colorDialog1.Color;
                pendingColorPanel.Update();

                pendingColorLabel.ForeColor = colorDialog1.Color.GetSaturation() < 0.5f ? Color.White : Color.Black;
            }
        }
        private void pendingColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void pendingColorLabel_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            if(affectedBlockCount.Items.Count == 0 || xmlDoc == null)
            {
                return;
            }

            MyMeHsv hsv = new MyMeHsv();

            double h, s, v;

            ColorToHSV(colorDialog1.Color, out h, out s, out v);
            hsv.h = (int)h;
            hsv.s = (int)(s * 100);
            hsv.v = (int)(v * 100) - 70;

            if(hsv.h > 359) hsv.h = 359;
            if(hsv.s > 100) hsv.s = 100;
            if(hsv.v > 100) hsv.v = 100;

            foreach (MyColorNode node in colorModifiers.colorNodes)
            {
                if (node.isMyString(affectedBlockCount.SelectedItem.ToString()))
                {
                    node.changeColor(hsv);

                    try
                    {
                        xmlTextReader.Close();
                        xmlDoc.Save(openFileDialog1.FileName);
                        xmlTextReader = new XmlTextReader(openFileDialog1.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Can't write to file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reloadXml();
                    return;
                }
            }
        }
    }
}
