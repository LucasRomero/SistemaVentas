namespace Deposito
{
    partial class MDIMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMenu));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Productos");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Categorias");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Almacen", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Clientes");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Nodo6");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Ventas", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Usuarios");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Mantenimiento", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Camiones");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Trafico", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("HacerBackUp");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Herramientas", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AlamacenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.camionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.camionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HerramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualdeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ImgMenu = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.AlamacenToolStripMenuItem,
            this.ventasToolStripMenuItem1,
            this.mantenimientoToolStripMenuItem,
            this.camionesToolStripMenuItem,
            this.HerramientasToolStripMenuItem,
            this.AyudaToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1028, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.salirToolStripMenuItem.Text = "Salir del sistema ";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // AlamacenToolStripMenuItem
            // 
            this.AlamacenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.categoriasToolStripMenuItem});
            this.AlamacenToolStripMenuItem.Name = "AlamacenToolStripMenuItem";
            this.AlamacenToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.AlamacenToolStripMenuItem.Text = "Almacen";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem1
            // 
            this.ventasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem2,
            this.clientesToolStripMenuItem});
            this.ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
            this.ventasToolStripMenuItem1.Size = new System.Drawing.Size(64, 24);
            this.ventasToolStripMenuItem1.Text = "Ventas";
            // 
            // ventasToolStripMenuItem2
            // 
            this.ventasToolStripMenuItem2.Name = "ventasToolStripMenuItem2";
            this.ventasToolStripMenuItem2.Size = new System.Drawing.Size(177, 26);
            this.ventasToolStripMenuItem2.Text = "Nuevo Pedido";
            this.ventasToolStripMenuItem2.Click += new System.EventHandler(this.ventasToolStripMenuItem2_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // camionesToolStripMenuItem
            // 
            this.camionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.camionesToolStripMenuItem1});
            this.camionesToolStripMenuItem.Name = "camionesToolStripMenuItem";
            this.camionesToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.camionesToolStripMenuItem.Text = "Trafico";
            // 
            // camionesToolStripMenuItem1
            // 
            this.camionesToolStripMenuItem1.Name = "camionesToolStripMenuItem1";
            this.camionesToolStripMenuItem1.Size = new System.Drawing.Size(149, 26);
            this.camionesToolStripMenuItem1.Text = "Camiones";
            this.camionesToolStripMenuItem1.Click += new System.EventHandler(this.camionesToolStripMenuItem1_Click);
            // 
            // HerramientasToolStripMenuItem
            // 
            this.HerramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem";
            this.HerramientasToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.HerramientasToolStripMenuItem.Text = "&Herramientas";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.optionsToolStripMenuItem.Text = "Generar Backup";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // AyudaToolStripMenuItem
            // 
            this.AyudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManualdeUsuarioToolStripMenuItem,
            this.toolStripSeparator8});
            this.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem";
            this.AyudaToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.AyudaToolStripMenuItem.Text = "Ay&uda";
            // 
            // ManualdeUsuarioToolStripMenuItem
            // 
            this.ManualdeUsuarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ManualdeUsuarioToolStripMenuItem.Image")));
            this.ManualdeUsuarioToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.ManualdeUsuarioToolStripMenuItem.Name = "ManualdeUsuarioToolStripMenuItem";
            this.ManualdeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.ManualdeUsuarioToolStripMenuItem.Text = "&Manual de Usuario";
            this.ManualdeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.ManualdeUsuarioToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(205, 6);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 32);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.MaximumSize = new System.Drawing.Size(310, 495);
            this.treeView1.MinimumSize = new System.Drawing.Size(310, 495);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Nodo1";
            treeNode1.Text = "Productos";
            treeNode2.Name = "Nodo2";
            treeNode2.Text = "Categorias";
            treeNode3.Name = "Nodo0";
            treeNode3.Text = "Almacen";
            treeNode4.Name = "Nodo4";
            treeNode4.Text = "Clientes";
            treeNode5.Name = "Nodo6";
            treeNode5.Text = "Nodo6";
            treeNode6.Name = "Nodo3";
            treeNode6.Text = "Ventas";
            treeNode7.Name = "Nodo8";
            treeNode7.Text = "Usuarios";
            treeNode8.Name = "Nodo7";
            treeNode8.Text = "Mantenimiento";
            treeNode9.Name = "Nodo1";
            treeNode9.Text = "Camiones";
            treeNode10.Name = "Nodo0";
            treeNode10.Text = "Trafico";
            treeNode11.Name = "Nodo2";
            treeNode11.Text = "HacerBackUp";
            treeNode12.Name = "Nodo1";
            treeNode12.Text = "Herramientas";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode8,
            treeNode10,
            treeNode12});
            this.treeView1.Size = new System.Drawing.Size(310, 495);
            this.treeView1.TabIndex = 4;
            // 
            // ImgMenu
            // 
            this.ImgMenu.Image = global::Deposito.Properties.Resources.waterview_connection;
            this.ImgMenu.Location = new System.Drawing.Point(317, 32);
            this.ImgMenu.Name = "ImgMenu";
            this.ImgMenu.Size = new System.Drawing.Size(706, 495);
            this.ImgMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgMenu.TabIndex = 6;
            this.ImgMenu.TabStop = false;
            // 
            // MDIMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1028, 532);
            this.Controls.Add(this.ImgMenu);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDIMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión WR";
            this.Load += new System.EventHandler(this.MDIMenu_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem HerramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AyudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManualdeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AlamacenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem camionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camionesToolStripMenuItem1;
        private System.Windows.Forms.PictureBox ImgMenu;
    }
}



