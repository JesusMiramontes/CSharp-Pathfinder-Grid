using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinder
{
    public partial class Form1 : Form
    {
        public static Matrix matriz;
        public static Drawing drawer;
        public bool tracking = false;
        public int fil, col = -1;
        public DateTime init_time = DateTime.MinValue;
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

            if ((e.Button & MouseButtons.Left) != 0 && (col != last_toggled_col || fil != last_toggled_fil) )// && (col != last_toggled_col) && (fil != last_toggled_fil))// DateTime.Now.Subtract(init_time).Milliseconds >= 300) // DateTime.Now.Subtract(init_time).Milliseconds >= 200) //&& last_toggled_col != col && last_toggled_fil != fil)
            {
                init_time = DateTime.Now;
                matriz[fil, col].ToggleUsed();
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

        private void Form1_Click_1(object sender, EventArgs e)
        {
            if (tracking)
            {
                matriz[fil, col].ToggleUsed();
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}
