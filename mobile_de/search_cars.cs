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
    public partial class search_cars : Form
    {
        public search_cars()
        {
            InitializeComponent();
        }

        private void search_config_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void search_config_clear_button_Click(object sender, EventArgs e)
        {
            search_config_listBox.Items.Clear();
        }

        private void search_config_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_config_add_button_Click(object sender, EventArgs e)
        {

        }

        private void search_config_remove_button_Click(object sender, EventArgs e)
        {

        }

        private void search_config_create_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            create_search_config_file search_config_form = new create_search_config_file();
            search_config_form.StartPosition = FormStartPosition.Manual;
            search_config_form.Location = this.Location;
            search_config_form.Size = this.Size;
            search_config_form.ShowDialog();
        }

        private void scores_config_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void scores_config_clear_button_Click(object sender, EventArgs e)
        {

        }

        private void scores_config_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void scores_config_select_button_Click(object sender, EventArgs e)
        {

        }

        private void scores_config_create_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            create_scores_config_file scores_config_form = new create_scores_config_file();
            scores_config_form.StartPosition = FormStartPosition.Manual;
            scores_config_form.Location = this.Location;
            scores_config_form.Size = this.Size;
            scores_config_form.ShowDialog();
        }
    }
}
