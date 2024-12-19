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

namespace SegundoProyectoAvanzada.Forms
{
    public partial class Crear_Ordenes : Form
    {
        public int IdOrder;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IShippersRepository _shippersRepository;
        private readonly ICustomersRepository _customersRepository;
        private readonly IOrdersServices _services;
        public Crear_Ordenes(IOrdersServices ordersServices, ICustomersRepository customersRepository,IEmployeesRepository employeesRepository, IShippersRepository shippersRepository)
        {
            _services = ordersServices;
            InitializeComponent();
            _customersRepository = customersRepository;
            _employeesRepository = employeesRepository;
            _shippersRepository = shippersRepository;
        }
        public void ObtenerOrden(int id)
        {
            IdOrder = id;
        }
        private async  void button1_Click(object sender, EventArgs e)
        {
          var orders = new OrdersDTO
            {
                OrderID = this.IdOrder,
                CustomerName = cmboxCustomerName.Text,
                EmployeeName = cmboxEmployeeName.Text,
                OrderDate = Convert.ToDateTime(dateTimePickerOrderD.Value),
                RequiredDate = Convert.ToDateTime(dateTimePickerREquiredD.Value),
                ShippedDate = Convert.ToDateTime(dateTimePickerShippedD.Value),
                Freight = Convert.ToDecimal(txtboxFreight.Text),
                ShipName = txtboxShipName.Text,
                ShipAddress = txtboxShipAddress.Text,
                ShipCity = txtboxShipCity.Text,
                ShipRegion = txtboxShipRegion.Text,
                ShipPostalCode=txtboxShipPostalC.Text,
                ShipCountry = txtboxShipCountry.Text,
            };
            if (orders.OrderID == 0)
                 await _services.add(orders);
            else
                 await _services.Update(orders);
            this.Close();
        }

        private async void Crear_Ordenes_Load(object sender, EventArgs e)
        {
            var employees = await _employeesRepository.GetAll();
            var customers= await _customersRepository.GetAll();
            


            if (IdOrder > 0)
            {
                var orders = await _services.GetById(IdOrder);
                cmboxCustomerName.Text = orders.CustomerName;
                cmboxEmployeeName.Text = orders.EmployeeName;
                dateTimePickerOrderD.Value= Convert.ToDateTime(orders.OrderDate);
                dateTimePickerREquiredD.Value=Convert.ToDateTime(orders.RequiredDate);
                dateTimePickerShippedD.Value=Convert.ToDateTime(orders.ShippedDate);
                txtboxFreight.Text= orders.Freight.ToString();
                txtboxShipName.Text= orders.ShipName;
                txtboxShipAddress.Text= orders.ShipAddress;
                txtboxShipCity.Text= orders.ShipCity;
                txtboxShipRegion.Text= orders.ShipRegion;
                txtboxShipPostalC.Text= orders.ShipPostalCode;
                txtboxShipCountry.Text= orders.ShipCountry;


            }

            if(employees != null && customers != null ) 
            {
                cmboxCustomerName.DisplayMember = "CompanyName";
                cmboxCustomerName.ValueMember = "CustomerID";
                cmboxCustomerName.DataSource = customers.ToList();

                cmboxEmployeeName.DisplayMember = "LastName";
                cmboxEmployeeName.ValueMember = "EmployeeID";
                cmboxEmployeeName.DataSource = employees.ToList();

                
                
            }
            else
        
                {
                    MessageBox.Show("Error al cargar datos de empleados, customers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }
    }
}
