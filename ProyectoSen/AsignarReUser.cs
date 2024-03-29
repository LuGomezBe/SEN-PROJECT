﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSen
{
    public partial class AsignarReUser : Form
    {
        public AsignarReUser()
        {
            InitializeComponent();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
     int nLeftRect,
     int nTopRect,
     int nRightRect,
     int nBottomRect,
     int nWithEllipse,
     int nHeightEllipse
          );
        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        private void btnSave_Click(object sender, EventArgs e)
        {
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.guardarReporte(comboBox1, txtDni, txtMarca,txtEstado);
            MessageBox.Show("Se guardo correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboBox1.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtDni.Text = string.Empty;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            InicioUsuario user = new InicioUsuario();
            user.ShowDialog();
        }

        private void txtDni_Leave(object sender, EventArgs e)
        {
            if (txtDni.Text == "")
            {
                txtDni.Text = "Ingrese DNI cliente";
                txtDni.ForeColor = Color.LightSteelBlue;
            }
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {

            if (txtDni.Text == "Ingrese DNI cliente")
            {
                txtDni.Text = "";
                txtDni.ForeColor = Color.Black;
            }
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {

            if (txtMarca.Text == "")
            {
                txtMarca.Text = "Ingrese la Marca";
                txtMarca.ForeColor = Color.LightSteelBlue;
            }
        }

        private void txtMarca_Enter(object sender, EventArgs e)
        {

            if (txtMarca.Text == "Ingrese la Marca")
            {
                txtMarca.Text = "";
                txtMarca.ForeColor = Color.Black;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AsignarModificarUser user = new AsignarModificarUser();
            user.ShowDialog();
        }

        private void txtTecnico_TextChanged(object sender, EventArgs e)
        {

        }

        private void AsignarReUser_Load(object sender, EventArgs e)
        {
            IntPtr region = CreateRoundRectRgn(0, 0, btnSave.Width, btnSave.Height, 30, 30);
            SetWindowRgn(btnSave.Handle, region, true);

            /*IntPtr region1 = CreateRoundRectRgn(0, 0, btnModificar.Width, btnModificar.Height, 30, 30);
            SetWindowRgn(btnModificar.Handle, region1, true);*/

            IntPtr region2 = CreateRoundRectRgn(0, 0, btnVolver.Width, btnVolver.Height, 30, 30);
            SetWindowRgn(btnVolver.Handle, region2, true);

            IntPtr region3 = CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 30, 30);
            SetWindowRgn(panel4.Handle, region3, true);
            Clases.CTecnico objetoTecnico = new Clases.CTecnico();
            objetoTecnico.LlenarComboBox(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Elija una opcion";
                comboBox1.ForeColor = Color.LightSteelBlue;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Elija una opcion")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
            }
        }
    }
}
