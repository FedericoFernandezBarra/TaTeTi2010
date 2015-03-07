using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaTeTi
{
    public partial class OpcionesJugadorVsJugador : Form
    {
        Principal prin = new Principal();
        int acepto = 0;
        public OpcionesJugadorVsJugador()
        {
            InitializeComponent();
        }

        private void OpcionesJugadorVsJugador_Load(object sender, EventArgs e)
        {
            nombre1.Text = NombresJugadores.NombreJugador1;
            if (Principal.tipojuego == 2)
            {
                nombre2.Text = "Jugador 2";
            }
            else
            {
                nombre2.Text = NombresJugadores.NombreJugador2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acepto = 1;
            Principal.tipojuego = 1;
            Principal.limpiar = true;
            NombresJugadores.NombreJugador1 = nombre1.Text;
            NombresJugadores.NombreJugador2 = nombre2.Text;
            if (radioButton1.Checked)
            {
                Principal.jugador = 1;
                Principal.empieza = 2;
                Principal.prin.Mensaje();
            }
            else if (radioButton2.Checked)
            {
                Principal.jugador = 2;
                Principal.empieza = 1;
                Principal.prin.Mensaje();
            }
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Principal.prin.JugarDeNuevo();
            acepto = 1;
            this.Close();
        }

        private void OpcionesJugadorVsJugador_Deactivate(object sender, EventArgs e)
        {
            if (acepto == 0)
            {
                MessageBox.Show("No puede volver al juego hasta que presione \"Aceptar\" o \"Cancelar\".", "TaTeTi");
            }
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
                nombre1.Text = NombresJugadores.NombreJugador1;
            }
        }

        private void nombre2_Leave(object sender, EventArgs e)
        {
            if (nombre2.Text == "")
            {
                nombre2.Text = NombresJugadores.NombreJugador2;
            }
        }

    }
}
