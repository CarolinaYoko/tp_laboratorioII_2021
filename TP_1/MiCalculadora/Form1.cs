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
        
        


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
           this.Close();                        
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

            sb.AppendLine(txtNumero1.Text);
            sb.AppendLine(cmbOperador.Text);
            sb.AppendLine(txtNumero2.Text);
            sb.AppendLine(" = ");
            sb.AppendLine(lblResultado.Text);                       

            lstOperaciones.Items.Add(sb.ToString());
            
        }

        private void Limpiar()
        {
            
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.Text = "";
            lblResultado.Text = "";

        }

        static double Operar(string numero1, string numero2, string operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);

            return Calculadora.Operar(n1, n2, char.Parse(operador));

        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;            
            }
        }
    }
}
