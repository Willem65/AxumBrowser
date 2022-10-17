using System;

using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;

using mshtml;

using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;
using System.Drawing;

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.IO;
//using SHDocVw;
//using System.Threading;
//using mshtml;
//using Microsoft.VisualBasic;
//using System.Text.RegularExpressions;

namespace AxumBrowser
{


    public partial class Form1 : Form
    {

        SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();

        // public InternetExplorer Ie { get => ie; set => ie = value; }

        //InternetExplorer ie = new InternetExplorer();
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Start_Click(object sender, EventArgs e)
        {
            //SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();
            // ie.Visible = true;
            // ie.ToolBar = 0;
             ie.StatusBar = true;
             ie.MenuBar = false;
             ie.AddressBar = true;
             ie.Visible = true;

            //// ShowWindow((IntPtr)ie.HWND, 3);
            ie.Navigate(URLtextBox.Text);
            while ((ie.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE) || (ie.Busy == true))
            {
                Thread.Sleep(150);
            }
            //this.TopMost = true;
            //HTMLDocument doci = (HTMLDocument)ie.Document.DomDocument;
            // HTMLDocument htmlDoc = (HTMLDocument)ie.Document;

            // //HtmlDocument docc = new HtmlDocument();
            // //htmlDoc.LoadHtml(htmlCode);

            HTMLDocument htmlDoc = (HTMLDocument)ie.Document;
            //System.Windows.Forms.HtmlDocument htmlDoc = (System.Windows.Forms.HtmlDocument)ie.Document;
            //string aFile = htmlDoc.body.OuterHtml;
            string a = htmlDoc.body.outerHTML;
            //string webtext = htmlDoc.Body.outerHTML;

            //StreamWriter wrl = new StreamWriter("names_database.txt");
            //wrl.Write(a);
            //wrl.Close();



            //dataSet.ReadXml("mixers.xml");

            //HtmlDocument doc = new HtmlDocument();
            //doc.LoadHtml("http://192.168.1.222/config/rack");

            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.Load("names_database.txt");

            //HtmlWeb Web = new HtmlWeb();
            // HtmlAgilityPack.HtmlDocument doc = Web.LoadFromBrowser("http://192.168.1.222/config/rack");


            //Thread.Sleep(500);

            //var title = doc.DocumentNode.SelectNodes("//table").First().InnerText;
            //var title = doc.table.SelectNodes("tr").First().InnerText;
            //var title = doc.DocumentNode.SelectNodes("//table");

            //StreamWriter wrlout = new StreamWriter("out_database.txt");
            //wrlout.Write(title);
            //wrlout.Close();


            //Thread.Sleep(200);

            //string html = a;
            //var table = new HtmlAgilityPack.HtmlDocument();

            //table.LoadHtml(html);

            //foreach (var tr in table.DocumentNode.SelectNodes("//*").First().InnerText)
            //{
            //    Debug.WriteLine(tr);
            //}



            HtmlAgilityPack.HtmlDocument docc = new HtmlAgilityPack.HtmlDocument();
            docc.LoadHtml(a);

            int count = 0;
            int Rowcount = 0;
            string[] buffer = new string[100];



            for (int t = 0; t < 36; t++)
            {
                dataGridView1.Columns.Add("", "");
            }

            //for (int t = 0; t < 10; t++)
            //{
            //    dataGridView1.Rows.Add("");
            //}


            //////string html = a;

            //////string pattern = "<tr>(?:<td>(.*?)</td>)*?</tr>";
            //////foreach (Match m in Regex.Matches(html, pattern, RegexOptions.IgnoreCase))

            //////{

            //////    // Add row
            //////    dataGridView1.Rows.Add("");

            //////    //foreach (Capture c in m.Groups[1].Captures)
            //////    foreach (var c in html.Split(new[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries)) //split into rows
            //////    {
            //////        buffer[count] = c;
            //////        count++;
            //////    }

            //////    for (UInt16 t = 0; t < count; t++)
            //////    {

            //////        dataGridView1[t, Rowcount].Value = buffer[t];
            //////    }
            //////    Rowcount++;
            //////    count = 0;
            //////}



            foreach (HtmlNode tablel in docc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>())
            {


                foreach (HtmlNode row in tablel.SelectNodes("//tr"))   // begin van de tabel
                {
                    dataGridView1.Rows.Add("");

                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        //Debug.WriteLine("cell: " + cell.InnerText + " " + count);
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

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //DialogResult dg = MessageBox.Show("Do you want to save changes?", "Closing", MessageBoxButtons.YesNoCancel);
            Kill_IE();
            Application.Exit();
        }









        private void ShowButton_Click(object sender, EventArgs e)
        {
            

            //int X = 1520;
            //int X1 = 0;
            //int Y = 124;

            if (!(dataGridView1.Columns.Count > 0)) return;  // Vlieg eruit als er niks is     

            //Panel pnl = new Panel();
            ////pnl.SuspendLayout();
            //pnl.Location = new Point(X, Y - 100);
            ////pnl.Name = "pnl" + t;
            //pnl.Size = new Size(50, 57);
            //pnl.BorderStyle = BorderStyle.FixedSingle;
            //pnl.BackColor = Color.Yellow;
            //Controls.Add(pnl);

            for (int t = 0; t < dataGridView1.Rows.Count; t++)
            {
                String str = (string)dataGridView1[1, t].Value;

                if (string.IsNullOrEmpty(str)) continue;   // Probeer het opnieuw                            

                //if (str.Contains("GPI-1") || str.Contains("GPO-1") || str.Contains("GPIO-1") )
                if ( str == "GPI-1" )
                {
                    string txtFound =  (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[3, t].Value;

                    //Label lbl = new Label();
                    //lbl.Location = new Point(X  + X1 , Y + 17);
                    //lbl.Size = new Size(9 * txtFound.Length, 16);
                    //lbl.Width = txtFound.Length*9;
                    //lbl.AutoSize=true;
                    //lbl.BackColor = Color.Yellow;
                    //lbl.Text = txtFound;
                    //this.Controls.Add(lbl);
                    //Y = Y + 15;

                    GPI1label.Text = txtFound;
                }

                if ( str == "GPI-1-Active-state" )
                {
                   // string txtFound = (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[2, t].Value;
                    GPI2label.Text = (string)dataGridView1[1, t].Value + " " + (string)dataGridView1[2, t].Value + " " + (string)dataGridView1[3, t].Value;
                }
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

























        private void GPIlabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //Graphics gra = this.CreateGraphics();
            //Pen pen = new Pen(Color.Black, 1);
            //Point p1 = new Point(700, 100);
            //Point p2 = new Point(750, 150);
            //e.Graphics.DrawLine(pen, p1, p2);
        }
    }
}
