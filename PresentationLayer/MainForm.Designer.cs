namespace PresentationLayer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            
            this.tabGames = new System.Windows.Forms.TabPage();
            this.tabStudios = new System.Windows.Forms.TabPage();
            this.tabGenres = new System.Windows.Forms.TabPage();
            this.tabPlatforms = new System.Windows.Forms.TabPage();
            this.tabPublishers = new System.Windows.Forms.TabPage();

            // Games Controls
            this.dgvGames = new System.Windows.Forms.DataGridView();
            this.txtGameTitle = new System.Windows.Forms.TextBox();
            this.txtGameYear = new System.Windows.Forms.TextBox();
            this.txtGameStudioId = new System.Windows.Forms.TextBox();
            this.txtGamePrice = new System.Windows.Forms.TextBox();
            this.txtGameRating = new System.Windows.Forms.TextBox();
            this.txtGameMultiplayer = new System.Windows.Forms.TextBox();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.btnGameAdd = new System.Windows.Forms.Button();
            this.btnGameUpdate = new System.Windows.Forms.Button();
            this.btnGameDelete = new System.Windows.Forms.Button();
            this.btnGameRefresh = new System.Windows.Forms.Button();
            this.btnGameClear = new System.Windows.Forms.Button();

            this.lblGameTitle = new System.Windows.Forms.Label();
            this.lblGameYear = new System.Windows.Forms.Label();
            this.lblGameStudioId = new System.Windows.Forms.Label();
            this.lblGamePrice = new System.Windows.Forms.Label();
            this.lblGameRating = new System.Windows.Forms.Label();
            this.lblGameMultiplayer = new System.Windows.Forms.Label();

            // Studios Controls
            this.dgvStudios = new System.Windows.Forms.DataGridView();
            this.txtStudioName = new System.Windows.Forms.TextBox();
            this.txtStudioCountry = new System.Windows.Forms.TextBox();
            this.txtStudioFounded = new System.Windows.Forms.TextBox();
            this.txtStudioWebsite = new System.Windows.Forms.TextBox();
            this.lblStudioStatus = new System.Windows.Forms.Label();
            this.btnStudioAdd = new System.Windows.Forms.Button();
            this.btnStudioUpdate = new System.Windows.Forms.Button();
            this.btnStudioDelete = new System.Windows.Forms.Button();
            this.btnStudioRefresh = new System.Windows.Forms.Button();
            this.btnStudioClear = new System.Windows.Forms.Button();
            
            this.lblStudioName = new System.Windows.Forms.Label();
            this.lblStudioCountry = new System.Windows.Forms.Label();
            this.lblStudioFounded = new System.Windows.Forms.Label();
            this.lblStudioWebsite = new System.Windows.Forms.Label();

            this.tabControl.SuspendLayout();
            this.tabGames.SuspendLayout();
            this.tabStudios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudios)).BeginInit();
            this.SuspendLayout();
            
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGames);
            this.tabControl.Controls.Add(this.tabStudios);
            this.tabControl.Controls.Add(this.tabGenres);
            this.tabControl.Controls.Add(this.tabPlatforms);
            this.tabControl.Controls.Add(this.tabPublishers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1050, 700);
            this.tabControl.TabIndex = 0;

            // =========================
            // G A M E S  T A B
            // =========================
            this.tabGames.Controls.Add(this.lblGameMultiplayer);
            this.tabGames.Controls.Add(this.txtGameMultiplayer);
            this.tabGames.Controls.Add(this.lblGameRating);
            this.tabGames.Controls.Add(this.lblGamePrice);
            this.tabGames.Controls.Add(this.lblGameStudioId);
            this.tabGames.Controls.Add(this.lblGameYear);
            this.tabGames.Controls.Add(this.lblGameTitle);
            this.tabGames.Controls.Add(this.btnGameClear);
            this.tabGames.Controls.Add(this.btnGameRefresh);
            this.tabGames.Controls.Add(this.btnGameUpdate);
            this.tabGames.Controls.Add(this.btnGameDelete);
            this.tabGames.Controls.Add(this.btnGameAdd);
            this.tabGames.Controls.Add(this.lblGameStatus);
            this.tabGames.Controls.Add(this.txtGameRating);
            this.tabGames.Controls.Add(this.txtGamePrice);
            this.tabGames.Controls.Add(this.txtGameStudioId);
            this.tabGames.Controls.Add(this.txtGameYear);
            this.tabGames.Controls.Add(this.txtGameTitle);
            this.tabGames.Controls.Add(this.dgvGames);
            this.tabGames.Location = new System.Drawing.Point(4, 29);
            this.tabGames.Name = "tabGames";
            this.tabGames.Size = new System.Drawing.Size(1042, 667);
            this.tabGames.TabIndex = 0;
            this.tabGames.Text = "🎮 Games";

            this.dgvGames.AllowUserToAddRows = false;
            this.dgvGames.AllowUserToDeleteRows = false;
            this.dgvGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGames.Location = new System.Drawing.Point(8, 6);
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.ReadOnly = true;
            this.dgvGames.RowHeadersWidth = 51;
            this.dgvGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGames.Size = new System.Drawing.Size(1026, 321);
            this.dgvGames.TabIndex = 0;
            this.dgvGames.SelectionChanged += new System.EventHandler(this.dgvGames_SelectionChanged);

            this.txtGameTitle.Location = new System.Drawing.Point(125, 350);
            this.txtGameTitle.Size = new System.Drawing.Size(220, 27);
            this.txtGameYear.Location = new System.Drawing.Point(125, 385);
            this.txtGameYear.Size = new System.Drawing.Size(80, 27);
            this.txtGameStudioId.Location = new System.Drawing.Point(125, 420);
            this.txtGameStudioId.Size = new System.Drawing.Size(80, 27);
            this.txtGamePrice.Location = new System.Drawing.Point(125, 455);
            this.txtGamePrice.Size = new System.Drawing.Size(100, 27);
            this.txtGameRating.Location = new System.Drawing.Point(125, 490);
            this.txtGameRating.Size = new System.Drawing.Size(80, 27);
            this.txtGameMultiplayer.Location = new System.Drawing.Point(125, 525);
            this.txtGameMultiplayer.Size = new System.Drawing.Size(80, 27);

            this.lblGameTitle.AutoSize = true;
            this.lblGameTitle.Location = new System.Drawing.Point(20, 353);
            this.lblGameTitle.Text = "Title:";
            this.lblGameYear.AutoSize = true;
            this.lblGameYear.Location = new System.Drawing.Point(20, 388);
            this.lblGameYear.Text = "Year:";
            this.lblGameStudioId.AutoSize = true;
            this.lblGameStudioId.Location = new System.Drawing.Point(20, 423);
            this.lblGameStudioId.Text = "Studio ID:";
            this.lblGamePrice.AutoSize = true;
            this.lblGamePrice.Location = new System.Drawing.Point(20, 458);
            this.lblGamePrice.Text = "Price:";
            this.lblGameRating.AutoSize = true;
            this.lblGameRating.Location = new System.Drawing.Point(20, 493);
            this.lblGameRating.Text = "Rating:";
            this.lblGameMultiplayer.AutoSize = true;
            this.lblGameMultiplayer.Location = new System.Drawing.Point(20, 528);
            this.lblGameMultiplayer.Text = "Multiplayer:";

            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Location = new System.Drawing.Point(8, 630);
            this.lblGameStatus.Text = "Status";

            this.btnGameAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGameAdd.ForeColor = System.Drawing.Color.White;
            this.btnGameAdd.Location = new System.Drawing.Point(16, 580);
            this.btnGameAdd.Size = new System.Drawing.Size(90, 30);
            this.btnGameAdd.Text = "Add";
            this.btnGameAdd.Click += new System.EventHandler(this.btnGameAdd_Click);

            this.btnGameUpdate.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGameUpdate.ForeColor = System.Drawing.Color.White;
            this.btnGameUpdate.Location = new System.Drawing.Point(115, 580);
            this.btnGameUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnGameUpdate.Text = "Update";
            this.btnGameUpdate.Click += new System.EventHandler(this.btnGameUpdate_Click);

            this.btnGameDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnGameDelete.ForeColor = System.Drawing.Color.White;
            this.btnGameDelete.Location = new System.Drawing.Point(215, 580);
            this.btnGameDelete.Size = new System.Drawing.Size(90, 30);
            this.btnGameDelete.Text = "Delete";
            this.btnGameDelete.Click += new System.EventHandler(this.btnGameDelete_Click);

            this.btnGameRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnGameRefresh.ForeColor = System.Drawing.Color.White;
            this.btnGameRefresh.Location = new System.Drawing.Point(315, 580);
            this.btnGameRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnGameRefresh.Text = "Refresh";
            this.btnGameRefresh.Click += new System.EventHandler(this.btnGameRefresh_Click);

            this.btnGameClear.BackColor = System.Drawing.Color.DimGray;
            this.btnGameClear.ForeColor = System.Drawing.Color.White;
            this.btnGameClear.Location = new System.Drawing.Point(415, 580);
            this.btnGameClear.Size = new System.Drawing.Size(90, 30);
            this.btnGameClear.Text = "Clear";
            this.btnGameClear.Click += new System.EventHandler(this.btnGameClear_Click);


            // =========================
            // S T U D I O S  T A B
            // =========================
            this.tabStudios.Controls.Add(this.lblStudioWebsite);
            this.tabStudios.Controls.Add(this.lblStudioFounded);
            this.tabStudios.Controls.Add(this.lblStudioCountry);
            this.tabStudios.Controls.Add(this.lblStudioName);
            this.tabStudios.Controls.Add(this.txtStudioWebsite);
            this.tabStudios.Controls.Add(this.txtStudioFounded);
            this.tabStudios.Controls.Add(this.txtStudioCountry);
            this.tabStudios.Controls.Add(this.txtStudioName);
            this.tabStudios.Controls.Add(this.btnStudioClear);
            this.tabStudios.Controls.Add(this.btnStudioRefresh);
            this.tabStudios.Controls.Add(this.btnStudioUpdate);
            this.tabStudios.Controls.Add(this.btnStudioDelete);
            this.tabStudios.Controls.Add(this.btnStudioAdd);
            this.tabStudios.Controls.Add(this.lblStudioStatus);
            this.tabStudios.Controls.Add(this.dgvStudios);
            this.tabStudios.Location = new System.Drawing.Point(4, 29);
            this.tabStudios.Name = "tabStudios";
            this.tabStudios.Size = new System.Drawing.Size(1042, 667);
            this.tabStudios.TabIndex = 1;
            this.tabStudios.Text = "🏢 Studios";

            this.dgvStudios.AllowUserToAddRows = false;
            this.dgvStudios.AllowUserToDeleteRows = false;
            this.dgvStudios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudios.Location = new System.Drawing.Point(8, 6);
            this.dgvStudios.Name = "dgvStudios";
            this.dgvStudios.ReadOnly = true;
            this.dgvStudios.RowHeadersWidth = 51;
            this.dgvStudios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudios.Size = new System.Drawing.Size(1026, 321);
            this.dgvStudios.TabIndex = 0;
            this.dgvStudios.SelectionChanged += new System.EventHandler(this.dgvStudios_SelectionChanged);


            this.txtStudioName.Location = new System.Drawing.Point(125, 350);
            this.txtStudioName.Size = new System.Drawing.Size(220, 27);
            this.txtStudioCountry.Location = new System.Drawing.Point(125, 385);
            this.txtStudioCountry.Size = new System.Drawing.Size(220, 27);
            this.txtStudioFounded.Location = new System.Drawing.Point(125, 420);
            this.txtStudioFounded.Size = new System.Drawing.Size(120, 27);
            this.txtStudioWebsite.Location = new System.Drawing.Point(125, 455);
            this.txtStudioWebsite.Size = new System.Drawing.Size(220, 27);

            this.lblStudioName.AutoSize = true;
            this.lblStudioName.Location = new System.Drawing.Point(20, 353);
            this.lblStudioName.Text = "Name:";
            this.lblStudioCountry.AutoSize = true;
            this.lblStudioCountry.Location = new System.Drawing.Point(20, 388);
            this.lblStudioCountry.Text = "Country:";
            this.lblStudioFounded.AutoSize = true;
            this.lblStudioFounded.Location = new System.Drawing.Point(20, 423);
            this.lblStudioFounded.Text = "Founded Date:";
            this.lblStudioWebsite.AutoSize = true;
            this.lblStudioWebsite.Location = new System.Drawing.Point(20, 458);
            this.lblStudioWebsite.Text = "Website:";

            this.lblStudioStatus.AutoSize = true;
            this.lblStudioStatus.Location = new System.Drawing.Point(8, 630);
            this.lblStudioStatus.Text = "Status";

            this.btnStudioAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnStudioAdd.ForeColor = System.Drawing.Color.White;
            this.btnStudioAdd.Location = new System.Drawing.Point(16, 510);
            this.btnStudioAdd.Size = new System.Drawing.Size(90, 30);
            this.btnStudioAdd.Text = "Add";
            this.btnStudioAdd.Click += new System.EventHandler(this.btnStudioAdd_Click);

            this.btnStudioUpdate.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnStudioUpdate.ForeColor = System.Drawing.Color.White;
            this.btnStudioUpdate.Location = new System.Drawing.Point(115, 510);
            this.btnStudioUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnStudioUpdate.Text = "Update";
            this.btnStudioUpdate.Click += new System.EventHandler(this.btnStudioUpdate_Click);

            this.btnStudioDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnStudioDelete.ForeColor = System.Drawing.Color.White;
            this.btnStudioDelete.Location = new System.Drawing.Point(215, 510);
            this.btnStudioDelete.Size = new System.Drawing.Size(90, 30);
            this.btnStudioDelete.Text = "Delete";
            this.btnStudioDelete.Click += new System.EventHandler(this.btnStudioDelete_Click);

            this.btnStudioRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnStudioRefresh.ForeColor = System.Drawing.Color.White;
            this.btnStudioRefresh.Location = new System.Drawing.Point(315, 510);
            this.btnStudioRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnStudioRefresh.Text = "Refresh";
            this.btnStudioRefresh.Click += new System.EventHandler(this.btnStudioRefresh_Click);

            this.btnStudioClear.BackColor = System.Drawing.Color.DimGray;
            this.btnStudioClear.ForeColor = System.Drawing.Color.White;
            this.btnStudioClear.Location = new System.Drawing.Point(415, 510);
            this.btnStudioClear.Size = new System.Drawing.Size(90, 30);
            this.btnStudioClear.Text = "Clear";
            this.btnStudioClear.Click += new System.EventHandler(this.btnStudioClear_Click);


            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 700);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Manager";
            this.tabControl.ResumeLayout(false);
            
            this.tabGames.ResumeLayout(false);
            this.tabGames.PerformLayout();
            
            this.tabStudios.ResumeLayout(false);
            this.tabStudios.PerformLayout();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudios)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        
        private System.Windows.Forms.TabPage tabGames;
        private System.Windows.Forms.TabPage tabStudios;
        private System.Windows.Forms.TabPage tabGenres;
        private System.Windows.Forms.TabPage tabPlatforms;
        private System.Windows.Forms.TabPage tabPublishers;

        private System.Windows.Forms.DataGridView dgvGames;
        private System.Windows.Forms.TextBox txtGameTitle;
        private System.Windows.Forms.TextBox txtGameYear;
        private System.Windows.Forms.TextBox txtGameStudioId;
        private System.Windows.Forms.TextBox txtGamePrice;
        private System.Windows.Forms.TextBox txtGameRating;
        private System.Windows.Forms.TextBox txtGameMultiplayer;
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.Button btnGameAdd;
        private System.Windows.Forms.Button btnGameUpdate;
        private System.Windows.Forms.Button btnGameDelete;
        private System.Windows.Forms.Button btnGameRefresh;
        private System.Windows.Forms.Button btnGameClear;

        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.Label lblGameYear;
        private System.Windows.Forms.Label lblGameStudioId;
        private System.Windows.Forms.Label lblGamePrice;
        private System.Windows.Forms.Label lblGameRating;
        private System.Windows.Forms.Label lblGameMultiplayer;
        
        private System.Windows.Forms.DataGridView dgvStudios;
        private System.Windows.Forms.TextBox txtStudioName;
        private System.Windows.Forms.TextBox txtStudioCountry;
        private System.Windows.Forms.TextBox txtStudioFounded;
        private System.Windows.Forms.TextBox txtStudioWebsite;
        private System.Windows.Forms.Label lblStudioStatus;
        
        private System.Windows.Forms.Button btnStudioAdd;
        private System.Windows.Forms.Button btnStudioUpdate;
        private System.Windows.Forms.Button btnStudioDelete;
        private System.Windows.Forms.Button btnStudioRefresh;
        private System.Windows.Forms.Button btnStudioClear;

        private System.Windows.Forms.Label lblStudioName;
        private System.Windows.Forms.Label lblStudioCountry;
        private System.Windows.Forms.Label lblStudioFounded;
        private System.Windows.Forms.Label lblStudioWebsite;
    }
}
