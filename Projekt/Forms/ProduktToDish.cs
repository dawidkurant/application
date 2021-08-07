using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt.Forms
{
    public partial class ProduktDoDania : Form
    {
        public ProduktDoDania()
        {
            InitializeComponent();
            Fillcombo();
            Fillcombo2();
            upLoadData();
            upLoadData2();
        }

        String server = "localhost";
        String username = "root";
        String password = "root";
        String database = "products";

        //Aktualizacja danych - suma wartości produktów wybranego dania
        private void upLoadData()
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "SELECT dishes.nazwa, sum(products.waga) AS 'Waga[g]'" +
                ",sum(products.wartosc) AS 'Wartość energetyczna[kcal]', sum(products.bialko) AS 'Białko ogółem[g]'," +
                " sum(products.tluszcz) AS 'Tłuszcz[g]', sum(products.weglowodany) AS 'Węglowodany[g]'," +
                " sum(products.weglowodanyP) AS 'Węglowodany przyswajalne[g]', sum(products.blonnik) AS 'Błonnik pokarmowy[g]'," +
                " sum(products.wymienniki) AS 'Wymienniki węglowodanowe[g]'" +
                " FROM products_to_dishes JOIN dishes ON products_to_dishes.dish_id=dishes.id JOIN products ON products_to_dishes.product_id=products.id" +
                " WHERE dishes.id=" + (this.comboBox2.SelectedIndex+1) + ";";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand sqlCmd = new MySqlCommand(query, conn);
            MySqlDataAdapter DtA = new MySqlDataAdapter();
            DtA.SelectCommand = sqlCmd;
            DataTable sqlDt = new DataTable();
            DtA.Fill(sqlDt);
            sqlDt.Columns.Add("zdjecie", Type.GetType("System.Byte[]"));

            foreach (DataRow row in sqlDt.Rows)
            {
                try
                {
                    row["zdjecie"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["sciezka"].ToString()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Brak zdjęcia w bazie", ex.Message);
                }
            }


            dataGridView1.DataSource = sqlDt;
            dataGridView1.RowTemplate.Height = 100;

        }

        //Aktualizacja danych - wartości produktów wybranego dania
        private void upLoadData2()
        {
            string connection1 = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query1 = "SELECT products.nazwa, products.waga AS 'Waga[g]'" +
                ",products.wartosc AS 'Wartość energetyczna[kcal]', products.bialko AS 'Białko ogółem[g]'," +
                " products.tluszcz AS 'Tłuszcz[g]', products.weglowodany AS 'Węglowodany[g]'," +
                " products.weglowodanyP AS 'Węglowodany przyswajalne[g]', products.blonnik AS 'Błonnik pokarmowy[g]'," +
                " products.wymienniki AS 'Wymienniki węglowodanowe[g]'" +
                " FROM products_to_dishes JOIN dishes ON products_to_dishes.dish_id=dishes.id JOIN products ON products_to_dishes.product_id=products.id" +
                " WHERE dishes.id=" + (this.comboBox2.SelectedIndex + 1) + ";";
            MySqlConnection conn1 = new MySqlConnection(connection1);
            MySqlCommand sqlCmd1 = new MySqlCommand(query1, conn1);
            MySqlDataAdapter DtA1 = new MySqlDataAdapter();
            DtA1.SelectCommand = sqlCmd1;
            DataTable sqlDt1 = new DataTable();
            DtA1.Fill(sqlDt1);
            sqlDt1.Columns.Add("zdjecie", Type.GetType("System.Byte[]"));

            foreach (DataRow row in sqlDt1.Rows)
            {
                try
                {
                    row["zdjecie"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["sciezka"].ToString()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Brak zdjęcia w bazie", ex.Message);
                }
            }


            dataGridView2.DataSource = sqlDt1;
            dataGridView2.RowTemplate.Height = 50;

        }

        //Lista produktów
        void Fillcombo()
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "select * from products.products";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand sqlCmd = new MySqlCommand(query, conn);
            MySqlDataReader sqlRd;
            try
            {
                conn.Open();
                sqlRd = sqlCmd.ExecuteReader();

                while (sqlRd.Read())
                {
                    string name = sqlRd.GetString("nazwa");
                    comboBox1.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Dodanie wybranego produktu do listy
        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Wybierz produkt z listy!");
            }
            else
            {
                listBox1.Items.Add(comboBox1.Text);
            }
        }

        //Usunięcie zaznaczonego produktu z listy
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Lista jest pusta!");
            }
            else
            {
                try
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Nie zaznaczono produktu!");
                }
            }
        }

        //Lista dań
        void Fillcombo2()
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "select * from products.dishes";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand sqlCmd = new MySqlCommand(query, conn);
            MySqlDataReader sqlRd;
            try
            {
                conn.Open();
                sqlRd = sqlCmd.ExecuteReader();

                while (sqlRd.Read())
                {
                    string name = sqlRd.GetString("nazwa");
                    comboBox2.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Przypisywanie produktów do dania
        private void AddProductToDishButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
                string queryProduct = "SELECT id FROM products.products WHERE nazwa = '" + this.listBox1.Items[i] + "';";
                MySqlConnection conn = new MySqlConnection(connection);
                MySqlCommand sqlCmd = new MySqlCommand(queryProduct, conn);
                MySqlDataReader sqlRd;

                conn.Open();

                try
                {
                    sqlRd = sqlCmd.ExecuteReader();

                    while (sqlRd.Read())
                    {
                        string name = sqlRd.GetString("id");
                        textBox1.Text = name;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Podano wartość z poza zakresu", ex.Message);
                }
                MessageBox.Show("Zapisano z sukcesem");

                string query = "INSERT INTO products.products_to_dishes(dish_id,product_id)" +
                        " VALUES('" + (this.comboBox2.SelectedIndex + 1) + "','" + int.Parse(textBox1.Text) + "')";
                MySqlConnection conn2 = new MySqlConnection(connection);
                MySqlCommand sqlCmd2 = new MySqlCommand(query, conn2);
                MySqlDataReader sqlRd2;
                conn2.Open();

                try
                {
                    sqlRd2 = sqlCmd2.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Podano wartość z poza zakresu", ex.Message);
                }
                conn.Close();
                conn2.Close();
            }


            upLoadData2();
            upLoadData();
        }

        private void ProduktDoDania_Load(object sender, EventArgs e)
        {

            upLoadData2();
            upLoadData();
        }

        //Box z daniami
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            upLoadData2();
            upLoadData();
        }
    }
}
