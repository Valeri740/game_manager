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
            
            // Tab Pages
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
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.btnGameAdd = new System.Windows.Forms.Button();
            this.btnGameDelete = new System.Windows.Forms.Button();
            this.btnGameRefresh = new System.Windows.Forms.Button();
            this.btnGameClear = new System.Windows.Forms.Button();

            // Additional Labels for Games
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.lblGameYear = new System.Windows.Forms.Label();
            this.lblGameStudioId = new System.Windows.Forms.Label();
            this.lblGamePrice = new System.Windows.Forms.Label();
            this.lblGameRating = new System.Windows.Forms.Label();

            // Initialization logic for TabControl
            this.tabControl.SuspendLayout();
            this.tabGames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
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
            // 
            // tabGames
            // 
            this.tabGames.Controls.Add(this.lblGameRating);
            this.tabGames.Controls.Add(this.lblGamePrice);
            this.tabGames.Controls.Add(this.lblGameStudioId);
            this.tabGames.Controls.Add(this.lblGameYear);
            this.tabGames.Controls.Add(this.lblGameTitle);
            this.tabGames.Controls.Add(this.btnGameClear);
            this.tabGames.Controls.Add(this.btnGameRefresh);
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
            this.tabGames.Padding = new System.Windows.Forms.Padding(3);
            this.tabGames.Size = new System.Drawing.Size(1042, 667);
            this.tabGames.TabIndex = 0;
            this.tabGames.Text = "🎮 Games";
            this.tabGames.UseVisualStyleBackColor = true;
            // 
            // dgvGames
            // 
            this.dgvGames.AllowUserToAddRows = false;
            this.dgvGames.AllowUserToDeleteRows = false;
            this.dgvGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGames.Location = new System.Drawing.Point(8, 6);
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.ReadOnly = true;
            this.dgvGames.RowHeadersWidth = 51;
            this.dgvGames.RowTemplate.Height = 29;
            this.dgvGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGames.Size = new System.Drawing.Size(1026, 321);
            this.dgvGames.TabIndex = 0;
            this.dgvGames.SelectionChanged += new System.EventHandler(this.dgvGames_SelectionChanged);
            // 
            // txtGameTitle
            // 
            this.txtGameTitle.Location = new System.Drawing.Point(125, 350);
            this.txtGameTitle.Name = "txtGameTitle";
            this.txtGameTitle.Size = new System.Drawing.Size(220, 27);
            this.txtGameTitle.TabIndex = 1;
            // 
            // txtGameYear
            // 
            this.txtGameYear.Location = new System.Drawing.Point(125, 385);
            this.txtGameYear.Name = "txtGameYear";
            this.txtGameYear.Size = new System.Drawing.Size(80, 27);
            this.txtGameYear.TabIndex = 2;
            // 
            // txtGameStudioId
            // 
            this.txtGameStudioId.Location = new System.Drawing.Point(125, 420);
            this.txtGameStudioId.Name = "txtGameStudioId";
            this.txtGameStudioId.Size = new System.Drawing.Size(80, 27);
            this.txtGameStudioId.TabIndex = 3;
            // 
            // txtGamePrice
            // 
            this.txtGamePrice.Location = new System.Drawing.Point(125, 455);
            this.txtGamePrice.Name = "txtGamePrice";
            this.txtGamePrice.Size = new System.Drawing.Size(100, 27);
            this.txtGamePrice.TabIndex = 4;
            // 
            // txtGameRating
            // 
            this.txtGameRating.Location = new System.Drawing.Point(125, 490);
            this.txtGameRating.Name = "txtGameRating";
            this.txtGameRating.Size = new System.Drawing.Size(80, 27);
            this.txtGameRating.TabIndex = 5;
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Location = new System.Drawing.Point(8, 630);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(52, 20);
            this.lblGameStatus.TabIndex = 6;
            this.lblGameStatus.Text = "Status";
            // 
            // btnGameAdd
            // 
            this.btnGameAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGameAdd.ForeColor = System.Drawing.Color.White;
            this.btnGameAdd.Location = new System.Drawing.Point(16, 540);
            this.btnGameAdd.Name = "btnGameAdd";
            this.btnGameAdd.Size = new System.Drawing.Size(90, 30);
            this.btnGameAdd.TabIndex = 7;
            this.btnGameAdd.Text = "Add";
            this.btnGameAdd.UseVisualStyleBackColor = false;
            this.btnGameAdd.Click += new System.EventHandler(this.btnGameAdd_Click);
            // 
            // btnGameDelete
            // 
            this.btnGameDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnGameDelete.ForeColor = System.Drawing.Color.White;
            this.btnGameDelete.Location = new System.Drawing.Point(115, 540);
            this.btnGameDelete.Name = "btnGameDelete";
            this.btnGameDelete.Size = new System.Drawing.Size(90, 30);
            this.btnGameDelete.TabIndex = 8;
            this.btnGameDelete.Text = "Delete";
            this.btnGameDelete.UseVisualStyleBackColor = false;
            this.btnGameDelete.Click += new System.EventHandler(this.btnGameDelete_Click);
            // 
            // btnGameRefresh
            // 
            this.btnGameRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnGameRefresh.ForeColor = System.Drawing.Color.White;
            this.btnGameRefresh.Location = new System.Drawing.Point(215, 540);
            this.btnGameRefresh.Name = "btnGameRefresh";
            this.btnGameRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnGameRefresh.TabIndex = 9;
            this.btnGameRefresh.Text = "Refresh";
            this.btnGameRefresh.UseVisualStyleBackColor = false;
            this.btnGameRefresh.Click += new System.EventHandler(this.btnGameRefresh_Click);
            // 
            // btnGameClear
            // 
            this.btnGameClear.BackColor = System.Drawing.Color.DimGray;
            this.btnGameClear.ForeColor = System.Drawing.Color.White;
            this.btnGameClear.Location = new System.Drawing.Point(315, 540);
            this.btnGameClear.Name = "btnGameClear";
            this.btnGameClear.Size = new System.Drawing.Size(90, 30);
            this.btnGameClear.TabIndex = 10;
            this.btnGameClear.Text = "Clear";
            this.btnGameClear.UseVisualStyleBackColor = false;
            this.btnGameClear.Click += new System.EventHandler(this.btnGameClear_Click);
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.AutoSize = true;
            this.lblGameTitle.Location = new System.Drawing.Point(20, 353);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(42, 20);
            this.lblGameTitle.TabIndex = 11;
            this.lblGameTitle.Text = "Title:";
            // 
            // lblGameYear
            // 
            this.lblGameYear.AutoSize = true;
            this.lblGameYear.Location = new System.Drawing.Point(20, 388);
            this.lblGameYear.Name = "lblGameYear";
            this.lblGameYear.Size = new System.Drawing.Size(40, 20);
            this.lblGameYear.TabIndex = 12;
            this.lblGameYear.Text = "Year:";
            // 
            // lblGameStudioId
            // 
            this.lblGameStudioId.AutoSize = true;
            this.lblGameStudioId.Location = new System.Drawing.Point(20, 423);
            this.lblGameStudioId.Name = "lblGameStudioId";
            this.lblGameStudioId.Size = new System.Drawing.Size(74, 20);
            this.lblGameStudioId.TabIndex = 13;
            this.lblGameStudioId.Text = "Studio ID:";
            // 
            // lblGamePrice
            // 
            this.lblGamePrice.AutoSize = true;
            this.lblGamePrice.Location = new System.Drawing.Point(20, 458);
            this.lblGamePrice.Name = "lblGamePrice";
            this.lblGamePrice.Size = new System.Drawing.Size(44, 20);
            this.lblGamePrice.TabIndex = 14;
            this.lblGamePrice.Text = "Price:";
            // 
            // lblGameRating
            // 
            this.lblGameRating.AutoSize = true;
            this.lblGameRating.Location = new System.Drawing.Point(20, 493);
            this.lblGameRating.Name = "lblGameRating";
            this.lblGameRating.Size = new System.Drawing.Size(55, 20);
            this.lblGameRating.TabIndex = 15;
            this.lblGameRating.Text = "Rating:";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        
        // Tab Pages
        private System.Windows.Forms.TabPage tabGames;
        private System.Windows.Forms.TabPage tabStudios;
        private System.Windows.Forms.TabPage tabGenres;
        private System.Windows.Forms.TabPage tabPlatforms;
        private System.Windows.Forms.TabPage tabPublishers;

        // Games Controls
        private System.Windows.Forms.DataGridView dgvGames;
        private System.Windows.Forms.TextBox txtGameTitle;
        private System.Windows.Forms.TextBox txtGameYear;
        private System.Windows.Forms.TextBox txtGameStudioId;
        private System.Windows.Forms.TextBox txtGamePrice;
        private System.Windows.Forms.TextBox txtGameRating;
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.Button btnGameAdd;
        private System.Windows.Forms.Button btnGameDelete;
        private System.Windows.Forms.Button btnGameRefresh;
        private System.Windows.Forms.Button btnGameClear;

        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.Label lblGameYear;
        private System.Windows.Forms.Label lblGameStudioId;
        private System.Windows.Forms.Label lblGamePrice;
        private System.Windows.Forms.Label lblGameRating;
        
        // I will add placeholders for other tabs here so VS doesn't crash if they are referenced,
        // The student can populate them from VS Designer.
        private System.Windows.Forms.DataGridView dgvStudios;
        private System.Windows.Forms.DataGridView dgvGenres;
        private System.Windows.Forms.DataGridView dgvPlatforms;
        private System.Windows.Forms.DataGridView dgvPublishers;
        
        private System.Windows.Forms.TextBox txtStudioName;
        private System.Windows.Forms.TextBox txtStudioCountry;
        private System.Windows.Forms.TextBox txtStudioFounded;
        private System.Windows.Forms.TextBox txtStudioWebsite;
        private System.Windows.Forms.Label lblStudioStatus;

        private System.Windows.Forms.TextBox txtGenreName;
        private System.Windows.Forms.TextBox txtGenreDesc;
        private System.Windows.Forms.Label lblGenreStatus;

        private System.Windows.Forms.TextBox txtPlatformName;
        private System.Windows.Forms.TextBox txtPlatformManufacturer;
        private System.Windows.Forms.TextBox txtPlatformRelease;
        private System.Windows.Forms.TextBox txtPlatformGen;
        private System.Windows.Forms.Label lblPlatformStatus;

        private System.Windows.Forms.TextBox txtPublisherName;
        private System.Windows.Forms.TextBox txtPublisherCountry;
        private System.Windows.Forms.TextBox txtPublisherFounded;
        private System.Windows.Forms.Label lblPublisherStatus;
    }
}
