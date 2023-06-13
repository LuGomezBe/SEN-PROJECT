using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSen
{
    public partial class ActualizarEstadoE_Admin : Form
    {
        public ActualizarEstadoE_Admin()
        {
            InitializeComponent();
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.mostrarReporte(dgvReporte);
        }

        private void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            if (cmbEstadoE.Text == "NUEVO")
            {
                Clases.CReporte objetoReporte = new Clases.CReporte();
                objetoReporte.BuscarEstado(dgvReporte, cmbEstadoE);
            }
            if (cmbEstadoE.Text == "PROCESO")
            {
                Clases.CReporte objetoReporte = new Clases.CReporte();
                objetoReporte.BuscarEstado(dgvReporte, cmbEstadoE);
            }
            if (cmbEstadoE.Text == "FINALIZADO")
            {
                Clases.CReporte objetoReporte = new Clases.CReporte();
                objetoReporte.BuscarEstado(dgvReporte, cmbEstadoE);
            }
            else
            {
                cmbEstadoE.Text = "Elija una opcion";
            }
        }

        private void ActualizarEstadoE_Admin_Load(object sender, EventArgs e)
        {

        }

        private void dgvReporte_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.SelecionEstado(dgvReporte, txtId,txtEstado);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.UpdateEstado(txtId, txtEstado);
            objetoReporte.mostrarReporte(dgvReporte);
            MessageBox.Show("Se actualizo correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtId.Text = string.Empty;
            txtEstado.Text = string.Empty;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            InicioAdmin admin = new InicioAdmin();
            admin.ShowDialog();
        }
    }
}
