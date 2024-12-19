using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SegundoProyectoAvanzada.Services.DTO;
using SegundoProyectoAvanzada.Models;
using SegundoProyectoAvanzada.Services;
using SegundoProyectoAvanzada.Infrastructure.Data;
using SegundoProyectoAvanzada.Infrastructure.Data.Repository;


namespace SegundoProyectoAvanzada
{
    public partial class ProductsForm : Form
    {
        private readonly IProductsServices _Productsservices;
        private readonly IProductsRepository _productsRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly NorthwindDbContexts _Context;
        public ProductsForm(IProductsRepository productsRepository, IServiceProvider serviceProvider, IProductsServices productsServices, NorthwindDbContexts contexts)
        {

            _productsRepository = productsRepository;

            _serviceProvider = serviceProvider;
            _Productsservices = productsServices;

            _Context = contexts;

            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Suplidor = _serviceProvider.GetRequiredService<SuplidorForm>();
            Suplidor.Show();
        }

        private async void ProductsForm_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = (await _Productsservices.GetAllProductsAsync()).ToList();

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var categoria = _serviceProvider.GetRequiredService<CategoriesForm>();
            categoria.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var producto = _serviceProvider.GetRequiredService<Crear_Products>();
            producto.ShowDialog();

            var cargarproductos= await _productsRepository.GetAllProducts();
            dataGridView1.DataSource= cargarproductos.ToList();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var filaSeleccionada = (ProductsDTO)dataGridView1.SelectedRows[0].DataBoundItem;
                var productsID = filaSeleccionada.ProductID;

                var crear = _serviceProvider.GetRequiredService<Crear_Products>();
                crear.ObtenerProducto(productsID);
                crear.ShowDialog();

                var cargarproductos= await _Productsservices.GetAllProductsAsync();
                dataGridView1.DataSource=cargarproductos.ToList() ;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para ser editado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                var filaSeleccionada = (ProductsDTO)dataGridView1.SelectedRows[0].DataBoundItem;
                var productsID = filaSeleccionada.ProductID;

                
                var confirmResult = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este producto?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        
                        var productsService = _serviceProvider.GetRequiredService<IProductsServices>();
                        await productsService.Delete(filaSeleccionada);

                        
                        MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        var productosActualizados = await _Productsservices.GetAllProductsAsync();
                        dataGridView1.DataSource = productosActualizados.ToList();
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show($"Ocurrió un error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
    }
}
