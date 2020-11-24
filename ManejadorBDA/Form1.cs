/***********************************************************/
/*            Sistema Manejador de Bases de Datos           /
/*                                                          /
/*           Universidad Autonoma de San Luis Potosi        /
/*              Area de Ciencias de la Computación          /
/*                   Facultad de Ingenieria                 /
/*					   Bases de Datos A                     /
/*                                                          /
/*       Autor:  Méndez Gutiérrez Nestor Javier             /
/*                                                          /
/*       Fecha:         Agosto-Diciembre 2018               /
/*                                                          /
/*   Proyecto creado para la materia de Bases de Datos A    /
/*   Con el fin educativo de programar un sistema manejador /
/*    de Bases de Datos                                     /
/*                                                          /
/*                       Copyright(c)                       /
/***********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ManejadorBDA
{
    public partial class Form1 : Form
    {
        List<Tabla> lTablas = new List<Tabla>();
        List<string> listPKTablas = new List<string>();

        Tabla auxTab;
        Diccionario Dic = new Diccionario();
        bool band = false;
        string sNomTabla = "";
        string sNombreAtr = "";
        int iIndiceRegistro = -1;
        bool bndModfica = false;
        string sNombreTempAtr = "";



        public Form1()
        {
            InitializeComponent();
            ((Control)TabPageAtributos).Enabled = false;
        }

        private void nuevaBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int r = Dic.NuevoDiccionario();

            switch (r)
            {
                case 0:
                    {
                        MessageBox.Show("correcto");
                        labNombreBD.Text = Dic.NombreBD;
                        AgregaTabla.Enabled = true;
                        txtBAgrega.Enabled = true;
                        cmbTablas.Enabled = true;
                        eliminarBaseDeDatosActualToolStripMenuItem.Enabled = true;
                        modificarBaseDeDatosToolStripMenuItem.Enabled = true;
                    }
                    break;
                case 1:
                    MessageBox.Show("Se cancelo la operación");
                    break;
                case 2:
                    MessageBox.Show("Error");
                    break;
            }
        }

        private void AgregaTabla_Click(object sender, EventArgs e)
        {
            //Se Valida que el textbox no este vacio
            if (string.IsNullOrEmpty(txtBAgrega.Text))
                return;

            Dic.LNombresTablas.Add(txtBAgrega.Text);
            Dic.ActualizaDiccionario();
            Tabla auxTabla = new Tabla(txtBAgrega.Text, Dic.Ruta);
            auxTabla.GuardaTabla();
            lTablas.Add(auxTabla);
            cmbTablas.Items.Add(txtBAgrega.Text);
            txtBAgrega.Clear();
        }

        private void abrirBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (System.Windows.Forms.FolderBrowserDialog dialogo = new System.Windows.Forms.FolderBrowserDialog())
                {
                    dialogo.Description = "Abrir";

                    if (dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        DirectoryInfo di = new DirectoryInfo(dialogo.SelectedPath);

                        if (di.GetFiles("*.dd").Count() != 0)
                        {
                            string snom = di.GetFiles("*.dd")[0].FullName;
                            ((Control)TabPageAtributos).Enabled = true;
                            AgregaTabla.Enabled = true;
                            txtBAgrega.Enabled = true;
                            cmbTablas.Enabled = true;
                            eliminarBaseDeDatosActualToolStripMenuItem.Enabled = true;
                            modificarBaseDeDatosToolStripMenuItem.Enabled = true;

                            cmbTablas.Items.Clear();
                            lTablas = new List<Tabla>();
                            using (Stream st = File.Open(snom, FileMode.Open))
                            {
                                var binfor = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                                Dic = new Diccionario();
                                Dic = (Diccionario)binfor.Deserialize(st);
                                labNombreBD.Text = Dic.NombreBD;
                                Tabla auxTabla;
                                for (int i = 0; i < Dic.LNombresTablas.Count; i++)
                                {
                                    cmbTablas.Items.Add(Dic.LNombresTablas[i]);
                                    string PathTabla = Dic.Ruta + "\\" + Dic.LNombresTablas[i] + ".tab";
                                    using (Stream str = File.Open(PathTabla, FileMode.Open))
                                    {
                                        auxTabla = new Tabla();
                                        var binforTab = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                                        auxTabla = (Tabla)binforTab.Deserialize(str);
                                        lTablas.Add(auxTabla);
                                    }
                                }
                            }
                        }
                        else
                            MessageBox.Show("No existe la Base de Datos");
                    }
                    else
                        MessageBox.Show("Se Cancelo La Operación");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnAltaAtr_Click(object sender, EventArgs e)
        {
            bool b = true;
            if (!bndModfica)
            {
                borrarErrorProviders();
                if (validarCampos())
                {
                    if (cmbtipoIndice.Text == "Clave Primaria")
                    {
                        if (auxTab.BPK)
                        {
                            MessageBox.Show("No se puede guardar el atributo por que la tabla no puede contener mas de una clave primaria");
                            b = false;
                        }
                        else
                            auxTab.BPK = true;
                    }

                    if (b)
                    {
                        guardaAtributo();
                        txtBoxLong.Clear();
                        txtBoxLong.Focus();
                        txtBoxNomAtribut.Clear();
                        txtBoxNomAtribut.Focus();
                        cmbTipo.SelectedIndex = -1;
                        cmbtipoIndice.SelectedIndex = -1;
                        actualizaDataGridAtributos();
                    }
                }
            }
            actualizalistaPKTablas();
        }

        private void actualizalistaPKTablas()
        {
            cmbTablasPK.Items.Clear();

            for (int i = 0; i < lTablas.Count; i++)
            {
                if (lTablas[i].BPK == true)
                {
                    cmbTablasPK.Items.Add(lTablas[i].Nombre);
                }
            }

            if (cmbTablasPK.Items.Contains(sNomTabla))
            {
                cmbTablasPK.Items.Remove(sNomTabla);
            }
        }

        private void actualizaDataGridAtributos()
        {
            dgAtributos.Rows.Clear();
            //Nombre de la entidad seleccionada

            if (auxTab.LAtributo.Count != 0)
            {
                for (int i = 0; i < auxTab.LAtributo.Count; i++)
                {
                    if (auxTab.LAtributo[i].TipoIndice == "Clave Foranea")
                        dgAtributos.Rows.Add(auxTab.LAtributo[i].NombreExt, auxTab.LAtributo[i].Tipo, auxTab.LAtributo[i].TipoIndice, auxTab.LAtributo[i].Longitud);
                    else
                        dgAtributos.Rows.Add(auxTab.LAtributo[i].Nombre, auxTab.LAtributo[i].Tipo, auxTab.LAtributo[i].TipoIndice, auxTab.LAtributo[i].Longitud);
                }
            }
        }

        private void guardaAtributo()
        {
            Atributo auxAt = null;
            auxAt = auxTab.LAtributo.FirstOrDefault(p => p.Nombre == txtBoxNomAtribut.Text);
            if (auxAt == null)
            {
                if (txtBoxLong.Enabled)
                {
                    Atributo auxAtr = null;
                    if (cmbtipoIndice.Text == "Clave Foranea")
                    {
                        auxAtr = new Atributo(sNombreTempAtr, cmbTipo.Text, cmbtipoIndice.Text, Int32.Parse(txtBoxLong.Text), txtBoxNomAtribut.Text);
                    }
                    else
                    {
                        auxAtr = new Atributo(txtBoxNomAtribut.Text , cmbTipo.Text, cmbtipoIndice.Text, Int32.Parse(txtBoxLong.Text));
                    }
                    auxTab.LAtributo.Add(auxAtr);
                }
                else
                {
                    Atributo auxAtr = null;
                    if (cmbtipoIndice.Text == "Clave Foranea")
                    {
                        auxAtr = new Atributo(sNombreTempAtr, cmbTipo.Text, cmbtipoIndice.Text, 4, txtBoxNomAtribut.Text);
                    }
                    else
                    {
                        auxAtr = new Atributo(txtBoxNomAtribut.Text, cmbTipo.Text, cmbtipoIndice.Text, 4);
                    }
                    auxTab.LAtributo.Add(auxAtr);
                }
                auxTab.ActualizaTabla();
            }
            else
                MessageBox.Show("No se puede guardar dos atributos con el mismo nombre");
        }

        private void borrarErrorProviders()
        {
            errorProvider1.SetError(txtBoxNomAtribut, "");
            errorProvider1.SetError(cmbTipo, "");
            errorProvider1.SetError(cmbtipoIndice, "");
            errorProvider1.SetError(txtBoxLong, "");
        }

        private bool validarCampos()
        {
            bool bnd = true;
            if (txtBoxNomAtribut.Text == "")
            {
                bnd = false;
                errorProvider1.SetError(txtBoxNomAtribut, "Ingrese Nombre");
            }
            if (txtBoxLong.Text == "")
            {
                if (band)
                {
                    bnd = false;
                    errorProvider1.SetError(txtBoxLong, "Ingrese la Longitud");
                }
            }
            if (cmbTipo.Text == "")
            {
                bnd = false;
                errorProvider1.SetError(cmbTipo, "Elija el tipo");
            }
            if (cmbtipoIndice.Text == "")
            {
                bnd = false;
                errorProvider1.SetError(cmbtipoIndice, "Elija el tipo de indice");
            }
            return bnd;
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            sNomTabla = cmbTablas.Text;
            //Cuando el valor del combobox que contiene las entidades cambia, se habilitan los controles que permiten agregar los atributos de la entidad seleccionada.
            ((Control)TabPageAtributos).Enabled = true;
            btnModificaTabla.Enabled = true;
            ///////////////////////////////////////////////////////////////

            int ntab = lTablas.Count;
            for (int i = 0; i < ntab; i++)
            {
                if (lTablas[i].Nombre == sNomTabla)
                    auxTab = lTablas[i];
            }

            actualizalistaPKTablas();
            actualizaDataGridAtributos();
            GeneraColumnas();
            actualizaDataGridRegistros();

        }

        private void modificarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nuevoNombre;
            Nuevo_Nombre f = new Nuevo_Nombre();

            if (f.ShowDialog() == DialogResult.OK)
            {
                nuevoNombre = f.dameNombre();
                string directorioOriginal = Dic.Ruta;
                string nuevoDirectorio = Path.GetDirectoryName(directorioOriginal);
                nuevoDirectorio = nuevoDirectorio + "\\" + nuevoNombre;

                Dic.Ruta = nuevoDirectorio;
                Directory.CreateDirectory(Dic.Ruta);
                Dic.NombreBD = nuevoNombre;
                Dic.FileName = Dic.Ruta + "\\" + nuevoNombre + ".dd";


                if (System.IO.Directory.Exists(directorioOriginal))
                {
                    try
                    {
                        System.IO.Directory.Delete(directorioOriginal, true);
                    }
                    catch (System.IO.IOException es)
                    {
                        MessageBox.Show(es.Message);
                    }
                }

                int ntab = lTablas.Count;
                if (ntab != 0)
                    for (int i = 0; i < ntab; i++)
                    {
                        lTablas[i].Ruta = Dic.Ruta;
                        lTablas[i].ActualizaTabla();
                    }

                Dic.ActualizaDiccionario();
                labNombreBD.Text = Dic.NombreBD;
            }
        }

        private void btnModificaAtr_Click(object sender, EventArgs e)
        {
            bool b = true;
            string sIndAnt;

            Atributo auxAt;
            if (bndModfica && validarCampos())
            {
                if (sNombreAtr != "")
                {
                    if (auxTab.LAtributo.Count != 0)
                    {
                        auxAt = auxTab.LAtributo.FirstOrDefault(p => p.Nombre == sNombreAtr);
                        sIndAnt = auxAt.TipoIndice;
                        ///////////////
                        if (sIndAnt == "Clave Primaria" && cmbtipoIndice.Text != "Clave Primaria")
                        {
                            auxTab.BPK = false;
                        }

                        borrarErrorProviders();
                        if (cmbtipoIndice.Text == "Clave Primaria" && sIndAnt != "Clave Primaria")
                        {
                            if (auxTab.BPK)
                            {
                                MessageBox.Show("No se puede Modificar el atributo por que la tabla no puede contener mas de una clave primaria");
                                b = false;
                            }
                            else
                                auxTab.BPK = true;
                        }

                        if (b)
                        {

                            if (cmbtipoIndice.Text == "Clave Foranea")
                            {
                                auxAt.Nombre = sNombreTempAtr;
                                auxAt.NombreExt = txtBoxNomAtribut.Text;
                                auxAt.Tipo = cmbTipo.Text;
                                auxAt.TipoIndice = cmbtipoIndice.Text;

                                if (txtBoxLong.Enabled)
                                {
                                    auxAt.Longitud = Int32.Parse(txtBoxLong.Text);
                                }
                                else
                                {
                                    auxAt.Longitud = 4;
                                }
                            }
                            else
                            {
                                auxAt.Nombre = txtBoxNomAtribut.Text;
                                auxAt.Tipo = cmbTipo.Text;
                                auxAt.TipoIndice = cmbtipoIndice.Text;

                                if (txtBoxLong.Enabled)
                                {
                                    auxAt.Longitud = Int32.Parse(txtBoxLong.Text);
                                }
                                else
                                {
                                    auxAt.Longitud = 4;
                                }
                            }

                            auxTab.ActualizaTabla();


                            txtBoxLong.Clear();
                            txtBoxLong.Focus();
                            txtBoxNomAtribut.Clear();
                            txtBoxNomAtribut.Focus();
                            cmbTipo.SelectedIndex = -1;
                            cmbtipoIndice.SelectedIndex = -1;
                            actualizaDataGridAtributos();
                            bndModfica = false;
                        }
                    }
                }
                else
                    MessageBox.Show("Elija el atributo que desea moficar");
            }
            actualizalistaPKTablas();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            borrarErrorProviders();
            if (cmbTipo.Text == "Entero" || cmbTipo.Text == "Flotante")
            {
                band = txtBoxLong.Enabled = false;
            }
            else
            {
                band = txtBoxLong.Enabled = true;
            }
        }

        private void eliminarBaseDeDatosActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(Dic.Ruta))
            {
                try
                {
                    System.IO.Directory.Delete(Dic.Ruta, true);
                }
                catch (System.IO.IOException es)
                {
                    MessageBox.Show(es.Message);
                }
            }
            ((Control)TabPageAtributos).Enabled = false;
            labNombreBD.Text = "Nombre de la BD";
            cmbTablas.Items.Clear();
            dgAtributos.Rows.Clear();
        }

        //Modifica Tabla
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbTablas.Text != "")
            {
                Nuevo_Nombre f = new Nuevo_Nombre();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    cmbTablas.Items.Remove(auxTab.Nombre);
                    string nuevoNombre = f.dameNombre();
                    cmbTablas.Items.Add(nuevoNombre);
                    Dic.LNombresTablas.Remove(auxTab.Nombre);
                    Dic.LNombresTablas.Add(nuevoNombre);

                    string nomOriginal = auxTab.Ruta + "\\" + auxTab.Nombre + ".tab";
                    auxTab.Nombre = nuevoNombre;

                    if (System.IO.File.Exists(nomOriginal))
                    {
                        // Use a try block to catch IOExceptions, to
                        // handle the case of the file already being
                        // opened by another process.
                        try
                        {
                            System.IO.File.Delete(nomOriginal);
                        }
                        catch (System.IO.IOException es)
                        {
                            Console.WriteLine(es.Message);
                            return;
                        }
                    }
                    auxTab.ActualizaTabla();
                    Dic.ActualizaDiccionario();
                }
            }
        }

        private void dgAtributos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                sNombreAtr = auxTab.LAtributo[e.RowIndex].Nombre;
            }
        }

        private void cmbtipoIndice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtipoIndice.Text == "Clave Foranea")
            {
                cmbTablasPK.Enabled = true;
                cmbTipo.Enabled = txtBoxLong.Enabled = false;

            }
            else
            {
                cmbTipo.Enabled = txtBoxLong.Enabled = true;
                cmbTablasPK.Enabled = false;
                txtBoxLong.Text = txtBoxNomAtribut.Text = "";
                cmbTablasPK.SelectedIndex = cmbTipo.SelectedIndex = -1;
            }
        }

        private void dgAtributos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bndModfica = true;
                string s = dgAtributos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string se = auxTab.LAtributo[e.RowIndex].Nombre;
                if (auxTab.LAtributo[e.RowIndex].TipoIndice == "Clave Foranea")
                {
                    sNombreAtr = se;
                    txtBoxNomAtribut.Text = s;
                }
                else
                    txtBoxNomAtribut.Text = sNombreAtr = s;
            }
        }

        private void btnEliminaAtr_Click(object sender, EventArgs e)
        {
            Atributo atAux;
            DialogResult res = MessageBox.Show("¿Esta seguro de eliminar este atributo?, los cambios realizados no podran deshacerse", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                if (sNombreAtr != "")
                {
                    
                    atAux = auxTab.LAtributo.FirstOrDefault(p => p.Nombre == sNombreAtr);

                    if (atAux.TipoIndice == "Clave Primaria" && auxTab.BandReg)
                    {
                        MessageBox.Show("No se puede eliminar este atributo por que es una llave primaria que actualmente contiene datos");
                    }
                    else
                    {
                        if (atAux.TipoIndice == "Clave Primaria")
                        {

                            auxTab.BPK = false;
                        }
                        auxTab.LAtributo.Remove(atAux);
                        foreach (List<RegistroAtributo> value in auxTab.Registros)
                        {
                            RegistroAtributo auxreg = value.FirstOrDefault(p => p.Atr.Nombre == sNombreAtr);
                            value.Remove(auxreg);
                        }
                        auxTab.ActualizaTabla();
                        actualizaDataGridAtributos();
                    }
                }
                else
                    MessageBox.Show("Elija el atributo que desea eliminar");
            }
        }

        private void cmbTablasPK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTablasPK.SelectedIndex != -1)
            {
                Atributo atAux = (lTablas.FirstOrDefault(p => p.Nombre == cmbTablasPK.Text)).LAtributo.FirstOrDefault(p => p.TipoIndice == "Clave Primaria");
                sNombreTempAtr = atAux.Nombre;
                cmbTipo.Text = atAux.Tipo;
                txtBoxLong.Text = atAux.Longitud.ToString();

            }
        }

        private void GeneraColumnas()
        {
            dgRegistros.Columns.Clear();
            if (cmbTablas.Text != "")
            {
                List<Atributo> listAtributos = auxTab.LAtributo;

                foreach (Atributo value in listAtributos)
                {
                    if(value.TipoIndice == "Clave Foranea")
                    {
                        dgRegistros.Columns.Add(value.NombreExt, value.NombreExt);
                    }
                    else
                        dgRegistros.Columns.Add(value.Nombre, value.Nombre);
                }
            }
            else
                MessageBox.Show("No ha seleccionado ninguna Tabla");
        }
                    //Nuevo Registro
        private void NewAdd_Click(object sender, EventArgs e)
        {
            List<RegistroAtributo> r = new List<RegistroAtributo>();
            Modifica_Atributo f = new Modifica_Atributo(auxTab.LAtributo, 0);
            if (f.ShowDialog() == DialogResult.OK)
            {
                r = f.Reg;

                //Antes de insertar el registro se valida la integridad de los datos, si los datos que se pretenden insertar "Existen"
                //A estos se les permite la inserción, aun que despues de haber pasado este primer filtro tambien se verifica 
                //Si la clave primaria que identifica al Registro ya exsite como identificador de algun otro registro y si esto es asi
                //No se permite su inserción.
                bool existe = IntegridadReferencialClavesSecundarias(r);    
                
                if (existe)
                {
                    if (auxTab.BPK)
                    {
                        RegistroAtributo ClavePrimaria = r.FirstOrDefault(p => p.Atr.TipoIndice == "Clave Primaria");
                        if (auxTab.CPrimarias.Contains(ClavePrimaria.Reg))
                        {
                            MessageBox.Show("No se puede insertar el registro por que ya existe una Clave Primaria con el mismo valor");
                        }
                        else
                        {
                            auxTab.Registros.Add(r);
                            auxTab.CPrimarias.Add(ClavePrimaria.Reg);
                            auxTab.BandReg = true;
                        }
                    }
                    else
                    {
                        auxTab.Registros.Add(r);
                        auxTab.BandReg = true;
                    }
                    auxTab.ActualizaTabla();
                    actualizaDataGridRegistros();
                }
                else
                    MessageBox.Show("No se puede insertar el registro por que no se está respetando la integridad de los datos");
            }
        }

        private bool IntegridadReferencialClavesSecundarias(List<RegistroAtributo> reg)
        {
            bool existe = false;
            List<RegistroAtributo> lClavesSec = null;

            lClavesSec = reg.Where(p => p.Atr.TipoIndice == "Clave Foranea").ToList();
            if (lClavesSec.Count != 0)
            {
                foreach (RegistroAtributo value in lClavesSec)
                {
                    foreach (Tabla val in lTablas)
                    {
                        Atributo at = null;
                        at = val.LAtributo.FirstOrDefault(p => p.Nombre == value.Atr.Nombre);
                        if (at != null && at.TipoIndice == "Clave Primaria")
                        {
                            int nReg = val.Registros.Count;
                            for (int i = 0; i < nReg; i++)
                            {
                                RegistroAtributo aux = null;
                                aux = val.Registros[i].FirstOrDefault(p => p.Reg == value.Reg && p.Atr.Nombre == value.Atr.Nombre);
                                if (aux != null)
                                {
                                    existe = true;
                                    break;
                                }
                                else
                                {
                                    existe = false;
                                }
                            }
                        }
                    }
                    if (!existe)
                        break;
                }
            }
            else
                existe = true;

            return existe;
        }

        private bool IntegridadReferencialClavesPrimarias(RegistroAtributo regAt)
        {
            bool existe = false;

            foreach (Tabla val in lTablas)
            {
                Atributo at = null;
                at = val.LAtributo.FirstOrDefault(p => p.Nombre == regAt.Atr.Nombre);
                if (at != null && at.TipoIndice == "Clave Foranea")
                {
                    int nReg = val.Registros.Count;
                    for (int i = 0; i < nReg; i++)
                    {
                        RegistroAtributo aux = null;
                        aux = val.Registros[i].FirstOrDefault(p => p.Reg == regAt.Reg && p.Atr.Nombre == regAt.Atr.Nombre);
                        if (aux != null)
                        {
                            existe = true;
                            break;
                        }
                        else
                            existe = false;
                    }
                }
            }

            return existe;
        }


        private void actualizaDataGridRegistros()
        {
            dgRegistros.Rows.Clear();
            //////////
            if(sNomTabla != "")
                if (auxTab.Registros.Count != 0)
                {
                    int nReg = auxTab.Registros.Count;
                    for (int i = 0; i < nReg; i++)
                    {
                        int nCampos = auxTab.LAtributo.Count;
                        int nCamposReg = auxTab.Registros[i].Count;
                        dgRegistros.Rows.Add();
                        int j2 = 0;
                        for (int j = 0; j < nCampos; j++)
                        {
                            if (auxTab.Registros[i][j2].Atr.TipoIndice == "Clave Foranea")
                            {
                                if (j2 < nCamposReg && dgRegistros.Columns[j].Name == auxTab.Registros[i][j2].Atr.NombreExt)
                                {
                                    dgRegistros.Rows[i].Cells[j].Value = auxTab.Registros[i][j2].Reg;
                                    j2++;
                                }
                                else
                                    dgRegistros.Rows[i].Cells[j].Value = "null";
                            }
                            else
                            {
                                if (j2 < nCamposReg && dgRegistros.Columns[j].Name == auxTab.Registros[i][j2].Atr.Nombre)
                                {
                                    dgRegistros.Rows[i].Cells[j].Value = auxTab.Registros[i][j2].Reg;
                                    j2++;
                                }
                                else
                                    dgRegistros.Rows[i].Cells[j].Value = "null";
                            }
                        }
                    }
                }
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == "TabPageRegistros")
            {
                GeneraColumnas();
                actualizaDataGridRegistros();
            }
        }

        private void dgRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iIndiceRegistro = e.RowIndex;
        }

        private void btModificaRegistro_Click(object sender, EventArgs e)
        {
            if (iIndiceRegistro != -1)
            {
                List<RegistroAtributo> r = new List<RegistroAtributo>();
                Modifica_Atributo f = new Modifica_Atributo(auxTab.LAtributo, 1);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    r = f.Reg;
                    int ntam = r.Count;
                    int i2 = 0;
                    List<Atributo> l = auxTab.LAtributo;
                    bool existe = IntegridadReferencialClavesSecundarias(r);

                    if (existe)
                    {
                        foreach (Atributo value in l)
                        {
                            RegistroAtributo RegistroActual = null;
                            RegistroAtributo RegistroNuevo = null;
                            RegistroActual = auxTab.Registros[iIndiceRegistro].FirstOrDefault(p => p.Atr.Nombre == value.Nombre);
                            RegistroNuevo = r.FirstOrDefault(p => p.Atr.Nombre == value.Nombre);

                            if (RegistroActual != null && RegistroNuevo != null)
                                RegistroActual.Reg = RegistroNuevo.Reg;
                            else
                                if (RegistroNuevo != null)
                                auxTab.Registros[iIndiceRegistro].Add(RegistroNuevo);
                        }
                        auxTab.ActualizaTabla();
                        actualizaDataGridRegistros();
                    }
                    else
                        MessageBox.Show("No se puede insertar el registro por que no se está respetando la integridad de los datos");

                }

                iIndiceRegistro = -1;
            }
            else
                MessageBox.Show("Seleccione un registro en la tabla");
        }

        private void btEliminaRegistro_Click(object sender, EventArgs e)
        {
            if (iIndiceRegistro != -1)
            {
                DialogResult res = MessageBox.Show("¿Esta seguro de eliminar este registro?, los cambios realizados no podran deshacerse", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    RegistroAtributo r = auxTab.Registros[iIndiceRegistro].FirstOrDefault(p => p.Atr.TipoIndice == "Clave Primaria");
                    bool existe = IntegridadReferencialClavesPrimarias(r);

                    if (!existe)
                    {
                        auxTab.Registros.RemoveAt(iIndiceRegistro);
                        auxTab.ActualizaTabla();
                        actualizaDataGridRegistros();
                    }
                    else
                        MessageBox.Show("No se puede eliminar el registro por que no se está respetando la integridad de los datos");
                }

                iIndiceRegistro = -1;
            }
            else
                MessageBox.Show("Elija el registro que desea eliminar");
        }

        private void btConsultas_Click(object sender, EventArgs e)
        {
            Consulta f = new Consulta(lTablas);

            f.ShowDialog();
        }

        private void btEliminaTabla_Click(object sender, EventArgs e)
        {
            if (cmbTablas.Text != "")
            {
                cmbTablas.Items.Remove(auxTab.Nombre);
                Dic.LNombresTablas.Remove(auxTab.Nombre);
                string nomOriginal = auxTab.Ruta + "\\" + auxTab.Nombre + ".tab";
                
                if (System.IO.File.Exists(nomOriginal))
                {
                    // Use a try block to catch IOExceptions, to
                    // handle the case of the file already being
                    // opened by another process.
                    try
                    {
                        System.IO.File.Delete(nomOriginal);
                    }
                    catch (System.IO.IOException es)
                    {
                        Console.WriteLine(es.Message);
                        return;
                    }
                }
                Dic.ActualizaDiccionario();
            }            
        }
    }
}