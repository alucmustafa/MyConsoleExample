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
using System.Xml.Linq;


namespace FirstSqlBaglantim
{
    public partial class Form1 : Form
    {

        void TabloGoster()
        {
            XmlDocument X = new XmlDocument(); DataSet ds = new DataSet();
            XmlReader xmlFile = XmlReader.Create(@"kitap.xml", new XmlReaderSettings());
            ds.ReadXml(xmlFile);
            dataGridView1.DataSource = ds.Tables[0];
            xmlFile.Close();

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor= SystemColors.Window;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabloGoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                XDocument x = XDocument.Load(@"kitap.xml");
                x.Element("Kitaplar").Add(
                    new XElement("Kitap",
                    new XElement("kitapno", textBox1.Text),
                    new XElement("kitapadi", textBox2.Text),
                    new XElement("yayinevi", textBox3.Text),
                    new XElement("yazaradi", textBox4.Text),
                    new XElement("tur", textBox5.Text),
                    new XElement("fiyat", textBox6.Text),
                    new XElement("puan", textBox7.Text),
                    new XElement("sayfasayisi", textBox8.Text)
                    ));
            x.Save(@"kitap.xml");
          
            TabloGoster();
            MessageBox.Show("Kitap ekleme işlemi  tamamlandı...");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"kitap.xml");
            XElement node = x.Element("Kitaplar").Elements("Kitap").FirstOrDefault(a => a.Element("kitapno").Value.Trim() == textBox1.Text);
            if (node!=null)
            {
                node.SetElementValue("kitapadi", textBox2.Text); 
                node.SetElementValue("yayinevi", textBox3.Text); 
                node.SetElementValue("yazaradi", textBox4.Text); 
                node.SetElementValue("tur", textBox5.Text); 
                node.SetElementValue("fiyat", textBox6.Text); 
                node.SetElementValue("puan", textBox7.Text); 
                node.SetElementValue("sayfasayisi", textBox8.Text);
                x.Save(@"kitap.xml");
                TabloGoster();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"kitap.xml");
            x.Root.Elements().Where(a => a.Element("kitapno").Value == textBox1.Text).Remove();
            x.Save(@"kitap.xml");
            MessageBox.Show("Silme işlemi tamamlandı...");
            TabloGoster();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
