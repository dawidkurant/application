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
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Projekt.Forms
{
    public partial class Produkty : Form
    {
        bool firstClick = true;

        String server = "localhost";
        String username = "root";
        String password = "root";
        String database = "products";

        public Produkty()
        {
            InitializeComponent();
            Fillcombo1();
            Fillcombo2();
        }

        //Aktualizacja danych
        private void upLoadData()
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "select * from products.products";
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

            DataGridViewImageColumn dGVimageColumn = (DataGridViewImageColumn)dataGridView1.Columns[105];
            dGVimageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.Columns[104].Visible = false;

        }

        //Wskazówki
        private void tip()
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.txtNazwa1, "Podaj nazwę produktu");
            toolTip1.SetToolTip(this.comboBoxKategoria, "Wybierz kategorię produktu");
            toolTip1.SetToolTip(this.comboBoxMiara, "Wybierz miarę produktu");
            toolTip1.SetToolTip(this.txtWaga, "Podaj wagę produktu w gramach");
            toolTip1.SetToolTip(this.txtWartosc, "Podaj wartość energetyczną produktu");
            toolTip1.SetToolTip(this.txtBialko, "Podaj ilość białka produktu");
            toolTip1.SetToolTip(this.txtTluszcz, "Podaj ilość tłuszczu produktu");
            toolTip1.SetToolTip(this.txtWeglowodany, "Podaj ilość węglowodanów produktu");
            toolTip1.SetToolTip(this.txtWeglowodanyP, "Podaj ilość węglowodanów przyswajalnych produktu");
            toolTip1.SetToolTip(this.txtBlonnik, "Podaj ilość błonnika produktu");
            toolTip1.SetToolTip(this.txtWymienniki, "Podaj ilość wymienników węglowodanowych produktu");
            toolTip1.SetToolTip(this.txtSearch, "Wpisz nazwę produktu, którego szukasz");

        }

        //Wszystkie kategorie
        void Fillcombo1()
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "select * from products.categories";
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
                    comboBoxKategoria.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Wszystkie miary
        void Fillcombo2()
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "select * from products.measures";
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
                    comboBoxMiara.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Dodawanie produktu
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            foreach (Control txt in panel3.Controls)
            {
                if (String.IsNullOrEmpty(txt.Text))
                {
                    txt.Text = "0";
                }

                if (String.IsNullOrEmpty(txtNazwa1.Text))
                {
                    txtNazwa1.Text = "Domyślna";
                }

                if (String.IsNullOrEmpty(comboBoxKategoria.Text))
                {
                    comboBoxKategoria.Text = "Inne";
                }

                if (String.IsNullOrEmpty(comboBoxMiara.Text))
                {
                    comboBoxMiara.Text = "Inne";
                }
            }

            foreach (Control txt in panel5.Controls)
            {
                if (String.IsNullOrEmpty(txt.Text))
                {
                    txt.Text = "0";
                }
            }

            string connection1 = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "INSERT INTO products.products(nazwa,id_kategorii,kategoria,id_miary,miara,waga,wartosc,bialko,tluszcz,weglowodany,weglowodanyP," +
                "blonnik,wymienniki,wartoscE1,wartoscE2,wartoscE3,bialkoZ,bialkoR,sod,potas,wapn,fosfor,magnez,zelazo,cynk,miedz,mangan,jod," +
                "witaminaA,retinol,karoten,witaminaD,witaminaE,tiamina,ryboflawina,niacyna,witaminaB6,foliany,witaminaB12,witaminaC,c4,c6,c8,c10,c12,c14," +
                "c15,c16,c17,c18,c20,kwasyTN,c141,c151,c161,c171,c181,c201,c221,kwasyTJ,c182,c183,c184,c203,c204,epa,dpa,dha,kwasyTW,n6,n3,izoleucyna," +
                "leucyna,lizyna,metionina,cysteina,fenyloalanina,tyrozyna,treonina,tryptofan,walina,arginina,histydyna,alanina,kwasA,kwasG,glicyna," +
                "prolina,seryna,woda,cholesterol,sacharoza,laktoza,skrobia,odpadki,bialkoO,popiol,sol,glukoza,fruktoza,energiaB,energiaT,energiaW," +
                "sciezka)" +
                    " VALUES('" + this.txtNazwa1.Text +
                    "','" + (this.comboBoxKategoria.SelectedIndex + 1) +
                    "','" + this.comboBoxKategoria.Text +
                    "','" + (this.comboBoxMiara.SelectedIndex + 1) +
                    "','" + this.comboBoxMiara.Text +
                    "','" + this.txtWaga.Text +
                    "','" + this.txtWartosc.Text +
                    "','" + this.txtBialko.Text +
                    "','" + this.txtTluszcz.Text +
                    "','" + this.txtWeglowodany.Text +
                    "','" + this.txtWeglowodanyP.Text +
                    "','" + this.txtBlonnik.Text +
                    "','" + this.txtWymienniki.Text +
                    "','" + this.txtWartosc1.Text +
                    "','" + this.txtWartosc2.Text +
                    "','" + this.txtWartosc3.Text +
                    "','" + this.txtBialkoZ.Text +
                    "','" + this.txtBialkoR.Text +
                    "','" + this.txtSod.Text +
                    "','" + this.txtPotas.Text +
                    "','" + this.txtWapn.Text +
                    "','" + this.txtFosfor.Text +
                    "','" + this.txtMagnez.Text +
                    "','" + this.txtZelazo.Text +
                    "','" + this.txtCynk.Text +
                    "','" + this.txtMiedz.Text +
                    "','" + this.txtMangan.Text +
                    "','" + this.txtJod.Text +
                    "','" + this.txtWitaminaA.Text +
                    "','" + this.txtRetinol.Text +
                    "','" + this.txtKaroten.Text +
                    "','" + this.txtWitaminaD.Text +
                    "','" + this.txtWitaminaE.Text +
                    "','" + this.txtTiamina.Text +
                    "','" + this.txtRyboflawina.Text +
                    "','" + this.txtNiacyna.Text +
                    "','" + this.txtWitaminaB6.Text +
                    "','" + this.txtFoliany.Text +
                    "','" + this.txtWitaminaB12.Text +
                    "','" + this.txtWitaminaC.Text +
                    "','" + this.txtC4.Text +
                    "','" + this.txtC6.Text +
                    "','" + this.txtC8.Text +
                    "','" + this.txtC10.Text +
                    "','" + this.txtC12.Text +
                    "','" + this.txtC14.Text +
                    "','" + this.txtC15.Text +
                    "','" + this.txtC16.Text +
                    "','" + this.txtC17.Text +
                    "','" + this.txtC18.Text +
                    "','" + this.txtC20.Text +
                    "','" + this.txtKwasyTN.Text +
                    "','" + this.txtC141.Text +
                    "','" + this.txtC151.Text +
                    "','" + this.txtC161.Text +
                    "','" + this.txtC171.Text +
                    "','" + this.txtC181.Text +
                    "','" + this.txtC201.Text +
                    "','" + this.txtC221.Text +
                    "','" + this.txtKwasyTJ.Text +
                    "','" + this.txtC182.Text +
                    "','" + this.txtC183.Text +
                    "','" + this.txtC184.Text +
                    "','" + this.txtC203.Text +
                    "','" + this.txtC204.Text +
                    "','" + this.txtEPA.Text +
                    "','" + this.txtDPA.Text +
                    "','" + this.txtDHA.Text +
                    "','" + this.txtKwasyTW.Text +
                    "','" + this.txtN6.Text +
                    "','" + this.txtN3.Text +
                    "','" + this.txtIzoleucyna.Text +
                    "','" + this.txtLeucyna.Text +
                    "','" + this.txtLizyna.Text +
                    "','" + this.txtMetionina.Text +
                    "','" + this.txtCysteina.Text +
                    "','" + this.txtFenyloalanina.Text +
                    "','" + this.txtTyrozyna.Text +
                    "','" + this.txtTreonina.Text +
                    "','" + this.txtTryptofan.Text +
                    "','" + this.txtWalina.Text +
                    "','" + this.txtArginina.Text +
                    "','" + this.txtHistydyna.Text +
                    "','" + this.txtAlanina.Text +
                    "','" + this.txtKwasA.Text +
                    "','" + this.txtKwasG.Text +
                    "','" + this.txtGlicyna.Text +
                    "','" + this.txtProlina.Text +
                    "','" + this.txtSeryna.Text +
                    "','" + this.txtWoda.Text +
                    "','" + this.txtCholesterol.Text +
                    "','" + this.txtSacharoza.Text +
                    "','" + this.txtLaktoza.Text +
                    "','" + this.txtSkrobia.Text +
                    "','" + this.txtOdpadki.Text +
                    "','" + this.txtBialkoO.Text +
                    "','" + this.txtPopiol.Text +
                    "','" + this.txtSol.Text +
                    "','" + this.txtGlukoza.Text +
                    "','" + this.txtFruktoza.Text +
                    "','" + this.txtEnergiaB.Text +
                    "','" + this.txtEnergiaT.Text +
                    "','" + this.txtEnergiaW.Text +
                    "','" + Path.GetFileName(pictureBox1.ImageLocation) + "');";
            MySqlConnection conn1 = new MySqlConnection(connection1);
            MySqlCommand sqlCmd1 = new MySqlCommand(query, conn1);
            MySqlDataReader sqlRd1;
            conn1.Open();

            try
            {
                sqlRd1 = sqlCmd1.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Podano wartość z poza zakresu", ex.Message);
            }
            Console.WriteLine("Zapisano z sukcesem");
            conn1.Close();

            try
            {
                File.Copy(imageText.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(pictureBox1.ImageLocation));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            upLoadData();
        }
        
        //Usuwa wszystkie łańuchy znaków z textboxów i comboboxów
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in panel3.Controls)
                {
                    if (c is TextBox)
                    {
                        ((TextBox)c).Clear();
                    }
                    txtSearch.Text = "";
                    pictureBox1.Image = null;
                    comboBoxKategoria.Text = null;
                    comboBoxMiara.Text = null;
                }

                foreach (Control c in panel5.Controls)
                {
                    if (c is TextBox)
                    {
                        ((TextBox)c).Clear();
                    }
                }

                foreach (Control txt in panel3.Controls)
                {
                    if (!txt.Text.Equals(""))
                    {
                        foreach (Control ctrl in panel3.Controls)
                        {
                            if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                            {
                                ctrl.BackColor = Color.Silver;
                            }

                            if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                            {
                                ctrl.ForeColor = Color.Silver;
                                if (string.IsNullOrEmpty(txt.Text))
                                {
                                    ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                                    ctrl.Cursor = Cursors.Arrow;
                                    ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 20);
                                }
                            }
                        }
                    }
                }

                foreach (Control txt in panel5.Controls)
                {
                    if (!txt.Text.Equals(""))
                    {
                        foreach (Control ctrl in panel5.Controls)
                        {
                            if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                            {
                                ctrl.BackColor = Color.Silver;
                            }

                            if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                            {
                                ctrl.ForeColor = Color.Silver;
                                if (string.IsNullOrEmpty(txt.Text))
                                {
                                    ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                                    ctrl.Cursor = Cursors.Arrow;
                                    ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 18);
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Dodawanie zdjęcia
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images files (*.png) |*.png|(*.jpg)|*.jpg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageText.Text = dialog.FileName;
                pictureBox1.Image = new Bitmap(dialog.FileName);
                pictureBox1.ImageLocation = dialog.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void Produkty_Load(object sender, EventArgs e)
        {
            tip();
            upLoadData();
        }

        //Edytowanie produktu
        private void btnEditProduct_Click(object sender, EventArgs e)
        {

            foreach (Control txt in panel3.Controls)
            {
                if (String.IsNullOrEmpty(txt.Text))
                {
                    txt.Text = "0";
                }

                if (String.IsNullOrEmpty(txtNazwa1.Text))
                {
                    txtNazwa1.Text = "Domyślna";
                }

                if (String.IsNullOrEmpty(comboBoxKategoria.Text))
                {
                    comboBoxKategoria.Text = "Inne";
                }

                if (String.IsNullOrEmpty(comboBoxMiara.Text))
                {
                    comboBoxMiara.Text = "Inne";
                }
            }

            foreach (Control txt in panel5.Controls)
            {
                if (String.IsNullOrEmpty(txt.Text))
                {
                    txt.Text = "0";
                }
            }

            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "UPDATE products.products SET nazwa='" + this.txtNazwa1.Text +
                "' ,id_kategorii='" + (this.comboBoxKategoria.SelectedIndex + 1) +
                "' ,kategoria='" + this.comboBoxKategoria.Text +
                "' ,id_miary='" + (this.comboBoxMiara.SelectedIndex + 1) +
                "' ,miara='" + this.comboBoxMiara.Text +
                "' ,waga='" + this.txtWaga.Text +
                "' ,wartosc='" + this.txtWartosc.Text +
                "' ,bialko='" + this.txtBialko.Text +
                "' ,tluszcz='" + this.txtTluszcz.Text +
                "' ,weglowodany='" + this.txtWeglowodany.Text +
                "' ,weglowodanyP='" + this.txtWeglowodanyP.Text +
                "' ,blonnik='" + this.txtBlonnik.Text +
                "' ,wymienniki='" + this.txtWymienniki.Text +
                "' ,wartoscE1='" + this.txtWartosc1.Text +
                "' ,wartoscE2='" + this.txtWartosc2.Text +
                "' ,wartoscE3='" + this.txtWartosc3.Text +
                "' ,bialkoZ='" + this.txtBialkoZ.Text +
                "' ,bialkoR='" + this.txtBialkoR.Text +
                "' ,sod='" + this.txtSod.Text +
                "' ,potas='" + this.txtPotas.Text +
                "' ,wapn='" + this.txtWapn.Text +
                "' ,fosfor='" + this.txtFosfor.Text +
                "' ,magnez='" + this.txtMagnez.Text +
                "' ,zelazo='" + this.txtZelazo.Text +
                "' ,cynk='" + this.txtCynk.Text +
                "' ,miedz='" + this.txtMiedz.Text +
                "' ,mangan='" + this.txtMangan.Text +
                "' ,jod='" + this.txtJod.Text +
                "' ,witaminaA='" + this.txtWitaminaA.Text +
                "' ,retinol='" + this.txtRetinol.Text +
                "' ,karoten='" + this.txtKaroten.Text +
                "' ,witaminaD='" + this.txtWitaminaD.Text +
                "' ,witaminaE='" + this.txtWitaminaE.Text +
                "' ,tiamina='" + this.txtTiamina.Text +
                "' ,ryboflawina='" + this.txtRyboflawina.Text +
                "' ,niacyna='" + this.txtNiacyna.Text +
                "' ,witaminaB6='" + this.txtWitaminaB6.Text +
                "' ,foliany='" + this.txtFoliany.Text +
                "' ,witaminaB12='" + this.txtWitaminaB12.Text +
                "' ,witaminaC='" + this.txtWitaminaC.Text +
                "' ,C4='" + this.txtC4.Text +
                "' ,C6='" + this.txtC6.Text +
                "' ,C8='" + this.txtC8.Text +
                "' ,C10='" + this.txtC10.Text +
                "' ,C12='" + this.txtC12.Text +
                "' ,C14='" + this.txtC14.Text +
                "' ,C15='" + this.txtC15.Text +
                "' ,C16='" + this.txtC16.Text +
                "' ,C17='" + this.txtC17.Text +
                "' ,C18='" + this.txtC18.Text +
                "' ,C20='" + this.txtC20.Text +
                "' ,kwasyTN='" + this.txtKwasyTN.Text +
                "' ,c141='" + this.txtC141.Text +
                "' ,c151='" + this.txtC151.Text +
                "' ,c161='" + this.txtC161.Text +
                "' ,c171='" + this.txtC171.Text +
                "' ,c181='" + this.txtC181.Text +
                "' ,c201='" + this.txtC201.Text +
                "' ,c221='" + this.txtC221.Text +
                "' ,kwasyTJ='" + this.txtKwasyTJ.Text +
                "' ,c182='" + this.txtC182.Text +
                "' ,c183='" + this.txtC183.Text +
                "' ,c184='" + this.txtC184.Text +
                "' ,c203='" + this.txtC203.Text +
                "' ,c204='" + this.txtC204.Text +
                "' ,epa='" + this.txtEPA.Text +
                "' ,dpa='" + this.txtDPA.Text +
                "' ,dha='" + this.txtDHA.Text +
                "' ,kwasyTW='" + this.txtKwasyTW.Text +
                "' ,n6='" + this.txtN6.Text +
                "' ,n3='" + this.txtN3.Text +
                "' ,izoleucyna='" + this.txtIzoleucyna.Text +
                "' ,leucyna='" + this.txtLeucyna.Text +
                "' ,lizyna='" + this.txtLizyna.Text +
                "' ,metionina='" + this.txtMetionina.Text +
                "' ,cysteina='" + this.txtCysteina.Text +
                "' ,fenyloalanina='" + this.txtFenyloalanina.Text +
                "' ,tyrozyna='" + this.txtTyrozyna.Text +
                "' ,treonina='" + this.txtTreonina.Text +
                "' ,tryptofan='" + this.txtTryptofan.Text +
                "' ,walina='" + this.txtWalina.Text +
                "' ,arginina='" + this.txtArginina.Text +
                "' ,histydyna='" + this.txtHistydyna.Text +
                "' ,alanina='" + this.txtAlanina.Text +
                "' ,kwasA='" + this.txtKwasA.Text +
                "' ,kwasG='" + this.txtKwasG.Text +
                "' ,glicyna='" + this.txtGlicyna.Text +
                "' ,prolina='" + this.txtProlina.Text +
                "' ,seryna='" + this.txtSeryna.Text +
                "' ,woda='" + this.txtWoda.Text +
                "' ,cholesterol='" + this.txtCholesterol.Text +
                "' ,sacharoza='" + this.txtSacharoza.Text +
                "' ,laktoza='" + this.txtLaktoza.Text +
                "' ,skrobia='" + this.txtSkrobia.Text +
                "' ,odpadki='" + this.txtOdpadki.Text +
                "' ,bialkoO='" + this.txtBialkoO.Text +
                "' ,popiol='" + this.txtPopiol.Text +
                "' ,sol='" + this.txtSol.Text +
                "' ,glukoza='" + this.txtGlukoza.Text +
                "' ,fruktoza='" + this.txtFruktoza.Text +
                "' ,energiaB='" + this.txtEnergiaB.Text +
                "' ,energiaT='" + this.txtEnergiaT.Text +
                "' ,energiaW='" + this.txtEnergiaW.Text +
                "' ,sciezka='" + Path.GetFileName(pictureBox1.ImageLocation) +
                "'WHERE id='" + this.txtNumer.Text + "';";

            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand sqlCmd = new MySqlCommand(query, conn);
            MySqlDataReader sqlRd;
            conn.Open();
            sqlRd = sqlCmd.ExecuteReader();
            MessageBox.Show("Zaaktualizowano z sukcesem");
            conn.Close();

            try
            {
                File.Copy(imageText.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(pictureBox1.ImageLocation));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            upLoadData();
        }

        //Usuwanie produktu
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "DELETE FROM products.products WHERE id='" + this.txtNumer.Text + "'";

            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand sqlCmd = new MySqlCommand(query, conn);
            MySqlDataReader sqlRd;
            conn.Open();
            sqlRd = sqlCmd.ExecuteReader();
            MessageBox.Show("Usunięto z sukcesem");
            conn.Close();
            upLoadData();
        }

        //Wyszukiwanie produktu
        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (firstClick)
            {
                txtSearch.Text = String.Empty;
                firstClick = false;
            }

            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;

            MySqlConnection conn = new MySqlConnection(connection);
            DataTable sqlDt;
            MySqlDataAdapter DtA;
            conn.Open();
            DtA = new MySqlDataAdapter("SELECT * FROM products.products WHERE nazwa LIKE'" + this.txtSearch.Text + "%';", conn);
            sqlDt = new DataTable();
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

            conn.Close();
        }

        //Kopiowanie danych z tabelki do textboxów
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (Control lbl in panel3.Controls)
            {
                if (lbl.GetType() == typeof(Label))
                {
                    if (lbl.Location.X == 12 || lbl.Location.X == 266)
                    {
                        lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                        lbl.Cursor = Cursors.Arrow;
                        lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 20);
                        foreach (Control txt in panel3.Controls)
                        {
                            if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                            {
                                txt.Focus();
                            }
                        }
                    }
                }
            }

            foreach (Control lbl in panel5.Controls)
            {
                if (lbl.GetType() == typeof(Label))
                {
                    if (lbl.Location.X == 20 || lbl.Location.X == 234 || lbl.Location.X == 451)
                    {
                        lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                        lbl.Cursor = Cursors.Arrow;
                        lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 18);
                        foreach (Control txt in panel5.Controls)
                        {
                            if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                            {
                                txt.Focus();
                            }
                        }
                    }
                }
            }



            try
            {
                txtNumer.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtNazwa1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                //2 i 4 to id 
                comboBoxKategoria.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString(); ;
                comboBoxMiara.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtWaga.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtWartosc.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txtBialko.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtTluszcz.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                txtWeglowodany.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                txtWeglowodanyP.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                txtBlonnik.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                txtWymienniki.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                txtWartosc1.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                txtWartosc2.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                txtWartosc3.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                txtBialkoZ.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                txtBialkoR.Text = dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                txtSod.Text = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                txtPotas.Text = dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                txtWapn.Text = dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
                txtFosfor.Text = dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
                txtMagnez.Text = dataGridView1.SelectedRows[0].Cells[23].Value.ToString();
                txtZelazo.Text = dataGridView1.SelectedRows[0].Cells[24].Value.ToString();
                txtCynk.Text = dataGridView1.SelectedRows[0].Cells[25].Value.ToString();
                txtMiedz.Text = dataGridView1.SelectedRows[0].Cells[26].Value.ToString();
                txtMangan.Text = dataGridView1.SelectedRows[0].Cells[27].Value.ToString();
                txtJod.Text = dataGridView1.SelectedRows[0].Cells[28].Value.ToString();
                txtWitaminaA.Text = dataGridView1.SelectedRows[0].Cells[29].Value.ToString();
                txtRetinol.Text = dataGridView1.SelectedRows[0].Cells[30].Value.ToString();
                txtKaroten.Text = dataGridView1.SelectedRows[0].Cells[31].Value.ToString();
                txtWitaminaD.Text = dataGridView1.SelectedRows[0].Cells[32].Value.ToString();
                txtWitaminaE.Text = dataGridView1.SelectedRows[0].Cells[33].Value.ToString();
                txtTiamina.Text = dataGridView1.SelectedRows[0].Cells[34].Value.ToString();
                txtRyboflawina.Text = dataGridView1.SelectedRows[0].Cells[35].Value.ToString();
                txtNiacyna.Text = dataGridView1.SelectedRows[0].Cells[36].Value.ToString();
                txtWitaminaB6.Text = dataGridView1.SelectedRows[0].Cells[37].Value.ToString();
                txtFoliany.Text = dataGridView1.SelectedRows[0].Cells[38].Value.ToString();
                txtWitaminaB12.Text = dataGridView1.SelectedRows[0].Cells[39].Value.ToString();
                txtWitaminaC.Text = dataGridView1.SelectedRows[0].Cells[40].Value.ToString();
                txtC4.Text = dataGridView1.SelectedRows[0].Cells[41].Value.ToString();
                txtC6.Text = dataGridView1.SelectedRows[0].Cells[42].Value.ToString();
                txtC8.Text = dataGridView1.SelectedRows[0].Cells[43].Value.ToString();
                txtC10.Text = dataGridView1.SelectedRows[0].Cells[44].Value.ToString();
                txtC12.Text = dataGridView1.SelectedRows[0].Cells[45].Value.ToString();
                txtC14.Text = dataGridView1.SelectedRows[0].Cells[46].Value.ToString();
                txtC15.Text = dataGridView1.SelectedRows[0].Cells[47].Value.ToString();
                txtC16.Text = dataGridView1.SelectedRows[0].Cells[48].Value.ToString();
                txtC17.Text = dataGridView1.SelectedRows[0].Cells[49].Value.ToString();
                txtC18.Text = dataGridView1.SelectedRows[0].Cells[50].Value.ToString();
                txtC20.Text = dataGridView1.SelectedRows[0].Cells[51].Value.ToString();
                txtKwasyTN.Text = dataGridView1.SelectedRows[0].Cells[52].Value.ToString();
                txtC141.Text = dataGridView1.SelectedRows[0].Cells[53].Value.ToString();
                txtC151.Text = dataGridView1.SelectedRows[0].Cells[54].Value.ToString();
                txtC161.Text = dataGridView1.SelectedRows[0].Cells[55].Value.ToString();
                txtC171.Text = dataGridView1.SelectedRows[0].Cells[56].Value.ToString();
                txtC181.Text = dataGridView1.SelectedRows[0].Cells[57].Value.ToString();
                txtC201.Text = dataGridView1.SelectedRows[0].Cells[58].Value.ToString();
                txtC221.Text = dataGridView1.SelectedRows[0].Cells[59].Value.ToString();
                txtKwasyTJ.Text = dataGridView1.SelectedRows[0].Cells[60].Value.ToString();
                txtC182.Text = dataGridView1.SelectedRows[0].Cells[61].Value.ToString();
                txtC183.Text = dataGridView1.SelectedRows[0].Cells[62].Value.ToString();
                txtC184.Text = dataGridView1.SelectedRows[0].Cells[63].Value.ToString();
                txtC203.Text = dataGridView1.SelectedRows[0].Cells[64].Value.ToString();
                txtC204.Text = dataGridView1.SelectedRows[0].Cells[65].Value.ToString();
                txtEPA.Text = dataGridView1.SelectedRows[0].Cells[66].Value.ToString();
                txtDPA.Text = dataGridView1.SelectedRows[0].Cells[67].Value.ToString();
                txtDHA.Text = dataGridView1.SelectedRows[0].Cells[68].Value.ToString();
                txtKwasyTW.Text = dataGridView1.SelectedRows[0].Cells[69].Value.ToString();
                txtN6.Text = dataGridView1.SelectedRows[0].Cells[70].Value.ToString();
                txtN3.Text = dataGridView1.SelectedRows[0].Cells[71].Value.ToString();
                txtIzoleucyna.Text = dataGridView1.SelectedRows[0].Cells[72].Value.ToString();
                txtLeucyna.Text = dataGridView1.SelectedRows[0].Cells[73].Value.ToString();
                txtLizyna.Text = dataGridView1.SelectedRows[0].Cells[74].Value.ToString();
                txtMetionina.Text = dataGridView1.SelectedRows[0].Cells[75].Value.ToString();
                txtCysteina.Text = dataGridView1.SelectedRows[0].Cells[76].Value.ToString();
                txtFenyloalanina.Text = dataGridView1.SelectedRows[0].Cells[77].Value.ToString();
                txtTyrozyna.Text = dataGridView1.SelectedRows[0].Cells[78].Value.ToString();
                txtTreonina.Text = dataGridView1.SelectedRows[0].Cells[79].Value.ToString();
                txtTryptofan.Text = dataGridView1.SelectedRows[0].Cells[80].Value.ToString();
                txtWalina.Text = dataGridView1.SelectedRows[0].Cells[81].Value.ToString();
                txtArginina.Text = dataGridView1.SelectedRows[0].Cells[82].Value.ToString();
                txtHistydyna.Text = dataGridView1.SelectedRows[0].Cells[83].Value.ToString();
                txtAlanina.Text = dataGridView1.SelectedRows[0].Cells[84].Value.ToString();
                txtKwasA.Text = dataGridView1.SelectedRows[0].Cells[85].Value.ToString();
                txtKwasG.Text = dataGridView1.SelectedRows[0].Cells[86].Value.ToString();
                txtGlicyna.Text = dataGridView1.SelectedRows[0].Cells[87].Value.ToString();
                txtProlina.Text = dataGridView1.SelectedRows[0].Cells[88].Value.ToString();
                txtSeryna.Text = dataGridView1.SelectedRows[0].Cells[89].Value.ToString();
                txtWoda.Text = dataGridView1.SelectedRows[0].Cells[90].Value.ToString();
                txtCholesterol.Text = dataGridView1.SelectedRows[0].Cells[91].Value.ToString();
                txtSacharoza.Text = dataGridView1.SelectedRows[0].Cells[92].Value.ToString();
                txtLaktoza.Text = dataGridView1.SelectedRows[0].Cells[93].Value.ToString();
                txtSkrobia.Text = dataGridView1.SelectedRows[0].Cells[94].Value.ToString();
                txtOdpadki.Text = dataGridView1.SelectedRows[0].Cells[95].Value.ToString();
                txtBialkoO.Text = dataGridView1.SelectedRows[0].Cells[96].Value.ToString();
                txtPopiol.Text = dataGridView1.SelectedRows[0].Cells[97].Value.ToString();
                txtSol.Text = dataGridView1.SelectedRows[0].Cells[98].Value.ToString();
                txtGlukoza.Text = dataGridView1.SelectedRows[0].Cells[99].Value.ToString();
                txtFruktoza.Text = dataGridView1.SelectedRows[0].Cells[100].Value.ToString();
                txtEnergiaB.Text = dataGridView1.SelectedRows[0].Cells[101].Value.ToString();
                txtEnergiaT.Text = dataGridView1.SelectedRows[0].Cells[102].Value.ToString();
                txtEnergiaW.Text = dataGridView1.SelectedRows[0].Cells[103].Value.ToString();



                //imageText.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                //byte[] img = (byte[])dataGridView1.SelectedRows[0].Cells[12].Value;
                //MemoryStream ms = new MemoryStream(img);
                //pictureBox1.Image = System.Drawing.Image.FromStream(ms);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            foreach (Control txt in panel3.Controls)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Text = txt.Text.Replace(',', '.');
                }
            }
        }

        //metoda eksportuje tabelkę do pliku pdf 
        public void exportGridToPDF(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfPTable = new PdfPTable(dgw.Columns.Count);
            pdfPTable.DefaultCell.Padding = 3;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);


            //Add header
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                cell.Rotation = 90;
                pdfPTable.AddCell(cell);
            }

            //Add datarow
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfPTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var saveFieldDialog = new SaveFileDialog();
            saveFieldDialog.FileName = filename;
            saveFieldDialog.DefaultExt = ".pdf";

            if (saveFieldDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFieldDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfPTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        //metoda wywołuje generowanie tabelki do pliku pdf
        private void btnToFile_Click(object sender, EventArgs e)
        {
            exportGridToPDF(dataGridView1, "Plik");
        }

        //kliknięcie w textbox przemieszcza label nad textbox dla pierwszej kolumny
        private void LabelEffect_Click(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 12)
            {
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 20);
                foreach (Control txt in panel3.Controls)
                {
                    if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                    {
                        txt.Focus();
                    }
                }
            }
        }

        //label i textbox zmienia kolor na niebieski dla pierwszej kolumny
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel3.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.DodgerBlue;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.DodgerBlue;
                    if (ctrl.Location.X != 9)
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X - 3, ctrl.Location.Y - 20);
                    }
                }
            }

        }

        //gdy textbox nieaktywny label wraca na swoje miejsce i zmienia kolor na silver dla pierwszej kolumny
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel3.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.Silver;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.Silver;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 20);
                    }
                }
            }
        }

        //kliknięcie w textbox przemieszcza label nad textbox dla drugiej kolumny
        private void LabelEffect_Click2(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 266)
            {
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 20);
                foreach (Control txt in panel3.Controls)
                {
                    if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                    {
                        txt.Focus();
                    }
                }
            }
        }

        //label i textbox zmienia kolor na niebieski dla drugiej kolumny
        private void TextBox_Enter2(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel3.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.DodgerBlue;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.DodgerBlue;
                    if (ctrl.Location.X != 263)
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X - 3, ctrl.Location.Y - 20);
                    }
                }
            }

        }

        //gdy textbox nieaktywny label wraca na swoje miejsce i zmienia kolor na silver dla drugiej kolumny
        private void TextBox_Leave2(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel3.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.Silver;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.Silver;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 20);
                    }
                }
            }
        }

        //kliknięcie w textbox przemieszcza label nad textbox dla wyszukiwania
        private void LabelEffect_Click3(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 8)
            {
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 30);
                foreach (Control txt in panel1.Controls)
                {
                    if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                    {
                        txt.Focus();
                    }
                }
            }
        }

        //label i textbox zmienia kolor na niebieski dla wyszukiwania
        private void TextBox_Enter3(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.DodgerBlue;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.DodgerBlue;
                    if (ctrl.Location.X != 5)
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X - 3, ctrl.Location.Y - 30);
                    }
                }
            }

        }

        //gdy textbox nieaktywny label wraca na swoje miejsce i zmienia kolor na silver dla wyszukiwania
        private void TextBox_Leave3(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.Silver;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.Silver;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 30);
                    }
                }
            }
        }

        //kliknięcie w textbox przemieszcza label nad textbox dla trzeciej kolumny
        private void LabelEffect_Click4(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 20)
            {
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 18);
                foreach (Control txt in panel5.Controls)
                {
                    if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                    {
                        txt.Focus();
                    }
                }
            }
        }

        //label i textbox zmienia kolor na niebieski dla trzeciej kolumny
        private void TextBox_Enter4(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.DodgerBlue;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.DodgerBlue;
                    if (ctrl.Location.X != 17)
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X - 3, ctrl.Location.Y - 18);
                    }
                }
            }

        }

        //gdy textbox nieaktywny label wraca na swoje miejsce i zmienia kolor na silver dla trzeciej kolumny
        private void TextBox_Leave4(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.Silver;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.Silver;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 18);
                    }
                }
            }
        }

        //kliknięcie w textbox przemieszcza label nad textbox dla czwartej kolumny
        private void LabelEffect_Click5(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 234)
            {
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 18);
                foreach (Control txt in panel5.Controls)
                {
                    if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                    {
                        txt.Focus();
                    }
                }
            }
        }

        //label i textbox zmienia kolor na niebieski dla czwartej kolumny
        private void TextBox_Enter5(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.DodgerBlue;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.DodgerBlue;
                    if (ctrl.Location.X != 231)
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X - 3, ctrl.Location.Y - 18);
                    }
                }
            }

        }

        //gdy textbox nieaktywny label wraca na swoje miejsce i zmienia kolor na silver dla czwartej kolumny
        private void TextBox_Leave5(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.Silver;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.Silver;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 18);
                    }
                }
            }
        }

        //kliknięcie w textbox przemieszcza label nad textbox dla piątej kolumny
        private void LabelEffect_Click6(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 451)
            {
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 18);
                foreach (Control txt in panel5.Controls)
                {
                    if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                    {
                        txt.Focus();
                    }
                }
            }
        }

        //label i textbox zmienia kolor na niebieski dla piątej kolumny
        private void TextBox_Enter6(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.DodgerBlue;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.DodgerBlue;
                    if (ctrl.Location.X != 448)
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X - 3, ctrl.Location.Y - 18);
                    }
                }
            }

        }

        //gdy textbox nieaktywny label wraca na swoje miejsce i zmienia kolor na silver dla piątej kolumny
        private void TextBox_Leave6(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.Silver;
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.Silver;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        ctrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 18);
                    }
                }
            }
        }

        //Filtr sprawdzający czy użytkownik wprowadza tylko liczby 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //wybór kolumny, która ma się wyświetlać w tabeli
        private void btnChange_Click(object sender, EventArgs e)
        {
            foreach (string s in checkedListBoxChange.CheckedItems)
            {
                if (s == "Kalorie")
                {
                    dataGridView1.Columns[7].Visible = true;
                }

                if (s == "Białko ogółem")
                {
                    dataGridView1.Columns[8].Visible = true;
                }

                if (s == "Tłuszcz")
                {
                    dataGridView1.Columns[9].Visible = true;
                }

                if (s == "Węglowodany ogółem")
                {
                    dataGridView1.Columns[10].Visible = true;
                }

                if (s == "Węglowodany przyswajalne")
                {
                    dataGridView1.Columns[11].Visible = true;
                }

                if (s == "Błonnik pokarmowy")
                {
                    dataGridView1.Columns[12].Visible = true;
                }

                if (s == "Wymienniki węglowodanowe")
                {
                    dataGridView1.Columns[13].Visible = true;
                }

                if (s == "Wartość energetyczna wg rozp.1169/2011 (kcal)[kcal]")
                {
                    dataGridView1.Columns[14].Visible = true;
                }

                if (s == "Wartość energetyczna (kJ)[kJ]")
                {
                    dataGridView1.Columns[15].Visible = true;
                }

                if (s == "Wartość energetyczna wg rozp.1169/2011 (kJ)[kJ]")
                {
                    dataGridView1.Columns[16].Visible = true;
                }

                if (s == "Białko zwierzęce [g]")
                {
                    dataGridView1.Columns[17].Visible = true;
                }

                if (s == "Białko roślinne [g]")
                {
                    dataGridView1.Columns[18].Visible = true;
                }

                if (s == "Sód [mg]")
                {
                    dataGridView1.Columns[19].Visible = true;
                }

                if (s == "Potas [mg]")
                {
                    dataGridView1.Columns[20].Visible = true;
                }

                if (s == "Wapń [mg]")
                {
                    dataGridView1.Columns[21].Visible = true;
                }

                if (s == "Fosfor [mg]")
                {
                    dataGridView1.Columns[22].Visible = true;
                }

                if (s == "Magnez [mg]")
                {
                    dataGridView1.Columns[23].Visible = true;
                }

                if (s == "Żelazo [mg]")
                {
                    dataGridView1.Columns[24].Visible = true;
                }

                if (s == "Cynk [mg]")
                {
                    dataGridView1.Columns[25].Visible = true;
                }

                if (s == "Miedź [mg]")
                {
                    dataGridView1.Columns[26].Visible = true;
                }

                if (s == "Mangan [mg]")
                {
                    dataGridView1.Columns[27].Visible = true;
                }

                if (s == "Jod [μg]")
                {
                    dataGridView1.Columns[28].Visible = true;
                }

                if (s == "Witamina A - ekwiwalent retinolu [μg]")
                {
                    dataGridView1.Columns[29].Visible = true;
                }

                if (s == "Retinol [μg]")
                {
                    dataGridView1.Columns[30].Visible = true;
                }

                if (s == "β-karoten [μg]")
                {
                    dataGridView1.Columns[31].Visible = true;
                }

                if (s == "Witamina D [μg]")
                {
                    dataGridView1.Columns[32].Visible = true;
                }

                if (s == "Witamina E – ekwiwalent α-tokoferolu [mg]")
                {
                    dataGridView1.Columns[33].Visible = true;
                }

                if (s == "Tiamina [mg]")
                {
                    dataGridView1.Columns[34].Visible = true;
                }

                if (s == "Ryboflawina [mg]")
                {
                    dataGridView1.Columns[35].Visible = true;
                }

                if (s == "Niacyna [mg]")
                {
                    dataGridView1.Columns[36].Visible = true;
                }

                if (s == "Witamina B6 [mg]")
                {
                    dataGridView1.Columns[37].Visible = true;
                }

                if (s == "Foliany [μg]")
                {
                    dataGridView1.Columns[38].Visible = true;
                }

                if (s == "Witamina B12 [μg]")
                {
                    dataGridView1.Columns[39].Visible = true;
                }

                if (s == "Witamina C [mg]")
                {
                    dataGridView1.Columns[40].Visible = true;
                }

                if (s == "C4:0 [g]")
                {
                    dataGridView1.Columns[41].Visible = true;
                }

                if (s == "C6:0 [g]")
                {
                    dataGridView1.Columns[42].Visible = true;
                }

                if (s == "C8:0 [g]")
                {
                    dataGridView1.Columns[43].Visible = true;
                }

                if (s == "C10:0 [g]")
                {
                    dataGridView1.Columns[44].Visible = true;
                }

                if (s == "C12:0 [g]")
                {
                    dataGridView1.Columns[45].Visible = true;
                }

                if (s == "C14:0 [g]")
                {
                    dataGridView1.Columns[46].Visible = true;
                }

                if (s == "C15:0 [g]")
                {
                    dataGridView1.Columns[47].Visible = true;
                }

                if (s == "C16:0 [g]")
                {
                    dataGridView1.Columns[48].Visible = true;
                }

                if (s == "C17:0 [g]")
                {
                    dataGridView1.Columns[49].Visible = true;
                }

                if (s == "C18:0 [g]")
                {
                    dataGridView1.Columns[50].Visible = true;
                }

                if (s == "C20:0 [g]")
                {
                    dataGridView1.Columns[51].Visible = true;
                }

                if (s == "Kwasy tłuszczowe nasycone ogółem [g]")
                {
                    dataGridView1.Columns[52].Visible = true;
                }

                if (s == "C14:1 [g]")
                {
                    dataGridView1.Columns[53].Visible = true;
                }

                if (s == "C15:1 [g]")
                {
                    dataGridView1.Columns[54].Visible = true;
                }

                if (s == "C16:1 [g]")
                {
                    dataGridView1.Columns[55].Visible = true;
                }

                if (s == "C17:1 [g]")
                {
                    dataGridView1.Columns[56].Visible = true;
                }

                if (s == "C18:1 [g]")
                {
                    dataGridView1.Columns[57].Visible = true;
                }

                if (s == "C20:1 [g]")
                {
                    dataGridView1.Columns[58].Visible = true;
                }

                if (s == "C22:1 [g]")
                {
                    dataGridView1.Columns[59].Visible = true;
                }

                if (s == "Kwasy tłuszczowe jednonienasycone ogółem [g]")
                {
                    dataGridView1.Columns[60].Visible = true;
                }

                if (s == "C18:2 [g]")
                {
                    dataGridView1.Columns[61].Visible = true;
                }

                if (s == "C18:3 [g]")
                {
                    dataGridView1.Columns[62].Visible = true;
                }

                if (s == "C18:4 [g]")
                {
                    dataGridView1.Columns[63].Visible = true;
                }

                if (s == "C20:3 [g]")
                {
                    dataGridView1.Columns[64].Visible = true;
                }

                if (s == "C20:4 [g]")
                {
                    dataGridView1.Columns[65].Visible = true;
                }

                if (s == "EPA [g]")
                {
                    dataGridView1.Columns[66].Visible = true;
                }

                if (s == "DPA [g]")
                {
                    dataGridView1.Columns[67].Visible = true;
                }

                if (s == "DHA [g]")
                {
                    dataGridView1.Columns[68].Visible = true;
                }

                if (s == "Kwasy tłuszczowe wielonienasycone ogółem [g]")
                {
                    dataGridView1.Columns[69].Visible = true;
                }

                if (s == "n-6 [g]")
                {
                    dataGridView1.Columns[70].Visible = true;
                }

                if (s == "n-3 [g]")
                {
                    dataGridView1.Columns[71].Visible = true;
                }

                if (s == "Izoleucyna [mg]")
                {
                    dataGridView1.Columns[72].Visible = true;
                }

                if (s == "Leucyna [mg]")
                {
                    dataGridView1.Columns[73].Visible = true;
                }

                if (s == "Lizyna [mg]")
                {
                    dataGridView1.Columns[74].Visible = true;
                }

                if (s == "Metionina [mg]")
                {
                    dataGridView1.Columns[75].Visible = true;
                }

                if (s == "Cysteina [mg]")
                {
                    dataGridView1.Columns[76].Visible = true;
                }

                if (s == "Fenyloalanina [mg]")
                {
                    dataGridView1.Columns[77].Visible = true;
                }

                if (s == "Tyrozyna [mg]")
                {
                    dataGridView1.Columns[78].Visible = true;
                }

                if (s == "Treonina [mg]")
                {
                    dataGridView1.Columns[79].Visible = true;
                }

                if (s == "Tryptofan [mg]")
                {
                    dataGridView1.Columns[80].Visible = true;
                }

                if (s == "Walina [mg]")
                {
                    dataGridView1.Columns[81].Visible = true;
                }

                if (s == "Arginina [mg]")
                {
                    dataGridView1.Columns[82].Visible = true;
                }

                if (s == "Histydyna [mg]")
                {
                    dataGridView1.Columns[83].Visible = true;
                }

                if (s == "Alanina [mg]")
                {
                    dataGridView1.Columns[84].Visible = true;
                }

                if (s == "Kwas asparaginowy [mg]")
                {
                    dataGridView1.Columns[85].Visible = true;
                }

                if (s == "Kwas glutaminowy [mg]")
                {
                    dataGridView1.Columns[86].Visible = true;
                }

                if (s == "Glicyna [mg]")
                {
                    dataGridView1.Columns[87].Visible = true;
                }

                if (s == "Prolina [mg]")
                {
                    dataGridView1.Columns[88].Visible = true;
                }

                if (s == "Seryna [mg]")
                {
                    dataGridView1.Columns[89].Visible = true;
                }

                if (s == "Woda [g]")
                {
                    dataGridView1.Columns[90].Visible = true;
                }

                if (s == "Cholesterol [mg]")
                {
                    dataGridView1.Columns[91].Visible = true;
                }

                if (s == "Sacharoza [g]")
                {
                    dataGridView1.Columns[92].Visible = true;
                }

                if (s == "Laktoza [g]")
                {
                    dataGridView1.Columns[93].Visible = true;
                }

                if (s == "Skrobia [g]")
                {
                    dataGridView1.Columns[94].Visible = true;
                }

                if (s == "Odpadki [%]")
                {
                    dataGridView1.Columns[95].Visible = true;
                }

                if (s == "Białko ogółem wg rozp. 1169/2011 [g]")
                {
                    dataGridView1.Columns[96].Visible = true;
                }

                if (s == "Popiół [g]")
                {
                    dataGridView1.Columns[97].Visible = true;
                }

                if (s == "Sól [g]")
                {
                    dataGridView1.Columns[98].Visible = true;
                }

                if (s == "Glukoza [g]")
                {
                    dataGridView1.Columns[99].Visible = true;
                }

                if (s == "Fruktoza [g]")
                {
                    dataGridView1.Columns[100].Visible = true;
                }

                if (s == "% energii z białka [%]")
                {
                    dataGridView1.Columns[101].Visible = true;
                }

                if (s == "% energii z tłuszczu [%]")
                {
                    dataGridView1.Columns[102].Visible = true;
                }

                if (s == "% energii z węglowodanów [%]")
                {
                    dataGridView1.Columns[103].Visible = true;
                }
            }
        }

        //cofa decyzje o wyświetlaniu kolumn  
        private void btnUndo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxChange.Items.Count; i++)
            {
                checkedListBoxChange.SetItemChecked(i, false);
            }

            for (int j = 7; j < 104; j++)
            {
                dataGridView1.Columns[j].Visible = false;
            }
        }
    }
}
