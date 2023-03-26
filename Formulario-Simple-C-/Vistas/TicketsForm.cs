using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas
{
    public partial class TicketsForm : Form
    {
        private TicketDB ticketDB = new TicketDB();
        public TicketsForm()
        {
            InitializeComponent();
            txtFecha.SelectedText = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {
            string selectItem = (string)(this.comboBox1.SelectedItem ?? "");
            txtPrecio.Text = selectItem switch
            {
                string i when i == "Basico" => "32.3",
                string i when i == "Intermedio" => "93.1",
                string i when i == "Avanzado" => "140.3",
                null => "0.0",
                _ => "0.0"
            };
            float pre = float.Parse(this.txtPrecio.Text);
            txtDescuento.Text = Math.Round(pre * 0.1,2).ToString();
            float desc = float.Parse(this.txtDescuento.Text);
            txtISV.Text = Math.Round(pre * 0.15,2).ToString();
            float isv = float.Parse(this.txtISV.Text);
            this.txtTotal.Text = (pre + isv - desc).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm form = new();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Ticket nuevoTicket = new(
                this.txtFecha.Text,
                "1",
                this.txtCliente.Text,
                this.comboBox1.Text,
                this.txtDescripcionSolicitud.Text,
                this.txtDescripcionRespuesta.Text,
                decimal.Parse(this.txtPrecio.Text),
                decimal.Parse(this.txtISV.Text),
                decimal.Parse(this.txtDescuento.Text),
                decimal.Parse(this.txtTotal.Text)
            );
            bool res = ticketDB.generarTicket(nuevoTicket);
            if (res){
                MessageBox.Show("Ticket generado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCliente.Text = "";
                this.comboBox1.Text = "";
                this.txtDescripcionSolicitud.Text = "";
                this.txtDescripcionRespuesta.Text = "";
                this.txtPrecio.Text="";
                this.txtISV.Text="";
                this.txtDescuento.Text="";
                this.txtTotal.Text="";
            }
            else{
                MessageBox.Show("Error al generar el ticket", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
