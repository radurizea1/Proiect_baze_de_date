using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;

namespace True_BD
{
    public partial class Form3 : Form
    {
        //Client side
        public Form3()
        {
            InitializeComponent();
        }
        //conexiunea la baza de date
        SqlConnection conn1 = new SqlConnection(@"Data Source=LAPTOP-GVQTV53C;Initial Catalog=Proiect_BD;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            //am folosit acelasi cod pentru fiecare buton, doar interogarile difera: am folosit textbox-uri pentru a implementa interogari bazate pe ce doreste utilizatorul
            String querry3 = "Select * from Produse where Denumire like '%" + textBox1.Text + "%'";
            SqlDataAdapter sda2 = new SqlDataAdapter(querry3, conn1);
            DataSet dset = new DataSet();
            sda2.Fill(dset, "Angajati");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Angajati";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

            String querry2 = "SELECT * FROM Categorie";
            SqlDataAdapter sda2 = new SqlDataAdapter(querry2, conn1);
            DataSet dset = new DataSet();
            sda2.Fill(dset, "Categorie");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Categorie";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            String querry3 = "Select * from Produse P inner join Categorie C on C.ID_Categorie = P.ID_Categorii Where Nume_categorie like '%" + textBox1.Text + "%'";
            SqlDataAdapter sda2 = new SqlDataAdapter(querry3, conn1);
            DataSet dset = new DataSet();
            sda2.Fill(dset, "Produse");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Angajati";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String querry3 = "SELECT TOP 1 MAX(NrBucatiVandute) AS NrBucati, Denumire FROM (SELECT COUNT(BP.ID_Produs) NrBucatiVandute, P.Denumire FROM Bon_produse BP INNER JOIN Produse P ON P.ID_Produse = BP.ID_Produs GROUP BY P.Denumire) AS Vanzari GROUP BY Denumire ORDER BY NrBucati DESC";
            SqlDataAdapter sda2 = new SqlDataAdapter(querry3, conn1);
            DataSet dset = new DataSet();
            sda2.Fill(dset, "Produse");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Produse";
        }
    }
}
