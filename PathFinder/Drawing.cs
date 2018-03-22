using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinder
{
    public class Drawing
    {
        // Tamaño default de pluma
        public static int DefaultSize = 10;

        // Objeto que se usará para dibujar
        public static Graphics g;

        // Pluma color default para objetos en pantalla
        //public static Pen Color = new Pen(System.Drawing.Color.Red,DefaultSize);
        Brush color = new SolidBrush(System.Drawing.Color.Red);
        Brush text_color = new SolidBrush(System.Drawing.Color.Yellow);

        private Font font = new Font(new FontFamily("Times New Roman"), 20, FontStyle.Regular, GraphicsUnit.Pixel);


        // Pluma usada para borrar el objeto dibujado, debe ser del mismo color del fondo de la forma
        //public static Pen Black = new Pen(System.Drawing.Color.Black,DefaultSize);
        Brush black = new SolidBrush(System.Drawing.Color.Black);

        // Forma sobre la que se está trabajando
        private Form f;

        /// <summary>
        /// Constructor Drawing
        /// La clase drawing se encarga de dibujar o borrar los elementos
        /// </summary>
        /// <param name="f">Forma sobre la que se trabaja</param>
        public Drawing(Form f)
        {
            this.f = f;
            g = f.CreateGraphics();
        }

        /// <summary>
        /// Dibuja en pantalla
        /// </summary>
        /// <param name="r">Rectangulo</param>
        public void dibujar(Rectangle r)
        {
            //g.DrawRectangle(Color,r);
            g.FillRectangle(color, r);
        }

        /// <summary>
        /// Dibuja en pantalla
        /// </summary>
        /// <param name="s">espacio a dibujar</param>
        public void dibujar(Space s)
        {
            dibujar(s.r);
        }

        /// <summary>
        /// Borra en pantalla
        /// </summary>
        /// <param name="r">Rectangulo a borrar</param>
        public void desdibujar(Rectangle r)
        {
            g.FillRectangle(black, r);
        }

        /// <summary>
        /// Borra en pantalla
        /// </summary>
        /// <param name="s">Espacio a borrar</param>
        public void desdibujar(Space s)
        {
            desdibujar(s.r);
        }

        public void drawText(string t, Space s)
        {
            int center = 0;// Matrix.DEFAULT_SPACE_SIZE / 4;
            g.DrawString(t, font, text_color, s.x1 + center,s.y1 + center);
        }

    }
}
