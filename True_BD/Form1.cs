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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace True_BD
{
    public partial class Form1 : Form {

    public Form1()
        {
            InitializeComponent();
        }
        //conexiunea la baza de date
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-GVQTV53C;Initial Catalog=Proiect_BD;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
        //se memoreaza valorile date intr-un string
        string username, parola;
        username = textBox1.Text;
        parola = textBox2.Text;
        //cu ajutorul unui querry se testeaza dacaa datele sunt corect
        String querry = "SELECT * FROM Angajat WHERE ID_Angajat = '" + textBox1.Text + "' AND Parola = '" + textBox2.Text + "'";
        SqlDataAdapter sda1 = new SqlDataAdapter(querry, conn);
        DataTable bag = new DataTable();
        sda1.Fill(bag);
        //daca datele sunt corecte,bag va avea cel putin un rand
            if (bag.Rows.Count > 0)
            {
                //conectare in baza de admin
                username = textBox1.Text;
                parola = textBox2.Text;
                MessageBox.Show("Ati intrat in baza de date ca admin!");
                Form2 Form2 = new Form2();
                Form2.Show();
                this.Hide();
            }
            else
            {
                //daca nu s-a puttu sa se conecteze la admini, va incerca la users
                String querry2 = "SELECT * FROM Client WHERE ID_Client = '" + textBox1.Text + "' AND Parola = '" + textBox2.Text + "'";
                SqlDataAdapter cump = new SqlDataAdapter(querry2, conn);
                DataTable login = new DataTable();
                cump.Fill(login);
                if (login.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    parola = textBox2.Text;
                    MessageBox.Show("Ati intrat in baza de date pentru clienti!");
                    Form3 Form3 = new Form3();
                    Form3.Show();
                    this.Hide();
                }
                else 
                {
                    //daca au fost introduse datele gresit, se va afisa un mesaj
                    MessageBox.Show("Ati introdus datele gresit!");
                }
            }


        conn.Close();
    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
