using System.Drawing;

namespace PathFinder
{
    public class Space
    {
        /*
         * La numeración comienza de la esquina superior izquierda de la pantalla
         * Se incrementa la columna hasta llegar al fin de la forma
         * Despues se incrementa la fila y se establece la columna a 0
         */

        // Ubicación del espacio <fila,columna>
        public int fila { get; set; }
        public int columna { get; set; }

        // Coordenadas
        public int x1,x2;
        public int y1,y2;

        // ¿La forma está en uso?
        public bool occupided { get; set; }

        // Rectangulo que se usa para dibujarse
        public Rectangle r { get; set; }

        public int value = -1;

        public Space()
        {
            occupided = false;
            r = new Rectangle();
            fila = columna = x1 = x2 = y1 = y2 = -1;
        }

        public Space(int fila, int columna, int x, int y)
        {
            occupided = false;
            this.fila = fila;
            this.columna = columna;
            r = new Rectangle(x, y, Matrix.DEFAULT_SPACE_SIZE, Matrix.DEFAULT_SPACE_SIZE);
            x1 = x;
            x2 = x + Matrix.DEFAULT_SPACE_SIZE;
            y1 = y;
            y2 = y + Matrix.DEFAULT_SPACE_SIZE;
        }

        /// <summary>
        /// Si el espacio está en uso lo marca como disponible y lo borra de pantalla
        /// Visceversa
        /// </summary>
        public void ToggleUsed()
        {
            //if (!occupided)
            //{
            //    Form1.drawer.dibujar(this);
            //}
            //else
            //{ Form1.drawer.desdibujar(this); }
            occupided = !occupided;
            drawMe();
        }

        public void drawMe()
        {
            if (occupided)
            {
                Form1.drawer.dibujar(this);
                Form1.drawer.drawText(value.ToString(), this);
            }
            else
            { Form1.drawer.desdibujar(this); }
        }


    }
}
