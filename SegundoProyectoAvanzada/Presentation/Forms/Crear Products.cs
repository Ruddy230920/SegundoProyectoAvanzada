using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Models;
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
    public partial class Crear_Products : Form
    {
        public int IdProducto;
        private readonly ISuppliersServices _suppliersServices;
        private readonly ICategoriesServices _categoriesServices;
        private readonly IProductsServices _productsServices;
        public Crear_Products(ICategoriesServices categoriesServices, IProductsServices productsServices, ISuppliersServices suppliersServices)
        {
            InitializeComponent();
            _categoriesServices = categoriesServices;
            _productsServices = productsServices;
            _suppliersServices = suppliersServices;
        }

        public void ObtenerProducto(int id)
        {
            IdProducto = id;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos requeridos no estén vacíos
                if (string.IsNullOrWhiteSpace(TxtNombreProducto.Text))
                    throw new Exception("El nombre del producto es obligatorio.");
                if (string.IsNullOrWhiteSpace(TxtCantidadPorUnidad.Text))
                    throw new Exception("La cantidad por unidad es obligatoria.");
                if (string.IsNullOrWhiteSpace(TxtPrecioUnidad.Text) || !decimal.TryParse(TxtPrecioUnidad.Text, out decimal unitPrice))
                    throw new Exception("El precio por unidad es obligatorio y debe ser un número válido.");
                if (cmboxCategoria.SelectedValue == null)
                    throw new Exception("Debes seleccionar una categoría.");
                if (cmboxSuplidor.SelectedValue == null)
                    throw new Exception("Debes seleccionar un suplidor.");

                // Crear el objeto con datos validados
                var products = new ProductsDTO
                {
                    ProductID = this.IdProducto,
                    ProductName = TxtNombreProducto.Text,
                    QuantityPerUnit = TxtCantidadPorUnidad.Text,
                    UnitPrice = unitPrice,
                    UnitsInStock = string.IsNullOrWhiteSpace(TxtUnidadStock.Text)
                        ? (short)0
                        : Convert.ToInt16(TxtUnidadStock.Text),
                    UnitsOnOrder = string.IsNullOrWhiteSpace(TxtUnidadBajoPedido.Text)
                        ? (short)0
                        : Convert.ToInt16(TxtUnidadBajoPedido.Text),
                    CategoryName = cmboxCategoria.Text,
                    CategoryID = Convert.ToInt32(cmboxCategoria.SelectedValue),
                    CompanyName = cmboxSuplidor.Text,
                    SupplierID = Convert.ToInt32(cmboxSuplidor.SelectedValue),
                    Discontinued = checkBox1.Checked
                };

                // Agregar o actualizar el producto
                if (products.ProductID == 0)
                    await _productsServices.add(products);
                else
                    await _productsServices.Update(products);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private async void Crear_Products_Load(object sender, EventArgs e)
        {
            var categoria= await _categoriesServices.GetAllAsync();
            var suplidor= await _suppliersServices.GetAllAsync();

            if (IdProducto > 0)
            {
                var producto= await _productsServices.GetProductsByIdAsync(IdProducto);
                TxtNombreProducto.Text=producto.ProductName;
                TxtCantidadPorUnidad.Text=producto.QuantityPerUnit;
                TxtPrecioUnidad.Text=producto.UnitPrice.ToString();
                TxtUnidadStock.Text= producto.UnitsInStock.ToString();
                TxtUnidadBajoPedido.Text=producto.UnitsOnOrder.ToString();
                cmboxCategoria.Text= producto.CategoryName;
                cmboxSuplidor.Text= producto.CompanyName;
                checkBox1.Checked = producto.Discontinued;
            }

            if (categoria != null && suplidor != null)
            {
                cmboxCategoria.DisplayMember = "CategoryName";
                cmboxCategoria.ValueMember = "CategoryID";
                cmboxCategoria.DataSource = categoria.ToList();

                cmboxSuplidor.DisplayMember = "CompanyName";
                cmboxSuplidor.ValueMember = "SupplierID";
                cmboxSuplidor.DataSource = suplidor.ToList();

            }
        }
    }
}
