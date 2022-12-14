using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista_Doblemente_Enlazada_Circular_N_1
{
    struct NodoAsig
    {
        // Declaramos los datos que seran la informacion que tendra el nodo
      


        public string Nombre;
        public int Numero;
    }
     
    internal class TNodo : TListaDobleCircular
    {
        public NodoAsig Informacion; // Variable que almacenara los datos de la lista

        public TNodo()
        {
        }

        public TNodo(String nombre, int nro): base()
        {
            Informacion.Nombre = nombre;
            Informacion.Numero = nro;
        }

        public int Date { get; internal set; }

        public string DameNombre()
        {
            return Informacion.Nombre;
        }

        public int DameNumero()
        {
            return Informacion.Numero;
        }
    }

    class ListaAsig : TLista
    {
        public ListaAsig() : base() { }

        // Creamos una lista 
        public void CrearLista(string n, int nro)
        {
            Insertar(new TNodo(n, nro));
        }
        public void CrearLista2(string n, int nro)
        {
            insertarMedio(new TNodo(n, nro));
        }
     
        public TListaDobleCircular Sucessor(string n)
        {
            return GetProxCursor();
        }
        
        public TListaDobleCircular AnteCessor(string n)
        {
            return GetAnteriorCursor();
        }


        public bool EliminarLista(string n)
        {
            Eliminar();
            return true;
        }

        public bool BuscarAsignado(string nombre)
        {
            bool buscar = false;
            TListaDobleCircular p;
            p = Primero;

            while(p!=null && buscar == false)
            {
                if (((TNodo)p).DameNombre().Equals(nombre))
                    buscar = true;
                else
                    p = p.EnlaceSiguiente;
            }
            if (buscar)
                Cursor = p;
            return buscar;
        }



    

            
        

    }

}
