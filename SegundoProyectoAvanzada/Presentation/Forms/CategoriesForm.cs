using Microsoft.Extensions.DependencyInjection;
using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Infrastructure.Data;
using SegundoProyectoAvanzada.Services;
using SegundoProyectoAvanzada.Services.DTO;
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
    public partial class CategoriesForm : Form
    {
        private readonly ICategoriesServices _services;
        private readonly ISuppliersServices _suppliers;
        private readonly IProductsServices _products;
        private readonly IServiceProvider _serviceProvider;
        private readonly NorthwindDbContexts _northwindDbContexts;


        public CategoriesForm(ICategoriesServices categoriesServices, IServiceProvider serviceProvider, NorthwindDbContexts northwindDbContexts)
        {
            _northwindDbContexts = northwindDbContexts;
            _services = categoriesServices;
            _serviceProvider = serviceProvider;

            InitializeComponent();
        }

        
        private async void CategoriesForm_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = (await _services.GetAllAsync()).ToList();

            //await cargarCategoria();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var categoria = _serviceProvider.GetRequiredService<Crear_Categories>();
            categoria.ShowDialog();

            var cargarcategoria= await _services.GetAllAsync();
            dataGridView1.DataSource=cargarcategoria.ToList();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var filaSeleccionada = (CategoriesDTO)dataGridView1.SelectedRows[0].DataBoundItem;
                var categoryID = filaSeleccionada.CategoryID;

                var crear = _serviceProvider.GetRequiredService<Crear_Categories>();
                crear.Obtenercategoria(categoryID);
                crear.ShowDialog();

                var cargarcategorias= await _services.GetAllAsync();
                dataGridView1.DataSource= cargarcategorias.ToList() ;

            }
            else
            {
                MessageBox.Show("Por favor, selecciona una categoria para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task cargarCategoria()
        {
            try
            {
                var CategoriaServices = _serviceProvider.GetRequiredService<ICategoriesServices>();
                var categorias = await CategoriaServices.GetAllAsync(); 
                
                dataGridView1.DataSource = categorias.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                var filaSeleccionada = (CategoriesDTO)dataGridView1.SelectedRows[0].DataBoundItem;
                var CategoriaID = filaSeleccionada.CategoryID;

               
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
                       
                        var CategoriaServices = _serviceProvider.GetRequiredService<ICategoriesServices>();
                        await CategoriaServices.Delete(filaSeleccionada);

                        
                        MessageBox.Show("Categoría eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var cargarcategorias = await CategoriaServices.GetAllAsync();
                        dataGridView1.DataSource= cargarcategorias.ToList();
                        
                    }
                    catch (Exception ex)
                    {
                        
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
