using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            SetAllListBoxesBackgoundColor();
        }

        List<string> init_unselected_features = System.IO.File.ReadLines(Path.Combine(Environment.CurrentDirectory, @".\data\features.txt")).ToList();
        List<string> unselected_features = new List<string>();

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

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        private void create_scores_config_file_Load(object sender, EventArgs e)
        {
            SendMessage(budget_textBox.Handle, EM_SETCUEBANNER, 0, "Введите Ваш бюджет");

            SendMessage(unselected_1_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_2_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_3_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_4_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_5_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_6_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_7_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_8_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_9_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(unselected_10_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");

            SendMessage(selected_1_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_2_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_3_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_4_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_5_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_6_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_7_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_8_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_9_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");
            SendMessage(selected_10_filter_textBox.Handle, EM_SETCUEBANNER, 0, "Введите фильтр характеристики");

            this.ActiveControl = search_cars_button;

            unselected_features.AddRange(init_unselected_features);

            UpdateListBoxFromList(unselected_1_listBox, unselected_features);
            UpdateListBoxFromList(unselected_2_listBox, unselected_features);
            UpdateListBoxFromList(unselected_3_listBox, unselected_features);
            UpdateListBoxFromList(unselected_4_listBox, unselected_features);
            UpdateListBoxFromList(unselected_5_listBox, unselected_features);
            UpdateListBoxFromList(unselected_6_listBox, unselected_features);
            UpdateListBoxFromList(unselected_7_listBox, unselected_features);
            UpdateListBoxFromList(unselected_8_listBox, unselected_features);
            UpdateListBoxFromList(unselected_9_listBox, unselected_features);
            UpdateListBoxFromList(unselected_10_listBox, unselected_features);

            SetButtonsEditable();
            SetAllListBoxesBackgoundColor();
        }

        private void SetListBoxBackgoundColor(ListBoxWithPlaceholderText listBox)
        {
            if (listBox.Items.Count == 0)
            {
                listBox.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                listBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void SetAllListBoxesBackgoundColor()
        {
            SetListBoxBackgoundColor(selected_1_listBox);
            SetListBoxBackgoundColor(selected_2_listBox);
            SetListBoxBackgoundColor(selected_3_listBox);
            SetListBoxBackgoundColor(selected_4_listBox);
            SetListBoxBackgoundColor(selected_5_listBox);
            SetListBoxBackgoundColor(selected_6_listBox);
            SetListBoxBackgoundColor(selected_7_listBox);
            SetListBoxBackgoundColor(selected_8_listBox);
            SetListBoxBackgoundColor(selected_9_listBox);
            SetListBoxBackgoundColor(selected_10_listBox);

            SetListBoxBackgoundColor(unselected_1_listBox);
            SetListBoxBackgoundColor(unselected_2_listBox);
            SetListBoxBackgoundColor(unselected_3_listBox);
            SetListBoxBackgoundColor(unselected_4_listBox);
            SetListBoxBackgoundColor(unselected_5_listBox);
            SetListBoxBackgoundColor(unselected_6_listBox);
            SetListBoxBackgoundColor(unselected_7_listBox);
            SetListBoxBackgoundColor(unselected_8_listBox);
            SetListBoxBackgoundColor(unselected_9_listBox);
            SetListBoxBackgoundColor(unselected_10_listBox);
        }

        // Enable and disable buttons.
        private void SetButtonsEditable()
        {
            select_1_button.Enabled = (unselected_1_listBox.SelectedItems.Count > 0);
            select_2_button.Enabled = (unselected_2_listBox.SelectedItems.Count > 0);
            select_3_button.Enabled = (unselected_3_listBox.SelectedItems.Count > 0);
            select_4_button.Enabled = (unselected_4_listBox.SelectedItems.Count > 0);
            select_5_button.Enabled = (unselected_5_listBox.SelectedItems.Count > 0);
            select_6_button.Enabled = (unselected_6_listBox.SelectedItems.Count > 0);
            select_7_button.Enabled = (unselected_7_listBox.SelectedItems.Count > 0);
            select_8_button.Enabled = (unselected_8_listBox.SelectedItems.Count > 0);
            select_9_button.Enabled = (unselected_9_listBox.SelectedItems.Count > 0);
            select_10_button.Enabled = (unselected_10_listBox.SelectedItems.Count > 0);

            select_all_1_button.Enabled = (unselected_1_listBox.Items.Count > 0);
            select_all_2_button.Enabled = (unselected_2_listBox.Items.Count > 0);
            select_all_3_button.Enabled = (unselected_3_listBox.Items.Count > 0);
            select_all_4_button.Enabled = (unselected_4_listBox.Items.Count > 0);
            select_all_5_button.Enabled = (unselected_5_listBox.Items.Count > 0);
            select_all_6_button.Enabled = (unselected_6_listBox.Items.Count > 0);
            select_all_7_button.Enabled = (unselected_7_listBox.Items.Count > 0);
            select_all_8_button.Enabled = (unselected_8_listBox.Items.Count > 0);
            select_all_9_button.Enabled = (unselected_9_listBox.Items.Count > 0);
            select_all_10_button.Enabled = (unselected_10_listBox.Items.Count > 0);

            unselect_1_button.Enabled = (selected_1_listBox.SelectedItems.Count > 0);
            unselect_2_button.Enabled = (selected_2_listBox.SelectedItems.Count > 0);
            unselect_3_button.Enabled = (selected_3_listBox.SelectedItems.Count > 0);
            unselect_4_button.Enabled = (selected_4_listBox.SelectedItems.Count > 0);
            unselect_5_button.Enabled = (selected_5_listBox.SelectedItems.Count > 0);
            unselect_6_button.Enabled = (selected_6_listBox.SelectedItems.Count > 0);
            unselect_7_button.Enabled = (selected_7_listBox.SelectedItems.Count > 0);
            unselect_8_button.Enabled = (selected_8_listBox.SelectedItems.Count > 0);
            unselect_9_button.Enabled = (selected_9_listBox.SelectedItems.Count > 0);
            unselect_10_button.Enabled = (selected_10_listBox.SelectedItems.Count > 0);

            unselect_all_1_button.Enabled = (selected_1_listBox.Items.Count > 0);
            unselect_all_2_button.Enabled = (selected_2_listBox.Items.Count > 0);
            unselect_all_3_button.Enabled = (selected_3_listBox.Items.Count > 0);
            unselect_all_4_button.Enabled = (selected_4_listBox.Items.Count > 0);
            unselect_all_5_button.Enabled = (selected_5_listBox.Items.Count > 0);
            unselect_all_6_button.Enabled = (selected_6_listBox.Items.Count > 0);
            unselect_all_7_button.Enabled = (selected_7_listBox.Items.Count > 0);
            unselect_all_8_button.Enabled = (selected_8_listBox.Items.Count > 0);
            unselect_all_9_button.Enabled = (selected_9_listBox.Items.Count > 0);
            unselect_all_10_button.Enabled = (selected_10_listBox.Items.Count > 0);
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
                    || listBox_from == unselected_4_listBox
                    || listBox_from == unselected_5_listBox
                    || listBox_from == unselected_6_listBox
                    || listBox_from == unselected_7_listBox
                    || listBox_from == unselected_8_listBox
                    || listBox_from == unselected_9_listBox
                    || listBox_from == unselected_10_listBox
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
                else if (listBox_from == selected_4_listBox)
                {
                    selected_4_features.Remove(item);
                }
                else if (listBox_from == selected_5_listBox)
                {
                    selected_5_features.Remove(item);
                }
                else if (listBox_from == selected_6_listBox)
                {
                    selected_6_features.Remove(item);
                }
                else if (listBox_from == selected_7_listBox)
                {
                    selected_7_features.Remove(item);
                }
                else if (listBox_from == selected_8_listBox)
                {
                    selected_8_features.Remove(item);
                }
                else if (listBox_from == selected_9_listBox)
                {
                    selected_9_features.Remove(item);
                }
                else if (listBox_from == selected_10_listBox)
                {
                    selected_10_features.Remove(item);
                }


                if (
                       listBox_to == unselected_1_listBox
                    || listBox_to == unselected_2_listBox
                    || listBox_to == unselected_3_listBox
                    || listBox_to == unselected_4_listBox
                    || listBox_to == unselected_5_listBox
                    || listBox_to == unselected_6_listBox
                    || listBox_to == unselected_7_listBox
                    || listBox_to == unselected_8_listBox
                    || listBox_to == unselected_9_listBox
                    || listBox_to == unselected_10_listBox
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
                else if (listBox_to == selected_4_listBox)
                {
                    selected_4_features.Add(item);
                }
                else if (listBox_to == selected_5_listBox)
                {
                    selected_5_features.Add(item);
                }
                else if (listBox_to == selected_6_listBox)
                {
                    selected_6_features.Add(item);
                }
                else if (listBox_to == selected_7_listBox)
                {
                    selected_7_features.Add(item);
                }
                else if (listBox_to == selected_8_listBox)
                {
                    selected_8_features.Add(item);
                }
                else if (listBox_to == selected_9_listBox)
                {
                    selected_9_features.Add(item);
                }
                else if (listBox_to == selected_10_listBox)
                {
                    selected_10_features.Add(item);
                }
            }
            UpdateListBoxFromList(unselected_1_listBox, unselected_features);
            UpdateListBoxFromList(unselected_2_listBox, unselected_features);
            UpdateListBoxFromList(unselected_3_listBox, unselected_features);
            UpdateListBoxFromList(unselected_4_listBox, unselected_features);
            UpdateListBoxFromList(unselected_5_listBox, unselected_features);
            UpdateListBoxFromList(unselected_6_listBox, unselected_features);
            UpdateListBoxFromList(unselected_7_listBox, unselected_features);
            UpdateListBoxFromList(unselected_8_listBox, unselected_features);
            UpdateListBoxFromList(unselected_9_listBox, unselected_features);
            UpdateListBoxFromList(unselected_10_listBox, unselected_features);
            SetButtonsEditable();
            SetAllListBoxesBackgoundColor();
        }

        // Move all items from one ListBox to another.
        private void MoveAllItems(ListBox listBox_from, ListBox listBox_to)
        {
            if (
                   listBox_from == unselected_1_listBox
                || listBox_from == unselected_2_listBox
                || listBox_from == unselected_3_listBox
                || listBox_from == unselected_4_listBox
                || listBox_from == unselected_5_listBox
                || listBox_from == unselected_6_listBox
                || listBox_from == unselected_7_listBox
                || listBox_from == unselected_8_listBox
                || listBox_from == unselected_9_listBox
                || listBox_from == unselected_10_listBox
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
            else if (listBox_from == selected_4_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_4_features.Remove(item);
                }
            }
            else if (listBox_from == selected_5_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_5_features.Remove(item);
                }
            }
            else if (listBox_from == selected_6_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_6_features.Remove(item);
                }
            }
            else if (listBox_from == selected_7_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_7_features.Remove(item);
                }
            }
            else if (listBox_from == selected_8_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_8_features.Remove(item);
                }
            }
            else if (listBox_from == selected_9_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_9_features.Remove(item);
                }
            }
            else if (listBox_from == selected_10_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_10_features.Remove(item);
                }
            }


            if (
                   listBox_to == unselected_1_listBox
                || listBox_to == unselected_2_listBox
                || listBox_to == unselected_3_listBox
                || listBox_to == unselected_4_listBox
                || listBox_to == unselected_5_listBox
                || listBox_to == unselected_6_listBox
                || listBox_to == unselected_7_listBox
                || listBox_to == unselected_8_listBox
                || listBox_to == unselected_9_listBox
                || listBox_to == unselected_10_listBox
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
            else if (listBox_to == selected_4_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_4_features.Add(item);
                }
            }
            else if (listBox_to == selected_5_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_5_features.Add(item);
                }
            }
            else if (listBox_to == selected_6_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_6_features.Add(item);
                }
            }
            else if (listBox_to == selected_7_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_7_features.Add(item);
                }
            }
            else if (listBox_to == selected_8_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_8_features.Add(item);
                }
            }
            else if (listBox_to == selected_9_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_9_features.Add(item);
                }
            }
            else if (listBox_to == selected_10_listBox)
            {
                foreach (string item in listBox_from.Items)
                {
                    selected_10_features.Add(item);
                }
            }


            listBox_to.Items.AddRange(listBox_from.Items);
            listBox_from.Items.Clear();

            UpdateListBoxFromList(unselected_1_listBox, unselected_features);
            UpdateListBoxFromList(unselected_2_listBox, unselected_features);
            UpdateListBoxFromList(unselected_3_listBox, unselected_features);
            UpdateListBoxFromList(unselected_4_listBox, unselected_features);
            UpdateListBoxFromList(unselected_5_listBox, unselected_features);
            UpdateListBoxFromList(unselected_6_listBox, unselected_features);
            UpdateListBoxFromList(unselected_7_listBox, unselected_features);
            UpdateListBoxFromList(unselected_8_listBox, unselected_features);
            UpdateListBoxFromList(unselected_9_listBox, unselected_features);
            UpdateListBoxFromList(unselected_10_listBox, unselected_features);
            SetButtonsEditable();
            SetAllListBoxesBackgoundColor();
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

        //validate
        private void validate_numeric_values(object sender, KeyPressEventArgs e)
        {
            if (
                e.Handled = !(char.IsDigit(e.KeyChar))
                && e.KeyChar != (char)Keys.Back
                && e.KeyChar != (char)Keys.Enter
                && e.KeyChar != (char)Keys.Delete
                )
            {

            }
        }

        private Boolean validate_budget()
        {
            Boolean wrong_data;
            wrong_data = false;

            if (budget_textBox.Text == "")
            {
                wrong_data = true;
            }
            else if (
                Int32.Parse(budget_textBox.Text) < 1000
             || Int32.Parse(budget_textBox.Text) > 100000
            )
            {
                wrong_data = true;
            }

            if (wrong_data == true)
            {
                MessageBox.Show("Значение бюджета должно быть между 1000 и 100000.");
            }

            return wrong_data;
        }


        //budget
        private void budget_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void budget_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void budget_clear_button_Click(object sender, EventArgs e)
        {
            budget_textBox.Text = String.Empty;
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



        //score 4
        private void score_4_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_4_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_4_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_4_filter_textBox.Text.ToLower()))
                {
                    unselected_4_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_4_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_4_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_4_listBox, selected_4_listBox);
            unselected_4_filter_textBox.Text = String.Empty;
        }

        private void selected_4_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_4_listBox.Items.Clear();

            foreach (string str in selected_4_features)
            {
                if (str.ToLower().Contains(selected_4_filter_textBox.Text.ToLower()))
                {
                    selected_4_listBox.Items.Add(str);
                }
            }
        }

        private void selected_4_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_4_listBox, unselected_4_listBox);
            selected_4_filter_textBox.Text = String.Empty;
        }

        private void selected_4_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_4_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_4_listBox, selected_4_listBox);
            unselected_4_filter_textBox.Text = String.Empty;
        }

        private void select_all_4_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_4_listBox, selected_4_listBox);
            unselected_4_filter_textBox.Text = String.Empty;
        }

        private void unselect_4_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_4_listBox, unselected_4_listBox);
            selected_4_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_4_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_4_listBox, unselected_4_listBox);
            selected_4_filter_textBox.Text = String.Empty;
        }



        //score 5
        private void score_5_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_5_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_5_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_5_filter_textBox.Text.ToLower()))
                {
                    unselected_5_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_5_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_5_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_5_listBox, selected_5_listBox);
            unselected_5_filter_textBox.Text = String.Empty;
        }

        private void selected_5_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_5_listBox.Items.Clear();

            foreach (string str in selected_5_features)
            {
                if (str.ToLower().Contains(selected_5_filter_textBox.Text.ToLower()))
                {
                    selected_5_listBox.Items.Add(str);
                }
            }
        }

        private void selected_5_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_5_listBox, unselected_5_listBox);
            selected_5_filter_textBox.Text = String.Empty;
        }

        private void selected_5_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_5_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_5_listBox, selected_5_listBox);
            unselected_5_filter_textBox.Text = String.Empty;
        }

        private void select_all_5_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_5_listBox, selected_5_listBox);
            unselected_5_filter_textBox.Text = String.Empty;
        }

        private void unselect_5_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_5_listBox, unselected_5_listBox);
            selected_5_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_5_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_5_listBox, unselected_5_listBox);
            selected_5_filter_textBox.Text = String.Empty;
        }


        //score 6
        private void score_6_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_6_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_6_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_6_filter_textBox.Text.ToLower()))
                {
                    unselected_6_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_6_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_6_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_6_listBox, selected_6_listBox);
            unselected_6_filter_textBox.Text = String.Empty;
        }

        private void selected_6_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_6_listBox.Items.Clear();

            foreach (string str in selected_6_features)
            {
                if (str.ToLower().Contains(selected_6_filter_textBox.Text.ToLower()))
                {
                    selected_6_listBox.Items.Add(str);
                }
            }
        }

        private void selected_6_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_6_listBox, unselected_6_listBox);
            selected_6_filter_textBox.Text = String.Empty;
        }

        private void selected_6_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_6_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_6_listBox, selected_6_listBox);
            unselected_6_filter_textBox.Text = String.Empty;
        }

        private void select_all_6_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_6_listBox, selected_6_listBox);
            unselected_6_filter_textBox.Text = String.Empty;
        }

        private void unselect_6_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_6_listBox, unselected_6_listBox);
            selected_6_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_6_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_6_listBox, unselected_6_listBox);
            selected_6_filter_textBox.Text = String.Empty;
        }


        //score 7
        private void score_7_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_7_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_7_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_7_filter_textBox.Text.ToLower()))
                {
                    unselected_7_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_7_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_7_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_7_listBox, selected_7_listBox);
            unselected_7_filter_textBox.Text = String.Empty;
        }

        private void selected_7_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_7_listBox.Items.Clear();

            foreach (string str in selected_7_features)
            {
                if (str.ToLower().Contains(selected_7_filter_textBox.Text.ToLower()))
                {
                    selected_7_listBox.Items.Add(str);
                }
            }
        }

        private void selected_7_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_7_listBox, unselected_7_listBox);
            selected_7_filter_textBox.Text = String.Empty;
        }

        private void selected_7_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_7_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_7_listBox, selected_7_listBox);
            unselected_7_filter_textBox.Text = String.Empty;
        }

        private void select_all_7_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_7_listBox, selected_7_listBox);
            unselected_7_filter_textBox.Text = String.Empty;
        }

        private void unselect_7_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_7_listBox, unselected_7_listBox);
            selected_7_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_7_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_7_listBox, unselected_7_listBox);
            selected_7_filter_textBox.Text = String.Empty;
        }


        //score 8
        private void score_8_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_8_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_8_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_8_filter_textBox.Text.ToLower()))
                {
                    unselected_8_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_8_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_8_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_8_listBox, selected_8_listBox);
            unselected_8_filter_textBox.Text = String.Empty;
        }

        private void selected_8_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_8_listBox.Items.Clear();

            foreach (string str in selected_8_features)
            {
                if (str.ToLower().Contains(selected_8_filter_textBox.Text.ToLower()))
                {
                    selected_8_listBox.Items.Add(str);
                }
            }
        }

        private void selected_8_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_8_listBox, unselected_8_listBox);
            selected_8_filter_textBox.Text = String.Empty;
        }

        private void selected_8_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_8_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_8_listBox, selected_8_listBox);
            unselected_8_filter_textBox.Text = String.Empty;
        }

        private void select_all_8_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_8_listBox, selected_8_listBox);
            unselected_8_filter_textBox.Text = String.Empty;
        }

        private void unselect_8_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_8_listBox, unselected_8_listBox);
            selected_8_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_8_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_8_listBox, unselected_8_listBox);
            selected_8_filter_textBox.Text = String.Empty;
        }


        //score 9
        private void score_9_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_9_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_9_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_9_filter_textBox.Text.ToLower()))
                {
                    unselected_9_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_9_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_9_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_9_listBox, selected_9_listBox);
            unselected_9_filter_textBox.Text = String.Empty;
        }

        private void selected_9_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_9_listBox.Items.Clear();

            foreach (string str in selected_9_features)
            {
                if (str.ToLower().Contains(selected_9_filter_textBox.Text.ToLower()))
                {
                    selected_9_listBox.Items.Add(str);
                }
            }
        }

        private void selected_9_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_9_listBox, unselected_9_listBox);
            selected_9_filter_textBox.Text = String.Empty;
        }

        private void selected_9_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_9_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_9_listBox, selected_9_listBox);
            unselected_9_filter_textBox.Text = String.Empty;
        }

        private void select_all_9_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_9_listBox, selected_9_listBox);
            unselected_9_filter_textBox.Text = String.Empty;
        }

        private void unselect_9_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_9_listBox, unselected_9_listBox);
            selected_9_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_9_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_9_listBox, unselected_9_listBox);
            selected_9_filter_textBox.Text = String.Empty;
        }


        //score 10
        private void score_10_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void unselected_10_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            unselected_10_listBox.Items.Clear();

            foreach (string str in unselected_features)
            {
                if (str.ToLower().Contains(unselected_10_filter_textBox.Text.ToLower()))
                {
                    unselected_10_listBox.Items.Add(str);
                }
            }
        }

        private void unselected_10_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void unselected_10_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_10_listBox, selected_10_listBox);
            unselected_10_filter_textBox.Text = String.Empty;
        }

        private void selected_10_filter_textBox_TextChanged(object sender, EventArgs e)
        {
            selected_10_listBox.Items.Clear();

            foreach (string str in selected_10_features)
            {
                if (str.ToLower().Contains(selected_10_filter_textBox.Text.ToLower()))
                {
                    selected_10_listBox.Items.Add(str);
                }
            }
        }

        private void selected_10_listBox_DoubleClick(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_10_listBox, unselected_10_listBox);
            selected_10_filter_textBox.Text = String.Empty;
        }

        private void selected_10_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEditable();
        }

        private void select_10_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(unselected_10_listBox, selected_10_listBox);
            unselected_10_filter_textBox.Text = String.Empty;
        }

        private void select_all_10_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(unselected_10_listBox, selected_10_listBox);
            unselected_10_filter_textBox.Text = String.Empty;
        }

        private void unselect_10_button_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(selected_10_listBox, unselected_10_listBox);
            selected_10_filter_textBox.Text = String.Empty;
        }

        private void unselect_all_10_button_Click(object sender, EventArgs e)
        {
            MoveAllItems(selected_10_listBox, unselected_10_listBox);
            selected_10_filter_textBox.Text = String.Empty;
        }



        //load
        private void load_scores_config_file_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON file (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //TODO
            }
        }


        //save
        private string get_selected_features_list(ListBox listBox_from)
        {
            string selectedFeatures = String.Empty;
            foreach (string li in listBox_from.Items)
            {
                selectedFeatures += $"{Environment.NewLine}            \"{li}\",";
            }

            if (selectedFeatures.Length > 0)
            {
                selectedFeatures = selectedFeatures.TrimEnd(',');
                selectedFeatures += $"{Environment.NewLine}        ";
            }

            return selectedFeatures;
        }

        private void save_scores_config_file_button_Click(object sender, EventArgs e)
        {
            Boolean wrong_data = validate_budget();

            if (wrong_data == true)
            {
                return;
            }

            string scores_config = ""
+ $"{{"
+ $"{Environment.NewLine}    \"Бюджет\": {budget_textBox.Text},"
+ $"{Environment.NewLine}    \"Оценки\": {{"
+ $"{Environment.NewLine}        \"1\": [{get_selected_features_list(selected_1_listBox)}],"
+ $"{Environment.NewLine}        \"2\": [{get_selected_features_list(selected_2_listBox)}],"
+ $"{Environment.NewLine}        \"3\": [{get_selected_features_list(selected_3_listBox)}],"
+ $"{Environment.NewLine}        \"4\": [{get_selected_features_list(selected_4_listBox)}],"
+ $"{Environment.NewLine}        \"5\": [{get_selected_features_list(selected_5_listBox)}],"
+ $"{Environment.NewLine}        \"6\": [{get_selected_features_list(selected_6_listBox)}],"
+ $"{Environment.NewLine}        \"7\": [{get_selected_features_list(selected_7_listBox)}],"
+ $"{Environment.NewLine}        \"8\": [{get_selected_features_list(selected_8_listBox)}],"
+ $"{Environment.NewLine}        \"9\": [{get_selected_features_list(selected_9_listBox)}],"
+ $"{Environment.NewLine}        \"10\": [{get_selected_features_list(selected_10_listBox)}]"
+ $"{Environment.NewLine}    }}"
+ $"{Environment.NewLine}}}";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, scores_config);
            }
        }


        //clear_all
        private void clear_scores_config_button_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Вы точно хотите очистить всё?",
                                     "Очистить всё",
                                     MessageBoxButtons.YesNoCancel);
            if (confirmResult == DialogResult.Yes)
            {
                budget_textBox.Text = String.Empty;


                unselected_features.Clear();
                unselected_features.AddRange(init_unselected_features);
                UpdateListBoxFromList(unselected_1_listBox, unselected_features);
                UpdateListBoxFromList(unselected_2_listBox, unselected_features);
                UpdateListBoxFromList(unselected_3_listBox, unselected_features);
                UpdateListBoxFromList(unselected_4_listBox, unselected_features);
                UpdateListBoxFromList(unselected_5_listBox, unselected_features);
                UpdateListBoxFromList(unselected_6_listBox, unselected_features);
                UpdateListBoxFromList(unselected_7_listBox, unselected_features);
                UpdateListBoxFromList(unselected_8_listBox, unselected_features);
                UpdateListBoxFromList(unselected_9_listBox, unselected_features);
                UpdateListBoxFromList(unselected_10_listBox, unselected_features);

                selected_1_features.Clear();
                selected_2_features.Clear();
                selected_3_features.Clear();
                selected_4_features.Clear();
                selected_5_features.Clear();
                selected_6_features.Clear();
                selected_7_features.Clear();
                selected_8_features.Clear();
                selected_9_features.Clear();
                selected_10_features.Clear();

                selected_1_listBox.Items.Clear();
                selected_2_listBox.Items.Clear();
                selected_3_listBox.Items.Clear();
                selected_4_listBox.Items.Clear();
                selected_5_listBox.Items.Clear();
                selected_6_listBox.Items.Clear();
                selected_7_listBox.Items.Clear();
                selected_8_listBox.Items.Clear();
                selected_9_listBox.Items.Clear();
                selected_10_listBox.Items.Clear();

                SetButtonsEditable();
            }
            else
            {
            }
        }


        //create_search_config
        private void create_search_config_file_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            create_search_config_file search_config_form = new create_search_config_file();
            search_config_form.StartPosition = FormStartPosition.Manual;
            search_config_form.Location = this.Location;
            search_config_form.Size = this.Size;
            search_config_form.ShowDialog();
        }


        //search_cars
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