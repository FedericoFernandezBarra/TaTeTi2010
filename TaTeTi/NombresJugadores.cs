using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaTeTi
{
    public partial class NombresJugadores : Form
    {
        int Acepto = 0;
        public static string NombreJugador1 = "Jugador 1";
        public static string NombreJugador2 = "Jugador 2";

        public NombresJugadores()
        {
            InitializeComponent();
        }

        private void NombresJugadores_Load(object sender, EventArgs e)
        {
            nombre1.Text = NombreJugador1;
            if (Principal.tipojuego == 2)
            {
                nombre2.Enabled = false;
            }
            nombre2.Text = NombreJugador2;
        }
       
        public void button1_Click(object sender, EventArgs e)
        {
            NombreJugador1 = nombre1.Text;
            NombreJugador2 = nombre2.Text;
            Acepto = 1;
            Principal.prin.Mensaje();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acepto = 1;
            this.Close();
        }

        private void nombre1_Click(object sender, EventArgs e)
        {
            nombre1.Text = "";
        }

        private void nombre2_Click(object sender, EventArgs e)
        {
            nombre2.Text = "";
        }

        private void nombre1_Leave(object sender, EventArgs e)
        {
            if (nombre1.Text == "")
            {
                nombre1.Text = NombreJugador1;
            }
        }

        private void nombre2_Leave(object sender, EventArgs e)
        {
            if (nombre2.Text == "")
            {
                nombre2.Text = NombreJugador2;
            }
        }

        private void NombresJugadores_Deactivate(object sender, EventArgs e)
        {
            if (Acepto == 0)
            {
                MessageBox.Show("No puede volver al juego hasta que presione \"Aceptar\" o \"Cancelar\".", "TaTeTi");
            }
        }
    }
}
