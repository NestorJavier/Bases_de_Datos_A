using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorBDA
{
    [Serializable]

    public class Atributo
    {
        private string nombre;
        private string NombreExterno = "";
        private string sTipo;
        private string sTipoIndice;
        private string sNombreTabla;
        private int iTamaño;

        public Atributo(string nombre, string sTipo, string sTipoIndice, int iTamaño, string nombreExterno)
        {
            this.nombre = nombre;
            this.sTipo = sTipo;
            this.sTipoIndice = sTipoIndice;
            this.iTamaño = iTamaño;
            this.NombreExterno = nombreExterno;
        }

        public Atributo(string nombre, string sTipo, string sTipoIndice, int iTamaño)
        {
            this.nombre = nombre;
            this.sTipo = sTipo;
            this.sTipoIndice = sTipoIndice;
            this.iTamaño = iTamaño;
        }

        public Atributo()
        {

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string NombreExt
        {
            get { return NombreExterno; }
            set { NombreExterno = value; }
        }

        public string Tipo
        {
            get { return sTipo; }
            set { sTipo = value; }
        }
        public string TipoIndice
        {
            get { return sTipoIndice; }
            set { sTipoIndice = value; }
        }
        public int Longitud
        {
            get { return iTamaño; }
            set { iTamaño = value; }
        }

    }
}