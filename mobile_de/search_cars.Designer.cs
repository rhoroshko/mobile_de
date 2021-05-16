namespace mobile_de
{
    partial class search_cars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(search_cars));
            this.search_cars_main_panel = new System.Windows.Forms.Panel();
            this.scores_config_groupBox = new System.Windows.Forms.GroupBox();
            this.scores_config_select_button = new System.Windows.Forms.Button();
            this.scores_config_create_button = new System.Windows.Forms.Button();
            this.scores_config_listBox = new System.Windows.Forms.ListBox();
            this.scores_config_clear_button = new System.Windows.Forms.Button();
            this.search_config_groupBox = new System.Windows.Forms.GroupBox();
            this.search_config_remove_button = new System.Windows.Forms.Button();
            this.search_config_add_button = new System.Windows.Forms.Button();
            this.search_config_create_button = new System.Windows.Forms.Button();
            this.search_config_listBox = new System.Windows.Forms.ListBox();
            this.search_config_clear_button = new System.Windows.Forms.Button();
            this.botton_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.search_cars_start_button = new System.Windows.Forms.Button();
            this.search_cars_main_panel.SuspendLayout();
            this.scores_config_groupBox.SuspendLayout();
            this.search_config_groupBox.SuspendLayout();
            this.botton_tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_cars_main_panel
            // 
            this.search_cars_main_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_cars_main_panel.Controls.Add(this.scores_config_groupBox);
            this.search_cars_main_panel.Controls.Add(this.search_config_groupBox);
            this.search_cars_main_panel.Location = new System.Drawing.Point(1, 1);
            this.search_cars_main_panel.Name = "search_cars_main_panel";
            this.search_cars_main_panel.Size = new System.Drawing.Size(833, 330);
            this.search_cars_main_panel.TabIndex = 0;
            // 
            // scores_config_groupBox
            // 
            this.scores_config_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scores_config_groupBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.scores_config_groupBox.Controls.Add(this.scores_config_select_button);
            this.scores_config_groupBox.Controls.Add(this.scores_config_create_button);
            this.scores_config_groupBox.Controls.Add(this.scores_config_listBox);
            this.scores_config_groupBox.Controls.Add(this.scores_config_clear_button);
            this.scores_config_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scores_config_groupBox.Location = new System.Drawing.Point(4, 165);
            this.scores_config_groupBox.Name = "scores_config_groupBox";
            this.scores_config_groupBox.Size = new System.Drawing.Size(807, 155);
            this.scores_config_groupBox.TabIndex = 2;
            this.scores_config_groupBox.TabStop = false;
            this.scores_config_groupBox.Text = "Конфигурация оценек";
            this.scores_config_groupBox.Enter += new System.EventHandler(this.scores_config_groupBox_Enter);
            // 
            // scores_config_select_button
            // 
            this.scores_config_select_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scores_config_select_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scores_config_select_button.Location = new System.Drawing.Point(717, 86);
            this.scores_config_select_button.Name = "scores_config_select_button";
            this.scores_config_select_button.Size = new System.Drawing.Size(75, 23);
            this.scores_config_select_button.TabIndex = 3;
            this.scores_config_select_button.Text = "Выбрать";
            this.scores_config_select_button.UseVisualStyleBackColor = true;
            this.scores_config_select_button.Click += new System.EventHandler(this.scores_config_select_button_Click);
            // 
            // scores_config_create_button
            // 
            this.scores_config_create_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scores_config_create_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scores_config_create_button.Location = new System.Drawing.Point(717, 115);
            this.scores_config_create_button.Name = "scores_config_create_button";
            this.scores_config_create_button.Size = new System.Drawing.Size(75, 23);
            this.scores_config_create_button.TabIndex = 2;
            this.scores_config_create_button.Text = "Создать";
            this.scores_config_create_button.UseVisualStyleBackColor = true;
            this.scores_config_create_button.Click += new System.EventHandler(this.scores_config_create_button_Click);
            // 
            // scores_config_listBox
            // 
            this.scores_config_listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scores_config_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scores_config_listBox.FormattingEnabled = true;
            this.scores_config_listBox.Location = new System.Drawing.Point(5, 31);
            this.scores_config_listBox.Name = "scores_config_listBox";
            this.scores_config_listBox.Size = new System.Drawing.Size(689, 108);
            this.scores_config_listBox.TabIndex = 1;
            this.scores_config_listBox.SelectedIndexChanged += new System.EventHandler(this.scores_config_listBox_SelectedIndexChanged);
            // 
            // scores_config_clear_button
            // 
            this.scores_config_clear_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scores_config_clear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scores_config_clear_button.Location = new System.Drawing.Point(717, 0);
            this.scores_config_clear_button.Name = "scores_config_clear_button";
            this.scores_config_clear_button.Size = new System.Drawing.Size(75, 25);
            this.scores_config_clear_button.TabIndex = 0;
            this.scores_config_clear_button.Text = "Очистить";
            this.scores_config_clear_button.UseVisualStyleBackColor = true;
            this.scores_config_clear_button.Click += new System.EventHandler(this.scores_config_clear_button_Click);
            // 
            // search_config_groupBox
            // 
            this.search_config_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_config_groupBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.search_config_groupBox.Controls.Add(this.search_config_remove_button);
            this.search_config_groupBox.Controls.Add(this.search_config_add_button);
            this.search_config_groupBox.Controls.Add(this.search_config_create_button);
            this.search_config_groupBox.Controls.Add(this.search_config_listBox);
            this.search_config_groupBox.Controls.Add(this.search_config_clear_button);
            this.search_config_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_config_groupBox.Location = new System.Drawing.Point(4, 4);
            this.search_config_groupBox.Name = "search_config_groupBox";
            this.search_config_groupBox.Size = new System.Drawing.Size(807, 155);
            this.search_config_groupBox.TabIndex = 1;
            this.search_config_groupBox.TabStop = false;
            this.search_config_groupBox.Text = "Фильтр поиска";
            this.search_config_groupBox.Enter += new System.EventHandler(this.search_config_groupBox_Enter);
            // 
            // search_config_remove_button
            // 
            this.search_config_remove_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_config_remove_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_config_remove_button.Location = new System.Drawing.Point(717, 86);
            this.search_config_remove_button.Name = "search_config_remove_button";
            this.search_config_remove_button.Size = new System.Drawing.Size(75, 23);
            this.search_config_remove_button.TabIndex = 4;
            this.search_config_remove_button.Text = "Удалить";
            this.search_config_remove_button.UseVisualStyleBackColor = true;
            this.search_config_remove_button.Click += new System.EventHandler(this.search_config_remove_button_Click);
            // 
            // search_config_add_button
            // 
            this.search_config_add_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_config_add_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_config_add_button.Location = new System.Drawing.Point(717, 57);
            this.search_config_add_button.Name = "search_config_add_button";
            this.search_config_add_button.Size = new System.Drawing.Size(75, 23);
            this.search_config_add_button.TabIndex = 3;
            this.search_config_add_button.Text = "Добавить";
            this.search_config_add_button.UseVisualStyleBackColor = true;
            this.search_config_add_button.Click += new System.EventHandler(this.search_config_add_button_Click);
            // 
            // search_config_create_button
            // 
            this.search_config_create_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_config_create_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_config_create_button.Location = new System.Drawing.Point(717, 115);
            this.search_config_create_button.Name = "search_config_create_button";
            this.search_config_create_button.Size = new System.Drawing.Size(75, 23);
            this.search_config_create_button.TabIndex = 2;
            this.search_config_create_button.Text = "Создать";
            this.search_config_create_button.UseVisualStyleBackColor = true;
            this.search_config_create_button.Click += new System.EventHandler(this.search_config_create_button_Click);
            // 
            // search_config_listBox
            // 
            this.search_config_listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_config_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_config_listBox.FormattingEnabled = true;
            this.search_config_listBox.Location = new System.Drawing.Point(5, 31);
            this.search_config_listBox.Name = "search_config_listBox";
            this.search_config_listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.search_config_listBox.Size = new System.Drawing.Size(689, 108);
            this.search_config_listBox.TabIndex = 1;
            this.search_config_listBox.SelectedIndexChanged += new System.EventHandler(this.search_config_listBox_SelectedIndexChanged);
            // 
            // search_config_clear_button
            // 
            this.search_config_clear_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_config_clear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_config_clear_button.Location = new System.Drawing.Point(717, 0);
            this.search_config_clear_button.Name = "search_config_clear_button";
            this.search_config_clear_button.Size = new System.Drawing.Size(75, 25);
            this.search_config_clear_button.TabIndex = 0;
            this.search_config_clear_button.Text = "Очистить";
            this.search_config_clear_button.UseVisualStyleBackColor = true;
            this.search_config_clear_button.Click += new System.EventHandler(this.search_config_clear_button_Click);
            // 
            // botton_tableLayoutPanel
            // 
            this.botton_tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.botton_tableLayoutPanel.ColumnCount = 3;
            this.botton_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.botton_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.botton_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.botton_tableLayoutPanel.Controls.Add(this.search_cars_start_button, 1, 0);
            this.botton_tableLayoutPanel.Location = new System.Drawing.Point(1, 331);
            this.botton_tableLayoutPanel.Name = "botton_tableLayoutPanel";
            this.botton_tableLayoutPanel.RowCount = 1;
            this.botton_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.botton_tableLayoutPanel.Size = new System.Drawing.Size(833, 31);
            this.botton_tableLayoutPanel.TabIndex = 1;
            // 
            // search_cars_start_button
            // 
            this.search_cars_start_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_cars_start_button.Location = new System.Drawing.Point(369, 3);
            this.search_cars_start_button.Name = "search_cars_start_button";
            this.search_cars_start_button.Size = new System.Drawing.Size(94, 25);
            this.search_cars_start_button.TabIndex = 0;
            this.search_cars_start_button.Text = "Начать поиск";
            this.search_cars_start_button.UseVisualStyleBackColor = true;
            this.search_cars_start_button.Click += new System.EventHandler(this.search_cars_start_button_Click);
            // 
            // search_cars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 364);
            this.Controls.Add(this.botton_tableLayoutPanel);
            this.Controls.Add(this.search_cars_main_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 400);
            this.Name = "search_cars";
            this.Text = "mobile.de Начать поиск";
            this.Load += new System.EventHandler(this.search_cars_Load);
            this.search_cars_main_panel.ResumeLayout(false);
            this.scores_config_groupBox.ResumeLayout(false);
            this.search_config_groupBox.ResumeLayout(false);
            this.botton_tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel search_cars_main_panel;
        private System.Windows.Forms.TableLayoutPanel botton_tableLayoutPanel;
        private System.Windows.Forms.Button search_cars_start_button;
        private System.Windows.Forms.GroupBox search_config_groupBox;
        private System.Windows.Forms.Button search_config_clear_button;
        private System.Windows.Forms.ListBox search_config_listBox;
        private System.Windows.Forms.Button search_config_add_button;
        private System.Windows.Forms.Button search_config_create_button;
        private System.Windows.Forms.GroupBox scores_config_groupBox;
        private System.Windows.Forms.Button scores_config_select_button;
        private System.Windows.Forms.Button scores_config_create_button;
        private System.Windows.Forms.ListBox scores_config_listBox;
        private System.Windows.Forms.Button scores_config_clear_button;
        private System.Windows.Forms.Button search_config_remove_button;
    }
}