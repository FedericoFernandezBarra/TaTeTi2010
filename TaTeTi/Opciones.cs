using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaTeTi
{
    public partial class Opciones : Form
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (radioButton3.Checked == true)
                {
                    if (radioButton1.Checked == true || radioButton2.Checked == true)
                    {
                        if (dificultad1.Checked == true || dificultad2.Checked == true || dificultad3.Checked == true)
                        {

                            if (dificultad1.Checked)
                            {
                                Principal.dificultad = 1;
                            }
                            else if (dificultad2.Checked)
                            {
                                Principal.dificultad = 2;
                            }
                            else if (dificultad3.Checked)
                            {
                                Principal.dificultad = 3;
                            }
                            if (radioButton1.Checked)
                            {
                                Principal.empieza = 1;
                                Principal.prin.Mensaje();
                            }
                            else if (radioButton2.Checked)
                            {
                                Principal.empieza = 2;
                                Principal.prin.ComienzaMaquina();
                            }
                            Principal.tipojuego = 2;
                            NombresJugadores.NombreJugador1 = nombre1.Text;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Faltan datos.", "TaTeTi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Faltan datos.", "TaTeTi");
                    }
                }
                else if (radioButton4.Checked == true)
                {
                    if (radioButton1.Checked == true || radioButton2.Checked == true)
                    {
                        
                        Principal.tipojuego = 1;
                        NombresJugadores.NombreJugador1 = nombre1.Text;
                        NombresJugadores.NombreJugador2 = nombre2.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Faltan datos.", "TaTeTi");
                    }
                }
                else
                {
                    MessageBox.Show("Faltan datos.", "TaTeTi");
                }
                if (radioButton1.Checked)
                {
                    Principal.jugador = 1;
                    Principal.empieza = 1;
                    Principal.prin.Mensaje();
                }
                else if (radioButton2.Checked)
                {
                    Principal.jugador = 2;
                    Principal.empieza = 2;
                    Principal.prin.Mensaje();
                }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Text = "PC";
            NombresJugadores.NombreJugador2 = "PC";
            nombre2.Text = NombresJugadores.NombreJugador2;
            dificultad1.Enabled = true;
            dificultad2.Enabled = true;
            dificultad3.Enabled = true;
            nombre2.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Text = "Jugador 2";
            NombresJugadores.NombreJugador2 = "Jugador 2";
            nombre2.Text = NombresJugadores.NombreJugador2;
            dificultad1.Enabled = false;
            dificultad2.Enabled = false;
            dificultad3.Enabled = false;
            nombre2.Enabled = true;
        }

        private void Opciones_Load(object sender, EventArgs e)
        {
            nombre1.Text = NombresJugadores.NombreJugador1;
            nombre2.Text = NombresJugadores.NombreJugador2;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


    }
}
