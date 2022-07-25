using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;


using System.Windows.Input;
namespace JuegoFeriaADSI
{
    public partial class fondo : Form
    {
        public fondo()
        {
            InitializeComponent();

        }


        int tiempo = 60;
        int puntos = 0;
        int disparos = 6;
        int disparosEscopeta = 4;
        int disparosMetra = 20;
        int precioBalasPistola=50;
        int precioBalasEscopeta = 500;
        int precioBalasMetra = 100;
        int balasPistola=6;
        int balasEscopeta = 4;
        int balasMetra = 6;
        int precioEscopeta=500;
        int precioMetra = 800;
        int valorSangreCompleta = 1000;
        int valorSangre50 = 500;
        int arma = 1;
        string seleccionada = "no";
        string ruta = Directory.GetCurrentDirectory()+ "\\Effectos De Sonido\\";
        string seleccionadaMetra = "no";
        bool compradaEscopeta = false;
        bool compradaMetra = false;
        int sangre = 100;




        private void Juego_Load(object sender, EventArgs e)
        {
            
            label2.Text = "Nivel 1";
            pictureBox8.Image = Properties.Resources.pistolaSeleccionada;
            pictureBox8.BackColor = Color.Black;
            labelPrecioEscopeta.Text = "$" + precioEscopeta;
            label7.Text = balasPistola.ToString();
            labelPrecioBalasPistola.Text = "$"+precioBalasPistola;
            labelPrecioBalasEscopeta.Text = "$" + precioBalasEscopeta;
            progressBar1.Value = sangre;
            valorSangre.Text = "$"+valorSangre50;
            sangreCompleta.Text = "$"+valorSangreCompleta;
            labelPrecioMetra.Text = "$" + precioMetra;
            label5.Text = "$" + precioBalasMetra;


        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 0)
            {
                timer1.Stop();
                mostrarGif();
            }
           
            if (tiempo == 0)
            {
                label4.Text = "Juego terminado, el dinero conseguido fue $" + puntos;
                label4.BringToFront();
                timer1.Stop();
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
              

            }
            else
            {
                tiempo--;
                label1.Text = "Tiempo " + tiempo;
                if (puntos>100)
                {
                    pictureBox3.Visible = true;
                }
                if (puntos>500)
                {
                    pictureBox2.Visible = true;

                }
                if (puntos>1000)
                {
                    pictureBox4.Visible = true;

                }
            }
        }

        public void moverEnemigo()
        {
            Random random = new Random();
            pictureBox1.Location = new Point(random.Next(170, 1200), random.Next(0, 500));
            pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.mask_skinner_clown;
        }

        public void moverEnemigo2()
        {
            Random random = new Random();
            pictureBox2.Location = new Point(random.Next(200, 1200), random.Next(0, 500));
            pictureBox2.Image = JuegoFeriaADSI.Properties.Resources._260px_Woman_in_box;
            

        }
        public void moverEnemigo3()
        {
            Random random = new Random();
            pictureBox3.Location = new Point(random.Next(170, 1200), random.Next(0, 500));
            pictureBox3.Image = JuegoFeriaADSI.Properties.Resources.The_White_Lady;

        }
        public void moverEnemigo4()
        {
            Random random = new Random();
            pictureBox4.Location = new Point(random.Next(170, 1200), random.Next(0, 500));
            pictureBox4.Image = JuegoFeriaADSI.Properties.Resources.fantasma11;
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            moverEnemigo();
            if (seleccionadaMetra == "no")
            {
                ptbArmaOculta.BackColor = Color.Silver;
                labelPrecioMetra.BackColor = Color.Silver;
                labelArmaOculta.BackColor = Color.Silver;

            }
            if (seleccionada=="no")
            {
                pictureBox9.BackColor = Color.Silver;
                label6.BackColor = Color.Silver;
                labelPrecioEscopeta.BackColor = Color.Silver;
            }
            
            
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            moverEnemigo2();
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            moverEnemigo3();


        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            moverEnemigo4();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (disparos != 0 && arma==1)
            {
                puntos = puntos + 50;
                label7.Text = balasPistola.ToString();
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.CHANGRE;
                disparos--;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }
            }
            else if (disparosEscopeta != 0 && arma==2)
            {
                puntos = puntos + 100;
                labelBalasEscopeta.Text = balasEscopeta.ToString();
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.aciertoEscopeta;
                disparosEscopeta--;
                 if (arma==1)
                {
                    disminuirBalas();
                }else if (arma==2)
	            {
                    disminuirBalasEscopeta();
	            }

            }
            else if (disparosMetra!=0 && arma==3)
            {
                puntos = puntos + 250;
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.aciertoEscopeta;
                disparosMetra--;
                label8.Text = "x" + disparosMetra;
                 if (arma==1)
                {
                    disminuirBalas();
                }else if (arma==2)
	            {
                    disminuirBalasEscopeta();
                }
                 else
                 {
                     disminuirBalasMetra();
                 }
            }
            else 
            {
                axWindowsMediaPlayer3.URL = ruta+"loading.mp3";
            }

            
 

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (disparos != 0 && arma == 1)
            {
                puntos = puntos + 50;
                label7.Text = balasPistola.ToString();
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.CHANGRE;
                disparos--;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }
            }
            else if (disparosEscopeta != 0 && arma == 2)
            {
                puntos = puntos + 100;
                labelBalasEscopeta.Text = balasEscopeta.ToString();
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.aciertoEscopeta;
                disparosEscopeta--;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }

            }
            else if (disparosMetra != 0 && arma == 3)
            {
                puntos = puntos + 250;
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.aciertoEscopeta;
                disparosMetra--;
                label8.Text = "x" + disparosMetra;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }
                else
                {
                    disminuirBalasMetra();
                }
            }
            else
            {
                axWindowsMediaPlayer3.URL = ruta+"loading.mp3";
            }

            
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (disparos != 0 && arma == 1)
            {
                puntos = puntos + 50;
                label7.Text = balasPistola.ToString();
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox3.Image = JuegoFeriaADSI.Properties.Resources.CHANGRE;
                disparos--;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }
            }
            else if (disparosEscopeta != 0 && arma == 2)
            {
                puntos = puntos + 100;
                labelBalasEscopeta.Text = balasEscopeta.ToString();
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox3.Image = JuegoFeriaADSI.Properties.Resources.aciertoEscopeta;
                disparosEscopeta--;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }

            }
            else if (disparosMetra != 0 && arma == 3)
            {
                puntos = puntos + 250;
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox3.Image = JuegoFeriaADSI.Properties.Resources.aciertoEscopeta;
                disparosMetra--;
                label8.Text = "x" + disparosMetra;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }
                else
                {
                    disminuirBalasMetra();
                }
            }
            else
            {
                axWindowsMediaPlayer3.URL = ruta+"loading.mp3";
            }

            


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (disparos != 0 && arma == 1)
            {
                puntos = puntos + 50;
                label7.Text = balasPistola.ToString();
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.CHANGRE;
                disparos--;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }
            }
            else if (disparosEscopeta != 0 && arma == 2)
            {
                puntos = puntos + 100;
                labelBalasEscopeta.Text = balasEscopeta.ToString();
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.aciertoEscopeta;
                disparosEscopeta--;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }

            }
            else if (disparosMetra != 0 && arma == 3)
            {
                puntos = puntos + 250;
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"headshot.mp3";
                axWindowsMediaPlayer3.URL = ruta+"disparoCabeza.mp3";
                pictureBox1.Image = JuegoFeriaADSI.Properties.Resources.aciertoEscopeta;
                disparosMetra--;
                label8.Text = "x" + disparosMetra;
                if (arma == 1)
                {
                    disminuirBalas();
                }
                else if (arma == 2)
                {
                    disminuirBalasEscopeta();
                }
                else
                {
                    disminuirBalasMetra();
                }
            }
            else
            {
                axWindowsMediaPlayer3.URL = ruta+"loading.mp3";
            }

            

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (disparos!=0 && arma==1 && sangre>=10)
            {
                sangre = sangre - 10;
                progressBar1.Value = sangre;

            }
            if (disparosEscopeta != 0 && arma == 2 && sangre >= 10)
            {
                sangre = sangre - 10;
                progressBar1.Value = sangre;

            }
            if (disparos != 0 && arma==1)
            {
                labelPuntos.Text = "$" + puntos;
                label7.Text = balasPistola.ToString();
                axWindowsMediaPlayer2.URL = ruta+"disparoPistola.mp3";
                axWindowsMediaPlayer3.URL = ruta+"risaPayaso.mp3";
                disparos--;
                disminuirBalas();

            }
            else if (disparosEscopeta!=0 && arma==2)
            {
                labelPuntos.Text = "$" + puntos;
                labelBalasEscopeta.Text = balasEscopeta.ToString();
                axWindowsMediaPlayer2.URL = ruta+"disparoPistola.mp3";
                axWindowsMediaPlayer3.URL = ruta+"risaPayaso.mp3";
                disparosEscopeta--;
                disminuirBalasEscopeta();
            }
            else if (disparosMetra != 0 && arma == 3)
            {
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer2.URL = ruta+"disparoPistola.mp3";
                axWindowsMediaPlayer3.URL = ruta+"risaPayaso.mp3";
                disparosMetra--;
                label8.Text = "x"+disparosMetra;

                disminuirBalasMetra();
            }
            else 
            {
                label3.ForeColor = Color.AntiqueWhite;
                axWindowsMediaPlayer3.URL = ruta+"loading.mp3";
            }

               
            
            
        }

    

        public void disminuirBalas() 
        {
            if (disparos==5)
            {
                bala6.Visible = false;
            }
            if (disparos == 4)
            {
                bala5.Visible = false;
            }
            if (disparos == 3)
            {
                bala4.Visible = false;
            }
            if (disparos == 2)
            {
                bala3.Visible = false;
            }
            if (disparos == 1)
            {
                bala2.Visible = false;
            }
            if (disparos == 0)
            {
                bala1.Visible = false;
                label3.Visible = true;

            }
            
        }
        public void disminuirBalasEscopeta()
        {
            if (disparosEscopeta == 4)
            {
                bala5.Visible = false;
            }
            if (disparosEscopeta == 3)
            {
                bala4.Visible = false;
            }
            if (disparosEscopeta == 2)
            {
                bala3.Visible = false;
            }
            if (disparosEscopeta == 1)
            {
                bala2.Visible = false;
            }
            if (disparosEscopeta == 0)
            {
                bala1.Visible = false;
                label3.Visible = true;

            }

        }

        public void disminuirBalasMetra()
        {
            if (disparosMetra == 5)
            {
                bala6.Visible = false;
            }
            if (disparosMetra == 4)
            {
                bala5.Visible = false;
            }
            if (disparosMetra == 3)
            {
                bala4.Visible = false;
            }
            if (disparosMetra == 2)
            {
                bala3.Visible = false;
            }
            if (disparosMetra == 1)
            {
                bala2.Visible = false;
            }
            if (disparosMetra == 0)
            {
                bala1.Visible = false;
                label3.Visible = true;

            }

        }


        private void label3_Click(object sender, EventArgs e)
        {
           
                for (int i = disparos; i < 6; i++)
                {
                    if (balasPistola > 0)
                    {
                        disparos++;
                        balasPistola--;
                    }
                }
                if (disparos == 6)
                {
                    bala1.Visible = true;
                    bala2.Visible = true;
                    bala3.Visible = true;
                    bala4.Visible = true;
                    bala5.Visible = true;
                    bala6.Visible = true;
                }
                if (disparos == 5)
                {
                    bala1.Visible = true;
                    bala2.Visible = true;
                    bala3.Visible = true;
                    bala4.Visible = true;
                    bala5.Visible = true;
                }
                if (disparos == 4)
                {
                    bala1.Visible = true;
                    bala2.Visible = true;
                    bala3.Visible = true;
                    bala4.Visible = true;

                }
                if (disparos == 3)
                {
                    bala1.Visible = true;
                    bala2.Visible = true;
                    bala3.Visible = true;
                }
                if (disparos == 2)
                {
                    bala1.Visible = true;
                    bala2.Visible = true;
                }
                if (disparos == 1)
                {
                    bala1.Visible = true;
                }
                label7.Text = "" + balasPistola;
                axWindowsMediaPlayer4.URL = ruta+"loading.mp3";
                label3.Visible = false;
            }
                                                                                                                       

        

        private void mostrarGif() 
        {
            pictureBox6.Visible = true;
            pictureBox6.BringToFront();
            pictureBox6.Dock = DockStyle.Fill;

            label4.BringToFront();
            axWindowsMediaPlayer1.close();

            axWindowsMediaPlayer1.URL = ruta+"grito.mp3";
            label4.Visible = true;
            label4.Text = "Juego terminado, el dinero conseguido fue $"+puntos; 
        }
        
        public void recargarPistola() 
        {
            bala1.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
            bala2.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
            bala3.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
            bala4.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
            for (int i = disparos; i < 6; i++)
            {
                if (balasPistola != 0)
                {
                    disparos++;
                    balasPistola--;
                }
            }
            if (disparos == 6)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
                bala4.Visible = true;
                bala5.Visible = true;
                bala6.Visible = true;
            }
            if (disparos == 5)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
                bala4.Visible = true;
                bala5.Visible = true;
            }
            if (disparos == 4)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
                bala4.Visible = true;

            }
            if (disparos == 3)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
            }
            if (disparos == 2)
            {
                bala1.Visible = true;
                bala2.Visible = true;
            }
            if (disparos == 1)
            {
                bala1.Visible = true;
            }
            label7.Text = "" + balasPistola;
            axWindowsMediaPlayer4.URL = ruta+"loading.mp3";
            label3.Visible = false;
        }

        public void recargarEscopeta()
        {
            bala1.Image = JuegoFeriaADSI.Properties.Resources.escopetaBalaPng;
            bala2.Image = JuegoFeriaADSI.Properties.Resources.escopetaBalaPng;
            bala3.Image = JuegoFeriaADSI.Properties.Resources.escopetaBalaPng;
            bala4.Image = JuegoFeriaADSI.Properties.Resources.escopetaBalaPng;

            for (int i = disparosEscopeta; i < 4; i++)
            {
                if (balasEscopeta != 0)
                {
                    disparosEscopeta++;
                    balasEscopeta--;
                }
            }
            if (disparosEscopeta == 4)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
                bala4.Visible = true;
                bala5.Visible = false;
                bala6.Visible = false;

            }
            if (disparosEscopeta == 3)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
                bala4.Visible = false;
                bala5.Visible = false;
                bala6.Visible = false;
            }
            if (disparosEscopeta == 2)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = false;
                bala4.Visible = false;
                bala5.Visible = false;
                bala6.Visible = false;
            }
            if (disparosEscopeta == 1)
            {
                bala1.Visible = true;
                bala2.Visible = false;
                bala3.Visible = false;
                bala4.Visible = false;
                bala5.Visible = false;
                bala6.Visible = false;
            }
            labelBalasEscopeta.Text = "" + balasEscopeta;
            axWindowsMediaPlayer4.URL = ruta+"loading.mp3";
            label3.Visible = false;
        }

        public void recargarMetralleta()
        {
            bala1.Image = JuegoFeriaADSI.Properties.Resources.balaPequeña;
            bala2.Image = JuegoFeriaADSI.Properties.Resources.balaPequeña;
            bala3.Image = JuegoFeriaADSI.Properties.Resources.balaPequeña;
            bala4.Image = JuegoFeriaADSI.Properties.Resources.balaPequeña;
            bala5.Image = JuegoFeriaADSI.Properties.Resources.balaPequeña;
            bala6.Image = JuegoFeriaADSI.Properties.Resources.balaPequeña;
            for (int i = balasMetra; i < 6; i++)
            {
                if (balasMetra != 0)
                {
                    balasMetra++;
                    disparosMetra--;
                }
            }
            if (balasMetra == 6)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
                bala4.Visible = true;
                bala5.Visible = true;
                bala6.Visible = true;
            }
            if (balasMetra == 5)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
                bala4.Visible = true;
                bala5.Visible = true;
            }
            if (balasMetra == 4)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
                bala4.Visible = true;

            }
            if (balasMetra == 3)
            {
                bala1.Visible = true;
                bala2.Visible = true;
                bala3.Visible = true;
            }
            if (balasMetra == 2)
            {
                bala1.Visible = true;
                bala2.Visible = true;
            }
            if (balasMetra == 1)
            {
                bala1.Visible = true;
            }
            label7.Text = "" + balasPistola;
            axWindowsMediaPlayer4.URL = ruta+"loading.mp3";
            label3.Visible = false;
        }
        private void fondo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                if (arma == 1 && balasPistola > 0)
                {
                    recargarPistola();
                }
                if (arma == 2 && balasEscopeta>0)
                {
                    recargarEscopeta();
                }
               
                
            }

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            pictureBox8.Image = Properties.Resources.pistola;

            arma = 2;
            pictureBox12.Visible = true;
            labelPrecioBalasEscopeta.Visible = true;
         
            balasPistola = balasPistola + disparos;
            label7.Text = balasPistola.ToString();
            disparos = 0;
            if (balasEscopeta!=0)
            {
                recargarEscopeta();
            }    
            seleccionada = "si";
             if (compradaEscopeta!=true)
            {

            if (puntos >= precioEscopeta )
            {

                pictureBox9.BackColor = Color.Transparent;
                pictureBox9.Image = Properties.Resources.escopetaSeleccionada;
                labelPrecioEscopeta.Visible = false;
                label6.Visible = false;
                labelBalasEscopeta.Visible = true;
                labelBalasEscopeta.Text = "" + balasEscopeta;
                compradaEscopeta = true;
                puntos = puntos - precioEscopeta;
                labelPuntos.Text = "$" + puntos;

            }
            }
             else
             {
                 pictureBox9.Image = Properties.Resources.escopetaSeleccionada;
             }
            if (seleccionadaMetra == "si")
            {
                ptbArmaOculta.Image = Properties.Resources.PPSh_41;
            }
           

           
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (puntos>=precioEscopeta && seleccionada=="no")
            {
                pictureBox9.BackColor = Color.Gold;
                label6.BackColor = Color.Gold;
                labelPrecioEscopeta.BackColor = Color.Gold;
                pictureBox9.Enabled = true;

            }
            if (puntos>=precioMetra && seleccionadaMetra=="no")
            {
                ptbArmaOculta.BackColor = Color.Gold;
                labelPrecioMetra.BackColor = Color.Gold;
                labelArmaOculta.BackColor = Color.Gold;
                ptbArmaOculta.Enabled = true;
            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            if (disparos==0)
            {
                bala1.Visible = false;
                bala2.Visible = false;
                bala3.Visible = false;
                bala4.Visible = false;
                bala5.Visible = false;
                bala6.Visible = false;
            }
            arma = 1;
            balasEscopeta = balasEscopeta + disparosEscopeta;
            labelBalasEscopeta.Text = balasEscopeta.ToString();
            disparosEscopeta = 0;
            if (balasPistola != 0)
            {
                recargarPistola();
                bala1.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
                bala2.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
                bala3.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
                bala4.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
                bala5.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;
                bala6.Image = JuegoFeriaADSI.Properties.Resources.sauvestre_fip_30_06_springfieldlourde_battue;

            }
            if (seleccionadaMetra=="si" )
            {
                ptbArmaOculta.Image = Properties.Resources.PPSh_41;

            } if (seleccionada=="si")
            {
                pictureBox9.Image = Properties.Resources.escopeta;

            }
            pictureBox8.Image = Properties.Resources.pistolaSeleccionada;
            label7.Visible = true;
            label7.Text = "" + balasPistola;
            
        }

        private void labelPrecioBalasPistola_Click(object sender, EventArgs e)
        {
            if (puntos>=precioBalasPistola)
            {
                balasPistola = balasPistola + 6;
                puntos = puntos - precioBalasPistola;
                label7.Text = "" + balasPistola;
                labelPuntos.Text="$"+puntos;
            }
         }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            arma = 3;
            pictureBox10.Visible = true;
            label5.Visible = true;
            label8.Visible = true;
            seleccionadaMetra = "si";
            label8.Text = "x" + disparosMetra;
            balasMetra = 6;
            if (disparosMetra != 0)
            {
                recargarMetralleta();
            }

            if (compradaMetra!=true)
            {
                if (puntos >= precioMetra)
                {
                    arma = 3;
                    puntos = puntos - precioMetra;
                    labelPuntos.Text = "$" + puntos;
                    pictureBox8.Image = Properties.Resources.pistola;
                    ptbArmaOculta.BackColor = Color.Transparent;
                    ptbArmaOculta.Image = Properties.Resources.PPSh_41Seleccionada;
                    labelArmaOculta.Visible = false;
                    labelPrecioMetra.Visible = false;
                    label8.Visible = true;
                    compradaMetra=true;
                    label8.Text = "x" + disparosMetra;

                }
            }
            else
            {
                pictureBox8.Image = Properties.Resources.pistola;
                ptbArmaOculta.Image = Properties.Resources.PPSh_41Seleccionada;


            }
            
            if (seleccionada == "si")
            {
                pictureBox9.Image = Properties.Resources.escopeta;

            }
        }

        private void labelPrecioBalasEscopeta_Click(object sender, EventArgs e)
        {
            if (puntos >= precioBalasEscopeta)
            {
                balasEscopeta = balasEscopeta + 4;
                puntos = puntos - precioBalasEscopeta;
                labelBalasEscopeta.Text = "" + balasEscopeta;
                labelPuntos.Text = "$" + puntos;
            }
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            if (puntos >= precioBalasMetra)
            {
                disparosMetra = disparosMetra + 26;
                puntos = puntos - precioBalasMetra;
                label8.Text = "x" + disparosMetra;
                labelPuntos.Text = "$" + puntos;
            }
        }

        private void valorSangre_Click(object sender, EventArgs e)
        {
            if (puntos>=valorSangre50)
            {
                axWindowsMediaPlayer5.URL = ruta+"monedas.mp3";

                puntos = puntos - valorSangre50;
                labelPuntos.Text = "$" + puntos;
                sangre = sangre + 30;
                progressBar1.Value = sangre;
            }
            
        }

        private void sangreCompleta_Click(object sender, EventArgs e)
        {
            if (puntos>=valorSangreCompleta)
            {
                axWindowsMediaPlayer5.URL = ruta+"monedas.mp3";

                puntos = puntos - valorSangreCompleta;
                labelPuntos.Text = "$" + puntos;
                sangre = 100;
                progressBar1.Value = sangre;
            }
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (puntos >= precioBalasPistola)
            {
                balasPistola = balasPistola + 6;
                puntos = puntos - precioBalasPistola;
                label7.Text = "" + balasPistola;
                labelPuntos.Text = "$" + puntos;
                axWindowsMediaPlayer5.URL=ruta+"monedas.mp3";
                
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (puntos >= precioBalasEscopeta)
            {
                balasEscopeta = balasEscopeta + 4;
                puntos = puntos - precioBalasEscopeta;
                labelBalasEscopeta.Text = "" + balasEscopeta;
                labelPuntos.Text = "$" + puntos;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (puntos >= valorSangre50)
            {
                axWindowsMediaPlayer5.URL = ruta+"monedas.mp3";
                puntos = puntos - valorSangre50;
                labelPuntos.Text = "$" + puntos;
                sangre = sangre + 30;
                progressBar1.Value = sangre;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            if (puntos >= valorSangreCompleta)
            {
                axWindowsMediaPlayer5.URL = ruta+"monedas.mp3";

                puntos = puntos - valorSangreCompleta;
                labelPuntos.Text = "$" + puntos;
                sangre = 100;
                progressBar1.Value = sangre;
            }
        }

       

        private void label5_Click(object sender, EventArgs e)
        {
            if (puntos >=precioBalasMetra)
            {
                disparosMetra = disparosMetra + 26;
                puntos = puntos - precioBalasMetra;
                label8.Text = "x" + disparosMetra;
                labelPuntos.Text = "$" + puntos;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }

       


        

       

       
        

   

        
        

    }

