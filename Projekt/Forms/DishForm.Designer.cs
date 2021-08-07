namespace Projekt.Forms
{
    partial class Dania
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnToFile = new FontAwesome.Sharp.IconButton();
            this.btnAddImage = new FontAwesome.Sharp.IconButton();
            this.btnReset = new FontAwesome.Sharp.IconButton();
            this.btnDeleteDish = new FontAwesome.Sharp.IconButton();
            this.btnEditDish = new FontAwesome.Sharp.IconButton();
            this.btnAddDish = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNumer = new System.Windows.Forms.Label();
            this.pnlNumer = new System.Windows.Forms.Panel();
            this.txtNumer = new System.Windows.Forms.TextBox();
            this.lblNazwa1 = new System.Windows.Forms.Label();
            this.pnlNazwa1 = new System.Windows.Forms.Panel();
            this.txtNazwa1 = new System.Windows.Forms.TextBox();
            this.przepis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.btnToFile);
            this.panelMenu.Controls.Add(this.btnAddImage);
            this.panelMenu.Controls.Add(this.btnReset);
            this.panelMenu.Controls.Add(this.btnDeleteDish);
            this.panelMenu.Controls.Add(this.btnEditDish);
            this.panelMenu.Controls.Add(this.btnAddDish);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMenu.Location = new System.Drawing.Point(1144, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(210, 651);
            this.panelMenu.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.panel2.Controls.Add(this.lblSearch);
            this.panel2.Controls.Add(this.pnlSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Location = new System.Drawing.Point(0, 414);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 91);
            this.panel2.TabIndex = 10;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSearch.ForeColor = System.Drawing.Color.Silver;
            this.lblSearch.Location = new System.Drawing.Point(8, 30);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(164, 25);
            this.lblSearch.TabIndex = 94;
            this.lblSearch.Text = "Wyszukaj danie";
            this.lblSearch.Click += new System.EventHandler(this.LabelEffect_Click3);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Silver;
            this.pnlSearch.ForeColor = System.Drawing.Color.White;
            this.pnlSearch.Location = new System.Drawing.Point(8, 61);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(195, 2);
            this.pnlSearch.TabIndex = 93;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(15)))), ((int)(((byte)(90)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(8, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 24);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.Enter += new System.EventHandler(this.TextBox_Enter3);
            this.txtSearch.Leave += new System.EventHandler(this.TextBox_Leave3);
            // 
            // btnToFile
            // 
            this.btnToFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToFile.FlatAppearance.BorderSize = 0;
            this.btnToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToFile.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnToFile.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnToFile.IconColor = System.Drawing.Color.Gainsboro;
            this.btnToFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnToFile.IconSize = 32;
            this.btnToFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToFile.Location = new System.Drawing.Point(0, 300);
            this.btnToFile.Name = "btnToFile";
            this.btnToFile.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnToFile.Size = new System.Drawing.Size(210, 60);
            this.btnToFile.TabIndex = 9;
            this.btnToFile.Text = "Do pliku";
            this.btnToFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToFile.UseVisualStyleBackColor = true;
            this.btnToFile.Click += new System.EventHandler(this.btnToFile_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddImage.FlatAppearance.BorderSize = 0;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAddImage.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.btnAddImage.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAddImage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddImage.IconSize = 32;
            this.btnAddImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddImage.Location = new System.Drawing.Point(0, 240);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnAddImage.Size = new System.Drawing.Size(210, 60);
            this.btnAddImage.TabIndex = 8;
            this.btnAddImage.Text = "Dodaj zdjęcie";
            this.btnAddImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReset.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnReset.IconColor = System.Drawing.Color.Gainsboro;
            this.btnReset.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReset.IconSize = 32;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(0, 180);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnReset.Size = new System.Drawing.Size(210, 60);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Wyczyść";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDeleteDish
            // 
            this.btnDeleteDish.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteDish.FlatAppearance.BorderSize = 0;
            this.btnDeleteDish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDish.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteDish.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnDeleteDish.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteDish.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeleteDish.IconSize = 32;
            this.btnDeleteDish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDish.Location = new System.Drawing.Point(0, 120);
            this.btnDeleteDish.Name = "btnDeleteDish";
            this.btnDeleteDish.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnDeleteDish.Size = new System.Drawing.Size(210, 60);
            this.btnDeleteDish.TabIndex = 6;
            this.btnDeleteDish.Text = "Usuń danie";
            this.btnDeleteDish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteDish.UseVisualStyleBackColor = true;
            this.btnDeleteDish.Click += new System.EventHandler(this.btnDeleteDish_Click);
            // 
            // btnEditDish
            // 
            this.btnEditDish.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditDish.FlatAppearance.BorderSize = 0;
            this.btnEditDish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDish.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEditDish.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnEditDish.IconColor = System.Drawing.Color.Gainsboro;
            this.btnEditDish.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditDish.IconSize = 32;
            this.btnEditDish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDish.Location = new System.Drawing.Point(0, 60);
            this.btnEditDish.Name = "btnEditDish";
            this.btnEditDish.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnEditDish.Size = new System.Drawing.Size(210, 60);
            this.btnEditDish.TabIndex = 5;
            this.btnEditDish.Text = "Zaaktualizuj danie";
            this.btnEditDish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditDish.UseVisualStyleBackColor = true;
            this.btnEditDish.Click += new System.EventHandler(this.btnEditDish_Click);
            // 
            // btnAddDish
            // 
            this.btnAddDish.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDish.FlatAppearance.BorderSize = 0;
            this.btnAddDish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDish.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAddDish.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddDish.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAddDish.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddDish.IconSize = 32;
            this.btnAddDish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDish.Location = new System.Drawing.Point(0, 0);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnAddDish.Size = new System.Drawing.Size(210, 60);
            this.btnAddDish.TabIndex = 4;
            this.btnAddDish.Text = "Dodaj danie";
            this.btnAddDish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
            this.panel3.Controls.Add(this.lblNumer);
            this.panel3.Controls.Add(this.pnlNumer);
            this.panel3.Controls.Add(this.txtNumer);
            this.panel3.Controls.Add(this.lblNazwa1);
            this.panel3.Controls.Add(this.pnlNazwa1);
            this.panel3.Controls.Add(this.txtNazwa1);
            this.panel3.Controls.Add(this.przepis);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.imageText);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(234, 651);
            this.panel3.TabIndex = 4;
            // 
            // lblNumer
            // 
            this.lblNumer.AutoEllipsis = true;
            this.lblNumer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblNumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumer.ForeColor = System.Drawing.Color.Silver;
            this.lblNumer.Location = new System.Drawing.Point(20, 19);
            this.lblNumer.Margin = new System.Windows.Forms.Padding(3);
            this.lblNumer.Name = "lblNumer";
            this.lblNumer.Size = new System.Drawing.Size(150, 20);
            this.lblNumer.TabIndex = 64;
            this.lblNumer.Text = "Numer";
            this.lblNumer.Click += new System.EventHandler(this.LabelEffect_Click);
            // 
            // pnlNumer
            // 
            this.pnlNumer.BackColor = System.Drawing.Color.Silver;
            this.pnlNumer.ForeColor = System.Drawing.Color.White;
            this.pnlNumer.Location = new System.Drawing.Point(20, 47);
            this.pnlNumer.Name = "pnlNumer";
            this.pnlNumer.Size = new System.Drawing.Size(150, 2);
            this.pnlNumer.TabIndex = 63;
            // 
            // txtNumer
            // 
            this.txtNumer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
            this.txtNumer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNumer.ForeColor = System.Drawing.Color.White;
            this.txtNumer.Location = new System.Drawing.Point(20, 19);
            this.txtNumer.Name = "txtNumer";
            this.txtNumer.ReadOnly = true;
            this.txtNumer.Size = new System.Drawing.Size(150, 19);
            this.txtNumer.TabIndex = 1;
            this.txtNumer.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtNumer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtNumer.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblNazwa1
            // 
            this.lblNazwa1.AutoEllipsis = true;
            this.lblNazwa1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblNazwa1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNazwa1.ForeColor = System.Drawing.Color.Silver;
            this.lblNazwa1.Location = new System.Drawing.Point(20, 78);
            this.lblNazwa1.Margin = new System.Windows.Forms.Padding(3);
            this.lblNazwa1.Name = "lblNazwa1";
            this.lblNazwa1.Size = new System.Drawing.Size(150, 20);
            this.lblNazwa1.TabIndex = 61;
            this.lblNazwa1.Text = "Nazwa dania";
            this.lblNazwa1.Click += new System.EventHandler(this.LabelEffect_Click);
            // 
            // pnlNazwa1
            // 
            this.pnlNazwa1.BackColor = System.Drawing.Color.Silver;
            this.pnlNazwa1.ForeColor = System.Drawing.Color.White;
            this.pnlNazwa1.Location = new System.Drawing.Point(20, 107);
            this.pnlNazwa1.Name = "pnlNazwa1";
            this.pnlNazwa1.Size = new System.Drawing.Size(150, 2);
            this.pnlNazwa1.TabIndex = 60;
            // 
            // txtNazwa1
            // 
            this.txtNazwa1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
            this.txtNazwa1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNazwa1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNazwa1.ForeColor = System.Drawing.Color.White;
            this.txtNazwa1.Location = new System.Drawing.Point(20, 79);
            this.txtNazwa1.Name = "txtNazwa1";
            this.txtNazwa1.Size = new System.Drawing.Size(150, 19);
            this.txtNazwa1.TabIndex = 2;
            this.txtNazwa1.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtNazwa1.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // przepis
            // 
            this.przepis.Location = new System.Drawing.Point(12, 190);
            this.przepis.Multiline = true;
            this.przepis.Name = "przepis";
            this.przepis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.przepis.ShortcutsEnabled = false;
            this.przepis.Size = new System.Drawing.Size(203, 184);
            this.przepis.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(9, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 54;
            this.label3.Text = "Przepis:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 437);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // imageText
            // 
            this.imageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.imageText.Location = new System.Drawing.Point(12, 397);
            this.imageText.Name = "imageText";
            this.imageText.Size = new System.Drawing.Size(203, 23);
            this.imageText.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(5)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(233, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(905, 639);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Numer";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 63;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "nazwa";
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Nazwa";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "przepis";
            this.Column3.HeaderText = "Przepis";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "zdjecie";
            this.Column4.HeaderText = "Zdjęcie";
            this.Column4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Dania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1354, 651);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelMenu);
            this.Name = "Dania";
            this.Text = "Dania";
            this.Load += new System.EventHandler(this.Dania_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnToFile;
        private FontAwesome.Sharp.IconButton btnAddImage;
        private FontAwesome.Sharp.IconButton btnReset;
        private FontAwesome.Sharp.IconButton btnDeleteDish;
        private FontAwesome.Sharp.IconButton btnEditDish;
        private FontAwesome.Sharp.IconButton btnAddDish;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox imageText;
        private System.Windows.Forms.TextBox przepis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.Label lblNumer;
        private System.Windows.Forms.Panel pnlNumer;
        private System.Windows.Forms.TextBox txtNumer;
        private System.Windows.Forms.Label lblNazwa1;
        private System.Windows.Forms.Panel pnlNazwa1;
        private System.Windows.Forms.TextBox txtNazwa1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}