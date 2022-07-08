using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expendedora
{
    public partial class frmExpendedora : Form
    {
        int id_prod, stock_prod;
        string nom_prod, prodP;
        double prec_prod, venta_prod, dinero = 0;

        Conexion conexion = new Conexion();

        public frmExpendedora()
        {
            InitializeComponent();

            //Inhabilitar textBoxes
            txtCambio.Enabled = false;
            txtDinero.Enabled = false;

            //Inhabilitar botones
            inhabilitarBotones();
        
            //Inhabilitar pictureBox del producto entregado
        }

        public void inhabilitarBotones()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        public void habilitarBotones()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtCambio.Text = Convert.ToString(prodP += "9");
        }

        private void rdb1_Click(object sender, EventArgs e)
        {
            dinero += 1;
            txtDinero.Clear();
            txtDinero.Text = "$ " + dinero;
            habilitarBotones();
        }

        private void rdb2_Click(object sender, EventArgs e)
        {
            dinero += 2;
            txtDinero.Clear();
            txtDinero.Text = "$ " + dinero;
            habilitarBotones();
        }

        private void rdb5_Click(object sender, EventArgs e)
        {
            dinero += 5;
            txtDinero.Clear();
            txtDinero.Text = "$ " + dinero;
            habilitarBotones();
        }

        private void rdb10_Click(object sender, EventArgs e)
        {
            dinero += 10;
            txtDinero.Clear();
            txtDinero.Text = "$ " + dinero;
            habilitarBotones();
        }
    }
}
