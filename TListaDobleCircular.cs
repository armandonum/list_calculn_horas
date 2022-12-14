using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista_Doblemente_Enlazada_Circular_N_1
{
    internal class TListaDobleCircular
    {
        // Una lista doblemente enlazada debe tener dos enlaces en sus nodos
        public TListaDobleCircular EnlaceSiguiente;
        public TListaDobleCircular EnlaceAnterior;


        // Los enlaces tendran primero valor de null
        public TListaDobleCircular()
        {
            EnlaceSiguiente = null;
            EnlaceAnterior = null;
        }
    }

    class TLista
    {
        // Operacione a realizar 
        public TListaDobleCircular Primero;  //Es para ver a quiene estamos apuntando primero de la lista
        public TListaDobleCircular Ultimo;  // El ultimo elemento que  estamos insertando
        public TListaDobleCircular Cursor;  // Le cursor sera para ver a quien estamos apuntandp o eligiendo
        public TListaDobleCircular Nuevo;

        //Inicializamos los valores en el constructor
        public TLista()
        {
            // Declaramos las operaciones en null por donde van a iniciar
            Primero = null;
            Ultimo = null;
            Cursor = null;
            Nuevo = null;
        }

        // Inicializar operaciones despues de cerrar el programa en null
        public void Inicializar()
        {
            Primero = null;
            Ultimo = null;
            Cursor = null;
            Nuevo = null;
        }

        // Vemos si la lista esta vacia
        public bool Vacia()
        {
            if (Primero == null && Ultimo == null)
                return true;
            else
                return false;
        }

        // Insertar a la lista en caso de estar vacia o no
        public void Insertar(TListaDobleCircular nodo)
        {
            if (Vacia())
            {
                nodo.EnlaceSiguiente = nodo;
                nodo.EnlaceAnterior = nodo;
                Primero = nodo;
                Ultimo = nodo;
                Cursor = nodo;
                Nuevo = nodo;
            }
            else
            {
                Nuevo = nodo;
                Ultimo.EnlaceSiguiente = Nuevo;
                Nuevo.EnlaceAnterior = Ultimo;
                Ultimo = Nuevo;
                Cursor = Nuevo;
            }
            nodo.EnlaceSiguiente = Primero;
            Primero.EnlaceAnterior = Ultimo;
        }

        public void insertarMedio(TListaDobleCircular nodo)
        {
            if (Vacia())
            {
                Primero = nodo;
                Cursor = nodo;
                Ultimo = nodo;
                nodo.EnlaceAnterior = nodo;
                nodo.EnlaceSiguiente = nodo;

            }
            else
            {
                TListaDobleCircular aux1;
                TListaDobleCircular aux2;
                aux1 = GetAnteriorCursor();
                aux2 = GetProxCursor();
                Ultimo.EnlaceSiguiente = nodo;
                Ultimo = nodo;
                Cursor = nodo;
                Ultimo.EnlaceAnterior = aux1;
                Ultimo.EnlaceSiguiente = aux2;
            }
          

        }





        public TListaDobleCircular EliminarPrimero()
        {
            if (Vacia())
                return null;
            else
            {
                if (Primero == Ultimo)
                    Inicializar();
                else
                {
                    if (Cursor == Primero)
                    {
                        Cursor = Primero.EnlaceSiguiente;
                        Primero = Primero.EnlaceSiguiente;
                        Primero.EnlaceAnterior = Ultimo;
                        Ultimo.EnlaceSiguiente = Primero;
                    }
                }
                return Primero;
            }
        }

        // Funcion eliminar lista en cualquier posicion
        public TListaDobleCircular Eliminar()
        {
            TListaDobleCircular pAux;
            if (Cursor == null)
                return null;
            else
            {
                if (Cursor == Primero)
                    return EliminarPrimero();
                else
                {
                    //pAux = GetAnteriorCursor();
                    pAux = Cursor.EnlaceAnterior;
                    pAux.EnlaceSiguiente = Cursor.EnlaceSiguiente;
                    if (Cursor == Ultimo)
                    {
                        Ultimo = pAux;
                        Cursor = pAux.EnlaceSiguiente;
                    }
                    // Ultimo = pAux;
                    //Cursor = pAux.EnlaceSiguiente.EnlaceAnterior;
                    Cursor.EnlaceSiguiente.EnlaceAnterior = pAux;
                    return Cursor;
                }
            }
        }



        public TListaDobleCircular GetPrimero()
        {
            return Primero;
        }

        public TListaDobleCircular GetUltimo()
        {
            return Ultimo;
        }

        public TListaDobleCircular GetCursor()
        {
            return Cursor;
        }

        public TListaDobleCircular GetProxCursor()
        {
            if (Cursor != null)
            {
                if (Cursor == Ultimo)
                    Cursor.EnlaceSiguiente = Primero;
                return Cursor.EnlaceSiguiente;
            }
            else
                return null;
        }

        public TListaDobleCircular GetAnteriorCursor()
        {
            if (Cursor != null)
            {
                if (Cursor == Primero)
                    Cursor.EnlaceAnterior = Ultimo;
                return Cursor.EnlaceAnterior;
            }
            else
                return null;
        }

        public void SetCursor(TListaDobleCircular p)
        {
            Cursor = p;
        }

        public string Mostrar()
        {
            string vLista = "";
            Cursor = Primero;

            while (Cursor.EnlaceSiguiente != null)
            {
                vLista += Cursor.ToString() + Environment.NewLine;
                Cursor = Cursor.EnlaceSiguiente;
            }
            return vLista;
        }
    }
}
