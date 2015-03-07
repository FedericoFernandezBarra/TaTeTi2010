using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace TaTeTi
{
    public partial class Principal : Form
    {
        
        public static int tipojuego = 1; //Tipo de juego 1 = Jugador vs Jugador || 2 = Jugador vs PC
        public static  int dificultad = 0; //Dificultad 1 = Fácil || 2 = Normal || 3 = Imposible
        public static int jugador; //Switch para controlar quién juega
        public static int empieza; //Variable para saber quién comienza
        int vecesjugadas = 0; //Cantidad de veces que se ha jugado
        int ganadas1 = 0; //Cantidad de veces que ganó el Jugador 1
        int ganadas2 = 0; //Cantidad de veces que ganó el Jugador 2
        int empates = 0; //Cantidad de veces que empataron
        int gan = 0; //Variable para saber si alguien ha ganado
        public static bool limpiar = false; //Variable booleana para saber cuando se comienza un tipo de juego diferente para limpiar el tablero y puntajes
        Random jugadar = new Random(); //Random para realizar jugada de PC
        int jugada = 0; //Auxiliar para utilizar el random
        int rojo = 0, azul = 192, verde = 192; //Variables de color de fondo
        public static bool salida = false; //Variable booleana para saber si se hizo click en el botón "Salir" de otro formulario.

        public static Principal prin; //Para vincular el formulario Principal con los otros
        public Principal()
        {
            InitializeComponent();
            Principal.prin = this; //Para vincular el formulario Principal con los otros
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Opciones carga = new Opciones();
            carga.Show();
            jug1.Text = NombresJugadores.NombreJugador1 + " (X)";
            jug2.Text = NombresJugadores.NombreJugador2 + " (O)";
            gan1num.Text = ganadas1.ToString();
            gan2num.Text = ganadas2.ToString();
            empnum.Text = empates.ToString();
            cantjugnum.Text = vecesjugadas.ToString();
            if (tipojuego == 1)
            {
                dificultadToolStripMenuItem.Enabled = false;
                fácilToolStripMenuItem.Enabled = false;
                normalToolStripMenuItem.Enabled = false;
                imposibleToolStripMenuItem.Enabled = false;
            }
        }


        //MENU

        //ARCHIVO

        //Nuevo
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult nuevo = MessageBox.Show("¿Está seguro que desea comenzar una nueva partida?", "TaTeTi", MessageBoxButtons.OKCancel);
            if (nuevo == DialogResult.OK)
            {
                JugarDeNuevo();
                ResetearPuntajes();
            }
        }

        //Resetear Puntaje
        private void resetearPuntajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult reset = MessageBox.Show("¿Está seguro que desea reiniciar los puntajes?", "TaTeTi", MessageBoxButtons.OKCancel);
            if (reset == DialogResult.OK)
            {
                ResetearPuntajes();
            }
        }

        //Salir
        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show("¿Está seguro que desea salir?", "TaTeTi", MessageBoxButtons.OKCancel);
            if (salir == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        //FIN DE ARCHIVO

        //OPCIONES

        //JUEGO

        //Jugador Vs PC
        private void jugadorVsPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpcionesJugadorVsPC opcpc = new OpcionesJugadorVsPC();
            opcpc.Show();
        }

        //Jugador Vs Jugador
        private void jugadorVsJugadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpcionesJugadorVsJugador opcjug = new OpcionesJugadorVsJugador();
            opcjug.Show();
        }

        //FIN DE JUEGO

        //Dificultad

        //Fácil
        private void fácilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NombresJugadores.NombreJugador2 = "PC Fácil";
            jug2.Text = NombresJugadores.NombreJugador2 + " (O)";
            button4.Text = "Jugar de Nuevo" + "\n" + "(Comienza " + NombresJugadores.NombreJugador2 + ")";
            normalToolStripMenuItem.Checked = false;
            imposibleToolStripMenuItem.Checked = false;
            dificultad = 1;
            JugarDeNuevo();
            ResetearPuntajes();
        }

        //Normal
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NombresJugadores.NombreJugador2 = "PC Normal";
            jug2.Text = NombresJugadores.NombreJugador2 + " (O)";
            button4.Text = "Jugar de Nuevo" + "\n" + "(Comienza " + NombresJugadores.NombreJugador2 + ")";
            fácilToolStripMenuItem.Checked = false;
            imposibleToolStripMenuItem.Checked = false;
            dificultad = 2;
            JugarDeNuevo();
            ResetearPuntajes();
        }

        //Imposible
        private void imposibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NombresJugadores.NombreJugador2 = "PC Imposible";
            jug2.Text = NombresJugadores.NombreJugador2 + " (O)";
            button4.Text = "Jugar de Nuevo" + "\n" + "(Comienza " + NombresJugadores.NombreJugador2 + ")";
            fácilToolStripMenuItem.Checked = false;
            normalToolStripMenuItem.Checked = false;
            dificultad = 3;
            JugarDeNuevo();
            ResetearPuntajes();
        }


        //Nombre de los Jugadores
        private void nombresDeLosJugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NombresJugadores nombresjugadores = new NombresJugadores();
            nombresjugadores.Show();
        }

        //FIN DE OPCIONES

        //ACERCA DE
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acercade = new AcercaDe();
            acercade.Show();
        }

        //SALIR
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show("¿Está seguro que desea salir?", "TaTeTi", MessageBoxButtons.OKCancel);
            if (salir == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        //Evento que ocurre cuando se hace click en el Formulario o se activa (por ejemplo, cuando se sale de las opciones)
        public void Principal_Activated(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                dificultadToolStripMenuItem.Enabled = false;
                fácilToolStripMenuItem.Enabled = false;
                normalToolStripMenuItem.Enabled = false;
                imposibleToolStripMenuItem.Enabled = false;
            }
            if (tipojuego == 2)
            {
                dificultadToolStripMenuItem.Enabled = true;
                fácilToolStripMenuItem.Enabled = true;
                normalToolStripMenuItem.Enabled = true;
                imposibleToolStripMenuItem.Enabled = true;
                if (dificultad == 1)
                {
                    fácilToolStripMenuItem.Checked = true;
                    normalToolStripMenuItem.Checked = false;
                    imposibleToolStripMenuItem.Checked = false;
                }
                if (dificultad == 2)
                {
                    fácilToolStripMenuItem.Checked = false;
                    normalToolStripMenuItem.Checked = true;
                    imposibleToolStripMenuItem.Checked = false;
                } 
                if (dificultad == 3)
                {
                    fácilToolStripMenuItem.Checked = false;
                    normalToolStripMenuItem.Checked = false;
                    imposibleToolStripMenuItem.Checked = true;
                }
            }
            if (gan == 0)
            {
                Mensaje();
            }
            if (limpiar == true)
            {
                ResetearPuntajes();
                JugarDeNuevo();
                limpiar = false;
            }
            if (salida == true)
            {
                this.Dispose();
            }
            if (empieza == 3)
            {
                ComienzaMaquina();
                empieza = 2;
            }
            jug1.Text = NombresJugadores.NombreJugador1 + " (X)";
            jug2.Text = NombresJugadores.NombreJugador2 + " (O)";
            button3.Text = "Jugar de Nuevo" + "\n" + "(Comienza " + NombresJugadores.NombreJugador1 + ")";
            button4.Text = "Jugar de Nuevo" + "\n" + "(Comienza " + NombresJugadores.NombreJugador2 + ")";
        }

        //Eventos de click en el Tablero del juego
        private void ESPACIO1_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X1.Visible = true;
                    ESPACIO1.Visible = false;
                    O1.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O1.Visible = true;
                    ESPACIO1.Visible = false;
                    X1.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X1.Visible = true;
                ESPACIO1.Visible = false;
                O1.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        private void ESPACIO2_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X2.Visible = true;
                    ESPACIO2.Visible = false;
                    O2.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O2.Visible = true;
                    ESPACIO2.Visible = false;
                    X2.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X2.Visible = true;
                ESPACIO2.Visible = false;
                O2.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        private void ESPACIO3_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X3.Visible = true;
                    ESPACIO3.Visible = false;
                    O3.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O3.Visible = true;
                    ESPACIO3.Visible = false;
                    X3.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X3.Visible = true;
                ESPACIO3.Visible = false;
                O3.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        private void ESPACIO4_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X4.Visible = true;
                    ESPACIO4.Visible = false;
                    O4.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O4.Visible = true;
                    ESPACIO4.Visible = false;
                    X4.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X4.Visible = true;
                ESPACIO4.Visible = false;
                O4.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        private void ESPACIO5_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X5.Visible = true;
                    ESPACIO5.Visible = false;
                    O5.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O5.Visible = true;
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X5.Visible = true;
                ESPACIO5.Visible = false;
                O5.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        private void ESPACIO6_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X6.Visible = true;
                    ESPACIO6.Visible = false;
                    O6.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O6.Visible = true;
                    ESPACIO6.Visible = false;
                    X6.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X6.Visible = true;
                ESPACIO6.Visible = false;
                O6.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        private void ESPACIO7_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X7.Visible = true;
                    ESPACIO7.Visible = false;
                    O7.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O7.Visible = true;
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X7.Visible = true;
                ESPACIO7.Visible = false;
                O7.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        private void ESPACIO8_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X8.Visible = true;
                    ESPACIO8.Visible = false;
                    O8.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O8.Visible = true;
                    ESPACIO8.Visible = false;
                    X8.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X8.Visible = true;
                ESPACIO8.Visible = false;
                O8.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        private void ESPACIO9_Click(object sender, EventArgs e)
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    X9.Visible = true;
                    ESPACIO9.Visible = false;
                    O9.Visible = false;
                    jugador = 2;
                }
                else
                {
                    O9.Visible = true;
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    jugador = 1;
                }
                Mensaje();
                Comprobar();
            }
            if (tipojuego == 2)
            {
                X9.Visible = true;
                ESPACIO9.Visible = false;
                O9.Visible = false;
                Mensaje();
                Comprobar();
                if (gan == 0)
                {
                    JuegaMaquina();
                    Mensaje();
                    Comprobar();
                }
            }
        }

        public void Comprobar()
        {
            if (X1.Visible == true && X2.Visible == true && X3.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador1 + " (X)";
                X1.BackColor = System.Drawing.Color.Fuchsia;
                X2.BackColor = System.Drawing.Color.Fuchsia;
                X3.BackColor = System.Drawing.Color.Fuchsia;
                ganadas1++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador1 + " (X)", "TaTeTi");
            }
            else if (X4.Visible == true && X5.Visible == true && X6.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador1 + " (X)";
                X4.BackColor = System.Drawing.Color.Fuchsia;
                X5.BackColor = System.Drawing.Color.Fuchsia;
                X6.BackColor = System.Drawing.Color.Fuchsia;
                ganadas1++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador1 + " (X)", "TaTeTi");
            }
            else if (X7.Visible == true && X8.Visible == true && X9.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador1 + " (X)";
                X7.BackColor = System.Drawing.Color.Fuchsia;
                X8.BackColor = System.Drawing.Color.Fuchsia;
                X9.BackColor = System.Drawing.Color.Fuchsia;
                ganadas1++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador1 + " (X)", "TaTeTi");
            }
            else if (X1.Visible == true && X4.Visible == true && X7.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador1 + " (X)";
                X1.BackColor = System.Drawing.Color.Fuchsia;
                X4.BackColor = System.Drawing.Color.Fuchsia;
                X7.BackColor = System.Drawing.Color.Fuchsia;
                ganadas1++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador1 + " (X)", "TaTeTi");
            }
            else if (X2.Visible == true && X5.Visible == true && X8.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador1 + " (X)";
                X2.BackColor = System.Drawing.Color.Fuchsia;
                X5.BackColor = System.Drawing.Color.Fuchsia;
                X8.BackColor = System.Drawing.Color.Fuchsia;
                ganadas1++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador1 + " (X)", "TaTeTi");

            }
            else if (X3.Visible == true && X6.Visible == true && X9.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador1 + " (X)";
                X3.BackColor = System.Drawing.Color.Fuchsia;
                X6.BackColor = System.Drawing.Color.Fuchsia;
                X9.BackColor = System.Drawing.Color.Fuchsia;
                ganadas1++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador1 + " (X)", "TaTeTi");
            }
            else if (X1.Visible == true && X5.Visible == true && X9.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador1 + " (X)";
                X1.BackColor = System.Drawing.Color.Fuchsia;
                X5.BackColor = System.Drawing.Color.Fuchsia;
                X9.BackColor = System.Drawing.Color.Fuchsia;
                ganadas1++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador1 + " (X)", "TaTeTi");
            }
            else if (X3.Visible == true && X5.Visible == true && X7.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador1 + " (X)";
                X3.BackColor = System.Drawing.Color.Fuchsia;
                X5.BackColor = System.Drawing.Color.Fuchsia;
                X7.BackColor = System.Drawing.Color.Fuchsia;
                ganadas1++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador1 + " (X)", "TaTeTi");
            }
            else if (O1.Visible == true && O2.Visible == true && O3.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador2 + " (O)";
                O1.BackColor = System.Drawing.Color.Fuchsia;
                O2.BackColor = System.Drawing.Color.Fuchsia;
                O3.BackColor = System.Drawing.Color.Fuchsia;
                ganadas2++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador2 + " (O)", "TaTeTi");
            }
            else if (O4.Visible == true && O5.Visible == true && O6.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador2 + " (O)";
                O4.BackColor = System.Drawing.Color.Fuchsia;
                O5.BackColor = System.Drawing.Color.Fuchsia;
                O6.BackColor = System.Drawing.Color.Fuchsia;
                ganadas2++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador2 + " (O)", "TaTeTi");
            }
            else if (O7.Visible == true && O8.Visible == true && O9.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador2 + " (O)";
                O7.BackColor = System.Drawing.Color.Fuchsia;
                O8.BackColor = System.Drawing.Color.Fuchsia;
                O9.BackColor = System.Drawing.Color.Fuchsia;
                ganadas2++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador2 + " (O)", "TaTeTi");
            }
            else if (O1.Visible == true && O4.Visible == true && O7.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador2 + " (O)";
                O1.BackColor = System.Drawing.Color.Fuchsia;
                O4.BackColor = System.Drawing.Color.Fuchsia;
                O7.BackColor = System.Drawing.Color.Fuchsia;
                ganadas2++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador2 + " (O)", "TaTeTi");
            }
            else if (O2.Visible == true && O5.Visible == true && O8.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador2 + " (O)";
                O2.BackColor = System.Drawing.Color.Fuchsia;
                O5.BackColor = System.Drawing.Color.Fuchsia;
                O8.BackColor = System.Drawing.Color.Fuchsia;
                ganadas2++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador2 + " (O)", "TaTeTi");
            }
            else if (O3.Visible == true && O6.Visible == true && O9.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador2 + " (O)";
                O3.BackColor = System.Drawing.Color.Fuchsia;
                O6.BackColor = System.Drawing.Color.Fuchsia;
                O9.BackColor = System.Drawing.Color.Fuchsia;
                ganadas2++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador2 + " (O)", "TaTeTi");
            }
            else if (O1.Visible == true && O5.Visible == true && O9.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador2 + " (O)";
                O1.BackColor = System.Drawing.Color.Fuchsia;
                O5.BackColor = System.Drawing.Color.Fuchsia;
                O9.BackColor = System.Drawing.Color.Fuchsia;
                ganadas2++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador2 + " (O)", "TaTeTi");
            }
            else if (O3.Visible == true && O5.Visible == true && O7.Visible == true)
            {
                mensaje.Text = "Ganador: " + NombresJugadores.NombreJugador2 + " (O)";
                O3.BackColor = System.Drawing.Color.Fuchsia;
                O5.BackColor = System.Drawing.Color.Fuchsia;
                O7.BackColor = System.Drawing.Color.Fuchsia;
                ganadas2++;
                gano();
                MessageBox.Show("Ganador: " + NombresJugadores.NombreJugador2 + " (O)", "TaTeTi");
            }
            else if (ESPACIO1.Visible == false && ESPACIO2.Visible == false && ESPACIO3.Visible == false && ESPACIO4.Visible == false && ESPACIO5.Visible == false && ESPACIO6.Visible == false && ESPACIO7.Visible == false && ESPACIO8.Visible == false && ESPACIO9.Visible == false)
            {
                mensaje.Text = "Empate";
                empates++;
                gano();
                MessageBox.Show("Empate", "TaTeTi");
            }

        }

        public void Mensaje()
        {
            if (tipojuego == 1)
            {
                if (jugador == 1)
                {
                    mensaje.Text = "Juega " + NombresJugadores.NombreJugador1 + " (X)";
                }
                if (jugador == 2)
                {
                    mensaje.Text = "Juega " + NombresJugadores.NombreJugador2 + " (O)";
                }
            }
            else
            {
                mensaje.Text = "Juega " + NombresJugadores.NombreJugador1 + " (X)";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JugarDeNuevo();
            if (jugador == 2 && tipojuego==2)
            {
                ComienzaMaquina();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult reset = MessageBox.Show("¿Está seguro que desea reiniciar los puntajes?", "TaTeTi", MessageBoxButtons.OKCancel);
            if (reset == DialogResult.OK)
            {
                ResetearPuntajes();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JugarDeNuevo();
            jugador = 1;
            Mensaje();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JugarDeNuevo();
            if (tipojuego == 2)
            {
                if (empieza == 1)
                {
                    jugador = 2;
                    empieza = 2;
                }
                else if (empieza == 2)
                {
                    jugador = 1;
                    empieza = 1;
                }
                ComienzaMaquina();
            }
            else
            {
                jugador = 2;
            }
            Mensaje();
        }

        public void JugarDeNuevo()
        {
            if (empieza == 1)
            {
                jugador = 2;
                empieza = 2;
            }
            else if (empieza == 2)
            {
                jugador = 1;
                empieza = 1;
            }
            gan = 0;
            ESPACIO1.Visible = true;
            ESPACIO2.Visible = true;
            ESPACIO3.Visible = true;
            ESPACIO4.Visible = true;
            ESPACIO5.Visible = true;
            ESPACIO6.Visible = true;
            ESPACIO7.Visible = true;
            ESPACIO8.Visible = true;
            ESPACIO9.Visible = true;
            X1.Visible = false;
            X2.Visible = false;
            X3.Visible = false;
            X4.Visible = false;
            X5.Visible = false;
            X6.Visible = false;
            X7.Visible = false;
            X8.Visible = false;
            X9.Visible = false;
            O1.Visible = false;
            O2.Visible = false;
            O3.Visible = false;
            O4.Visible = false;
            O5.Visible = false;
            O6.Visible = false;
            O7.Visible = false;
            O8.Visible = false;
            O9.Visible = false;
            X1.BackColor = Color.FromArgb(rojo, verde, azul);
            X2.BackColor = Color.FromArgb(rojo, verde, azul);
            X3.BackColor = Color.FromArgb(rojo, verde, azul);
            X4.BackColor = Color.FromArgb(rojo, verde, azul);
            X5.BackColor = Color.FromArgb(rojo, verde, azul);
            X6.BackColor = Color.FromArgb(rojo, verde, azul);
            X7.BackColor = Color.FromArgb(rojo, verde, azul);
            X8.BackColor = Color.FromArgb(rojo, verde, azul);
            X9.BackColor = Color.FromArgb(rojo, verde, azul);
            O1.BackColor = Color.FromArgb(rojo, verde, azul);
            O2.BackColor = Color.FromArgb(rojo, verde, azul);
            O3.BackColor = Color.FromArgb(rojo, verde, azul);
            O4.BackColor = Color.FromArgb(rojo, verde, azul);
            O5.BackColor = Color.FromArgb(rojo, verde, azul);
            O6.BackColor = Color.FromArgb(rojo, verde, azul);
            O7.BackColor = Color.FromArgb(rojo, verde, azul);
            O8.BackColor = Color.FromArgb(rojo, verde, azul);
            O9.BackColor = Color.FromArgb(rojo, verde, azul);
            Mensaje();
        }

        public void ComienzaMaquina()
        {
            if (dificultad == 1 || dificultad == 2  || dificultad == 3)
            {
                jugada = jugadar.Next(1, 10);
                if (jugada == 1)
                {
                    ESPACIO1.Visible = false;
                    O1.Visible = true;
                    X1.Visible = false;
                }
                if (jugada == 2)
                {
                    ESPACIO2.Visible = false;
                    O2.Visible = true;
                    X2.Visible = false;
                }
                if (jugada == 3)
                {
                    ESPACIO3.Visible = false;
                    O3.Visible = true;
                    X3.Visible = false;
                }
                if (jugada == 4)
                {
                    ESPACIO4.Visible = false;
                    O4.Visible = true;
                    X4.Visible = false;
                }
                if (jugada == 5)
                {
                    ESPACIO5.Visible = false;
                    O5.Visible = true;
                    X5.Visible = false;
                }
                if (jugada == 6)
                {
                    ESPACIO6.Visible = false;
                    O6.Visible = true;
                    X6.Visible = false;
                }
                if (jugada == 7)
                {
                    ESPACIO7.Visible = false;
                    O7.Visible = true;
                    X7.Visible = false;
                }
                if (jugada == 8)
                {
                    ESPACIO8.Visible = false;
                    O8.Visible = true;
                    X8.Visible = false;
                }
                if (jugada == 9)
                {
                    ESPACIO9.Visible = false;
                    O9.Visible = true;
                    X9.Visible = false;
                }
            }
            Mensaje();
        }

        public void JuegaMaquina()
        {
            if (dificultad == 1)
            {
                Facil();
            }
            if (dificultad == 2)
            {
                Normal();
            }
            if (dificultad == 3)
            {
                Imposible();
            }
        }

        public void JugadaAleatoria()
        {
        Generar:
            jugada = jugadar.Next(1, 10);
            if (jugada == 1)
            {
                if (ESPACIO1.Visible == true)
                {
                    ESPACIO1.Visible = false;
                    O1.Visible = true;
                    X1.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
            if (jugada == 2)
            {
                if (ESPACIO2.Visible == true)
                {
                    ESPACIO2.Visible = false;
                    O2.Visible = true;
                    X2.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
            if (jugada == 3)
            {
                if (ESPACIO3.Visible == true)
                {
                    ESPACIO3.Visible = false;
                    O3.Visible = true;
                    X3.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
            if (jugada == 4)
            {
                if (ESPACIO4.Visible == true)
                {
                    ESPACIO4.Visible = false;
                    O4.Visible = true;
                    X4.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
            if (jugada == 5)
            {
                if (ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    O5.Visible = true;
                    X5.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
            if (jugada == 6)
            {
                if (ESPACIO6.Visible == true)
                {
                    ESPACIO6.Visible = false;
                    O6.Visible = true;
                    X6.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
            if (jugada == 7)
            {
                if (ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    O7.Visible = true;
                    X7.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
            if (jugada == 8)
            {
                if (ESPACIO8.Visible == true)
                {
                    ESPACIO8.Visible = false;
                    O8.Visible = true;
                    X8.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
            if (jugada == 9)
            {
                if (ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    O9.Visible = true;
                    X9.Visible = false;
                }
                else
                {
                    goto Generar;
                }
            }
        }

        public void Facil()
        {
            if (O1.Visible == true && O2.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else if (O4.Visible == true && O5.Visible == true && ESPACIO6.Visible == true)
            {
                ESPACIO6.Visible = false;
                O6.Visible = true;
                X6.Visible = false;
            }
            else if (O7.Visible == true && O8.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O1.Visible == true && O3.Visible == true && ESPACIO2.Visible == true)
            {
                ESPACIO2.Visible = false;
                O2.Visible = true;
                X2.Visible = false;
            }
            else if (O4.Visible == true && O6.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O7.Visible == true && O9.Visible == true && ESPACIO8.Visible == true)
            {
                ESPACIO8.Visible = false;
                O8.Visible = true;
                X8.Visible = false;
            }
            else if (O2.Visible == true && O3.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O6.Visible == true && ESPACIO4.Visible == true)
            {
                ESPACIO4.Visible = false;
                O4.Visible = true;
                X4.Visible = false;
            }
            else if (O8.Visible == true && O9.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O1.Visible == true && O4.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O2.Visible == true && O5.Visible == true && ESPACIO8.Visible == true)
            {
                ESPACIO8.Visible = false;
                O8.Visible = true;
                X8.Visible = false;
            }
            else if (O3.Visible == true && O6.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O1.Visible == true && O7.Visible == true && ESPACIO4.Visible == true)
            {
                ESPACIO4.Visible = false;
                O4.Visible = true;
                X4.Visible = false;
            }
            else if (O2.Visible == true && O8.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O3.Visible == true && O9.Visible == true && ESPACIO6.Visible == true)
            {
                ESPACIO6.Visible = false;
                O6.Visible = true;
                X6.Visible = false;
            }
            else if (O4.Visible == true && O7.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O8.Visible == true && ESPACIO2.Visible == true)
            {
                ESPACIO2.Visible = false;
                O2.Visible = true;
                X2.Visible = false;
            }
            else if (O6.Visible == true && O9.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else if (O1.Visible == true && O5.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O3.Visible == true && O5.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O1.Visible == true && O9.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O3.Visible == true && O7.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O5.Visible == true && O9.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O7.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else
            {
                JugadaAleatoria();
            }
        }

        public void Normal()
        {
            if (O1.Visible == true && O2.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else if (O4.Visible == true && O5.Visible == true && ESPACIO6.Visible == true)
            {
                ESPACIO6.Visible = false;
                O6.Visible = true;
                X6.Visible = false;
            }
            else if (O7.Visible == true && O8.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O1.Visible == true && O3.Visible == true && ESPACIO2.Visible == true)
            {
                ESPACIO2.Visible = false;
                O2.Visible = true;
                X2.Visible = false;
            }
            else if (O4.Visible == true && O6.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O7.Visible == true && O9.Visible == true && ESPACIO8.Visible == true)
            {
                ESPACIO8.Visible = false;
                O8.Visible = true;
                X8.Visible = false;
            }
            else if (O2.Visible == true && O3.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O6.Visible == true && ESPACIO4.Visible == true)
            {
                ESPACIO4.Visible = false;
                O4.Visible = true;
                X4.Visible = false;
            }
            else if (O8.Visible == true && O9.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O1.Visible == true && O4.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O2.Visible == true && O5.Visible == true && ESPACIO8.Visible == true)
            {
                ESPACIO8.Visible = false;
                O8.Visible = true;
                X8.Visible = false;
            }
            else if (O3.Visible == true && O6.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O1.Visible == true && O7.Visible == true && ESPACIO4.Visible == true)
            {
                ESPACIO4.Visible = false;
                O4.Visible = true;
                X4.Visible = false;
            }
            else if (O2.Visible == true && O8.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O3.Visible == true && O9.Visible == true && ESPACIO6.Visible == true)
            {
                ESPACIO6.Visible = false;
                O6.Visible = true;
                X6.Visible = false;
            }
            else if (O4.Visible == true && O7.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O8.Visible == true && ESPACIO2.Visible == true)
            {
                ESPACIO2.Visible = false;
                O2.Visible = true;
                X2.Visible = false;
            }
            else if (O6.Visible == true && O9.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else if (O1.Visible == true && O5.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O3.Visible == true && O5.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O1.Visible == true && O9.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O3.Visible == true && O7.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O5.Visible == true && O9.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O7.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else
            {
                if (X1.Visible == true && X2.Visible == true && ESPACIO3.Visible == true)
                {
                    ESPACIO3.Visible = false;
                    X3.Visible = false;
                    O3.Visible = true;
                }
                else if (X4.Visible == true && X5.Visible == true && ESPACIO6.Visible == true)
                {
                    ESPACIO6.Visible = false;
                    X6.Visible = false;
                    O6.Visible = true;
                }
                else if (X7.Visible == true && X8.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else if (X1.Visible == true && X3.Visible == true && ESPACIO2.Visible == true)
                {
                    ESPACIO2.Visible = false;
                    X2.Visible = false;
                    O2.Visible = true;
                }
                else if (X4.Visible == true && X6.Visible == true && ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    O5.Visible = true;
                }
                else if (X7.Visible == true && X9.Visible == true && ESPACIO8.Visible == true)
                {
                    ESPACIO8.Visible = false;
                    X8.Visible = false;
                    O8.Visible = true;
                }
                else if (X2.Visible == true && X3.Visible == true && ESPACIO1.Visible == true)
                {
                    ESPACIO1.Visible = false;
                    X1.Visible = false;
                    O1.Visible = true;
                }
                else if (X5.Visible == true && X6.Visible == true && ESPACIO4.Visible == true)
                {
                    ESPACIO4.Visible = false;
                    X4.Visible = false;
                    O4.Visible = true;
                }
                else if (X8.Visible == true && X9.Visible == true && ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    O7.Visible = true;
                }
                else if (X1.Visible == true && X4.Visible == true && ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    O7.Visible = true;
                }
                else if (X2.Visible == true && X5.Visible == true && ESPACIO8.Visible == true)
                {
                    ESPACIO8.Visible = false;
                    X8.Visible = false;
                    O8.Visible = true;
                }
                else if (X3.Visible == true && X6.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else if (X1.Visible == true && X7.Visible == true && ESPACIO4.Visible == true)
                {
                    ESPACIO4.Visible = false;
                    X4.Visible = false;
                    O4.Visible = true;
                }
                else if (X2.Visible == true && X8.Visible == true && ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    O5.Visible = true;
                }
                else if (X3.Visible == true && X9.Visible == true && ESPACIO6.Visible == true)
                {
                    ESPACIO6.Visible = false;
                    X6.Visible = false;
                    O6.Visible = true;
                }
                else if (X4.Visible == true && X7.Visible == true && ESPACIO1.Visible == true)
                {
                    ESPACIO1.Visible = false;
                    X1.Visible = false;
                    O1.Visible = true;
                }
                else if (X5.Visible == true && X8.Visible == true && ESPACIO2.Visible == true)
                {
                    ESPACIO2.Visible = false;
                    X2.Visible = false;
                    O2.Visible = true;
                }
                else if (X6.Visible == true && X9.Visible == true && ESPACIO3.Visible == true)
                {
                    ESPACIO3.Visible = false;
                    X3.Visible = false;
                    O3.Visible = true;
                }
                else if (X1.Visible == true && X5.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else if (X3.Visible == true && X5.Visible == true && ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    O7.Visible = true;
                }
                else if (X1.Visible == true && X9.Visible == true && ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    O5.Visible = true;
                }
                else if (X3.Visible == true && X7.Visible == true && ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    O5.Visible = true;
                }
                else if (X5.Visible == true && X9.Visible == true && ESPACIO1.Visible == true)
                {
                    ESPACIO1.Visible = false;
                    X1.Visible = false;
                    O1.Visible = true;
                }
                else if (X5.Visible == true && X7.Visible == true && ESPACIO3.Visible == true)
                {
                    ESPACIO3.Visible = false;
                    X3.Visible = false;
                    O3.Visible = true;
                }
                else
                {
                    JugadaAleatoria();
                }
            }
        }

        public void Imposible()
        {
            if (O1.Visible == true && O2.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else if (O4.Visible == true && O5.Visible == true && ESPACIO6.Visible == true)
            {
                ESPACIO6.Visible = false;
                O6.Visible = true;
                X6.Visible = false;
            }
            else if (O7.Visible == true && O8.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O1.Visible == true && O3.Visible == true && ESPACIO2.Visible == true)
            {
                ESPACIO2.Visible = false;
                O2.Visible = true;
                X2.Visible = false;
            }
            else if (O4.Visible == true && O6.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O7.Visible == true && O9.Visible == true && ESPACIO8.Visible == true)
            {
                ESPACIO8.Visible = false;
                O8.Visible = true;
                X8.Visible = false;
            }
            else if (O2.Visible == true && O3.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O6.Visible == true && ESPACIO4.Visible == true)
            {
                ESPACIO4.Visible = false;
                O4.Visible = true;
                X4.Visible = false;
            }
            else if (O8.Visible == true && O9.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O1.Visible == true && O4.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O2.Visible == true && O5.Visible == true && ESPACIO8.Visible == true)
            {
                ESPACIO8.Visible = false;
                O8.Visible = true;
                X8.Visible = false;
            }
            else if (O3.Visible == true && O6.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O1.Visible == true && O7.Visible == true && ESPACIO4.Visible == true)
            {
                ESPACIO4.Visible = false;
                O4.Visible = true;
                X4.Visible = false;
            }
            else if (O2.Visible == true && O8.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O3.Visible == true && O9.Visible == true && ESPACIO6.Visible == true)
            {
                ESPACIO6.Visible = false;
                O6.Visible = true;
                X6.Visible = false;
            }
            else if (O4.Visible == true && O7.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O8.Visible == true && ESPACIO2.Visible == true)
            {
                ESPACIO2.Visible = false;
                O2.Visible = true;
                X2.Visible = false;
            }
            else if (O6.Visible == true && O9.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else if (O1.Visible == true && O5.Visible == true && ESPACIO9.Visible == true)
            {
                ESPACIO9.Visible = false;
                O9.Visible = true;
                X9.Visible = false;
            }
            else if (O3.Visible == true && O5.Visible == true && ESPACIO7.Visible == true)
            {
                ESPACIO7.Visible = false;
                O7.Visible = true;
                X7.Visible = false;
            }
            else if (O1.Visible == true && O9.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O3.Visible == true && O7.Visible == true && ESPACIO5.Visible == true)
            {
                ESPACIO5.Visible = false;
                O5.Visible = true;
                X5.Visible = false;
            }
            else if (O5.Visible == true && O9.Visible == true && ESPACIO1.Visible == true)
            {
                ESPACIO1.Visible = false;
                O1.Visible = true;
                X1.Visible = false;
            }
            else if (O5.Visible == true && O7.Visible == true && ESPACIO3.Visible == true)
            {
                ESPACIO3.Visible = false;
                O3.Visible = true;
                X3.Visible = false;
            }
            else
            {
                if (X1.Visible == true && X2.Visible == true && ESPACIO3.Visible == true)
                {
                    ESPACIO3.Visible = false;
                    X3.Visible = false;
                    O3.Visible = true;
                }
                else if (X4.Visible == true && X5.Visible == true && ESPACIO6.Visible == true)
                {
                    ESPACIO6.Visible = false;
                    X6.Visible = false;
                    O6.Visible = true;
                }
                else if (X7.Visible == true && X8.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else if (X1.Visible == true && X3.Visible == true && ESPACIO2.Visible == true)
                {
                    ESPACIO2.Visible = false;
                    X2.Visible = false;
                    O2.Visible = true;
                }
                else if (X4.Visible == true && X6.Visible == true && ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    O5.Visible = true;
                }
                else if (X7.Visible == true && X9.Visible == true && ESPACIO8.Visible == true)
                {
                    ESPACIO8.Visible = false;
                    X8.Visible = false;
                    O8.Visible = true;
                }
                else if (X2.Visible == true && X3.Visible == true && ESPACIO1.Visible == true)
                {
                    ESPACIO1.Visible = false;
                    X1.Visible = false;
                    O1.Visible = true;
                }
                else if (X5.Visible == true && X6.Visible == true && ESPACIO4.Visible == true)
                {
                    ESPACIO4.Visible = false;
                    X4.Visible = false;
                    O4.Visible = true;
                }
                else if (X8.Visible == true && X9.Visible == true && ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    O7.Visible = true;
                }
                else if (X1.Visible == true && X4.Visible == true && ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    O7.Visible = true;
                }
                else if (X2.Visible == true && X5.Visible == true && ESPACIO8.Visible == true)
                {
                    ESPACIO8.Visible = false;
                    X8.Visible = false;
                    O8.Visible = true;
                }
                else if (X3.Visible == true && X6.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else if (X1.Visible == true && X7.Visible == true && ESPACIO4.Visible == true)
                {
                    ESPACIO4.Visible = false;
                    X4.Visible = false;
                    O4.Visible = true;
                }
                else if (X2.Visible == true && X8.Visible == true && ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    O5.Visible = true;
                }
                else if (X3.Visible == true && X9.Visible == true && ESPACIO6.Visible == true)
                {
                    ESPACIO6.Visible = false;
                    X6.Visible = false;
                    O6.Visible = true;
                }
                else if (X4.Visible == true && X7.Visible == true && ESPACIO1.Visible == true)
                {
                    ESPACIO1.Visible = false;
                    X1.Visible = false;
                    O1.Visible = true;
                }
                else if (X5.Visible == true && X8.Visible == true && ESPACIO2.Visible == true)
                {
                    ESPACIO2.Visible = false;
                    X2.Visible = false;
                    O2.Visible = true;
                }
                else if (X6.Visible == true && X9.Visible == true && ESPACIO3.Visible == true)
                {
                    ESPACIO3.Visible = false;
                    X3.Visible = false;
                    O3.Visible = true;
                }
                else if (X1.Visible == true && X5.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else if (X3.Visible == true && X5.Visible == true && ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    O7.Visible = true;
                }
                else if (X1.Visible == true && X9.Visible == true && ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    O5.Visible = true;
                }
                else if (X3.Visible == true && X7.Visible == true && ESPACIO5.Visible == true)
                {
                    ESPACIO5.Visible = false;
                    X5.Visible = false;
                    O5.Visible = true;
                }
                else if (X5.Visible == true && X9.Visible == true && ESPACIO1.Visible == true)
                {
                    ESPACIO1.Visible = false;
                    X1.Visible = false;
                    O1.Visible = true;
                }
                else if (X5.Visible == true && X7.Visible == true && ESPACIO3.Visible == true)
                {
                    ESPACIO3.Visible = false;
                    X3.Visible = false;
                    O3.Visible = true;
                }
                else if (X1.Visible == true && X9.Visible == true && ESPACIO2.Visible == true)
                {
                    ESPACIO2.Visible = false;
                    X2.Visible = false;
                    O2.Visible = true;
                }
                else if (X3.Visible == true && X7.Visible == true && ESPACIO2.Visible == true)
                {
                    ESPACIO2.Visible = false;
                    X2.Visible = false;
                    O2.Visible = true;
                }
                else if (X2.Visible == true && X4.Visible == true && ESPACIO1.Visible == true)
                {
                    ESPACIO1.Visible = false;
                    X1.Visible = false;
                    O1.Visible = true;
                }
                else if (X2.Visible == true && X6.Visible == true && ESPACIO3.Visible == true)
                {
                    ESPACIO3.Visible = false;
                    X3.Visible = false;
                    O3.Visible = true;
                }
                else if (X4.Visible == true && X8.Visible == true && ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    O7.Visible = true;
                }
                else if (X6.Visible == true && X8.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else  if(X1.Visible == true && X8.Visible ==  true && ESPACIO7.Visible == true)
                {
                    ESPACIO7.Visible = false;
                    X7.Visible = false;
                    O7.Visible = true;
                }
                else if (X3.Visible == true && X8.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else if (X7.Visible == true && X6.Visible == true && ESPACIO9.Visible == true)
                {
                    ESPACIO9.Visible = false;
                    X9.Visible = false;
                    O9.Visible = true;
                }
                else
                {
                    if (ESPACIO5.Visible == true)
                    {
                        O5.Visible = true;
                        X5.Visible = false;
                        ESPACIO5.Visible = false;
                    }
                    else if (ESPACIO1.Visible == true)
                    {
                        ESPACIO1.Visible = false;
                        O1.Visible = true;
                        X1.Visible = false;
                    }
                    else if (ESPACIO3.Visible == true)
                    {
                        ESPACIO3.Visible = false;
                        O3.Visible = true;
                        X3.Visible = false;
                    }
                    else if (ESPACIO7.Visible == true)
                    {
                        ESPACIO7.Visible = false;
                        O7.Visible = true;
                        X7.Visible = false;
                    }
                    else if (ESPACIO9.Visible == true)
                    {
                        ESPACIO9.Visible = false;
                        O9.Visible = true;
                        X9.Visible = false;
                    }
                    else
                    {
                        JugadaAleatoria();
                    }
                }
            }
        }

        public void ResetearPuntajes()
        {
            ganadas1 = 0;
            ganadas2 = 0;
            empates = 0;
            vecesjugadas = 0;
            gan1num.Text = ganadas1.ToString();
            gan2num.Text = ganadas2.ToString();
            empnum.Text = empates.ToString();
            cantjugnum.Text = vecesjugadas.ToString();
        }

        public void gano()
        {
            gan = 1;
            vecesjugadas++;
            ESPACIO1.Visible = false;
            ESPACIO2.Visible = false;
            ESPACIO3.Visible = false;
            ESPACIO4.Visible = false;
            ESPACIO5.Visible = false;
            ESPACIO6.Visible = false;
            ESPACIO7.Visible = false;
            ESPACIO8.Visible = false;
            ESPACIO9.Visible = false;
            gan1num.Text = ganadas1.ToString();
            gan2num.Text = ganadas2.ToString();
            empnum.Text = empates.ToString();
            cantjugnum.Text = vecesjugadas.ToString();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult salir = MessageBox.Show("¿Está seguro que desea salir?", "TaTeTi", MessageBoxButtons.OKCancel);
            if (salir == DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            rojo = trackBar1.Value * 5;
            verde = trackBar2.Value * 5;
            azul = trackBar3.Value * 5;
            this.BackColor = System.Drawing.Color.FromArgb(rojo, verde, azul);
            X1.BackColor = Color.FromArgb(rojo, verde, azul);
            X2.BackColor = Color.FromArgb(rojo, verde, azul);
            X3.BackColor = Color.FromArgb(rojo, verde, azul);
            X4.BackColor = Color.FromArgb(rojo, verde, azul);
            X5.BackColor = Color.FromArgb(rojo, verde, azul);
            X6.BackColor = Color.FromArgb(rojo, verde, azul);
            X7.BackColor = Color.FromArgb(rojo, verde, azul);
            X8.BackColor = Color.FromArgb(rojo, verde, azul);
            X9.BackColor = Color.FromArgb(rojo, verde, azul);
            O1.BackColor = Color.FromArgb(rojo, verde, azul);
            O2.BackColor = Color.FromArgb(rojo, verde, azul);
            O3.BackColor = Color.FromArgb(rojo, verde, azul);
            O4.BackColor = Color.FromArgb(rojo, verde, azul);
            O5.BackColor = Color.FromArgb(rojo, verde, azul);
            O6.BackColor = Color.FromArgb(rojo, verde, azul);
            O7.BackColor = Color.FromArgb(rojo, verde, azul);
            O8.BackColor = Color.FromArgb(rojo, verde, azul);
            O9.BackColor = Color.FromArgb(rojo, verde, azul);
        }



        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {
            rojo = trackBar1.Value * 5;
            verde = trackBar2.Value * 5;
            azul = trackBar3.Value * 5;
            this.BackColor = System.Drawing.Color.FromArgb(rojo, verde, azul);
            X1.BackColor = Color.FromArgb(rojo, verde, azul);
            X2.BackColor = Color.FromArgb(rojo, verde, azul);
            X3.BackColor = Color.FromArgb(rojo, verde, azul);
            X4.BackColor = Color.FromArgb(rojo, verde, azul);
            X5.BackColor = Color.FromArgb(rojo, verde, azul);
            X6.BackColor = Color.FromArgb(rojo, verde, azul);
            X7.BackColor = Color.FromArgb(rojo, verde, azul);
            X8.BackColor = Color.FromArgb(rojo, verde, azul);
            X9.BackColor = Color.FromArgb(rojo, verde, azul);
            O1.BackColor = Color.FromArgb(rojo, verde, azul);
            O2.BackColor = Color.FromArgb(rojo, verde, azul);
            O3.BackColor = Color.FromArgb(rojo, verde, azul);
            O4.BackColor = Color.FromArgb(rojo, verde, azul);
            O5.BackColor = Color.FromArgb(rojo, verde, azul);
            O6.BackColor = Color.FromArgb(rojo, verde, azul);
            O7.BackColor = Color.FromArgb(rojo, verde, azul);
            O8.BackColor = Color.FromArgb(rojo, verde, azul);
            O9.BackColor = Color.FromArgb(rojo, verde, azul);
        }

        private void trackBar3_Scroll_1(object sender, EventArgs e)
        {
            rojo = trackBar1.Value * 5;
            verde = trackBar2.Value * 5;
            azul = trackBar3.Value * 5;
            this.BackColor = System.Drawing.Color.FromArgb(rojo, verde, azul);
            X1.BackColor = Color.FromArgb(rojo, verde, azul);
            X2.BackColor = Color.FromArgb(rojo, verde, azul);
            X3.BackColor = Color.FromArgb(rojo, verde, azul);
            X4.BackColor = Color.FromArgb(rojo, verde, azul);
            X5.BackColor = Color.FromArgb(rojo, verde, azul);
            X6.BackColor = Color.FromArgb(rojo, verde, azul);
            X7.BackColor = Color.FromArgb(rojo, verde, azul);
            X8.BackColor = Color.FromArgb(rojo, verde, azul);
            X9.BackColor = Color.FromArgb(rojo, verde, azul);
            O1.BackColor = Color.FromArgb(rojo, verde, azul);
            O2.BackColor = Color.FromArgb(rojo, verde, azul);
            O3.BackColor = Color.FromArgb(rojo, verde, azul);
            O4.BackColor = Color.FromArgb(rojo, verde, azul);
            O5.BackColor = Color.FromArgb(rojo, verde, azul);
            O6.BackColor = Color.FromArgb(rojo, verde, azul);
            O7.BackColor = Color.FromArgb(rojo, verde, azul);
            O8.BackColor = Color.FromArgb(rojo, verde, azul);
            O9.BackColor = Color.FromArgb(rojo, verde, azul);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            rojo = 0;
            verde = 192;
            azul = 192;
            this.BackColor = System.Drawing.Color.FromArgb(rojo, verde, azul);
            X1.BackColor = Color.FromArgb(rojo, verde, azul);
            X2.BackColor = Color.FromArgb(rojo, verde, azul);
            X3.BackColor = Color.FromArgb(rojo, verde, azul);
            X4.BackColor = Color.FromArgb(rojo, verde, azul);
            X5.BackColor = Color.FromArgb(rojo, verde, azul);
            X6.BackColor = Color.FromArgb(rojo, verde, azul);
            X7.BackColor = Color.FromArgb(rojo, verde, azul);
            X8.BackColor = Color.FromArgb(rojo, verde, azul);
            X9.BackColor = Color.FromArgb(rojo, verde, azul);
            O1.BackColor = Color.FromArgb(rojo, verde, azul);
            O2.BackColor = Color.FromArgb(rojo, verde, azul);
            O3.BackColor = Color.FromArgb(rojo, verde, azul);
            O4.BackColor = Color.FromArgb(rojo, verde, azul);
            O5.BackColor = Color.FromArgb(rojo, verde, azul);
            O6.BackColor = Color.FromArgb(rojo, verde, azul);
            O7.BackColor = Color.FromArgb(rojo, verde, azul);
            O8.BackColor = Color.FromArgb(rojo, verde, azul);
            O9.BackColor = Color.FromArgb(rojo, verde, azul);
        }

    }
}
