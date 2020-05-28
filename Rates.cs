using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Linq.Expressions;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms.DataVisualization.Charting;

namespace _1045_BarsanescuDiana_Proiect
{
    public partial class Rates : Form
    {
        readonly List<string> Months = new List<string> { "January", "February", "March", "April", "May" };
        bool variable = false;
        double[] vector = new double[6];
        int noValues = 0;
        int selectedCurrencies = 0;


        public Rates()
        {
            InitializeComponent();
            this.listView2.LostFocus += (s, e) => this.listView2.SelectedIndices.Clear();

            StreamReader sr = new StreamReader("nbrfxrates.xml");
            string str = sr.ReadToEnd();
            sr.Close();

            XmlReader reader = XmlReader.Create(new StringReader(str));
            while (reader.Read())
            {

                if (reader.Name == "Rate" && reader.NodeType == XmlNodeType.Element)
                {
                    string atribut = reader["currency"];
                    reader.Read();
                    ListViewItem itm = new ListViewItem(atribut);
                    if(atribut == "HUF" || atribut == "JPY" || atribut == "KRW")
                    {
                        itm.SubItems.Add(Convert.ToString(Convert.ToDouble(reader.Value) / 100));
                        itm.SubItems.Add(Convert.ToString(Convert.ToDouble(reader.Value) / 100));
                    }
                    else
                    {
                        itm.SubItems.Add(Convert.ToString(reader.Value));
                        itm.SubItems.Add(Convert.ToString(reader.Value));
                    }
                    listView2.Items.Add(itm);

                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView2.Items)
            {
                if (itm.Checked)
                {
                    Close();
                    Add frm = new Add(itm.SubItems[0].Text, itm.SubItems[1].Text);
                    frm.ShowDialog();
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView2.Items)
            {
                if (itm.Checked)
                {
                    StreamReader strg = new StreamReader("Monthly.txt");
                    string line = null;
                    while ((line = strg.ReadLine()) != null)
                    {
                        try
                        {
                            if (itm.Text == line.Split(',')[0])
                            {
                                noValues++;
                                if (selectedCurrencies == 0)
                                    chart1.Series["currency"].Name = itm.Text;
                                else
                                {
                                    chart1.Series.Clear();
                                    chart1.Series.Add(itm.Text);
                                    chart1.Series[itm.Text].ChartType = SeriesChartType.Area;
                                    //art1.Series[itm.Text].BorderWidth = 5;
                                }


                                vector[0] = Convert.ToDouble(line.Split(',')[1]);
                                vector[1] = Convert.ToDouble(line.Split(',')[2]);
                                vector[2] = Convert.ToDouble(line.Split(',')[3]);
                                vector[3] = Convert.ToDouble(line.Split(',')[4]);
                                vector[4] = Convert.ToDouble(line.Split(',')[5]);


                                double min = vector[0];
                                double max = vector[0];
                                for (int i = 0; i < 5; i++)
                                {
                                    if (vector[i] < min)
                                        min = vector[i];
                                    else
                                        if (vector[i] > max)
                                        max = vector[i];

                                }

                                chart1.ChartAreas[0].AxisY.Minimum = min;
                                chart1.ChartAreas[0].AxisY.Maximum = max;
                                chart1.ChartAreas[0].AxisY.Interval = (max - min) / 4;
                                for (int i = 0; i < 5; i++)
                                {
                                    chart1.Series[itm.Text].Points.AddXY(Months[i], vector[i]);
                                }

                                foreach (ListViewItem item in listView2.Items)
                                {
                                    item.Selected = false;
                                }

                                chart1.Invalidate();
                                selectedCurrencies++;
                                variable = true;

                                if (this.listView2.SelectedIndices.Count > 0)
                                    for (int i = 0; i < this.listView2.SelectedIndices.Count; i++)
                                    {
                                        this.listView2.Items[this.listView2.SelectedIndices[i]].Selected = false;
                                    }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        noValues = 0;
                    }
                    strg.Close();
                        if (selectedCurrencies == 0)
                        {
                            errorProvider1.SetError(button1,"Please choose a currency");
                        }

                }

            }
        }

        private void listView2_MouseDown(object sender, MouseEventArgs e)
        {
            listView2.DoDragDrop(listView2.SelectedItems, DragDropEffects.Copy);
        }

        private void chart1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void chart1_DragDrop(object sender, DragEventArgs e)
        {
            foreach (ListViewItem itm in listView2.Items)
            {
                if (itm.Checked)
                {
                    StreamReader strg = new StreamReader("Monthly.txt");
                    string line = null;
                    while ((line = strg.ReadLine()) != null)
                    {
                        try
                        {
                            if (itm.Text == line.Split(',')[0])
                            {
                                noValues++;
                                if (selectedCurrencies == 0)
                                    chart1.Series["currency"].Name = itm.Text;
                                else
                                {
                                    chart1.Series.Clear();
                                    chart1.Series.Add(itm.Text);
                                    chart1.Series[itm.Text].ChartType = SeriesChartType.Area;
                                    //art1.Series[itm.Text].BorderWidth = 5;
                                }


                                vector[0] = Convert.ToDouble(line.Split(',')[1]);
                                vector[1] = Convert.ToDouble(line.Split(',')[2]);
                                vector[2] = Convert.ToDouble(line.Split(',')[3]);
                                vector[3] = Convert.ToDouble(line.Split(',')[4]);
                                vector[4] = Convert.ToDouble(line.Split(',')[5]);


                                double min = vector[0];
                                double max = vector[0];
                                for (int i = 0; i < 5; i++)
                                {
                                    if (vector[i] < min)
                                        min = vector[i];
                                    else
                                        if (vector[i] > max)
                                        max = vector[i];

                                }

                                chart1.ChartAreas[0].AxisY.Minimum = min;
                                chart1.ChartAreas[0].AxisY.Maximum = max;
                                chart1.ChartAreas[0].AxisY.Interval = (max - min) / 4;
                                for (int i = 0; i < 5; i++)
                                {
                                    chart1.Series[itm.Text].Points.AddXY(Months[i], vector[i]);
                                }

                                foreach (ListViewItem item in listView2.Items)
                                {
                                    item.Selected = false;
                                }

                                chart1.Invalidate();
                                selectedCurrencies++;
                                variable = true;

                                if (this.listView2.SelectedIndices.Count > 0)
                                    for (int i = 0; i < this.listView2.SelectedIndices.Count; i++)
                                    {
                                        this.listView2.Items[this.listView2.SelectedIndices[i]].Selected = false;
                                    }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        noValues = 0;
                    }
                    strg.Close();
                    if (selectedCurrencies == 0)
                    {
                        MessageBox.Show("Please select a currency!");
                    }

                }

            }
        }


        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //e.Item.Selected = true;
            if (listView2.CheckedIndices.Count >= 2)
            {
                for (int i = 0; i < listView2.CheckedIndices.Count; i++)
                {

                    listView2.Items[listView2.CheckedIndices[i]].Checked = false;
                    listView2.Items[this.listView2.CheckedIndices[i]].Selected = false;
                    listView2.Refresh();
                }
                
            }
            
        }

        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView2.Items)
            {
                if (itm.Checked)
                    itm.Checked = false;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView2.Items)
            {
                if (itm.Checked == true)
                {
                    Clipboard.SetText("Currency: " + itm.SubItems[0] + Environment.NewLine + "\tRate: " + itm.SubItems[1]);
                }
            }
        }
    }
}
