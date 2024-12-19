using Microsoft.Extensions.DependencyInjection;
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
    public partial class MenuInicio : Form
    {
        //private readonly ServiceProvider _serviceProvider;
        private readonly IServiceProvider _provider;
        public MenuInicio(/*ServiceProvider serviceProvider*/ IServiceProvider provider)
        {
            InitializeComponent();
            //_serviceProvider = serviceProvider;
            _provider = provider;
        }

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(147, 52);
            label1.Name = "label1";
            label1.Size = new Size(126, 30);
            label1.TabIndex = 0;
            label1.Text = "NorthWind";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 117);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Menu Inicio";
            // 
            // button1
            // 
            button1.Location = new Point(111, 151);
            button1.Name = "button1";
            button1.Size = new Size(218, 60);
            button1.TabIndex = 2;
            button1.Text = "Productos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(111, 217);
            button2.Name = "button2";
            button2.Size = new Size(218, 60);
            button2.TabIndex = 3;
            button2.Text = "Categorias";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(111, 283);
            button3.Name = "button3";
            button3.Size = new Size(218, 60);
            button3.TabIndex = 4;
            button3.Text = "Suplidores";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(111, 349);
            button4.Name = "button4";
            button4.Size = new Size(218, 60);
            button4.TabIndex = 5;
            button4.Text = "Ordenes";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(123, 461);
            button5.Name = "button5";
            button5.Size = new Size(192, 31);
            button5.TabIndex = 6;
            button5.Text = "Cerrar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // MenuInicio
            // 
            ClientSize = new Size(435, 514);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MenuInicio";
            Text = "Menu Inicio";
            Load += MenuInicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Suplidor = _provider.GetRequiredService<SuplidorForm>();
            Suplidor.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var categoria = _provider.GetRequiredService<CategoriesForm>();
            categoria.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ordenes = _provider.GetRequiredService<OrdersForm>();
            ordenes.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Productos = _provider.GetRequiredService<ProductsForm>();
            Productos.Show();
        }

        private void MenuInicio_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
