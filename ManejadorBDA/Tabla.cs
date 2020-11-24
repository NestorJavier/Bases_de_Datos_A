using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorBDA
{
    [Serializable]

    public class Tabla
    {
        private string nombre;
        private string sRuta;
        private List<Atributo> listAtributo = new List<Atributo>();
        private List<string> ClavesPrimarias = new List<string>();
        private List<string> ClavesSecundarias = new List<string>();
        private List<List<RegistroAtributo>> registros = new List<List<RegistroAtributo>>();
        private bool bandPK = false;
        private bool bandReg = false;

        public Tabla(string nombre, string sRuta)
        {
            this.nombre = nombre;
            this.sRuta = sRuta;
        }

        public Tabla()
        {

        }

        public List<string> CPrimarias
        {
            get { return ClavesPrimarias; }
            set { ClavesPrimarias = value; }
        }

        public List<string> CSecundarias
        {
            get { return ClavesSecundarias; }
            set { ClavesSecundarias = value; }
        }

        public List<Atributo> LAtributo
        {
            get { return listAtributo; }
            set { listAtributo = value; }
        }

        public List<List<RegistroAtributo>> Registros
        {
            get { return registros; }
            set { registros = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Ruta
        {
            get { return sRuta; }
            set { sRuta = value; }
        }

        public bool BPK
        {
            get { return bandPK; }
            set { bandPK = value; }
        }

        public bool BandReg
        {
            get { return bandReg; }
            set { bandReg = value; }
        }

        public int GuardaTabla()
        {
            string nom = sRuta + "\\" + nombre + ".tab";
            try
            {
                using (Stream st = File.Open(nom, FileMode.Create))
                {
                    var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binfor.Serialize(st, this);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        public int ActualizaTabla()
        {
            string nom = sRuta + "\\" + nombre + ".tab";
            try
            {
                using (Stream st = File.Open(nom, FileMode.OpenOrCreate))
                {
                    var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binfor.Serialize(st, this);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
    }
}
