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

namespace True_BD
{
    public partial class Form2 : Form
    {
        //Admin side
        public Form2()
        {
            InitializeComponent();
        }
        //conexiunea la baza de date
        SqlConnection conn1 = new SqlConnection(@"Data Source=LAPTOP-GVQTV53C;Initial Catalog=Proiect_BD;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            //am folosit acelasi cod pentru fiecare buton, doar interogarile difera: am folosit textbox-uri si combobox-uri pentru a implementa interogari bazate pe ce doreste admin-ul
            String querry1 = "SELECT * FROM " + textBox1.Text +"";
            SqlDataAdapter sda2 = new SqlDataAdapter(querry1, conn1);
            DataSet dset = new DataSet();
            sda2.Fill(dset, "" + textBox1.Text +"");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "" + textBox1.Text +"";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String querry9 = "DELETE FROM " + textBox1.Text + " WHERE "+textBox3.Text+" = '"+textBox2.Text+"'";
            SqlDataAdapter sda9 = new SqlDataAdapter(querry9, conn1);
            DataSet dset = new DataSet();
            sda9.Fill(dset, "" + textBox1.Text + "");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //pentru insert, am deschis 2 form-uri noi, speciale pentru fiecare caz, iar apoi se vor inchide automat dupa ce datele au fost introduse
            if (comboBox2.Text == "Client")
            {
                Form5 Form5 = new Form5();
                Form5.Show();
            }
            else
            {
                Form6 Form6= new Form6();
                Form6.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {  
            String querry4 = "Select Nume, Prenume From Angajat A inner join Bon B on B.ID_Angajat=A.ID_Angajat Group by A.Nume, A.Prenume HAVING SUM(B.Valoare) in (Select max(B.Valoare) from Bon B Group by B.ID_Angajat)";
            SqlDataAdapter sda5 = new SqlDataAdapter(querry4, conn1);
            DataSet dset = new DataSet();
            sda5.Fill(dset, "Angajati");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Angajati";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String querry5 = "Select Nume, Prenume From Angajat Where Nr_ore_lucru in (Select max(Nr_ore_lucru) from Angajat)";
            SqlDataAdapter sda6 = new SqlDataAdapter(querry5, conn1);
            DataSet dset = new DataSet();
            sda6.Fill(dset, "Angajati");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Angajati";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String querry6 = "select "+comboBox1.Text+"(Bonuri) as NR_de_Bonuri from(select count(B.ID_Bon) as Bonuri, C.Nume, C.Prenume from Bon B inner join Client C on C.ID_Client = B.ID_Client group by C.Nume, C.Prenume) as NR_Bonuri ";
            SqlDataAdapter sda7 = new SqlDataAdapter(querry6, conn1);
            DataSet dset = new DataSet();
            sda7.Fill(dset, "Client");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Client";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            String querry10 = "UPDATE "+textBox1.Text+" set "+textBox3.Text+" = '"+textBox2.Text+"' ";
            SqlDataAdapter sda10 = new SqlDataAdapter(querry10, conn1);
            DataSet dset = new DataSet();
            sda10.Fill(dset, ""+textBox1.Text+"");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            String querry6 = "select data from Bon B inner join Bon_produse Bp on Bp.ID_Bon = B.ID_Bon  where Bp.Cantitate > 1";
            SqlDataAdapter sda7 = new SqlDataAdapter(querry6, conn1);
            DataSet dset = new DataSet();
            sda7.Fill(dset, "Bon");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Bon";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String querry6 = "select Nume,Prenume from Client C inner join Bon B on B.ID_Client = C.ID_Client  where Valoare > 100";
            SqlDataAdapter sda7 = new SqlDataAdapter(querry6, conn1);
            DataSet dset = new DataSet();
            sda7.Fill(dset, "Client");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Client";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //4 int
            String querry12 = "select Nume,Prenume from Angajat A inner join Bon B on B.ID_Angajat = A.ID_Angajat  where Data = '2023-01-05'";
            SqlDataAdapter sda12 = new SqlDataAdapter(querry12, conn1);
            DataSet dset = new DataSet();
            sda12.Fill(dset, "Angajat");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Angajat";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String querry13 = "select Nume_categorie from Categorie C inner join Produse P on P.ID_Categorii = C.ID_Categorie  where  P.Pret > 50";
            SqlDataAdapter sda13 = new SqlDataAdapter(querry13, conn1);
            DataSet dset = new DataSet();
            sda13.Fill(dset, "Angajat");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Angajat";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            String querry14 = "select Data from Bon B inner join Angajat A on A.ID_Angajat = B.ID_Angajat  where  Sex = 'F'";
            SqlDataAdapter sda14 = new SqlDataAdapter(querry14, conn1);
            DataSet dset = new DataSet();
            sda14.Fill(dset, "Bon");
            dataGridView1.DataSource = dset;
            dataGridView1.DataMember = "Bon";
        }
    }
}
