using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bdInmobiliria
{
    public partial class Localidades : Form
    {
        public Localidades()
        {
            InitializeComponent();
        }

        private void Localidades_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }


        private void CargarDatos()
        {
            string sql;
            if (txt_busqueda.Text.Trim() == string.Empty)
            {
                sql = "SELECT * FROM Localidades;";
            }
            else
            {
                sql = $"SELECT * FROM Localidades WHERE Localidad LIKE '{txt_busqueda.Text.Trim()}%'";
            }
            DataTable dt = new DataTable();
            dt = Libreria.Recuperar(sql);

            dt_Localidades.DataSource = dt;
            dt_Localidades.AllowUserToAddRows = false;
            dt_Localidades.AllowUserToDeleteRows = false;
            dt_Localidades.Columns["idLocalidad"].Visible = false;
            dt_Localidades.Columns["CodigoPostal"].HeaderText = "Codigo Postal";
            dt_Localidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btn_Busqueda_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void option_Exportar_Click(object sender, EventArgs e)
        {
            FileStream Archivo;
            StreamWriter EscribirArchivo;
            string cadena;

            Archivo = new FileStream("datos.csv", FileMode.Create);
            EscribirArchivo = new StreamWriter(Archivo);

           foreach(DataGridViewRow fila in dt_Localidades.Rows)
            {
                cadena = string.Empty;
              
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    cadena += celda.Value.ToString() + ";";
                }
             EscribirArchivo.WriteLine(cadena);
            }

            MessageBox.Show("Se guardo reporte");
            EscribirArchivo.Close();
            Archivo.Close();
     

        }
    }
}
