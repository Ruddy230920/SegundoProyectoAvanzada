using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoProyectoAvanzada
{
    public partial class Crear_Suppliers : Form
    {
        public int SuplidorID;
        private readonly ISuppliersServices _suppliersServices;
        public Crear_Suppliers(ISuppliersServices suppliersServices)
        {
            _suppliersServices = suppliersServices;
            InitializeComponent();
        }

        public void ObtenerSuplidor(int id )
        {
            SuplidorID =id;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtboxNombreCompañia.Text) ||
                    string.IsNullOrWhiteSpace(txtboxNombreContacto.Text) ||
                    string.IsNullOrWhiteSpace(txtboxTituloContacto.Text) ||
                    string.IsNullOrWhiteSpace(txtboxCiudadSuplidor.Text) ||
                    string.IsNullOrWhiteSpace(txtboxDireccionSuplidor.Text) ||
                    string.IsNullOrWhiteSpace(txtboxPaisSuplidor.Text) ||
                    string.IsNullOrWhiteSpace(txtboxTelefonoSuplidor.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var suplidor = new SupplierDTO
                {
                    SupplierID = this.SuplidorID,
                    CompanyName = txtboxNombreCompañia.Text,
                    ContactName = txtboxNombreContacto.Text,
                    ContactTitle = txtboxTituloContacto.Text,
                    City = txtboxCiudadSuplidor.Text,
                    Address = txtboxDireccionSuplidor.Text,
                    Country = txtboxPaisSuplidor.Text,
                    Phone = txtboxTelefonoSuplidor.Text,
                };

                if (suplidor.SupplierID == 0)
                {
                    await _suppliersServices.add(suplidor);
                    MessageBox.Show("Suplidor agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _suppliersServices.Update(suplidor);
                    MessageBox.Show("Suplidor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrió un error al guardar el suplidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void Crear_Suppliers_Load(object sender, EventArgs e)
        {
            if (SuplidorID > 0)
            {

                var suplidor = await _suppliersServices.GetById(SuplidorID);
                txtboxNombreCompañia.Text = suplidor.CompanyName;
                txtboxNombreContacto.Text = suplidor.ContactName;
                txtboxTituloContacto.Text = suplidor.ContactTitle;
                txtboxCiudadSuplidor.Text = suplidor.City;
                txtboxDireccionSuplidor.Text = suplidor.Address;
                txtboxPaisSuplidor.Text = suplidor.Country;
                txtboxTelefonoSuplidor.Text = suplidor.Phone;
            }

        }
    }
}
