using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorBDA
{
    [Serializable]

    public class RegistroAtributo
    {
        private string registro = "null";
        private Atributo atributo;
        
        public RegistroAtributo(string registro, Atributo atributo)
        {
            this.registro = registro;
            this.atributo = atributo;
        }

        public RegistroAtributo(Atributo atributo)
        {
            this.atributo = atributo;
        }

        public RegistroAtributo(string registro)
        {
            this.registro = registro;
        }

        public string Reg
        {
            get { return registro; }
            set { registro  = value; }
        }
        public Atributo Atr
        {
            get { return atributo; }
            set { atributo = value; }
        }
    }
}
