
namespace GasolineraPUMA
{
    partial class Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Producto));
            this.p_header = new System.Windows.Forms.Panel();
            this.btn_Salir = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbx_Proveedor = new System.Windows.Forms.ComboBox();
            this.cmbx_Categoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PrecioProducto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_CantidadProducto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_DescProducto = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_NombreProducto = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_IDProducto = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btn_Eliminar = new System.Windows.Forms.PictureBox();
            this.btn_LimpiarPantallaP = new System.Windows.Forms.PictureBox();
            this.btn_Buscar = new System.Windows.Forms.PictureBox();
            this.btn_Modificar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.p_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Eliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_LimpiarPantallaP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Buscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Modificar)).BeginInit();
            this.SuspendLayout();
            // 
            // p_header
            // 
            this.p_header.BackColor = System.Drawing.Color.LightCoral;
            this.p_header.Controls.Add(this.btn_Salir);
            this.p_header.Controls.Add(this.pictureBox1);
            this.p_header.Location = new System.Drawing.Point(0, 0);
            this.p_header.Name = "p_header";
            this.p_header.Size = new System.Drawing.Size(1158, 104);
            this.p_header.TabIndex = 47;
            // 
            // btn_Salir
            // 
            this.btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Salir.Image")));
            this.btn_Salir.Location = new System.Drawing.Point(1075, 21);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(51, 54);
            this.btn_Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Salir.TabIndex = 90;
            this.btn_Salir.TabStop = false;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // cmbx_Proveedor
            // 
            this.cmbx_Proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_Proveedor.FormattingEnabled = true;
            this.cmbx_Proveedor.Location = new System.Drawing.Point(174, 402);
            this.cmbx_Proveedor.Name = "cmbx_Proveedor";
            this.cmbx_Proveedor.Size = new System.Drawing.Size(461, 21);
            this.cmbx_Proveedor.TabIndex = 87;
            // 
            // cmbx_Categoria
            // 
            this.cmbx_Categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx_Categoria.FormattingEnabled = true;
            this.cmbx_Categoria.Location = new System.Drawing.Point(174, 353);
            this.cmbx_Categoria.Name = "cmbx_Categoria";
            this.cmbx_Categoria.Size = new System.Drawing.Size(461, 21);
            this.cmbx_Categoria.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 85;
            this.label2.Text = "Precio";
            // 
            // txt_PrecioProducto
            // 
            this.txt_PrecioProducto.Location = new System.Drawing.Point(174, 451);
            this.txt_PrecioProducto.Name = "txt_PrecioProducto";
            this.txt_PrecioProducto.Size = new System.Drawing.Size(461, 20);
            this.txt_PrecioProducto.TabIndex = 84;
            this.txt_PrecioProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PrecioProducto_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(48, 403);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 16);
            this.label12.TabIndex = 78;
            this.label12.Text = "Proveedor";
            // 
            // txt_CantidadProducto
            // 
            this.txt_CantidadProducto.Location = new System.Drawing.Point(174, 498);
            this.txt_CantidadProducto.Name = "txt_CantidadProducto";
            this.txt_CantidadProducto.Size = new System.Drawing.Size(461, 20);
            this.txt_CantidadProducto.TabIndex = 77;
            this.txt_CantidadProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CantidadProducto_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(49, 502);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 16);
            this.label19.TabIndex = 76;
            this.label19.Text = "Cantidad";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(48, 354);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 16);
            this.label21.TabIndex = 75;
            this.label21.Text = "Categoria";
            // 
            // txt_DescProducto
            // 
            this.txt_DescProducto.Location = new System.Drawing.Point(174, 265);
            this.txt_DescProducto.Multiline = true;
            this.txt_DescProducto.Name = "txt_DescProducto";
            this.txt_DescProducto.Size = new System.Drawing.Size(461, 63);
            this.txt_DescProducto.TabIndex = 74;
            this.txt_DescProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DescProducto_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(48, 265);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 16);
            this.label22.TabIndex = 73;
            this.label22.Text = "Descripcion";
            // 
            // txt_NombreProducto
            // 
            this.txt_NombreProducto.Location = new System.Drawing.Point(174, 211);
            this.txt_NombreProducto.Name = "txt_NombreProducto";
            this.txt_NombreProducto.Size = new System.Drawing.Size(461, 20);
            this.txt_NombreProducto.TabIndex = 72;
            this.txt_NombreProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_NombreProducto_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(48, 211);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 16);
            this.label23.TabIndex = 71;
            this.label23.Text = "Nombre";
            // 
            // txt_IDProducto
            // 
            this.txt_IDProducto.Location = new System.Drawing.Point(174, 161);
            this.txt_IDProducto.Name = "txt_IDProducto";
            this.txt_IDProducto.Size = new System.Drawing.Size(461, 20);
            this.txt_IDProducto.TabIndex = 70;
            this.txt_IDProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_IDProducto_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(48, 161);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(21, 16);
            this.label27.TabIndex = 69;
            this.label27.Text = "ID";
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Eliminar.Image")));
            this.btn_Eliminar.Location = new System.Drawing.Point(854, 344);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(79, 71);
            this.btn_Eliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Eliminar.TabIndex = 90;
            this.btn_Eliminar.TabStop = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click_1);
            // 
            // btn_LimpiarPantallaP
            // 
            this.btn_LimpiarPantallaP.Image = ((System.Drawing.Image)(resources.GetObject("btn_LimpiarPantallaP.Image")));
            this.btn_LimpiarPantallaP.Location = new System.Drawing.Point(854, 439);
            this.btn_LimpiarPantallaP.Name = "btn_LimpiarPantallaP";
            this.btn_LimpiarPantallaP.Size = new System.Drawing.Size(79, 71);
            this.btn_LimpiarPantallaP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_LimpiarPantallaP.TabIndex = 91;
            this.btn_LimpiarPantallaP.TabStop = false;
            this.btn_LimpiarPantallaP.Click += new System.EventHandler(this.btn_LimpiarPantallaP_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(854, 142);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(79, 62);
            this.btn_Buscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Buscar.TabIndex = 92;
            this.btn_Buscar.TabStop = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Modificar.Image")));
            this.btn_Modificar.Location = new System.Drawing.Point(854, 238);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(79, 71);
            this.btn_Modificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Modificar.TabIndex = 93;
            this.btn_Modificar.TabStop = false;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(953, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 94;
            this.label1.Text = "Buscar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(953, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 18);
            this.label3.TabIndex = 95;
            this.label3.Text = "Editar Producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(953, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 18);
            this.label4.TabIndex = 96;
            this.label4.Text = "Eliminar Producto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(953, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 18);
            this.label5.TabIndex = 97;
            this.label5.Text = "Limpiar Pantalla";
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 675);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.btn_LimpiarPantallaP);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.cmbx_Proveedor);
            this.Controls.Add(this.cmbx_Categoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_PrecioProducto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_CantidadProducto);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txt_DescProducto);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txt_NombreProducto);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txt_IDProducto);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.p_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Productos";
            this.Load += new System.EventHandler(this.Frm_Productos_Load);
            this.p_header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Eliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_LimpiarPantallaP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Buscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Modificar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel p_header;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbx_Proveedor;
        private System.Windows.Forms.ComboBox cmbx_Categoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_PrecioProducto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_CantidadProducto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_DescProducto;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_NombreProducto;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_IDProducto;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.PictureBox btn_Salir;
        private System.Windows.Forms.PictureBox btn_Eliminar;
        private System.Windows.Forms.PictureBox btn_LimpiarPantallaP;
        private System.Windows.Forms.PictureBox btn_Buscar;
        private System.Windows.Forms.PictureBox btn_Modificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}