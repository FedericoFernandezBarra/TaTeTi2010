using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaTeTi
{
    public partial class OpcionesJugadorVsPC : Form
    {
        int acepto = 0;
        
        public OpcionesJugadorVsPC()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (dificultad1.Checked == true || dificultad2.Checked == true || dificultad3.Checked == true)
            {
                Principal.tipojuego = 2;
                if (dificultad1.Checked)
                {
                    Principal.dificultad = 1;
                    NombresJugadores.NombreJugador2 = "PC Fácil";
                }
                else if (dificultad2.Checked)
                {
                    Principal.dificultad = 2;
                    NombresJugadores.NombreJugador2 = "PC Normal";
                }
                else if (dificultad3.Checked)
                {
                    Principal.dificultad = 3;
                    NombresJugadores.NombreJugador2 = "PC Imposible";
                }
                if (radioButton1.Checked)
                {
                    Principal.empieza = 1;
                }
                else if (radioButton2.Checked)
                {
                    Principal.empieza = 3;
                }
                Principal.limpiar = true;
                acepto = 1;
                this.Close();
            }
            else
            {
                acepto = 1;
                MessageBox.Show("No has elegido la dificultad.", "TaTeTi");
                acepto = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            acepto = 1;
            this.Close();
        }

        public void OpcionDificultad_Deactivate(object sender, EventArgs e)
        {
            if (acepto == 0)
            {
                MessageBox.Show("No puede volver al juego hasta que presione \"Aceptar\" o \"Cancelar\".", "TaTeTi");
            }
        }
    }
}
