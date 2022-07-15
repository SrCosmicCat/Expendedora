using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Expendedora
{
    public partial class frmExpendedora : Form
    {
        int id_prod, stock_prod, modStock, modTotVen;
        string nom_prod, prodP;
        double prec_prod, venta_prod, dinero = 0, cambio = 0;
        string SQL = "";
        MySqlCommand Query; //La clase MySqlCommand crea una instancia SQL que se ejecutará en el bd
        MySqlDataReader Registros; //La clase MySqlDataReader permite ejecutar la sentencia SQL
        Conexion Con = new Conexion(); //Clase conexion
        Producto Prod = new Producto(); //Clase producto

        Conexion conexion = new Conexion();

        public void limpiar()
        {
            txtDinero.Clear();
            txtCambio.Clear();
            SinStock();
            id_prod = 0;
            prec_prod = 0;
            venta_prod = 0;
            cambio = 0;
            prodP = "";
            modStock = 0;
            modTotVen = 0;
            inhabilitarBotones();
        }

        public void ComprarProducto()
        {
            if (Con.abrirBD())
            {
                MessageBox.Show("BD conectada uwu");
                try
                {
                    SQL = "SELECT * FROM PRODUCTO WHERE id_prod = " + Prod.Clave1;
                    Query = new MySqlCommand(SQL, Con.connection);
                    Registros = Query.ExecuteReader();
                    if (Registros.Read())
                    {
                        id_prod = Registros.GetInt32(0);
                        nom_prod = Registros.GetString(1);
                        prec_prod = Registros.GetDouble(2);
                        stock_prod = Registros.GetInt32(3);
                        venta_prod = Registros.GetDouble(4);
                        Registros.Close();

                        if (stock_prod > 0 && dinero > prec_prod)
                        {
                            try
                            {
                                SQL = "UPDATE PRODUCTO SET stock_prod = stock_prod-1 WHERE id_prod = " + Prod.Clave1;
                                Query = new MySqlCommand(SQL, Con.connection);
                                modStock = Query.ExecuteNonQuery();
                                if (modStock == 1)
                                {
                                    try
                                    {
                                        SQL = "UPDATE PRODUCTO SET venta_prod = venta_prod + prec_prod WHERE id_prod = " + Prod.Clave1;
                                        Query = new MySqlCommand(SQL, Con.connection);
                                        modTotVen = Query.ExecuteNonQuery();
                                        
                                        if (modTotVen == 1)
                                        {
                                            MessageBox.Show("Compra exitosa");
                                            pctProducto.Visible = true;
                                            pctProducto.Image = mglProducto.Images[id_prod-1];

                                            cambio = dinero - prec_prod;
                                            txtCambio.Text = "$ " + cambio;
                                        }
                                    }
                                    catch (MySqlException ex)
                                    {
                                        Console.WriteLine("Error: " + ex);
                                    }
                                } 
                            }
                            catch(MySqlException ex)
                            {
                                Console.WriteLine("Error: " + ex);
                            }

                        }
                    }
                    Con.cerrarBD();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
            }
            else
            {
                MessageBox.Show("BD no conectada unu");
            }
        }

        public void SinStock()
        {
            if (Con.abrirBD())
            {
                MessageBox.Show("BD conectada uwu");
                try
                {
                    SQL = "SELECT id_prod, stock_prod FROM PRODUCTO";
                    Query = new MySqlCommand(SQL, Con.connection);
                    Registros = Query.ExecuteReader();
                    while (Registros.Read())
                    {
                        id_prod = Registros.GetInt32(0);
                        stock_prod = Registros.GetInt32(1);
                        if (stock_prod == 0)
                        {
                            switch (id_prod)
                            {
                                case 1: pct1.Visible = false; break;
                                case 2: pct2.Visible = false; break;
                                case 3: pct3.Visible = false; break;
                                case 4: pct4.Visible = false; break;
                                case 5: pct5.Visible = false; break;
                                case 6: pct6.Visible = false; break;
                                case 7: pct7.Visible = false; break;
                                case 8: pct8.Visible = false; break;
                                case 9: pct9.Visible = false; break;
                            }
                        }
                    }
                    Con.cerrarBD();
                }
                catch(MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
            }
            else
            {
                MessageBox.Show("BD no conectada unu");
            }
        }

        

        public frmExpendedora()
        {
            InitializeComponent();

            //Inhabilitar textBoxes
            txtCambio.Enabled = false;
            txtDinero.Enabled = false;
            txtProducto.Enabled = false;

            //Inhabilitar botones
            inhabilitarBotones();

            //Inhabilitar pictureBox del producto entregado
            pctProducto.Visible = false;

            //Verificar si existe un producto sin stock
            SinStock();
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
            txtProducto.Text = Convert.ToString(prodP += "1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtProducto.Text = Convert.ToString(prodP += "2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtProducto.Text = Convert.ToString(prodP += "3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtProducto.Text = Convert.ToString(prodP += "4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtProducto.Text = Convert.ToString(prodP += "5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtProducto.Text = Convert.ToString(prodP += "6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtProducto.Text = Convert.ToString(prodP += "7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtProducto.Text = Convert.ToString(prodP += "8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtProducto.Text = Convert.ToString(prodP += "9");
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() != "")
            {
                Prod.Clave1 = Convert.ToInt32(txtProducto.Text);
                ComprarProducto(); //Método comprar producto
            }
            else
            {
                MessageBox.Show("Ingrese la clave del producto");
            }
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
