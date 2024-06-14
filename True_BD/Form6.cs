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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace True_BD
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection conm1 = new SqlConnection(@"Data Source=LAPTOP-GVQTV53C;Initial Catalog=Proiect_BD;Integrated Security=True");

        private void Form6_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String querry = "Insert into Categorie (Nume_Categorie,Descriere) Values ('" + textBox1.Text + "','" + textBox2.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conm1);
            DataSet dset = new DataSet();
            sda.Fill(dset, "Categorie");
            this.Hide();
        }
    }
}
