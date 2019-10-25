﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesYMolduras
{
    public partial class Cotizacion : MetroFramework.Forms.MetroForm
    {
        Listados padre;
        string txtFecha;
        Double auxtablasMDF, tablaMDF = 0, auxtablasMOLDURA, tablaMOLDURA = 0, auxtablasPINO, tablaPINO = 0, envio=0, cargo_extra;
        int idCategoria, idMaterial, idTamano, idTipo, idCliente;
        String modelo, tipo_cliente;
        Boolean factura = false, agregar = false;
        MySqlDataReader datosCliente;
        DataTable dataCantidad, dataProductosCotizacion, datosClientes;


        private void Cotizacion_Load(object sender, EventArgs e)
        {
            cargarCategoria();
            cargarClientes();
            cargarDatosTablaCotizacion();

            for (int i = 1; i <= 6; i++)
            {
                limpiarTabla(i);
            }
            txtSubTotal.Text = string.Format("{0:c2}", 0);
            txtIVA.Text = string.Format("{0:c2}", 0);
            txtEnvio.Text = string.Format("{0:c2}", 0);
            txtCargo.Text = string.Format("{0:c2}", 0);
            comboUrgencia.Items.Add("URGENTE");
            comboUrgencia.Items.Add("NORMAL");
            comboUrgencia.SelectedIndex = 0;
        }

        public Cotizacion(Listados padre)
        {
            this.padre = padre;
            InitializeComponent();
        }

        private void ComboBoxCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idCategoria = Convert.ToInt32(comboBoxCategoria.SelectedValue);
            for (int i = 2; i <= 6; i++) { limpiarTabla(i); }
            cargarMaterial();
        }

        private void MetroGrid5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MetroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TablaMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 3; i <= 6; i++) { limpiarTabla(i); }
            idMaterial = Convert.ToInt32(tablaMaterial.SelectedRows[0].Cells["ID"].Value.ToString());
            cargarModelo();
        }

        private void cargarCategoria()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable datosCategorias = BD.listarCategoriasForCotizacion();
            comboBoxCategoria.DataSource = datosCategorias;
            comboBoxCategoria.ValueMember = "id_categoria";
            comboBoxCategoria.DisplayMember = "NOMBRE";
            Cursor.Current = Cursors.Default;
        }

        private void TablaModelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            modelo = tablaModelo.SelectedRows[0].Cells["MODELO"].Value.ToString();
            for (int i = 4; i <= 6; i++) { limpiarTabla(i); }
            cargarTamanos();
        }

        private void cargarMaterial()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarMaterialesForCategoriasCotizacion(tablaMaterial, idCategoria);
            tablaMaterial.Columns["ID"].Visible = false;
            tablaMaterial.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void TablaTamano_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTamano = Convert.ToInt32(tablaTamano.SelectedRows[0].Cells["ID"].Value.ToString());
            for (int i = 5; i <= 6; i++) { limpiarTabla(i); }
            cargarTipo();
        }

        private void cargarModelo()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosFiltroMaterial(tablaModelo, idCategoria, idMaterial);
            tablaModelo.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void TablaTipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //limpiarTabla(6);
            idTipo = Convert.ToInt32(tablaTipo.SelectedRows[0].Cells["ID"].Value.ToString());
            cargarColores();
        }

        private void cargarClientes()
        {
            Cursor.Current = Cursors.WaitCursor;
            datosClientes = BD.listarClientesForCotizacion();
            comboBoxCliente.DataSource = datosClientes;
            comboBoxCliente.ValueMember = "id_cliente";
            comboBoxCliente.DisplayMember = "RAZONSOCIAL";
            Cursor.Current = Cursors.Default;
        }

        private void TablaColor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarProducto();

        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult pregunta;

                pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea eliminar este producto?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (pregunta == DialogResult.Yes)
                {
                    dataProductosCotizacion.Rows.RemoveAt(tablaCotizacion.CurrentRow.Index);
                    tablaCotizacion.DataSource = dataProductosCotizacion;
                    Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarTextoPrecios));
                    hiloPesosYPrecios.Start();
                }

            }
            catch
            {
                DialogResult pregunta;

                pregunta = MetroFramework.MetroMessageBox.Show(this, "No hay productos agregados o no ha seleccionado alguno.", "Error al quitar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MetroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void MetroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked) {
                factura = true;
                CargarTextoPrecios();
            }
            else
            {
                factura = false;
                CargarTextoPrecios();
            }
        }

        private void MetroTextBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                cargo_extra = Convert.ToDouble(txtCargo.Text);
                txtCargo.Text = string.Format("{0:c2}", cargo_extra);
                CargarTextoPrecios();
            }
            catch
            {
                txtCargo.Text = string.Format("{0:c2}",cargo_extra);
                CargarTextoPrecios();
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarCotizacion));
            hiloPesosYPrecios.Start();
        }

        private void TxtEnvio_Leave(object sender, EventArgs e)
        {
            try
            {
                envio = Convert.ToDouble(txtEnvio.Text);
                txtEnvio.Text = string.Format("{0:c2}", envio);
                CargarTextoPrecios();
            }
            catch
            {
                txtEnvio.Text = string.Format("{0:c2}", envio);
                CargarTextoPrecios();
            }

        }

        private void MetroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ComboBoxCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {


            DialogResult pregunta;

            pregunta = MetroFramework.MetroMessageBox.Show(this, "\n ¿Desea seleccionar el Cliente: "+ comboBoxCliente.Text + " ?.\n No se podrá cambiar despues de seleccionarlo", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                idCliente = Convert.ToInt32(comboBoxCliente.SelectedValue);

                BD metodos = new BD();
                BD.ObtenerConexion();
                datosCliente = metodos.consultarClienteTipo(idCliente);
                tipo_cliente = datosCliente.GetString(0);
                BD.CerrarConexion();
                lblTipoC.Text = tipo_cliente;
                comboBoxCliente.Enabled = false;
                comboBoxCategoria.Enabled = true;
                btnAgregar.Enabled = true;
                btnQuitar.Enabled = true;
            }
        }

        private void cargarTamanos()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductosFiltroTamano(tablaTamano, idCategoria, idMaterial, modelo);
            tablaTamano.Columns["ID"].Visible = false;
            tablaTamano.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string result = txtCantidad.Text;

            if (string.IsNullOrEmpty(result) || result.Equals("0"))
            {
                DialogResult pregunta;

                pregunta = MetroFramework.MetroMessageBox.Show(this, "Ingrese la cantiad de productos que desea agregar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataRow row = dataProductosCotizacion.NewRow();
                row["ID"] = tablaInfoProducto.SelectedRows[0].Cells["ID"].Value.ToString();
                row["MODELO"] = tablaInfoProducto.SelectedRows[0].Cells["MODELO"].Value.ToString();
                row["CATEGORIA"] = tablaInfoProducto.SelectedRows[0].Cells["CATEGORIA"].Value.ToString();
                row["MATERIAL"] = tablaInfoProducto.SelectedRows[0].Cells["MATERIAL"].Value.ToString();
                row["COLOR"] = tablaColorID.SelectedRows[0].Cells["COLOR"].Value.ToString();//
                row["TAMAÑO"] = tablaInfoProducto.SelectedRows[0].Cells["TAMAÑO"].Value.ToString();//
                row["TIPO"] = tablaInfoProducto.SelectedRows[0].Cells["TIPO"].Value.ToString();
                row["CANT"] = txtCantidad.Text;
                row["PRECIO"] = tablaInfoProducto.SelectedRows[0].Cells["PRECIO"].Value.ToString();//
                Double valor = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PESO"].Value.ToString()) * Convert.ToDouble(row["CANT"]);
                row["PESO"] = string.Format("{0:n2}", (Math.Truncate(valor * 100) / 100)) + "kg";
                row["ID_COLOR"] = tablaColorID.SelectedRows[0].Cells["ID_COLOR"].Value.ToString();
                row["ID_TIPO"] = tablaColorID.SelectedRows[0].Cells["ID_TIPO"].Value.ToString();
                row["CANTA"] = tablaInfoProducto.SelectedRows[0].Cells["CANTA"].Value.ToString();

                dataProductosCotizacion.Rows.Add(row);
                tablaCotizacion.DataSource = dataProductosCotizacion;

                tablaCotizacion.Columns["ID_COLOR"].Visible = false;
                tablaCotizacion.Columns["ID_TIPO"].Visible = false;
                tablaCotizacion.Columns["CANTA"].Visible = false;
                tablaCotizacion.Columns["PRECIO"].DefaultCellStyle.Format = "C2";

                if (tablaInfoProducto.SelectedRows[0].Cells["MATERIAL"].Value.ToString().Equals("MDF"))
                {
                    double cantidad = Convert.ToDouble(txtCantidad.Text);
                    auxtablasMDF = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PORCENTAJE"].Value.ToString()) * cantidad;
                    tablaMDF = tablaMDF + auxtablasMDF;
                }
                if (tablaInfoProducto.SelectedRows[0].Cells["MATERIAL"].Value.ToString().Equals("MOLDURA"))
                {
                    double cantidad = Convert.ToDouble(txtCantidad.Text);
                    auxtablasMOLDURA = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PORCENTAJE"].Value.ToString()) * cantidad;
                    tablaMOLDURA = tablaMOLDURA + auxtablasMOLDURA;
                }
                if (tablaInfoProducto.SelectedRows[0].Cells["MATERIAL"].Value.ToString().Equals("PINO"))
                {
                    double cantidad = Convert.ToDouble(txtCantidad.Text);
                    auxtablasPINO = Convert.ToDouble(tablaInfoProducto.SelectedRows[0].Cells["PORCENTAJE"].Value.ToString()) * cantidad;
                    tablaPINO = tablaPINO + auxtablasPINO;
                }

                Thread hiloPesosYPrecios = new Thread(new ThreadStart(this.CargarTextoPrecios));
                hiloPesosYPrecios.Start();
            }


        }

        private void cargarTipo()
        {
            Cursor.Current = Cursors.WaitCursor;
            BD.listarMaterialesForCotizacion(tablaTipo, idCategoria, idMaterial, idTamano, modelo);
            tablaTipo.Columns["ID"].Visible = false;
            tablaTipo.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        private void cargarColores()
        {

            Cursor.Current = Cursors.WaitCursor;
            BD.listarColoresForCotizacion(tablaColor);
            tablaColor.Columns["ID"].Visible = false;
            tablaColor.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void cargarProducto()
        {

            Cursor.Current = Cursors.WaitCursor;
            BD.listarProductoForCotizacion(tablaInfoProducto, idCategoria, idMaterial, modelo, idTamano, idTipo, tipo_cliente);
            tablaInfoProducto.Columns["PESO"].Visible = false;
            tablaInfoProducto.Columns["PORCENTAJE"].Visible = false;
            tablaInfoProducto.Columns["CANTA"].Visible = false;

            dataCantidad = new DataTable();
            dataCantidad.Columns.Add("ID_COLOR", typeof(String));
            dataCantidad.Columns.Add("ID_TIPO", typeof(String));
            dataCantidad.Columns.Add("COLOR", typeof(String));
            tablaColorID.DataSource = dataCantidad;

            dataCantidad.Rows.Add(tablaColor.SelectedRows[0].Cells["ID"].Value.ToString(), tablaTipo.SelectedRows[0].Cells["ID"].Value.ToString(), tablaColor.SelectedRows[0].Cells["COLOR"].Value.ToString());
            tablaColorID.DataSource = dataCantidad;
            tablaColorID.Columns["ID_COLOR"].Visible = false;
            tablaColorID.Columns["ID_TIPO"].Visible = false;

            tablaInfoProducto.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
            tablaInfoProducto.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        private void BtnSalirProducto_Click(object sender, EventArgs e)
        {
            DialogResult pregunta;

            pregunta = MetroFramework.MetroMessageBox.Show(this, "¿Desea cancelar el proceso?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                padre.Enabled = true;
                padre.FocusMe();
                this.Close();
            }
        }

        private void limpiarTabla(int s)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (s)
            {
                case 1:
                    DataTable headerMaterial = new DataTable();
                    headerMaterial.Columns.Add("MATERIAL", typeof(String));
                    tablaMaterial.DataSource = headerMaterial;
                    tablaMaterial.Enabled = false;
                    break;
                case 2:
                    DataTable headerModelo = new DataTable();
                    headerModelo.Columns.Add("MODELO", typeof(String));
                    tablaModelo.DataSource = headerModelo;
                    tablaModelo.Enabled = false;
                    break;
                case 3:
                    DataTable headerTamano = new DataTable();
                    headerTamano.Columns.Add("TAMAÑO", typeof(String));
                    tablaTamano.DataSource = headerTamano;
                    tablaTamano.Enabled = false;
                    break;
                case 4:
                    DataTable headerTipo = new DataTable();
                    headerTipo.Columns.Add("TIPO", typeof(String));
                    tablaTipo.DataSource = headerTipo;
                    tablaTipo.Enabled = false;
                    break;
                case 5:
                    DataTable headerColor = new DataTable();
                    headerColor.Columns.Add("COLOR", typeof(String));
                    tablaColor.DataSource = headerColor;
                    tablaColor.Enabled = false;
                    break;
                case 6:
                    DataTable headerProductoInfo = new DataTable();
                    headerProductoInfo.Columns.Add("ID", typeof(String));
                    headerProductoInfo.Columns.Add("MODELO", typeof(String));
                    headerProductoInfo.Columns.Add("CATEGORIA", typeof(String));
                    headerProductoInfo.Columns.Add("MATERIAL", typeof(String));
                    headerProductoInfo.Columns.Add("COLOR", typeof(String));
                    headerProductoInfo.Columns.Add("TAMAÑO", typeof(String));
                    headerProductoInfo.Columns.Add("DECRIPCION", typeof(String));
                    headerProductoInfo.Columns.Add("PESO", typeof(String));
                    headerProductoInfo.Columns.Add("PRECIO", typeof(String));
                    tablaInfoProducto.DataSource = headerProductoInfo;

                    dataCantidad = new DataTable();
                    dataCantidad.Columns.Add("COLOR", typeof(String));
                    tablaColorID.DataSource = dataCantidad;
                    tablaInfoProducto.Enabled = false;
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void cargarDatosTablaCotizacion()
        {
            dataProductosCotizacion = new DataTable();
            dataProductosCotizacion.Columns.Add("ID");
            dataProductosCotizacion.Columns.Add("MODELO");
            dataProductosCotizacion.Columns.Add("CATEGORIA");
            dataProductosCotizacion.Columns.Add("MATERIAL");
            dataProductosCotizacion.Columns.Add("COLOR");
            dataProductosCotizacion.Columns.Add("TAMAÑO");
            dataProductosCotizacion.Columns.Add("TIPO");
            dataProductosCotizacion.Columns.Add("PESO");
            dataProductosCotizacion.Columns.Add("CANT").MaxLength = 4;
            dataProductosCotizacion.Columns.Add("PRECIO");
            dataProductosCotizacion.Columns.Add("ID_COLOR");
            dataProductosCotizacion.Columns.Add("ID_TIPO");
            dataProductosCotizacion.Columns.Add("CANTA");

            tablaCotizacion.DataSource = dataProductosCotizacion;
        }
        private void CargarTextoPrecios()
        {
            double auxPrecios = 0;
            double auxPrecios2 = 0;
            double precioFinal = 0;
            double auxPesos = 0;
            double pesoFinal = 0;
            int i = 0;
            foreach (DataRow rowN in dataProductosCotizacion.Rows)
            {
                double cantidad = Convert.ToDouble(dataProductosCotizacion.Rows[i]["CANT"]);
                string cadena = dataProductosCotizacion.Rows[i]["PRECIO"].ToString();
                string resultado = cadena.Replace("$", "");
                string cadena2 = dataProductosCotizacion.Rows[i]["PESO"].ToString();
                string resultado2 = cadena2.Replace("k", "");
                string resultado3 = resultado2.Replace("g", "");
                auxPrecios = Convert.ToDouble(resultado);
                auxPrecios2 = auxPrecios * cantidad;
                precioFinal = precioFinal + auxPrecios2;
                auxPesos = Convert.ToDouble(resultado3);
                pesoFinal = pesoFinal + auxPesos;
                i++;
            }
            double totalIVA = 0;

            if (factura == true)
            {
                totalIVA = precioFinal * 0.16;
            }
            else
            {
                totalIVA = 0;

            }

            txtSubTotal.Text = string.Format("{0:c2}", precioFinal);
            txtIVA.Text = string.Format("{0:c2}", totalIVA);
            txtTotal.Text = string.Format("{0:c2}", precioFinal + totalIVA+envio+cargo_extra);
            txtPesoTotal.Text = Convert.ToString(pesoFinal) + "kg";
        }
        private void CargarCotizacion()
        {

            int idUsuario = Login.idUsuario;
            string observacion = Convert.ToString(txtObservaciones.Text);
            if (observacion.Equals(""))
            {
                observacion = "NINGUNA";
            }
            double envio;
            try
            {
                envio = Convert.ToDouble(txtEnvio.Text);
            }
            catch
            {
                envio = 0;
            }
            int noCotizacionCliente;
            int nocotizacion = Convert.ToInt32(datosClientes.Rows[comboBoxCliente.SelectedIndex]["nocotizacion"]);
            if (nocotizacion == 0)
            {
                noCotizacionCliente = 1;
            }
            else
            {
                noCotizacionCliente = nocotizacion + 1;
            }
            int isProduccion = 0;
            string fecha = obtenerFecha();
            string prioridad = comboUrgencia.SelectedText;
            if (prioridad.Equals(""))
            {
                prioridad = "NORMAL";
            }
            string pesoTotalAux = txtPesoTotal.Text.Replace("k", "").Replace("g", "");
            double pesoTotal = Convert.ToDouble(pesoTotalAux);
            agregar = BD.InsertarCotizacion(idCliente, idUsuario, observacion, envio, noCotizacionCliente, isProduccion, fecha, cargo_extra, tablaMDF, tablaPINO, tablaMOLDURA, prioridad, pesoTotal);
            BD.modificarNoCotizacion(idCliente, noCotizacionCliente);
            DataTable idCotizacionActual = BD.consultaIdCotizaion(idCliente, idUsuario);
            int idCotizacion = Convert.ToInt32(idCotizacionActual.Rows[0]["id_cotizacion"]);
            if (agregar == true)
            {
                int i = 0;
                foreach (DataRow row in dataProductosCotizacion.Rows)
                {
                    int idProducto = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID"]);
                    int idColor = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID_COLOR"]);
                    int idTipo = Convert.ToInt32(dataProductosCotizacion.Rows[i]["ID_TIPO"]);
                    int cantida = Convert.ToInt32(dataProductosCotizacion.Rows[i]["CANT"]);
                    int cantidadA = Convert.ToInt32(dataProductosCotizacion.Rows[i]["CANTA"]);
                    int cantidadP = 0;
                    if (cantida <= cantidadA)
                    {
                        cantidadP = 0;
                        cantidadA = cantidadA - cantida;
                        BD.AgregarDetalleCotizacion(idProducto, idColor, idTipo, idCotizacion, cantida, cantida, cantidadP);
                    }
                    else
                    {
                        cantidadP = cantida - cantidadA;
                        BD.AgregarDetalleCotizacion(idProducto, idColor, idTipo, idCotizacion, cantida, cantidadA, cantidadP);
                    }
                    //                    BD.AgregarDetalleCotizacion(idProducto, idColor, idTipo, idCotizacion, cantida,cantidadA,cantidadP);
                    modificarProducto(idProducto, cantidadA);
                    i++;
                }
                string precioFinalAux = txtTotal.Text.Replace("$", "");
                double precioFinal = Convert.ToDouble(precioFinalAux);
                BD.AgregarCuentaCliente(idCotizacion, precioFinal);
                DialogResult pregunta;
                pregunta = MetroFramework.MetroMessageBox.Show(this, "Cotización agregada correctamente", "Cotización agregada", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    padre.Enabled = true;
                    padre.CargarDatos();
                    padre.FocusMe();
                    this.Close();
                }
            }
            else if (agregar == false)
            {
                MetroFramework.MetroMessageBox.
                Show(this, "Revisa tu conexión a internet e intentalo de nuevo.", "Error de conexíón", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private string obtenerFecha()
        {
            DateTime t = BD.ObtenerFecha();
            return txtFecha = t.Year + "-" + t.Month + "-" + t.Day;
        }
        private void modificarProducto(int idProducto, int cantidad)
        {
            Boolean modificarP;
            BD metodos = new BD();
            BD.ObtenerConexion();
            modificarP = metodos.modificarProducto(idProducto, cantidad);
            BD.CerrarConexion();
        }
    }
}
