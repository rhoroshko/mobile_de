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

        private void SetButtonsEditable()
        {
            search_config_remove_button.Enabled = (search_config_listBox.SelectedItems.Count > 0);
            search_cars_start_button.Enabled = (search_config_listBox.Items.Count > 0 && scores_config_listBox.Items.Count > 0);
        }

        private void search_cars_Load(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        //search config
        private void search_config_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void search_config_clear_button_Click(object sender, EventArgs e)
        {
            search_config_listBox.Items.Clear();

            SetButtonsEditable();
        }

        private void search_config_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_config_add_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "JSON file (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    if (!search_config_listBox.Items.Contains(file))
                    {
                        search_config_listBox.Items.Add(file);
                    }
                }
            }

            SetButtonsEditable();
        }

        private void search_config_remove_button_Click(object sender, EventArgs e)
        {
            while (search_config_listBox.SelectedItems.Count > 0)
            {
                string item = (string)search_config_listBox.SelectedItems[0];
                search_config_listBox.Items.Remove(item);
            }

            SetButtonsEditable();
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

        //scores_config
        private void scores_config_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void scores_config_clear_button_Click(object sender, EventArgs e)
        {
            scores_config_listBox.Items.Clear();

            SetButtonsEditable();
        }

        private void scores_config_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void scores_config_select_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "JSON file (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (scores_config_listBox.Items.Count > 0)
                {
                    var confirmResult = MessageBox.Show($"Конфигурация оценек уже выбрана. Использовать новую,"
                                                        , ""
                                                        , MessageBoxButtons.YesNoCancel);
                    if (confirmResult == DialogResult.Yes)
                    {
                        scores_config_listBox.Items.Clear();
                    }
                    else
                    {
                        return;
                    }
                }

                scores_config_listBox.Items.Add(openFileDialog.FileName);
            }

            SetButtonsEditable();
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


        //start search cars
        private void search_cars_start_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Magic is happening...{Environment.NewLine}Output file:{Environment.NewLine}{saveFileDialog.FileName}"
                    ,""
                    ,MessageBoxButtons.OK);
                //TODO

                
            }
        }
    }
}
