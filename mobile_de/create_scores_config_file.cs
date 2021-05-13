using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobile_de
{
    public partial class create_scores_config_file : Form
    {
        public create_scores_config_file()
        {
            InitializeComponent();
            SetButtonsEditable();
        }

        List<string> unselected_features = System.IO.File.ReadLines(@"C:\Users\SoMaL\documents\visual studio 2015\Projects\mobile_de\mobile_de\data\features.txt").ToList();
        List<string> selected_1_features = new List<string>();
        List<string> selected_2_features = new List<string>();
        List<string> selected_3_features = new List<string>();
        List<string> selected_4_features = new List<string>();
        List<string> selected_5_features = new List<string>();
        List<string> selected_6_features = new List<string>();
        List<string> selected_7_features = new List<string>();
        List<string> selected_8_features = new List<string>();
        List<string> selected_9_features = new List<string>();
        List<string> selected_10_features = new List<string>();

        private void create_scores_config_file_Load(object sender, EventArgs e)
        {
            UpdateListBoxFromList(unselected_1_listBox, unselected_features);
            UpdateListBoxFromList(unselected_2_listBox, unselected_features);
            UpdateListBoxFromList(unselected_3_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_4_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_5_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_6_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_7_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_8_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_9_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_10_listBox, unselected_features);

            SetButtonsEditable();
        }

        // Enable and disable buttons.
        private void SetButtonsEditable()
        {
            select_1_button.Enabled = (unselected_1_listBox.SelectedItems.Count > 0);
            select_2_button.Enabled = (unselected_2_listBox.SelectedItems.Count > 0);
            select_3_button.Enabled = (unselected_3_listBox.SelectedItems.Count > 0);
            //select_4_button.Enabled = (unselected_4_listBox.SelectedItems.Count > 0);
            //select_5_button.Enabled = (unselected_5_listBox.SelectedItems.Count > 0);
            //select_6_button.Enabled = (unselected_6_listBox.SelectedItems.Count > 0);
            //select_7_button.Enabled = (unselected_7_listBox.SelectedItems.Count > 0);
            //select_8_button.Enabled = (unselected_8_listBox.SelectedItems.Count > 0);
            //select_9_button.Enabled = (unselected_9_listBox.SelectedItems.Count > 0);
            //select_10_button.Enabled = (unselected_10_listBox.SelectedItems.Count > 0);

            select_all_1_button.Enabled = (unselected_1_listBox.Items.Count > 0);
            select_all_2_button.Enabled = (unselected_2_listBox.Items.Count > 0);
            select_all_3_button.Enabled = (unselected_3_listBox.Items.Count > 0);
            //select_all_4_button.Enabled = (unselected_4_listBox.Items.Count > 0);
            //select_all_5_button.Enabled = (unselected_5_listBox.Items.Count > 0);
            //select_all_6_button.Enabled = (unselected_6_listBox.Items.Count > 0);
            //select_all_7_button.Enabled = (unselected_7_listBox.Items.Count > 0);
            //select_all_8_button.Enabled = (unselected_8_listBox.Items.Count > 0);
            //select_all_9_button.Enabled = (unselected_9_listBox.Items.Count > 0);
            //select_all_10_button.Enabled = (unselected_10_listBox.Items.Count > 0);

            unselect_1_button.Enabled = (selected_1_listBox.SelectedItems.Count > 0);
            unselect_2_button.Enabled = (selected_2_listBox.SelectedItems.Count > 0);
            unselect_3_button.Enabled = (selected_3_listBox.SelectedItems.Count > 0);
            //unselect_4_button.Enabled = (selected_4_listBox.SelectedItems.Count > 0);
            //unselect_5_button.Enabled = (selected_5_listBox.SelectedItems.Count > 0);
            //unselect_6_button.Enabled = (selected_6_listBox.SelectedItems.Count > 0);
            //unselect_7_button.Enabled = (selected_7_listBox.SelectedItems.Count > 0);
            //unselect_8_button.Enabled = (selected_8_listBox.SelectedItems.Count > 0);
            //unselect_9_button.Enabled = (selected_9_listBox.SelectedItems.Count > 0);
            //unselect_10_button.Enabled = (selected_10_listBox.SelectedItems.Count > 0);

            unselect_all_1_button.Enabled = (selected_1_listBox.Items.Count > 0);
            unselect_all_2_button.Enabled = (selected_2_listBox.Items.Count > 0);
            unselect_all_3_button.Enabled = (selected_3_listBox.Items.Count > 0);
            //unselect_all_4_button.Enabled = (selected_4_listBox.Items.Count > 0);
            //unselect_all_5_button.Enabled = (selected_5_listBox.Items.Count > 0);
            //unselect_all_6_button.Enabled = (selected_6_listBox.Items.Count > 0);
            //unselect_all_7_button.Enabled = (selected_7_listBox.Items.Count > 0);
            //unselect_all_8_button.Enabled = (selected_8_listBox.Items.Count > 0);
            //unselect_all_9_button.Enabled = (selected_9_listBox.Items.Count > 0);
            //unselect_all_10_button.Enabled = (selected_10_listBox.Items.Count > 0);
        }

        // Move selected items from one ListBox to another.
        private void MoveSelectedItems(ListBox listBox_from, ListBox listBox_to)
        {
            while (listBox_from.SelectedItems.Count > 0)
            {
                string item = (string)listBox_from.SelectedItems[0];
                listBox_to.Items.Add(item);
                listBox_from.Items.Remove(item);

                if (
                       listBox_from == unselected_1_listBox
                    || listBox_from == unselected_2_listBox
                    || listBox_from == unselected_3_listBox
                //|| listBox_from == unselected_4_listBox
                //|| listBox_from == unselected_5_listBox
                //|| listBox_from == unselected_6_listBox
                //|| listBox_from == unselected_7_listBox
                //|| listBox_from == unselected_8_listBox
                //|| listBox_from == unselected_9_listBox
                //|| listBox_from == unselected_10_listBox
                )
                {
                    unselected_features.Remove(item);
                }
                else if (listBox_from == selected_1_listBox)
                {
                    selected_1_features.Remove(item);
                }
                else if (listBox_from == selected_2_listBox)
                {
                    selected_2_features.Remove(item);
                }
                else if (listBox_from == selected_3_listBox)
                {
                    selected_3_features.Remove(item);
                }


                if (
                       listBox_to == unselected_1_listBox
                    || listBox_to == unselected_2_listBox
                    || listBox_to == unselected_3_listBox
                //|| listBox_to == unselected_4_listBox
                //|| listBox_to == unselected_5_listBox
                //|| listBox_to == unselected_6_listBox
                //|| listBox_to == unselected_7_listBox
                //|| listBox_to == unselected_8_listBox
                //|| listBox_to == unselected_9_listBox
                //|| listBox_to == unselected_10_listBox
                )
                {
                    unselected_features.Add(item);
                }
                else if (listBox_to == selected_1_listBox)
                {
                    selected_1_features.Add(item);
                }
                else if (listBox_to == selected_2_listBox)
                {
                    selected_2_features.Add(item);
                }
                else if (listBox_to == selected_3_listBox)
                {
                    selected_3_features.Add(item);
                }
            }
            UpdateListBoxFromList(unselected_1_listBox, unselected_features);
            UpdateListBoxFromList(unselected_2_listBox, unselected_features);
            UpdateListBoxFromList(unselected_3_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_4_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_5_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_6_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_7_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_8_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_9_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_10_listBox, unselected_features);
            SetButtonsEditable();
        }

        // Move all items from one ListBox to another.
        private void MoveAllItems(ListBox listBox_from, ListBox listBox_to)
        {
            if (
                   listBox_from == unselected_1_listBox
                || listBox_from == unselected_2_listBox
                || listBox_from == unselected_3_listBox
            //|| listBox_from == unselected_4_listBox
            //|| listBox_from == unselected_5_listBox
            //|| listBox_from == unselected_6_listBox
            //|| listBox_from == unselected_7_listBox
            //|| listBox_from == unselected_8_listBox
            //|| listBox_from == unselected_9_listBox
            //|| listBox_from == unselected_10_listBox
            )
            {
                foreach (string item in listBox_from.Items)
                {
                    unselected_features.Remove(item);
                }
            }
            else if (listBox_from == selected_1_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_1_features.Remove(item);
                }
            }
            else if (listBox_from == selected_2_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_2_features.Remove(item);
                }
            }
            else if (listBox_from == selected_3_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_3_features.Remove(item);
                }
            }


            if (
                   listBox_to == unselected_1_listBox
                || listBox_to == unselected_2_listBox
                || listBox_to == unselected_3_listBox
            //|| listBox_to == unselected_4_listBox
            //|| listBox_to == unselected_5_listBox
            //|| listBox_to == unselected_6_listBox
            //|| listBox_to == unselected_7_listBox
            //|| listBox_to == unselected_8_listBox
            //|| listBox_to == unselected_9_listBox
            //|| listBox_to == unselected_10_listBox
            )
            {
                foreach (string item in listBox_from.Items)
                {
                    unselected_features.Add(item);
                }
            }
            else if (listBox_to == selected_1_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_1_features.Add(item);
                }
            }
            else if (listBox_to == selected_2_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_2_features.Add(item);
                }
            }
            else if (listBox_to == selected_3_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_3_features.Add(item);
                }
            }


            listBox_to.Items.AddRange(listBox_from.Items);
            listBox_from.Items.Clear();

            UpdateListBoxFromList(unselected_1_listBox, unselected_features);
            UpdateListBoxFromList(unselected_2_listBox, unselected_features);
            UpdateListBoxFromList(unselected_3_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_4_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_5_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_6_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_7_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_8_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_9_listBox, unselected_features);
            //UpdateListBoxFromList(unselected_10_listBox, unselected_features);
            SetButtonsEditable();
        }

        //Update ListBox from list object
        private void UpdateListBoxFromList(ListBox listBox, List<string> list)
        {
            listBox.Items.Clear();
            foreach (string listBoxItem in list)
            {
                listBox.Items.Add(listBoxItem);
            }
        }

        ////Update list object from ListBox
        //private void UpdateListFromListBox(List<string> list, ListBox listBox)
        //{
        //    list.Clear();
        //    foreach (string listBoxItem in listBox.Items)
        //    {
        //        list.Add(listBoxItem);
        //    }
        //}



        private void load_scores_config_file_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON file (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //TODO
            }
        }

        private void save_scores_config_file_button_Click(object sender, EventArgs e)
        {
            string scores_config = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, scores_config);
            }
        }

        private void clear_scores_config_button_Click(object sender, EventArgs e)
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

        private void search_cars_button_Click(object sender, EventArgs e)
        {

        }


        //budget
        private void budget_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void budget_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void budget_clean_button_Click(object sender, EventArgs e)
        {

        }


        //score 1
        private void score_1_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_1_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_1_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_1_filter_textBox.Text.ToLower()))
                {
                    unselected_1_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_1_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_1_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_1_listBox, selected_1_listBox);
            unselected_1_filter_textBox.Text = String.Empty;
        }

        private void selected_1_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_1_listBox.Items.Clear();

            foreach (string str in selected_1_features)
            {
                if (str.ToLower().Contains(selected_1_filter_textBox.Text.ToLower()))
                {
                    selected_1_listBox.Items.Add(str);
                }
            }
        }

        private void selected_1_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_1_listBox, unselected_1_listBox);
            selected_1_filter_textBox.Text = String.Empty;
        }

        private void selected_1_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_1_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_1_listBox, selected_1_listBox);
            unselected_1_filter_textBox.Text = String.Empty;
        }

        private void select_all_1_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_1_listBox, selected_1_listBox);
            unselected_1_filter_textBox.Text = String.Empty;
        }

        private void unselect_1_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_1_listBox, unselected_1_listBox);
            selected_1_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_1_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_1_listBox, unselected_1_listBox);
            selected_1_filter_textBox.Text = String.Empty;
        }



        //score 2
        private void score_2_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_2_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_2_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_2_filter_textBox.Text.ToLower()))
                {
                    unselected_2_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_2_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_2_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_2_listBox, selected_2_listBox);
            unselected_2_filter_textBox.Text = String.Empty;
        }

        private void selected_2_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_2_listBox.Items.Clear();

            foreach (string str in selected_2_features)
            {
                if (str.ToLower().Contains(selected_2_filter_textBox.Text.ToLower()))
                {
                    selected_2_listBox.Items.Add(str);
                }
            }
        }

        private void selected_2_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_2_listBox, unselected_2_listBox);
            selected_2_filter_textBox.Text = String.Empty;
        }

        private void selected_2_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_2_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_2_listBox, selected_2_listBox);
            unselected_2_filter_textBox.Text = String.Empty;
        }

        private void select_all_2_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_2_listBox, selected_2_listBox);
            unselected_2_filter_textBox.Text = String.Empty;
        }

        private void unselect_2_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_2_listBox, unselected_2_listBox);
            selected_2_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_2_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_2_listBox, unselected_2_listBox);
            selected_2_filter_textBox.Text = String.Empty;
        }



        //score 3
        private void score_3_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_3_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_3_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_3_filter_textBox.Text.ToLower()))
                {
                    unselected_3_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_3_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_3_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_3_listBox, selected_3_listBox);
            unselected_3_filter_textBox.Text = String.Empty;
        }

        private void selected_3_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_3_listBox.Items.Clear();

            foreach (string str in selected_3_features)
            {
                if (str.ToLower().Contains(selected_3_filter_textBox.Text.ToLower()))
                {
                    selected_3_listBox.Items.Add(str);
                }
            }
        }

        private void selected_3_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_3_listBox, unselected_3_listBox);
            selected_3_filter_textBox.Text = String.Empty;
        }

        private void selected_3_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_3_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_3_listBox, selected_3_listBox);
            unselected_3_filter_textBox.Text = String.Empty;
        }

        private void select_all_3_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_3_listBox, selected_3_listBox);
            unselected_3_filter_textBox.Text = String.Empty;
        }

        private void unselect_3_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_3_listBox, unselected_3_listBox);
            selected_3_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_3_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_3_listBox, unselected_3_listBox);
            selected_3_filter_textBox.Text = String.Empty;
        }



        //score 2
    }
}