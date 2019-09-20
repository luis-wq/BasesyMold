﻿namespace BasesYMolduras
{
    partial class Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Producto));
            this.panelArriba = new MetroFramework.Controls.MetroPanel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxMateial = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxCategoria = new MetroFramework.Controls.MetroComboBox();
            this.panelAbajo = new MetroFramework.Controls.MetroPanel();
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btnModificarProducto = new MetroFramework.Controls.MetroButton();
            this.btnSalirProducto = new MetroFramework.Controls.MetroButton();
            this.panelArriba.SuspendLayout();
            this.panelAbajo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // panelArriba
            // 
            this.panelArriba.Controls.Add(this.metroTextBox1);
            this.panelArriba.Controls.Add(this.metroLabel3);
            this.panelArriba.Controls.Add(this.comboBoxMateial);
            this.panelArriba.Controls.Add(this.metroLabel2);
            this.panelArriba.Controls.Add(this.comboBoxCategoria);
            this.panelArriba.HorizontalScrollbarBarColor = true;
            this.panelArriba.HorizontalScrollbarHighlightOnWheel = false;
            this.panelArriba.HorizontalScrollbarSize = 10;
            this.panelArriba.Location = new System.Drawing.Point(0, 3);
            this.panelArriba.Name = "panelArriba";
            this.panelArriba.Size = new System.Drawing.Size(1361, 79);
            this.panelArriba.TabIndex = 28;
            this.panelArriba.VerticalScrollbarBarColor = true;
            this.panelArriba.VerticalScrollbarHighlightOnWheel = false;
            this.panelArriba.VerticalScrollbarSize = 10;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(514, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.DisplayIcon = true;
            this.metroTextBox1.Icon = ((System.Drawing.Image)(resources.GetObject("metroTextBox1.Icon")));
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(763, 29);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(538, 25);
            this.metroTextBox1.TabIndex = 28;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(402, 29);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(77, 25);
            this.metroLabel3.TabIndex = 29;
            this.metroLabel3.Text = "Material:";
            // 
            // comboBoxMateial
            // 
            this.comboBoxMateial.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxMateial.FormattingEnabled = true;
            this.comboBoxMateial.ItemHeight = 19;
            this.comboBoxMateial.Location = new System.Drawing.Point(500, 29);
            this.comboBoxMateial.Name = "comboBoxMateial";
            this.comboBoxMateial.Size = new System.Drawing.Size(237, 25);
            this.comboBoxMateial.TabIndex = 30;
            this.comboBoxMateial.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(39, 29);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(89, 25);
            this.metroLabel2.TabIndex = 28;
            this.metroLabel2.Text = "Categoria:";
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.ItemHeight = 19;
            this.comboBoxCategoria.Location = new System.Drawing.Point(134, 29);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(237, 25);
            this.comboBoxCategoria.TabIndex = 28;
            this.comboBoxCategoria.UseSelectable = true;
            this.comboBoxCategoria.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategoria_SelectedIndexChanged);
            // 
            // panelAbajo
            // 
            this.panelAbajo.Controls.Add(this.txtCantidad);
            this.panelAbajo.Controls.Add(this.metroLabel4);
            this.panelAbajo.Controls.Add(this.btnModificarProducto);
            this.panelAbajo.Controls.Add(this.btnSalirProducto);
            this.panelAbajo.HorizontalScrollbarBarColor = true;
            this.panelAbajo.HorizontalScrollbarHighlightOnWheel = false;
            this.panelAbajo.HorizontalScrollbarSize = 10;
            this.panelAbajo.Location = new System.Drawing.Point(0, 666);
            this.panelAbajo.Name = "panelAbajo";
            this.panelAbajo.Size = new System.Drawing.Size(1361, 79);
            this.panelAbajo.TabIndex = 29;
            this.panelAbajo.VerticalScrollbarBarColor = true;
            this.panelAbajo.VerticalScrollbarHighlightOnWheel = false;
            this.panelAbajo.VerticalScrollbarSize = 10;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.SystemColors.Window;
            this.txtCantidad.Location = new System.Drawing.Point(1036, 30);
            this.txtCantidad.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(65, 20);
            this.txtCantidad.TabIndex = 30;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(938, 28);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(84, 25);
            this.metroLabel4.TabIndex = 31;
            this.metroLabel4.Text = "Cantidad:";
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.Location = new System.Drawing.Point(1120, 23);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(181, 32);
            this.btnModificarProducto.TabIndex = 3;
            this.btnModificarProducto.Text = "MODIFICAR";
            this.btnModificarProducto.UseSelectable = true;
            // 
            // btnSalirProducto
            // 
            this.btnSalirProducto.Location = new System.Drawing.Point(40, 13);
            this.btnSalirProducto.Name = "btnSalirProducto";
            this.btnSalirProducto.Size = new System.Drawing.Size(181, 56);
            this.btnSalirProducto.TabIndex = 2;
            this.btnSalirProducto.Text = "SALIR";
            this.btnSalirProducto.UseSelectable = true;
            this.btnSalirProducto.Click += new System.EventHandler(this.BtnSalirProducto_Click);
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1360, 768);
            this.ControlBox = false;
            this.Controls.Add(this.panelAbajo);
            this.Controls.Add(this.panelArriba);
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Producto";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.Producto_Load);
            this.panelArriba.ResumeLayout(false);
            this.panelArriba.PerformLayout();
            this.panelAbajo.ResumeLayout(false);
            this.panelAbajo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelArriba;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox comboBoxMateial;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox comboBoxCategoria;
        private MetroFramework.Controls.MetroPanel panelAbajo;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton btnModificarProducto;
        private MetroFramework.Controls.MetroButton btnSalirProducto;
        private System.Windows.Forms.NumericUpDown txtCantidad;
    }
}