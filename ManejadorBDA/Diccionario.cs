using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorBDA
{
    [Serializable]

    class Diccionario
    {
        //ruta del archivo
        private string fileNameDD;
        //ruta del directorio
        private string sRuta;
        //Nombre de la BD
        private string sNombreBD = "";
        private List<string> lNombresTablas = new List<string>();

        public string NombreBD
        {
            get { return sNombreBD; }
            set { sNombreBD = value; }
        }

        public string FileName
        {
            get { return fileNameDD; }
            set { fileNameDD = value; }
        }

        public string Ruta
        {
            get { return sRuta; }
            set { sRuta = value; }
        }

        public List<string> LNombresTablas
        {
            get { return lNombresTablas; }
            set { lNombresTablas = value; }
        }

        public int NuevoDiccionario()
        {
            try
            {
                using (System.Windows.Forms.SaveFileDialog dialogo = new System.Windows.Forms.SaveFileDialog())
                {
                    dialogo.Title = "Guardar Como";

                    if (dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Directory.CreateDirectory(dialogo.FileName);
                        sRuta = dialogo.FileName;
                        sNombreBD = Path.GetFileName(dialogo.FileName);
                        fileNameDD = dialogo.FileName + "\\" + sNombreBD + ".dd";

                        using (Stream st = File.Open(fileNameDD, FileMode.Create))
                        {
                            var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            binfor.Serialize(st, this);
                            return 0;
                        }
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        public int ActualizaDiccionario()
        {
            try
            {
                using (Stream st = File.Open(fileNameDD, FileMode.OpenOrCreate))
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
