using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                if (item.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(item);
                }else if (item.Estado == Paquete.EEstado.EnViaje)
                {
                    this.lstEstadoEnViaje.Items.Add(item);
                }
                else if (item.Estado == Paquete.EEstado.Entregado)
                {
                    this.lstEstadoEntregado.Items.Add(item);
                }

            }
        }
        private void MostrarInformacion<T>(IMostrar<T> elemento )
        {
            if (elemento != null)
            {
               this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
               this.rtbMostrar.Text.Guardar("salida.txt");
            }

        }
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            p.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            try
            {
                this.correo += p;
            }
            catch(TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.ActualizarEstados();

        }


        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
           this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        private void FrmPpal_FormClosing(object sender, FormClosedEventArgs e)
        {
            correo.FinEntregas();
            Application.Exit();


        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    
    }
}
