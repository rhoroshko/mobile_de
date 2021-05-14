namespace mobile_de
{
    partial class welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(welcome));
            this.welcome_main_panel = new System.Windows.Forms.Panel();
            this.create_search_config_file_button = new System.Windows.Forms.Button();
            this.search_cars_button = new System.Windows.Forms.Button();
            this.create_scores_config_file_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcome_main_panel
            // 
            this.welcome_main_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.welcome_main_panel.Location = new System.Drawing.Point(1, 1);
            this.welcome_main_panel.Name = "welcome_main_panel";
            this.welcome_main_panel.Size = new System.Drawing.Size(833, 330);
            this.welcome_main_panel.TabIndex = 0;
            this.welcome_main_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.welcome_main_panel_Paint);
            // 
            // create_search_config_file_button
            // 
            this.create_search_config_file_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.create_search_config_file_button.Location = new System.Drawing.Point(217, 8);
            this.create_search_config_file_button.Name = "create_search_config_file_button";
            this.create_search_config_file_button.Size = new System.Drawing.Size(129, 25);
            this.create_search_config_file_button.TabIndex = 20;
            this.create_search_config_file_button.Text = "Фильтр поиска";
            this.create_search_config_file_button.UseVisualStyleBackColor = true;
            this.create_search_config_file_button.Click += new System.EventHandler(this.create_search_config_file_button_Click);
            // 
            // search_cars_button
            // 
            this.search_cars_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_cars_button.Location = new System.Drawing.Point(487, 8);
            this.search_cars_button.Name = "search_cars_button";
            this.search_cars_button.Size = new System.Drawing.Size(129, 25);
            this.search_cars_button.TabIndex = 19;
            this.search_cars_button.Text = "Поиск";
            this.search_cars_button.UseVisualStyleBackColor = true;
            this.search_cars_button.Click += new System.EventHandler(this.search_cars_button_Click);
            // 
            // create_scores_config_file_button
            // 
            this.create_scores_config_file_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.create_scores_config_file_button.Location = new System.Drawing.Point(352, 8);
            this.create_scores_config_file_button.Name = "create_scores_config_file_button";
            this.create_scores_config_file_button.Size = new System.Drawing.Size(129, 25);
            this.create_scores_config_file_button.TabIndex = 21;
            this.create_scores_config_file_button.Text = "Конфигурация оценек";
            this.create_scores_config_file_button.UseVisualStyleBackColor = true;
            this.create_scores_config_file_button.Click += new System.EventHandler(this.create_scores_config_file_button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.search_cars_button, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.create_search_config_file_button, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.create_scores_config_file_button, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 328);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(833, 36);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 364);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.welcome_main_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 400);
            this.Name = "welcome";
            this.Text = "mobile.de";
            this.Load += new System.EventHandler(this.welcome_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel welcome_main_panel;
        private System.Windows.Forms.Button create_search_config_file_button;
        private System.Windows.Forms.Button search_cars_button;
        private System.Windows.Forms.Button create_scores_config_file_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}