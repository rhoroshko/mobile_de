using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobile_de
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            this.ActiveControl = search_cars_button;
        }

        private void welcome_main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void create_search_config_file_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            create_search_config_file search_config_form = new create_search_config_file();
            search_config_form.StartPosition = FormStartPosition.Manual;
            search_config_form.Location = this.Location;
            search_config_form.Size = this.Size;
            search_config_form.ShowDialog();
        }

        private void create_scores_config_file_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            create_scores_config_file scores_config_form = new create_scores_config_file();
            scores_config_form.StartPosition = FormStartPosition.Manual;
            scores_config_form.Location = this.Location;
            scores_config_form.Size = this.Size;
            scores_config_form.ShowDialog();
        }

        private void search_cars_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            search_cars search_cars_form = new search_cars();
            search_cars_form.StartPosition = FormStartPosition.Manual;
            search_cars_form.Location = this.Location;
            search_cars_form.Size = this.Size;
            search_cars_form.ShowDialog();
        }
    }
}
