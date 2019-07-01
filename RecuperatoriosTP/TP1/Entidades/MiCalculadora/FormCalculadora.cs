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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
       
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero2 = txtNumero2.Text;
            string numero1 = txtNumero1.Text;
            string operador;

            
            // Si se selecciona un operador incorrecto se cambia a + luego calcular el resultado
            if (cmbOperador.SelectedIndex == -1)
            {
                operador = cmbOperador.SelectedText;
                txtResultado.Text = Operar(numero1, numero2, operador).ToString();

                cmbOperador.SelectedIndex = 3;
            }
            else
            {
                operador = cmbOperador.SelectedItem.ToString();
                txtResultado.Text = Operar(numero1, numero2, operador).ToString();
            }

           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            Numero n = new Numero();
            string t = txtResultado.Text;

            txtResultado.Text = n.DecimalBinario(t);


        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            Numero n = new Numero(txtResultado.Text);
            txtResultado.Text = n.BinarioDecimal(txtResultado.Text);

            /*
            string r = txtResultado.Text;
            if (r != "")
            {
                Numero n = new Numero(txtResultado.Text);
                txtResultado.Text = n.BinarioDecimal(txtResultado.Text);
            }
            else { MessageBox.Show("Realice una operacion para convertir a Decimal el resultado"); }
            */

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        private void Limpiar()
        {
            txtResultado.Text = "";
            txtNumero2.Text = "";
            txtNumero1.Text = "";
            cmbOperador.SelectedIndex = -1;
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            Calculadora c = new Calculadora();
            return  c.Operar(new Numero(numero1), new Numero(numero2), operador);
           
        }
    }
}
