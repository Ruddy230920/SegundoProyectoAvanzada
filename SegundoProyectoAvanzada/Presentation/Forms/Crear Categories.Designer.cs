namespace SegundoProyectoAvanzada
{
    partial class Crear_Categories
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxCategoria = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            txtboxNombreCategoria = new TextBox();
            txtboxDescripcionCategoria = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCategoria).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCategoria
            // 
            pictureBoxCategoria.Location = new Point(183, 118);
            pictureBoxCategoria.Name = "pictureBoxCategoria";
            pictureBoxCategoria.Size = new Size(146, 96);
            pictureBoxCategoria.TabIndex = 0;
            pictureBoxCategoria.TabStop = false;
            pictureBoxCategoria.Click += pictureBoxCategoria_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(142, 50);
            label1.Name = "label1";
            label1.Size = new Size(229, 30);
            label1.TabIndex = 1;
            label1.Text = "Creador de Categorias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(98, 260);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre Categoria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(114, 326);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 3;
            label3.Text = "Descripcion";
            // 
            // button1
            // 
            button1.Location = new Point(183, 384);
            button1.Name = "button1";
            button1.Size = new Size(146, 38);
            button1.TabIndex = 4;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtboxNombreCategoria
            // 
            txtboxNombreCategoria.Location = new Point(215, 257);
            txtboxNombreCategoria.Name = "txtboxNombreCategoria";
            txtboxNombreCategoria.Size = new Size(167, 23);
            txtboxNombreCategoria.TabIndex = 5;
            // 
            // txtboxDescripcionCategoria
            // 
            txtboxDescripcionCategoria.Location = new Point(215, 323);
            txtboxDescripcionCategoria.Name = "txtboxDescripcionCategoria";
            txtboxDescripcionCategoria.Size = new Size(167, 23);
            txtboxDescripcionCategoria.TabIndex = 6;
            // 
            // Crear_Categories
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 494);
            Controls.Add(txtboxDescripcionCategoria);
            Controls.Add(txtboxNombreCategoria);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBoxCategoria);
            Name = "Crear_Categories";
            Text = "Crear_Categories";
            Load += Crear_Categories_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCategoria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxCategoria;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox txtboxNombreCategoria;
        private TextBox txtboxDescripcionCategoria;
    }
}