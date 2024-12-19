using Proyecto1Avanzada.DTO;
using SegundoProyectoAvanzada.Infrastructure.Data.Repository;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SegundoProyectoAvanzada
{

    public partial class Crear_Categories : Form

    {
       
        public int IdCategory;
        private readonly ISuppliersServices _suppliersServices;
        private readonly IProductsServices _productsServices;
        private readonly ICategoriesServices _categoriesServices;
        public Crear_Categories(ICategoriesServices categoriesServices, ISuppliersServices suppliersServices, IProductsServices productsServices)
        {
            
            _categoriesServices = categoriesServices;
            _suppliersServices = suppliersServices;
            _productsServices = productsServices;
            InitializeComponent();
        }

        public void Obtenercategoria(int id)
        {
            IdCategory = id;
        }

        private void pictureBoxCategoria_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxNombreCategoria.Text) || string.IsNullOrWhiteSpace(txtboxDescripcionCategoria.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            var category = new CategoriesDTO
            {
                CategoryID = this.IdCategory,
                CategoryName = txtboxNombreCategoria.Text,
                Description = txtboxDescripcionCategoria.Text,




            };
            try
            {
                if (category.CategoryID == 0)
                    await _categoriesServices.add(category);
                else
                    await _categoriesServices.Update(category);

                MessageBox.Show("Categoría guardada exitosamente.");
               
                this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la categoría: {ex.Message}");
            }
        }

        private async void Crear_Categories_Load(object sender, EventArgs e)
        {

            try
            {
                if (this.IdCategory > 1)
                {
                    var categoria = await _categoriesServices.GetById(this.IdCategory);

                    if (categoria == null)
                    {
                        MessageBox.Show("Categoría no encontrada.");
                        return;
                    }

                    txtboxDescripcionCategoria.Text = categoria.Description;
                    txtboxNombreCategoria.Text = categoria.CategoryName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrió un error al cargar la categoría: {ex.Message}");
            }

            

        }
    }
}
