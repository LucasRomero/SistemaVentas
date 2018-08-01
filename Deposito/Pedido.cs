using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deposito
{
    public partial class Pedido : Form
    {
        public Pedido()
        {
            InitializeComponent();
            monthCalendar1.Visible = false;
        }

        private void btncalendario_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFecha.Text = monthCalendar1.SelectionStart.ToString(); // ver que no se vea el horario
            monthCalendar1.Visible = false;
        }
    }
}
