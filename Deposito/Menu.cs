using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Deposito
{
    public partial class MDIMenu : Form
    {
        private int childFormNumber = 0;

        public MDIMenu(int tipo)
        {
            
            InitializeComponent();
            desabilitar(tipo);
        }

        public void desabilitar(int tipo)
        {
            treeView1.Nodes.Clear();
            cargarTreeView(tipo);
            if (tipo == 1)
            {
                HerramientasToolStripMenuItem.Enabled = true;
                mantenimientoToolStripMenuItem.Enabled = true;
                categoriasToolStripMenuItem.Enabled = true;
                camionesToolStripMenuItem.Enabled = true;
            }
            if (tipo == 2) // ventas
            {
                mantenimientoToolStripMenuItem.Enabled = false;
                HerramientasToolStripMenuItem.Enabled = false;
                camionesToolStripMenuItem.Enabled = false;
            }
            if (tipo == 3) // expedicion
            {
                HerramientasToolStripMenuItem.Enabled = false;
                mantenimientoToolStripMenuItem.Enabled = false;
                categoriasToolStripMenuItem.Enabled = false;
                camionesToolStripMenuItem.Enabled = false;
            }
        }

        private void cargarTreeView(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    treeView1.Nodes.Add("Nodo0", "Almacen");
                    treeView1.Nodes["Nodo0"].Nodes.Add("Productos");
                    treeView1.Nodes["Nodo0"].Nodes.Add("Categorias");
                    treeView1.Nodes.Add("Nodo1", "Ventas");
                    treeView1.Nodes["Nodo1"].Nodes.Add("Clientes");
                    treeView1.Nodes.Add("Nodo2", "Mantenimiento");
                    treeView1.Nodes["Nodo2"].Nodes.Add("Usuarios");
                    treeView1.Nodes.Add("Nodo3", "Trafico");
                    treeView1.Nodes["Nodo3"].Nodes.Add("Camiones");
                    treeView1.Nodes.Add("Nodo4", "Herramientas");
                    treeView1.Nodes["Nodo4"].Nodes.Add("Generar Backup");
                    break;
                case 2:
                    treeView1.Nodes.Add("Nodo0", "Almacen");
                    treeView1.Nodes["Nodo0"].Nodes.Add("Productos");
                    treeView1.Nodes["Nodo0"].Nodes.Add("Categorias");
                    treeView1.Nodes.Add("Nodo1", "Ventas");
                    treeView1.Nodes["Nodo1"].Nodes.Add("Clientes");
                    treeView1.Nodes.Add("Nodo4", "Herramientas");
                    treeView1.Nodes["Nodo4"].Nodes.Add("Generar Backup");
                    break;
                case 3:
                    treeView1.Nodes.Add("Nodo0", "Almacen");
                    treeView1.Nodes["Nodo0"].Nodes.Add("Productos");
                    treeView1.Nodes["Nodo0"].Nodes.Add("Categorias");
                    treeView1.Nodes.Add("Nodo3", "Trafico");
                    treeView1.Nodes["Nodo3"].Nodes.Add("Camiones");
                    treeView1.Nodes.Add("Nodo4", "Herramientas");
                    treeView1.Nodes["Nodo4"].Nodes.Add("Generar Backup");
                    break;
                default:
                    break;
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            inicio ini = new inicio();
            ini.ShowDialog();
            if (ini.login() != -1)
            {
                this.Enabled = true;
            }
            else { this.Close(); }
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            inicio ini = new inicio();
            ini.ShowDialog();

            if (ini.login() != -1)
            {
                this.Enabled = true;
                this.desabilitar(ini.tipo);
            }
            else { this.Close(); }
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorias cat = new Categorias();
            cat.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos pro = new Productos();
            pro.ShowDialog();
        }

        private void MDIMenu_Load(object sender, EventArgs e)
        {
            ImageList img = new ImageList();
            //img.Images.Add(Image.FromFile("C:\\Users\\Administrador\\Desktop\\WR\\Deposito\\Resources\\carpeta.jpg"));
            // img.Images.Add(Image.FromFile("C:\\Users\\wadef\\Desktop\\WR-Gestion\\WR-Gestion\\Deposito\\Resources\\carpeta.jpg"));
            img.Images.Add(Image.FromFile(" E:\\Facu\\programacion 3\\Proyecto\\Deposito\\Deposito\\Resources\\carpeta.jpg"));
            //img.Images.Add(Image.FromFile("C:\\Users\\Administrador\\Desktop\\WR-Gestion\\Deposito\\Resources\\carpeta.jpg"));

            treeView1.ImageList = img;
            foreach (TreeNode nodo in treeView1.Nodes)
            {
                nodo.ImageIndex = 0;
                nodo.SelectedImageIndex = 0;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Productos":
                    Productos pro = new Productos();
                    pro.ShowDialog();
                    break;
                case "Categorias":
                    Categorias cat = new Categorias();
                    cat.ShowDialog();
                    break;
                case "Clientes":
                    Clientes cli = new Clientes();
                    cli.ShowDialog();
                    break;
                case "Usuarios":
                    Usuarios u = new Usuarios();
                    u.ShowDialog();
                    break;
                case "Camiones":
                    Camiones cam = new Camiones();
                    cam.ShowDialog();
                    break;
                case "HacerBackUp":
                    Datos ad = new Datos();
                    ad.BackUp();
                    break;
            }

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            cli.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios();
            u.ShowDialog();
        }

        private void camionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Camiones cam = new Camiones();
            cam.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datos ad = new Datos();
            ad.BackUp();
        }

        private void ManualdeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datos ad = new Datos();
            ad.AbrirManualdeUsuario();
        }

        private void btnManualdeusuario_Click(object sender, EventArgs e)
        {
            Datos ad = new Datos();
            ad.AbrirManualdeUsuario();
        }

        private void ventasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ven.ShowDialog();
        }
    }
}
