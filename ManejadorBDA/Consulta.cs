using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorBDA
{
    public partial class Consulta : Form
    {
        private List<Tabla> auxtablas = null;
        private List<string> CadenasReservadas = new List<string> { "SELECT", "FROM", "*" ,"WHERE"};
        // 4 es el numero minimo de elementos que debe de almacenar el split de la consulta
        //SELECT * FROM Tabla;
        //   1   2  3     4
        private int inumeroMinimo = 4;
        Tabla auxt = null;
        public Consulta(List<Tabla> t)
        {
            InitializeComponent();

            this.auxtablas = t;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword("SELECT", Color.Blue, 0);
            this.CheckKeyword("FROM", Color.Blue, 0);
            this.CheckKeyword("WHERE", Color.Blue, 0);
            this.CheckKeyword("*", Color.Blue, 0);
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
        }


        private void btEjecutar_Click(object sender, EventArgs e)
        {
            if (auxtablas != null)
            {
                List<string> splitConsulta = (richTextBox1.Text).Split().ToList();

                if (splitConsulta.Count < 4)
                    MessageBox.Show("No es posible interpretar el texto de entrada");
                else
                {
                    if (splitConsulta.Contains("SELECT") && splitConsulta.Contains("FROM"))
                    {
                        int SELECTIndex = splitConsulta.IndexOf("SELECT");
                        int FROMIndex = splitConsulta.IndexOf("FROM");
                        /***********Falta validar que la tabla exista**********/
                        /**
                         * Verifica que la palabra FROM             Verifica que exista almenos una palabra 
                         * no sea la ultima de la lista             entre el SELECT y el FROM           
                         */
                        if (FROMIndex < (splitConsulta.Count - 1) && SELECTIndex < (FROMIndex - 1))
                        {
                            /**
                             * Verifica que la palabra que existe           Verifica el numero de palabras 
                             *  despues de FROM sea un *                    en el split sea cuatro para ejecutar 
                             *                                              la consulta a todas las tablas
                             */
                            if (splitConsulta[SELECTIndex + 1] == "*" && splitConsulta.Count == inumeroMinimo)
                            {
                                /**
                                 *                           Obtiene el nombre de la tabla que se ha de consultar
                                 *                           la cual se encuentra almacenada en la ultima posición
                                 *                           del Split
                                 */
                                auxt = auxtablas.FirstOrDefault(p => p.Nombre == splitConsulta[inumeroMinimo - 1]);

                                if (auxt != null)
                                {
                                    GeneraColumnas();
                                    actualizaDataGridRegistros();
                                    auxt = null;
                                }
                                else
                                    MessageBox.Show("La Tabla que desea consultar no existe");
                            }
                            else/**Si no se cumple la condición de arriba hay que verificar cuales son las plabaras que existen entre SELECT y FROM*/
                            {
                                if (splitConsulta.Contains("WHERE"))
                                {
                                    int WHEREIndex = splitConsulta.IndexOf("WHERE");

                                    if (splitConsulta.Count > WHEREIndex + 1)
                                    {
                                        string atributoConsulta = splitConsulta[WHEREIndex + 1];
                                        /** La variable "tab" contiene el nombre de la tabla a consultar */

                                        string tab = splitConsulta[FROMIndex + 1];
                                        auxt = auxtablas.FirstOrDefault(p => p.Nombre == tab);

                                        //Verificar que el atributo exista
                                        if (auxt != null)
                                        {
                                            if (existeAtributo(atributoConsulta))
                                            {
                                                string signo = null;
                                                signo = splitConsulta.FirstOrDefault(p => p == "=");

                                                if (signo != null)
                                                {
                                                    int SIGNOIndex = splitConsulta.IndexOf(signo);
                                                    if (SIGNOIndex > WHEREIndex)
                                                    {
                                                        if (splitConsulta.Count - 1 > SIGNOIndex)
                                                        {
                                                            //Dato Condicional
                                                            string sDato = splitConsulta[splitConsulta.Count - 1];

                                                            /////////////////////////////////////
                                                            List<string> lCampos;

                                                            /**                 
                                                             *                  Obtiene la lista de atributos que se han de consultar
                                                             *                  Esto lo hace verificando que los valores que esta obteniendo
                                                             *                  son diferentes de las palabras reservadas "SELECT", "FROM" 
                                                             *                  y el nombre de la tabla.
                                                             **/
                                                            lCampos = splitConsulta.Where(p => p != "SELECT" && p != "FROM" && p != tab && p != "WHERE" && p != "=" && p != sDato).ToList();
                                                            if (lCampos.Contains(atributoConsulta))
                                                            {
                                                                int pos = lCampos.IndexOf(atributoConsulta);
                                                                lCampos.RemoveAt(pos);
                                                            }
                                                            /** 
                                                             *      Se verifica si todos los elementos dentro de la lista de campos (lCampos) realmente son 
                                                             *      atributos de "tab" la tabla que se ha de consultar.
                                                             */


                                                            bool existenCampos = false;
                                                            foreach (string value in lCampos)
                                                            {
                                                                existenCampos = existeAtributo(value);
                                                                if (!existenCampos)
                                                                    break;
                                                            }
                                                            if (existenCampos)
                                                            {
                                                                GeneraColumnas(lCampos);
                                                                actualizaDataGridRegistros(lCampos, sDato, atributoConsulta);
                                                                auxt = null;
                                                            }
                                                            else
                                                                MessageBox.Show("Alguno o algunos de los campos que desea Consultar no existen, verifique que esten correctamente escritos");
                                                            ///////////////////////////////////////

                                                        }
                                                        else
                                                            MessageBox.Show("No es posible interpretar el texto de entrada");
                                                    }
                                                    else
                                                        MessageBox.Show("No es posible interpretar el texto de entrada");

                                                }
                                                else
                                                    MessageBox.Show("No es posible interpretar el texto de entrada");
                                            }
                                            else
                                                MessageBox.Show("El atributo " + atributoConsulta + " no existe, verifique que este bien escrito");
                                        }
                                        else
                                            MessageBox.Show("La Tabla que desea consultar no existe");
                                    }
                                }
                                else
                                {
                                    List<string> lCampos;
                                    /** La variable "tab" contiene el nombre de la tabla a consultar */
                                    string tab = splitConsulta[splitConsulta.Count - 1];
                                    /**                 
                                     *                  Obtiene la lista de atributos que se han de consultar
                                     *                  Esto lo hace verificando que los valores que esta obteniendo
                                     *                  son diferentes de las palabras reservadas "SELECT", "FROM" 
                                     *                  y el nombre de la tabla.
                                     **/
                                    lCampos = splitConsulta.Where(p => p != "SELECT" && p != "FROM" && p != tab).ToList();

                                    /** 
                                     *      Se verifica si todos los elementos dentro de la lista de campos (lCampos) realmente son 
                                     *      atributos de "tab" la tabla que se ha de consultar.
                                     */

                                    auxt = auxtablas.FirstOrDefault(p => p.Nombre == tab);

                                    if (auxt != null)
                                    {
                                        bool existenCampos = false;
                                        foreach (string value in lCampos)
                                        {
                                            existenCampos = existeAtributo(value);
                                            if (!existenCampos)
                                                break;
                                        }
                                        if (existenCampos)
                                        {
                                            GeneraColumnas(lCampos);
                                            actualizaDataGridRegistros(lCampos);
                                            auxt = null;
                                        }
                                        else
                                            MessageBox.Show("Alguno o algunos de los campos que desea Consultar no existen, verifique que esten correctamente escritos");
                                    }
                                    else
                                        MessageBox.Show("La Tabla que desea consultar no existe");
                                }
                            }
                        }
                        else
                            MessageBox.Show("No es posible interpretar el texto de entrada");
                    }
                }
            }
            else
                MessageBox.Show("No existe una base de datos la cual consultar");
        }
        private bool existeAtributo(string nomAtributo)
        {
            bool existenCampos = false;

            Atributo auxAt = null;
            auxAt = auxt.LAtributo.FirstOrDefault(p => p.Nombre == nomAtributo || p.NombreExt == nomAtributo);
            if (auxAt != null)
                existenCampos = true;

            return existenCampos;
        }

        /// <summary>
        private void GeneraColumnas()
        {
            dgConsultas.Columns.Clear();
            if (auxt != null)
            {
                List<Atributo> listAtributos = auxt.LAtributo;

                foreach (Atributo value in listAtributos)
                {
                    dgConsultas.Columns.Add(value.Nombre, value.Nombre);
                }
            }
            else
                MessageBox.Show("Error");
        }

        private void GeneraColumnas(List<string> lCamp)
        {
            dgConsultas.Columns.Clear();
            if (auxt != null)
            {
                foreach (string value in lCamp)
                {
                    dgConsultas.Columns.Add(value, value);
                }
            }
            else
                MessageBox.Show("Error");
        }


        /// </summary>


        //////////////
        private void actualizaDataGridRegistros(List<string> lCamp)
        {
            dgConsultas.Rows.Clear();

            if (auxt.Registros.Count != 0)
            {
                int nReg = auxt.Registros.Count;
                for (int i = 0; i < nReg; i++)
                {
                    int nCampos = lCamp.Count;
                    int nCamposReg = auxt.Registros[i].Count;
                    dgConsultas.Rows.Add();
                    int j2 = 0;
                    for (int j = 0; j < nCampos; j++)
                    {

                        RegistroAtributo auxr = null;
                        
                        auxr = auxt.Registros[i].FirstOrDefault(p => p.Atr.Nombre == lCamp[j] || p.Atr.NombreExt == lCamp[j]);
                        if (auxr != null)
                        {
                            dgConsultas.Rows[i].Cells[j].Value = auxr.Reg;
                        }
                        else
                            dgConsultas.Rows[i].Cells[j].Value = "null";
                    }
                }
            }
        }

        private void actualizaDataGridRegistros(List<string> lCamp, string sDatoCondición, string sCampo)
        {
            dgConsultas.Rows.Clear();

            if (auxt.Registros.Count != 0)
            {
                int l = 0;
                int nReg = auxt.Registros.Count;
                for (int i = 0; i < nReg; i++)
                {
                    int nCampos = lCamp.Count;
                    int nCamposReg = auxt.Registros[i].Count;
                    RegistroAtributo Dato = null;
                    Dato = auxt.Registros[i].FirstOrDefault(p => p.Atr.Nombre == sCampo && p.Reg == sDatoCondición);
                    
                    if (Dato != null)
                    {
                        dgConsultas.Rows.Add();
                        int j2 = 0;
                        for (int j = 0; j < nCampos; j++)
                        {

                            RegistroAtributo auxr = null;
                            auxr = auxt.Registros[i].FirstOrDefault(p => p.Atr.Nombre == lCamp[j] || p.Atr.NombreExt == lCamp[j]);
                            if (auxr != null)
                            {
                                dgConsultas.Rows[l].Cells[j].Value = auxr.Reg;
                            }
                            else
                                dgConsultas.Rows[l].Cells[j].Value = "null";

                        }
                        l++;
                    }
                }
            }
        }
        //SELECT IdVenta Total FechaVenta FROM Venta WHERE IdEmpleado = 7

        private void actualizaDataGridRegistros()
        {
            dgConsultas.Rows.Clear();

            if (auxt.Registros.Count != 0)
            {
                int nReg = auxt.Registros.Count;
                for (int i = 0; i < nReg; i++)
                {
                    int nCampos = auxt.LAtributo.Count;
                    int nCamposReg = auxt.Registros[i].Count;
                    dgConsultas.Rows.Add();
                    int j2 = 0;
                    for (int j = 0; j < nCampos; j++)
                    {
                        if (j2 < nCamposReg && (dgConsultas.Columns[j].Name == auxt.Registros[i][j2].Atr.Nombre || dgConsultas.Columns[j].Name == auxt.Registros[i][j2].Atr.NombreExt))
                        {
                            dgConsultas.Rows[i].Cells[j].Value = auxt.Registros[i][j2].Reg;
                            j2++;
                        }
                        else
                            dgConsultas.Rows[i].Cells[j].Value = "null";
                    }
                }
            }
        }
    }
}
