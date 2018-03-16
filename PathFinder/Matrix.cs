using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PathFinder
{
    public class Matrix
    {
        // Lista que almacena la matriz.
        // Solo un space debe hacer uso de esta propiedad.
        public List<Space> spaces;

        // Recuento de cuantas filas x columnas caben en la forma actual
        public int filas, columnas;

        // Valores por defecto de la pluma.
        // Modificar aquí para alterar el tamaño de los cuadros y el espaciado.
        public const int DEFAULT_SPACE_SIZE = 50;
        public const int DEFAULT_SPACE_SPACING = 10;

        public Form form;

        /// <summary>
        /// Indizador de la lista de espacios.
        /// Regresa el Space buscado
        /// </summary>
        /// <param name="fil">Fila buscada</param>
        /// <param name="col">Columna buscada</param>
        /// <returns></returns>
        public Space this[int fil, int col]
        {
            get
            {
                try
                {
                    return spaces[(columnas * fil) + col];
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public Matrix(Form f)
        {
            filas = columnas = 0;
            spaces = new List<Space>();
            form = f;
        }

        /// <summary>
        /// Crea la matriz de espacios.
        /// Determina las posiciones x,y de cada espacio.
        /// Agrega los espacios a la lista.
        /// </summary>
        /// <param name="f">Forma sobre la que se trabaja</param>
        public void CreateMatrix()
        {
            int x = 10;
            int y = 10;
            int fila = 0;
            int columna = 0;

            while (x <= form.Width && y <= form.Height)
            {
                spaces.Add(new Space(fila, columna, x, y));
                if (x + DEFAULT_SPACE_SPACING + DEFAULT_SPACE_SPACING + DEFAULT_SPACE_SIZE + 22 < form.Width)
                {
                    x += DEFAULT_SPACE_SPACING + DEFAULT_SPACE_SIZE;
                    columna++;
                    if (columnas < columna)
                        columnas = columna;
                }
                else if (y + DEFAULT_SPACE_SPACING + DEFAULT_SPACE_SPACING + DEFAULT_SPACE_SIZE + 40 < form.Height)
                {
                    x = 10;
                    y += DEFAULT_SPACE_SPACING + DEFAULT_SPACE_SIZE;
                    columna = 0;
                    fila++;
                    if (filas < fila)
                        filas = fila;
                }
                else
                {
                    break;
                }
            }

            filas++;
            columnas++;
        }

        public bool MoveDown(Space space)
        {
            Space pivote = this[space.fila + 1, space.columna];
            if (pivote != null && !pivote.occupided)
            {
                space.ToggleUsed();
                this[space.fila + 1, space.columna].ToggleUsed();
                return true;
            }
            return false;
        }

        public bool MoveLR(Space space, char direction)
        {
            int izq_der;
            Space pivote = null;
            switch (direction)
            {
                case 'L':
                    izq_der = -1;
                    break;
                case 'R':
                    izq_der = 1;
                    break;
                default:
                    return false;
            }

            if ((space.columna + izq_der < columnas && space.columna + izq_der >= 0))
                pivote = this[space.fila, space.columna + izq_der];

            if (pivote != null && !pivote.occupided)
            {
                space.ToggleUsed();
                this[space.fila, space.columna + izq_der].ToggleUsed();
                return true;
            }
            return false;
        }

        public int asignNextFreeOnLine(int line)
        {
            for (int i = 0; i < columnas; i++)
            {
                if (!this[line, i].occupided)
                {
                    this[line, i].ToggleUsed();
                    return spaces.IndexOf(this[line, i]);
                }
            }

            return -1;
        }

        public void updateDrawingState()
        {
            for (int col = 0; col < Form1.matriz.filas; col++)
            {
                for (int fil = 0; fil < Form1.matriz.columnas; fil++)
                {
                    Random rnd = new Random((int)DateTime.Now.Ticks);
                    if (rnd.Next(0, 2) == 0)
                    {
                        Form1.matriz[col, fil].ToggleUsed();
                    }

                    Form1.matriz[col, fil].drawMe();
                }
            }
        }
    }
}
