using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class Dania : Form
    {

        String server = "localhost";
        String username = "root";
        String password = "root";
        String database = "products";

        public Dania()
        {
            InitializeComponent();
        }

        //Aktualizacja danych
        private void upLoadData()
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "select * from products.dishes";
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

            DataGridViewImageColumn dGVimageColumn = (DataGridViewImageColumn)dataGridView1.Columns[4];
            dGVimageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Columns[3].Visible = false;

        }

        //Dodawanie dania
        private void btnAddDish_Click(object sender, EventArgs e)
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "INSERT INTO products.dishes(nazwa,przepis,sciezka)" +
                    " VALUES('" + this.txtNazwa1.Text + "','" + this.przepis.Text + "','" + Path.GetFileName(pictureBox1.ImageLocation) + "');";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand sqlCmd = new MySqlCommand(query, conn);
            MySqlDataReader sqlRd;
            conn.Open();

            try
            {
                sqlRd = sqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Podano wartość z poza zakresu", ex.Message);
            }
            MessageBox.Show("Zapisano z sukcesem");
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

        //Czyszczenie wszystkich boxów z wartości
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Dodawanie obrazka
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

        //Usuwanie dania
        private void btnDeleteDish_Click(object sender, EventArgs e)
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "DELETE FROM products.dishes WHERE id='" + this.txtNumer.Text + "'";

            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand sqlCmd = new MySqlCommand(query, conn);
            MySqlDataReader sqlRd;
            conn.Open();
            sqlRd = sqlCmd.ExecuteReader();
            MessageBox.Show("Usunięto z sukcesem");
            conn.Close();
            upLoadData();
        }

        private void Dania_Load(object sender, EventArgs e)
        {
            upLoadData();
        }

        //Edycja dania
        private void btnEditDish_Click(object sender, EventArgs e)
        {
            string connection = "server= " + server + ";" + " user id = " + username + ";" +
                " password = " + password + ";" + " database = " + database;
            string query = "UPDATE products.dishes SET nazwa='" + this.txtNazwa1.Text + "' ,przepis='" + this.przepis.Text + "' ,sciezka='" +
                Path.GetFileName(pictureBox1.ImageLocation) + "'WHERE id='" + this.txtNumer.Text + "';";

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

        //Metoda eksportuje tabelkę do pliku pdf 
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
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfPTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        //Metoda wywołuje generowanie tabelki do pliku pdf
        private void btnToFile_Click(object sender, EventArgs e)
        {
            exportGridToPDF(dataGridView1, "Plik2");
        }

        //Kopiowanie danych z tabelki do boxów
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Control lbl in panel3.Controls)
            {
                if (lbl.GetType() == typeof(Label))
                {
                    if (lbl.Location.X == 20)
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

            try
            {
                txtNumer.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtNazwa1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                przepis.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                //imageText.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                //byte[] img = (byte[])dataGridView1.SelectedRows[0].Cells[12].Value;
                //MemoryStream ms = new MemoryStream(img);
                //pictureBox1.Image = System.Drawing.Image.FromStream(ms);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Kliknięcie w textbox przemieszcza label nad textbox dla pierwszej kolumny
        private void LabelEffect_Click(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 20)
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
                    if (ctrl.Location.X != 17)
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

        //kliknięcie w textbox przemieszcza label nad textbox dla wyszukiwania
        private void LabelEffect_Click3(object sender, EventArgs e)
        {
            var lbl = sender as Label;

            if (lbl.Location.X == 8)
            {
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 30);
                foreach (Control txt in panel2.Controls)
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

            foreach (Control ctrl in panel2.Controls)
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

            foreach (Control ctrl in panel2.Controls)
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
    }
}
