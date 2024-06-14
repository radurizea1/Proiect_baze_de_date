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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection conm1 = new SqlConnection(@"Data Source=LAPTOP-GVQTV53C;Initial Catalog=Proiect_BD;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            String querry = "Insert into Client (Nume,Prenume,Certificat,Parola) Values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conm1);
            DataSet dset = new DataSet();
            sda.Fill(dset, "Client");
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
