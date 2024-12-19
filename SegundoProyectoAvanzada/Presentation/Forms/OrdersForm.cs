using Microsoft.Extensions.DependencyInjection;
using SegundoProyectoAvanzada.Infrastructure.Data.Repository;
using SegundoProyectoAvanzada.Forms;
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
   
    public partial class OrdersForm : Form
    { 
        private readonly IServiceProvider _serviceProvider;
        private readonly IOrdersServices _services;
        public OrdersForm(IOrdersServices services, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _services = services;
            InitializeComponent();
        }

        private async void OrdersForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (await _services.GetAllAsync()).ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Ordenes = _serviceProvider.GetRequiredService<Crear_Ordenes>();
            Ordenes.ShowDialog();
        }
    }
}
