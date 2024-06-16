using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace pruebas_parcial
{
    public partial class Form1 : Form
    {
        b formagregar = new b();
        c formresult = new c();
        int[] numerosenteros = new int[1000];
        int contador = 0;
        int ret;
 


        public Form1()
        {
            InitializeComponent();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(tbBusqueda.Text);
                if (rbSecuencial.Checked)
                {
                    metodoburbuja();
                    int aux = secuencial(num);
                    if (aux != -1)
                    {
                        MessageBox.Show($"Numero {numerosenteros[aux]}, encontrado en la poscicion {aux}");
                    }
                    else
                    {
                        MessageBox.Show("Numero no encontrado");
                    }
                }
                else if (rbBinaria.Checked)
                {
                    metodoburbuja();
                    int aux = binario(num);
                    if (aux != -1)
                    {
                    MessageBox.Show($"Numero {numerosenteros[aux]}, encontrado en la poscicion {aux}");
                    }
                    else
                    {
                        MessageBox.Show(("Numero no encontrado"));
                    }
                }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (formagregar.ShowDialog() == DialogResult.OK)
                {
                    int num = Convert.ToInt32(formagregar.tbIngresar.Text); //corregir en hoja
                    agregarnumero(num);
                    formagregar.tbIngresar.Clear();
                }
            }
            formagregar.tbIngresar.Clear();
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            formresult.lbResultados.Items.Clear();                         //corregir en hoja
            formresult.lbResultados.Items.Add(calcularpromedio());
            formresult.ShowDialog();
        }

        private void btnListado_Click(object sender, EventArgs e) //corregir en hoja
        {
            formresult.lbResultados.Items.Clear();
            metodoburbuja();
            for(int i=0; i<contador; i++)
            {
                formresult.lbResultados.Items.Add(numerosenteros[i]); //corregir en hoja
            }

            formresult.ShowDialog();
        }


        public void agregarnumero(int num)
        {
            numerosenteros[contador] = num;
            contador++;
        }

        public void metodoburbuja()
        {
            for(int i=0; i<contador-1; i++)
            {
                for (int j = i + 1; j < contador; j++)
                {
                    if (numerosenteros[i] > numerosenteros[j])
                    {
                        int aux = numerosenteros[j];
                        numerosenteros[j] = numerosenteros[i];
                        numerosenteros[i] = aux;
                    }
                }
            }
        }

        public double calcularpromedio()
        {
            double acum = 0;
            double promedio = 0;
             for(int i = 0; i<contador; i++)
            {
                acum += numerosenteros[i];
            }
            if (contador != 0)
            {
                promedio = acum / contador;
            }

            return promedio;
        }


        public int secuencial(int buscado)
        {
            ret = -1;
            for(int i = 0; i < contador; i++)
            {
                if (numerosenteros[i] == buscado) //corregir en hoja
                {
                    ret = i;
                }
            }

            return ret;
        }


        public int binario(int buscado) //corregir en hoja
        {
            int izq, der, medio, ret = -1;
            izq = 0;
            der = contador - 1;
            do
            {
                medio = (izq + der) / 2;
                if (numerosenteros[medio] == buscado)
                {
                    ret = medio;
                }
                else if (numerosenteros[medio] < buscado)
                {
                    izq = medio + 1;
                }
                else
                {
                    der = medio - 1;
                }
            } while ((izq <= der) && (ret == -1));

            return ret;
        }

    }
}
