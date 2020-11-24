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
    public partial class Modifica_Atributo : Form
    {
        private List<Atributo> listaCampos = new List<Atributo>();
        private List<RegistroAtributo> registro = new List<RegistroAtributo>();
        private int i = 0;
        private int inumCampos;
        private int BandInsercionModificacion;// Esta bandera indica si se va a Insertar (0) un registro o se va a Modificar (1)

        public Modifica_Atributo(List<Atributo> l, int band)
        {
            InitializeComponent();
            this.listaCampos = l;
            this.inumCampos = listaCampos.Count;
            this.BandInsercionModificacion = band;

            if (BandInsercionModificacion == 1 && (listaCampos[i].TipoIndice == "Clave Primaria" || listaCampos[i].TipoIndice == "Clave Secundaria"))
            {
                i++;
            }
            if(listaCampos[i].TipoIndice=="Clave Foranea")
            {
                label.Text = listaCampos[i].NombreExt;
            }
            else
                label.Text = listaCampos[i].Nombre;

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                    //Boton Agregar
        private void button1_Click(object sender, EventArgs e)
        {
            if (i < inumCampos && tBoxReg.Text != "")
            {
                RegistroAtributo r = new RegistroAtributo(tBoxReg.Text, listaCampos[i]);
                registro.Add(r);
                i++;
                if (i < inumCampos)
                {
                    if (listaCampos[i].TipoIndice == "Clave Foranea")
                    {
                        label.Text = listaCampos[i].NombreExt;
                    }
                    else
                        label.Text = listaCampos[i].Nombre;
                }
                    
                
                if (i < inumCampos)
                    if (BandInsercionModificacion == 1 && (listaCampos[i].TipoIndice == "Clave Primaria" || listaCampos[i].TipoIndice == "Clave Secundaria"))
                        i++;

                if (i < inumCampos)
                {
                    if (listaCampos[i].TipoIndice == "Clave Foranea")
                    {
                        label.Text = listaCampos[i].NombreExt;
                    }
                    else
                        label.Text = listaCampos[i].Nombre;

                    tBoxReg.Text = "";
                }

                if (i == inumCampos)
                {
                    Aceptar.Visible = true;
                    button1.Visible = false;
                    tBoxReg.Visible = false;
                    label.Text = "Todos los campos han sido completados";
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Introdusca la información");
            }
                
        }

        private void tBoxReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (i < inumCampos)
            {
                if (listaCampos[i].Tipo == "Entero" || listaCampos[i].Tipo == "Flotante")
                    ValidaciónTextBoxs.onlyNumbers(e);
            }
        }

        public List<RegistroAtributo> Reg
        {
            get { return registro; }
            set { registro = value; }
        }
    }
}
