
namespace GasolineraPUMA
{
    partial class Frm_BuscarProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BuscarProductos));
            this.rbServicio = new System.Windows.Forms.RadioButton();
            this.rbRepuesto = new System.Windows.Forms.RadioButton();
            this.rbOtrosProductos = new System.Windows.Forms.RadioButton();
            this.btn_Gestionar = new System.Windows.Forms.Button();
            this.dgv_BuscarProducto = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BuscarProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // rbServicio
            // 
            this.rbServicio.AutoSize = true;
            this.rbServicio.Location = new System.Drawing.Point(435, 117);
            this.rbServicio.Name = "rbServicio";
            this.rbServicio.Size = new System.Drawing.Size(63, 17);
            this.rbServicio.TabIndex = 82;
            this.rbServicio.TabStop = true;
            this.rbServicio.Text = "Servicio";
            this.rbServicio.UseVisualStyleBackColor = true;
            // 
            // rbRepuesto
            // 
            this.rbRepuesto.AutoSize = true;
            this.rbRepuesto.Location = new System.Drawing.Point(319, 117);
            this.rbRepuesto.Name = "rbRepuesto";
            this.rbRepuesto.Size = new System.Drawing.Size(71, 17);
            this.rbRepuesto.TabIndex = 81;
            this.rbRepuesto.TabStop = true;
            this.rbRepuesto.Text = "Repuesto";
            this.rbRepuesto.UseVisualStyleBackColor = true;
            // 
            // rbOtrosProductos
            // 
            this.rbOtrosProductos.AutoSize = true;
            this.rbOtrosProductos.Location = new System.Drawing.Point(542, 117);
            this.rbOtrosProductos.Name = "rbOtrosProductos";
            this.rbOtrosProductos.Size = new System.Drawing.Size(101, 17);
            this.rbOtrosProductos.TabIndex = 80;
            this.rbOtrosProductos.TabStop = true;
            this.rbOtrosProductos.Text = "Otros Productos";
            this.rbOtrosProductos.UseVisualStyleBackColor = true;
            // 
            // btn_Gestionar
            // 
            this.btn_Gestionar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gestionar.Location = new System.Drawing.Point(667, 181);
            this.btn_Gestionar.Name = "btn_Gestionar";
            this.btn_Gestionar.Size = new System.Drawing.Size(87, 61);
            this.btn_Gestionar.TabIndex = 79;
            this.btn_Gestionar.Text = "GESTIONAR PRODUCTOS";
            this.btn_Gestionar.UseVisualStyleBackColor = true;
            // 
            // dgv_BuscarProducto
            // 
            this.dgv_BuscarProducto.AllowUserToOrderColumns = true;
            this.dgv_BuscarProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv_BuscarProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BuscarProducto.Location = new System.Drawing.Point(299, 147);
            this.dgv_BuscarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_BuscarProducto.Name = "dgv_BuscarProducto";
            this.dgv_BuscarProducto.ReadOnly = true;
            this.dgv_BuscarProducto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_BuscarProducto.RowTemplate.Height = 24;
            this.dgv_BuscarProducto.Size = new System.Drawing.Size(351, 149);
            this.dgv_BuscarProducto.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 77;
            this.label1.Text = "BUSCAR:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(418, 81);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(245, 13);
            this.txtBuscar.TabIndex = 76;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(361, 98);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 1);
            this.panel3.TabIndex = 75;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(725, 34);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 35);
            this.button4.TabIndex = 74;
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(394, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 39);
            this.label2.TabIndex = 73;
            this.label2.Text = " PRODUCTOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(26, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 296);
            this.panel1.TabIndex = 72;
            // 
            // Frm_BuscarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 338);
            this.Controls.Add(this.rbServicio);
            this.Controls.Add(this.rbRepuesto);
            this.Controls.Add(this.rbOtrosProductos);
            this.Controls.Add(this.btn_Gestionar);
            this.Controls.Add(this.dgv_BuscarProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_BuscarProductos";
            this.Text = "Frm_BuscarProductos";
            this.Load += new System.EventHandler(this.Frm_BuscarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BuscarProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbServicio;
        private System.Windows.Forms.RadioButton rbRepuesto;
        private System.Windows.Forms.RadioButton rbOtrosProductos;
        private System.Windows.Forms.Button btn_Gestionar;
        private System.Windows.Forms.DataGridView dgv_BuscarProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}