using System;
using System.Windows.Forms;

namespace PathFinder
{
    public partial class Form1 : Form
    {
        public static Matrix matriz;
        public static Drawing drawer;
        public bool tracking = false;
        public int fil, col = -1;
        public DateTime last_update = DateTime.MinValue;
        public int last_toggled_col = -1, last_toggled_fil = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matriz = new Matrix(this);
            drawer = new Drawing(matriz.form);
            matriz.CreateMatrix();
            matriz.updateDrawingState();
            Console.Out.WriteLine("");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tracking)
            {
                Space s = matriz.whereAmI(e.Location.X, e.Location.Y);
                fil = s.fila;
                col = s.columna;
                button2.Text = s.columna.ToString() + ", " + s.fila.ToString();
            }

            if ((e.Button & MouseButtons.Left) != 0 && (col != last_toggled_col || fil != last_toggled_fil) )// && (col != last_toggled_col) && (fil != last_toggled_fil))// DateTime.Now.Subtract(last_update).Milliseconds >= 300) // DateTime.Now.Subtract(last_update).Milliseconds >= 200) //&& last_toggled_col != col && last_toggled_fil != fil)
            {
                last_update = DateTime.Now;
                try
                {
                    matriz[fil, col].ToggleUsed();
                }
                catch (Exception)
                {

                    //throw;
                }
                last_toggled_col = col;
                last_toggled_fil = fil;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tracking = !tracking;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            matriz.updateDrawingState();
        }

        private void keep_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (matriz != null) //&& DateTime.Now.Subtract(last_update).Milliseconds >= 100)
            {
                matriz.updateDrawingState();
                last_update = DateTime.Now;
            }
        }

        private void Form1_Click_1(object sender, EventArgs e)
        {
            if (tracking)
            {
                matriz[fil, col].ToggleUsed();
            }
        }
    }
}
