using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPListasJOELDAMERDJIAN
{
    public partial class Form1 : Form
    {

        Cola Clientes = new Cola();
        int total = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (txtNombreNodo.Text.Length == 0 || double.Parse(txtCodigoNodo.Text)<=0 || double.Parse(txtImporteNodo.Text) <= 0  || string.IsNullOrWhiteSpace(txtImporteNodo.Text) ||
        string.IsNullOrWhiteSpace(txtCodigoNodo.Text) ||
        string.IsNullOrWhiteSpace(txtNombreNodo.Text ))
            {
                MessageBox.Show("Nombre/Importe o Codigo ingresado incorrecto");
            }
           

            else
            {
                Nodo unNuevoNodo = new Nodo();
                unNuevoNodo.Nombre = txtNombreNodo.Text;
                unNuevoNodo.Codigo = txtCodigoNodo.Text;
                unNuevoNodo.Importe = txtImporteNodo.Text;
                Clientes.Encolar(unNuevoNodo);
                MostrarCola();
                MostrarTotalRecaudado();
            }

        }

         private void MostrarTotalRecaudado()
        {
            int importe = int.Parse(txtImporteNodo.Text);
            total += importe;
            txtTotal.Text = total.ToString();

            



        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (Clientes.Vacia())
            {
                MessageBox.Show("No hay ningun cliente agregado!");
            }
            else
            {
                Clientes.Desencolar();
                MostrarCola();
            } 
        }

        private void MostrarCola()
        {
            lstCola.Items.Clear();
            MostrarNodoEnPantalla(Clientes.Inicio);
        }

        private void MostrarNodoEnPantalla(Nodo unNodo)
        {
            if (unNodo!=null)
            {
                lstCola.Items.Add(unNodo.Nombre);
                lstCola.Items.Add(unNodo.Codigo);
                lstCola.Items.Add(unNodo.Importe);

                if (unNodo.Siguiente!=null)
                {
                    MostrarNodoEnPantalla(unNodo.Siguiente);
                }
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
