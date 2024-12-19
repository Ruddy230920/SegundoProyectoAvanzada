using Microsoft.Extensions.DependencyInjection;
using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Infrastructure.Data;
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
    public partial class SuplidorForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISuppliersServices _suppliersServices;
        private readonly NorthwindDbContexts _northwindDbContexts;

        public SuplidorForm(IServiceProvider serviceProvider, ISuppliersServices suppliersServices, NorthwindDbContexts northwindDbContexts)
        {
            _serviceProvider = serviceProvider;
            _suppliersServices = suppliersServices;
            _northwindDbContexts = northwindDbContexts;

            InitializeComponent();
        }

        private async void SuplidorForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (await _suppliersServices.GetAllAsync()).ToList();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var suplidor = _serviceProvider.GetRequiredService<Crear_Suppliers>();
            suplidor.ShowDialog();

            var cargarsuplidor = await _suppliersServices.GetAllAsync();
            dataGridView1.DataSource = cargarsuplidor.ToList();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var filaSeleccionada = (SupplierDTO)dataGridView1.SelectedRows[0].DataBoundItem;
                var suplidorID = filaSeleccionada.SupplierID;

                var suplidor = _serviceProvider.GetRequiredService<Crear_Suppliers>();
                suplidor.ObtenerSuplidor(suplidorID);
                suplidor.ShowDialog();

                var cargarsuplidor = await _suppliersServices.GetAllAsync();
                dataGridView1.DataSource = cargarsuplidor.ToList();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un suplidor para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el producto seleccionado
                var filaSeleccionada =(SupplierDTO)dataGridView1.SelectedRows[0].DataBoundItem;
                var SuplidorID = filaSeleccionada.SupplierID;

                // Confirmar la acción de borrado
                var confirmResult = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar esta categoría?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                       
                        var suplidorservicios = _serviceProvider.GetRequiredService<ISuppliersServices>();
                        await suplidorservicios.Delete(SuplidorID);

                        MessageBox.Show("Categoría eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var cargarsuplidores = await _suppliersServices.GetAllAsync();
                      dataGridView1.DataSource=cargarsuplidores.ToList();
                        
                    }
                    catch (Exception ex)
                    {
                        // Manejar cualquier error
                        MessageBox.Show($"Ocurrió un error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una categoría para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
