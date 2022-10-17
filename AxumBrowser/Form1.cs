using System;
using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;
using mshtml;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;
using System.Drawing;


namespace AxumBrowser
{


    public partial class Form1 : Form
    {
        SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
             ie.StatusBar = true;
             ie.MenuBar = false;
             ie.AddressBar = true;
             ie.Visible = true;

            ie.Navigate(URLtextBox.Text);
            while ((ie.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE) || (ie.Busy == true))
            {
                Thread.Sleep(150);
            }

            HTMLDocument htmlDoc = (HTMLDocument)ie.Document;
            string outHtml = htmlDoc.body.outerHTML;

            HtmlAgilityPack.HtmlDocument docc = new HtmlAgilityPack.HtmlDocument();
            docc.LoadHtml(outHtml);

            int count = 0;
            int Rowcount = 0;
            string[] buffer = new string[100];

            for (int t = 0; t < 36; t++)
            {
                dataGridView1.Columns.Add("", "");
            }



            foreach (HtmlNode tablel in docc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>())
            {
                foreach (HtmlNode row in tablel.SelectNodes("//tr"))   // begin van de tabel
                {
                    dataGridView1.Rows.Add("");

                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        buffer[count] = cell.InnerText;
                        count++;
                    }

                    for (int t = 0; t < count; t++)
                    {
                        dataGridView1[t, Rowcount].Value = buffer[t];
                    }
                    Rowcount++;
                    count = 0;
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }



        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Kill_IE();
            Application.Exit();
        }



        private void ShowButton_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.Columns.Count > 0)) return;  // Vlieg eruit als er niks is     

            for (int t = 0; t < dataGridView1.Rows.Count; t++)
            {
                String str = (string)dataGridView1[1, t].Value;

                if (string.IsNullOrEmpty(str)) continue;   // Probeer het opnieuw                            

                if ( str == "GPI-1" )
                {
                    string txtFound =  (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[3, t].Value;
                    GPI1label.Text = txtFound;
                }
                if ( str == "GPI-1-Active-state" )                
                    GPI2label.Text = (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[3, t].Value;               
                if (str == "GPIO-1-Mode")
                    GPI3label.Text = (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[3, t].Value;
                if (str == "GPO-1")
                    GPI4label.Text = (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[3, t].Value;
                if (str == "GPO-1-Time")
                {
                    GPI5label.Text = (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[3, t].Value;
                    trackBarGPOtime.Value = int.Parse((string)dataGridView1[3, t].Value);
                }
                if (str == "GPO-1-Active-state")
                    GPI6label.Text = (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[3, t].Value;
            }
        }






        private void Kill_IE()
        {
            ie.Quit();
        }

        private void URLlabel_Click(object sender, EventArgs e)
        {

        }

        private void URLtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void URLBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GPIlabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
