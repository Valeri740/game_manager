// КОРЕКЦИЯ спрямо предишната версия:
// - Namespace: Business_layer -> BusinessLayer (промяна в проекта на съучениците)
// - Вместо DataLayer контексти директно, използваме ServiceLayer
// - GameManagerDbContext вместо AppDbContext

using BusinessLayer;
using ServiceLayer;

namespace PresentationLayer
{
    public class MainForm : Form
    {
        // Използваме ServiceLayer — той се грижи за DataLayer вместо нас
        private readonly GameService      _gameService;
        private readonly StudioService    _studioService;
        private readonly GenreService     _genreService;
        private readonly PlatformService  _platformService;
        private readonly PublisherService _publisherService;

        private TabControl tabControl = null!;

        // Games
        private DataGridView dgvGames   = null!;
        private TextBox txtGameTitle    = null!;
        private TextBox txtGameYear     = null!;
        private TextBox txtGameStudioId = null!;
        private TextBox txtGamePrice    = null!;
        private TextBox txtGameRating   = null!;
        private Label   lblGameStatus   = null!;

        // Studios
        private DataGridView dgvStudios   = null!;
        private TextBox txtStudioName     = null!;
        private TextBox txtStudioCountry  = null!;
        private TextBox txtStudioFounded  = null!;
        private TextBox txtStudioWebsite  = null!;
        private Label   lblStudioStatus   = null!;

        // Genres
        private DataGridView dgvGenres  = null!;
        private TextBox txtGenreName    = null!;
        private TextBox txtGenreDesc    = null!;
        private Label   lblGenreStatus  = null!;

        // Platforms
        private DataGridView dgvPlatforms       = null!;
        private TextBox txtPlatformName         = null!;
        private TextBox txtPlatformManufacturer = null!;
        private TextBox txtPlatformRelease      = null!;
        private TextBox txtPlatformGen          = null!;
        private Label   lblPlatformStatus       = null!;

        // Publishers
        private DataGridView dgvPublishers    = null!;
        private TextBox txtPublisherName      = null!;
        private TextBox txtPublisherCountry   = null!;
        private TextBox txtPublisherFounded   = null!;
        private Label   lblPublisherStatus    = null!;

        public MainForm()
        {
            _gameService      = new GameService();
            _studioService    = new StudioService();
            _genreService     = new GenreService();
            _platformService  = new PlatformService();
            _publisherService = new PublisherService();

            BuildUI();
            LoadAll();
        }

        // ════════════════════════════════════════════════════════
        // UI BUILDER
        // ════════════════════════════════════════════════════════
        private void BuildUI()
        {
            Text          = "Game Manager";
            Size          = new Size(1050, 700);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize   = new Size(800, 580);
            Font          = new Font("Segoe UI", 9.5f);

            tabControl = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(tabControl);

            tabControl.TabPages.Add(BuildGamesTab());
            tabControl.TabPages.Add(BuildStudiosTab());
            tabControl.TabPages.Add(BuildGenresTab());
            tabControl.TabPages.Add(BuildPlatformsTab());
            tabControl.TabPages.Add(BuildPublishersTab());
        }

        // ── Помощни методи ────────────────────────────────────────

        private static DataGridView MakeGrid() => new DataGridView
        {
            Dock                  = DockStyle.Top,
            Height                = 300,
            ReadOnly              = true,
            AllowUserToAddRows    = false,
            AllowUserToDeleteRows = false,
            SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect           = false,
            AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor       = SystemColors.Window,
            BorderStyle           = BorderStyle.None,
        };

        private static TextBox MakeBox(int width = 220) => new TextBox { Width = width };

        private static Button MakeBtn(string text, Color back) => new Button
        {
            Text      = text,
            Width     = 90,
            Height    = 30,
            BackColor = back,
            FlatStyle = FlatStyle.Flat,
            ForeColor = Color.White,
        };

        private static Label MakeStatus() => new Label
        {
            Dock      = DockStyle.Bottom,
            Height    = 24,
            TextAlign = ContentAlignment.MiddleLeft,
        };

        // Показва статус съобщение — зелено OK, червено грешка
        private static void Status(Label lbl, string msg, bool ok = true)
        {
            lbl.Text      = msg;
            lbl.ForeColor = ok ? Color.ForestGreen : Color.Crimson;
        }

        // Прави ред с лейбъл и поле: [Name:] [TextBox]
        private static Panel MakeRow(string label, Control input)
        {
            var p = new FlowLayoutPanel
            {
                AutoSize      = true,
                FlowDirection = FlowDirection.LeftToRight,
                Margin        = new Padding(0, 4, 0, 0),
            };
            p.Controls.Add(new Label
            {
                Text      = label + ":",
                Width     = 115,
                TextAlign = ContentAlignment.MiddleRight,
            });
            p.Controls.Add(input);
            return p;
        }

        // ════════════════════════════════════════════════════════
        // GAMES TAB
        // ════════════════════════════════════════════════════════
        private TabPage BuildGamesTab()
        {
            var tab = new TabPage("🎮  Games");

            dgvGames = MakeGrid();
            // Когато избереш ред в таблицата, данните се появяват в полетата
            dgvGames.SelectionChanged += (s, e) => FillGameFields();

            txtGameTitle    = MakeBox();
            txtGameYear     = MakeBox(80);
            txtGameStudioId = MakeBox(80);
            txtGamePrice    = MakeBox(100);
            txtGameRating   = MakeBox(80);
            lblGameStatus   = MakeStatus();

            var btnAdd     = MakeBtn("Add",     Color.SteelBlue);
            var btnDelete  = MakeBtn("Delete",  Color.Crimson);
            var btnRefresh = MakeBtn("Refresh", Color.Gray);
            var btnClear   = MakeBtn("Clear",   Color.DimGray);

            btnAdd.Click     += (s, e) => AddGame();
            btnDelete.Click  += (s, e) => DeleteGame();
            btnRefresh.Click += (s, e) => LoadGames();
            btnClear.Click   += (s, e) => ClearGameFields();

            var form = new FlowLayoutPanel
            {
                Dock          = DockStyle.Fill,
                Padding       = new Padding(10),
                FlowDirection = FlowDirection.TopDown,
                AutoScroll    = true,
            };
            form.Controls.Add(MakeRow("Title",     txtGameTitle));
            form.Controls.Add(MakeRow("Year",      txtGameYear));
            form.Controls.Add(MakeRow("Studio ID", txtGameStudioId));
            form.Controls.Add(MakeRow("Price",     txtGamePrice));
            form.Controls.Add(MakeRow("Rating",    txtGameRating));

            var btns = new FlowLayoutPanel { AutoSize = true, Padding = new Padding(0, 8, 0, 0) };
            btns.Controls.AddRange(new Control[] { btnAdd, btnDelete, btnRefresh, btnClear });
            form.Controls.Add(btns);

            tab.Controls.Add(lblGameStatus);
            tab.Controls.Add(form);
            tab.Controls.Add(dgvGames);
            return tab;
        }

        private void LoadGames()
        {
            try
            {
                var list = _gameService.ReadAll(useNavigationalProperties: true).ToList();
                dgvGames.DataSource = list.Select(g => new
                {
                    g.Id,
                    g.Title,
                    Year      = g.ReleaseYear,
                    Studio_id = g.Studio_id,
                    g.Price,
                    g.Rating,
                    Genres    = string.Join(", ", g.Genres?.Select(x => x.Name)    ?? []),
                    Platforms = string.Join(", ", g.Platforms?.Select(x => x.Name) ?? []),
                }).ToList();
            }
            catch (Exception ex) { Status(lblGameStatus, "Error: " + ex.Message, false); }
        }

        private void FillGameFields()
        {
            if (dgvGames.CurrentRow == null) return;
            var row = dgvGames.CurrentRow;
            txtGameTitle.Text    = row.Cells["Title"].Value?.ToString()     ?? "";
            txtGameYear.Text     = row.Cells["Year"].Value?.ToString()      ?? "";
            txtGameStudioId.Text = row.Cells["Studio_id"].Value?.ToString() ?? "";
            txtGamePrice.Text    = row.Cells["Price"].Value?.ToString()     ?? "";
            txtGameRating.Text   = row.Cells["Rating"].Value?.ToString()    ?? "";
        }

        private void AddGame()
        {
            if (!short.TryParse(txtGameYear.Text, out short year))
            { Status(lblGameStatus, "Invalid year.", false); return; }
            if (!int.TryParse(txtGameStudioId.Text, out int studioId))
            { Status(lblGameStatus, "Invalid Studio ID.", false); return; }
            if (!decimal.TryParse(txtGamePrice.Text, out decimal price))
            { Status(lblGameStatus, "Invalid price.", false); return; }
            if (!int.TryParse(txtGameRating.Text, out int rating))
            { Status(lblGameStatus, "Invalid rating.", false); return; }

            try
            {
                var game = new Game(txtGameTitle.Text.Trim(), year, studioId, price, rating);
                _gameService.Create(game);
                LoadGames();
                ClearGameFields();
                Status(lblGameStatus, "Game added successfully!");
            }
            catch (Exception ex) { Status(lblGameStatus, "Error: " + ex.Message, false); }
        }

        private void DeleteGame()
        {
            if (dgvGames.CurrentRow == null)
            { Status(lblGameStatus, "Select a game first.", false); return; }

            int    id    = (int)dgvGames.CurrentRow.Cells["Id"].Value;
            string title = dgvGames.CurrentRow.Cells["Title"].Value?.ToString() ?? "";

            if (MessageBox.Show($"Delete '{title}'?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                _gameService.Delete(id);
                LoadGames();
                Status(lblGameStatus, $"'{title}' deleted.");
            }
            catch (Exception ex) { Status(lblGameStatus, "Error: " + ex.Message, false); }
        }

        private void ClearGameFields()
        {
            txtGameTitle.Clear(); txtGameYear.Clear();
            txtGameStudioId.Clear(); txtGamePrice.Clear(); txtGameRating.Clear();
        }

        // ════════════════════════════════════════════════════════
        // STUDIOS TAB
        // ════════════════════════════════════════════════════════
        private TabPage BuildStudiosTab()
        {
            var tab = new TabPage("🏢  Studios");

            dgvStudios = MakeGrid();
            dgvStudios.SelectionChanged += (s, e) => FillStudioFields();

            txtStudioName    = MakeBox();
            txtStudioCountry = MakeBox();
            txtStudioFounded = MakeBox(150);
            txtStudioWebsite = MakeBox(300);
            lblStudioStatus  = MakeStatus();

            var btnAdd     = MakeBtn("Add",     Color.SteelBlue);
            var btnDelete  = MakeBtn("Delete",  Color.Crimson);
            var btnRefresh = MakeBtn("Refresh", Color.Gray);
            var btnClear   = MakeBtn("Clear",   Color.DimGray);

            btnAdd.Click     += (s, e) => AddStudio();
            btnDelete.Click  += (s, e) => DeleteStudio();
            btnRefresh.Click += (s, e) => LoadStudios();
            btnClear.Click   += (s, e) => ClearStudioFields();

            var form = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, Padding = new Padding(10),
                FlowDirection = FlowDirection.TopDown, AutoScroll = true,
            };
            form.Controls.Add(MakeRow("Name",    txtStudioName));
            form.Controls.Add(MakeRow("Country", txtStudioCountry));
            form.Controls.Add(MakeRow("Founded", txtStudioFounded));
            form.Controls.Add(MakeRow("Website", txtStudioWebsite));

            var btns = new FlowLayoutPanel { AutoSize = true, Padding = new Padding(0, 8, 0, 0) };
            btns.Controls.AddRange(new Control[] { btnAdd, btnDelete, btnRefresh, btnClear });
            form.Controls.Add(btns);

            tab.Controls.Add(lblStudioStatus);
            tab.Controls.Add(form);
            tab.Controls.Add(dgvStudios);
            return tab;
        }

        private void LoadStudios()
        {
            try
            {
                var list = _studioService.ReadAll().ToList();
                dgvStudios.DataSource = list.Select(s => new
                    { s.Studio_id, s.Name, s.Country, s.Founded_date, s.Website }).ToList();
            }
            catch (Exception ex) { Status(lblStudioStatus, "Error: " + ex.Message, false); }
        }

        private void FillStudioFields()
        {
            if (dgvStudios.CurrentRow == null) return;
            var row = dgvStudios.CurrentRow;
            txtStudioName.Text    = row.Cells["Name"].Value?.ToString()        ?? "";
            txtStudioCountry.Text = row.Cells["Country"].Value?.ToString()     ?? "";
            txtStudioFounded.Text = row.Cells["Founded_date"].Value?.ToString() ?? "";
            txtStudioWebsite.Text = row.Cells["Website"].Value?.ToString()     ?? "";
        }

        private void AddStudio()
        {
            try
            {
                var s = new Studio(txtStudioName.Text.Trim(), txtStudioCountry.Text.Trim(),
                                   txtStudioFounded.Text.Trim(), txtStudioWebsite.Text.Trim());
                _studioService.Create(s);
                LoadStudios();
                ClearStudioFields();
                Status(lblStudioStatus, "Studio added!");
            }
            catch (Exception ex) { Status(lblStudioStatus, "Error: " + ex.Message, false); }
        }

        private void DeleteStudio()
        {
            if (dgvStudios.CurrentRow == null)
            { Status(lblStudioStatus, "Select a studio first.", false); return; }

            int    id   = (int)dgvStudios.CurrentRow.Cells["Studio_id"].Value;
            string name = dgvStudios.CurrentRow.Cells["Name"].Value?.ToString() ?? "";

            if (MessageBox.Show($"Delete '{name}'?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _studioService.Delete(id);
                LoadStudios();
                Status(lblStudioStatus, $"'{name}' deleted.");
            }
            catch (Exception ex) { Status(lblStudioStatus, "Error: " + ex.Message, false); }
        }

        private void ClearStudioFields()
        {
            txtStudioName.Clear(); txtStudioCountry.Clear();
            txtStudioFounded.Clear(); txtStudioWebsite.Clear();
        }

        // ════════════════════════════════════════════════════════
        // GENRES TAB
        // ════════════════════════════════════════════════════════
        private TabPage BuildGenresTab()
        {
            var tab = new TabPage("🏷  Genres");

            dgvGenres = MakeGrid();
            dgvGenres.SelectionChanged += (s, e) => FillGenreFields();

            txtGenreName   = MakeBox();
            txtGenreDesc   = new TextBox { Width = 400, Height = 60, Multiline = true };
            lblGenreStatus = MakeStatus();

            var btnAdd     = MakeBtn("Add",     Color.SteelBlue);
            var btnDelete  = MakeBtn("Delete",  Color.Crimson);
            var btnRefresh = MakeBtn("Refresh", Color.Gray);
            var btnClear   = MakeBtn("Clear",   Color.DimGray);

            btnAdd.Click     += (s, e) => AddGenre();
            btnDelete.Click  += (s, e) => DeleteGenre();
            btnRefresh.Click += (s, e) => LoadGenres();
            btnClear.Click   += (s, e) => ClearGenreFields();

            var form = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, Padding = new Padding(10),
                FlowDirection = FlowDirection.TopDown, AutoScroll = true,
            };
            form.Controls.Add(MakeRow("Name",        txtGenreName));
            form.Controls.Add(MakeRow("Description", txtGenreDesc));

            var btns = new FlowLayoutPanel { AutoSize = true, Padding = new Padding(0, 8, 0, 0) };
            btns.Controls.AddRange(new Control[] { btnAdd, btnDelete, btnRefresh, btnClear });
            form.Controls.Add(btns);

            tab.Controls.Add(lblGenreStatus);
            tab.Controls.Add(form);
            tab.Controls.Add(dgvGenres);
            return tab;
        }

        private void LoadGenres()
        {
            try
            {
                var list = _genreService.ReadAll().ToList();
                dgvGenres.DataSource = list.Select(g => new
                    { g.Genre_id, g.Name, g.Description }).ToList();
            }
            catch (Exception ex) { Status(lblGenreStatus, "Error: " + ex.Message, false); }
        }

        private void FillGenreFields()
        {
            if (dgvGenres.CurrentRow == null) return;
            txtGenreName.Text = dgvGenres.CurrentRow.Cells["Name"].Value?.ToString()        ?? "";
            txtGenreDesc.Text = dgvGenres.CurrentRow.Cells["Description"].Value?.ToString() ?? "";
        }

        private void AddGenre()
        {
            try
            {
                var g = new Genre(0, txtGenreName.Text.Trim(),
                                  txtGenreDesc.Text.Trim(), new List<Game>());
                _genreService.Create(g);
                LoadGenres();
                ClearGenreFields();
                Status(lblGenreStatus, "Genre added!");
            }
            catch (Exception ex) { Status(lblGenreStatus, "Error: " + ex.Message, false); }
        }

        private void DeleteGenre()
        {
            if (dgvGenres.CurrentRow == null)
            { Status(lblGenreStatus, "Select a genre first.", false); return; }

            int    id   = (int)dgvGenres.CurrentRow.Cells["Genre_id"].Value;
            string name = dgvGenres.CurrentRow.Cells["Name"].Value?.ToString() ?? "";

            if (MessageBox.Show($"Delete '{name}'?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _genreService.Delete(id);
                LoadGenres();
                Status(lblGenreStatus, $"'{name}' deleted.");
            }
            catch (Exception ex) { Status(lblGenreStatus, "Error: " + ex.Message, false); }
        }

        private void ClearGenreFields() { txtGenreName.Clear(); txtGenreDesc.Clear(); }

        // ════════════════════════════════════════════════════════
        // PLATFORMS TAB
        // ════════════════════════════════════════════════════════
        private TabPage BuildPlatformsTab()
        {
            var tab = new TabPage("🖥  Platforms");

            dgvPlatforms = MakeGrid();
            dgvPlatforms.SelectionChanged += (s, e) => FillPlatformFields();

            txtPlatformName         = MakeBox();
            txtPlatformManufacturer = MakeBox();
            txtPlatformRelease      = MakeBox(150);
            txtPlatformGen          = MakeBox(100);
            lblPlatformStatus       = MakeStatus();

            var btnAdd     = MakeBtn("Add",     Color.SteelBlue);
            var btnDelete  = MakeBtn("Delete",  Color.Crimson);
            var btnRefresh = MakeBtn("Refresh", Color.Gray);
            var btnClear   = MakeBtn("Clear",   Color.DimGray);

            btnAdd.Click     += (s, e) => AddPlatform();
            btnDelete.Click  += (s, e) => DeletePlatform();
            btnRefresh.Click += (s, e) => LoadPlatforms();
            btnClear.Click   += (s, e) => ClearPlatformFields();

            var form = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, Padding = new Padding(10),
                FlowDirection = FlowDirection.TopDown, AutoScroll = true,
            };
            form.Controls.Add(MakeRow("Name",         txtPlatformName));
            form.Controls.Add(MakeRow("Manufacturer", txtPlatformManufacturer));
            form.Controls.Add(MakeRow("Release date", txtPlatformRelease));
            form.Controls.Add(MakeRow("Generation",   txtPlatformGen));

            var btns = new FlowLayoutPanel { AutoSize = true, Padding = new Padding(0, 8, 0, 0) };
            btns.Controls.AddRange(new Control[] { btnAdd, btnDelete, btnRefresh, btnClear });
            form.Controls.Add(btns);

            tab.Controls.Add(lblPlatformStatus);
            tab.Controls.Add(form);
            tab.Controls.Add(dgvPlatforms);
            return tab;
        }

        private void LoadPlatforms()
        {
            try
            {
                var list = _platformService.ReadAll().ToList();
                dgvPlatforms.DataSource = list.Select(p => new
                    { p.Id, p.Name, p.Manufacturer, p.Release_date, p.Generation }).ToList();
            }
            catch (Exception ex) { Status(lblPlatformStatus, "Error: " + ex.Message, false); }
        }

        private void FillPlatformFields()
        {
            if (dgvPlatforms.CurrentRow == null) return;
            var row = dgvPlatforms.CurrentRow;
            txtPlatformName.Text         = row.Cells["Name"].Value?.ToString()         ?? "";
            txtPlatformManufacturer.Text = row.Cells["Manufacturer"].Value?.ToString() ?? "";
            txtPlatformRelease.Text      = row.Cells["Release_date"].Value?.ToString() ?? "";
            txtPlatformGen.Text          = row.Cells["Generation"].Value?.ToString()   ?? "";
        }

        private void AddPlatform()
        {
            try
            {
                var p = new Platform(txtPlatformName.Text.Trim(),
                                     txtPlatformManufacturer.Text.Trim(),
                                     txtPlatformRelease.Text.Trim(),
                                     txtPlatformGen.Text.Trim());
                _platformService.Create(p);
                LoadPlatforms();
                ClearPlatformFields();
                Status(lblPlatformStatus, "Platform added!");
            }
            catch (Exception ex) { Status(lblPlatformStatus, "Error: " + ex.Message, false); }
        }

        private void DeletePlatform()
        {
            if (dgvPlatforms.CurrentRow == null)
            { Status(lblPlatformStatus, "Select a platform first.", false); return; }

            int    id   = (int)dgvPlatforms.CurrentRow.Cells["Id"].Value;
            string name = dgvPlatforms.CurrentRow.Cells["Name"].Value?.ToString() ?? "";

            if (MessageBox.Show($"Delete '{name}'?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _platformService.Delete(id);
                LoadPlatforms();
                Status(lblPlatformStatus, $"'{name}' deleted.");
            }
            catch (Exception ex) { Status(lblPlatformStatus, "Error: " + ex.Message, false); }
        }

        private void ClearPlatformFields()
        {
            txtPlatformName.Clear(); txtPlatformManufacturer.Clear();
            txtPlatformRelease.Clear(); txtPlatformGen.Clear();
        }

        // ════════════════════════════════════════════════════════
        // PUBLISHERS TAB
        // ════════════════════════════════════════════════════════
        private TabPage BuildPublishersTab()
        {
            var tab = new TabPage("📦  Publishers");

            dgvPublishers = MakeGrid();
            dgvPublishers.SelectionChanged += (s, e) => FillPublisherFields();

            txtPublisherName    = MakeBox();
            txtPublisherCountry = MakeBox();
            txtPublisherFounded = MakeBox(150);
            lblPublisherStatus  = MakeStatus();

            var btnAdd     = MakeBtn("Add",     Color.SteelBlue);
            var btnDelete  = MakeBtn("Delete",  Color.Crimson);
            var btnRefresh = MakeBtn("Refresh", Color.Gray);
            var btnClear   = MakeBtn("Clear",   Color.DimGray);

            btnAdd.Click     += (s, e) => AddPublisher();
            btnDelete.Click  += (s, e) => DeletePublisher();
            btnRefresh.Click += (s, e) => LoadPublishers();
            btnClear.Click   += (s, e) => ClearPublisherFields();

            var form = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill, Padding = new Padding(10),
                FlowDirection = FlowDirection.TopDown, AutoScroll = true,
            };
            form.Controls.Add(MakeRow("Name",         txtPublisherName));
            form.Controls.Add(MakeRow("Country",      txtPublisherCountry));
            form.Controls.Add(MakeRow("Founded date", txtPublisherFounded));

            var btns = new FlowLayoutPanel { AutoSize = true, Padding = new Padding(0, 8, 0, 0) };
            btns.Controls.AddRange(new Control[] { btnAdd, btnDelete, btnRefresh, btnClear });
            form.Controls.Add(btns);

            tab.Controls.Add(lblPublisherStatus);
            tab.Controls.Add(form);
            tab.Controls.Add(dgvPublishers);
            return tab;
        }

        private void LoadPublishers()
        {
            try
            {
                var list = _publisherService.ReadAll().ToList();
                dgvPublishers.DataSource = list.Select(p => new
                {
                    p.Publisher_id, p.Name, p.Country,
                    Founded = p.Founded_date.ToShortDateString()
                }).ToList();
            }
            catch (Exception ex) { Status(lblPublisherStatus, "Error: " + ex.Message, false); }
        }

        private void FillPublisherFields()
        {
            if (dgvPublishers.CurrentRow == null) return;
            var row = dgvPublishers.CurrentRow;
            txtPublisherName.Text    = row.Cells["Name"].Value?.ToString()    ?? "";
            txtPublisherCountry.Text = row.Cells["Country"].Value?.ToString() ?? "";
            txtPublisherFounded.Text = row.Cells["Founded"].Value?.ToString() ?? "";
        }

        private void AddPublisher()
        {
            if (!DateTime.TryParse(txtPublisherFounded.Text, out DateTime founded))
            { Status(lblPublisherStatus, "Invalid date. Use yyyy-mm-dd.", false); return; }

            try
            {
                var p = new Publisher(0, txtPublisherName.Text.Trim(),
                                      txtPublisherCountry.Text.Trim(), founded);
                _publisherService.Create(p);
                LoadPublishers();
                ClearPublisherFields();
                Status(lblPublisherStatus, "Publisher added!");
            }
            catch (Exception ex) { Status(lblPublisherStatus, "Error: " + ex.Message, false); }
        }

        private void DeletePublisher()
        {
            if (dgvPublishers.CurrentRow == null)
            { Status(lblPublisherStatus, "Select a publisher first.", false); return; }

            int    id   = (int)dgvPublishers.CurrentRow.Cells["Publisher_id"].Value;
            string name = dgvPublishers.CurrentRow.Cells["Name"].Value?.ToString() ?? "";

            if (MessageBox.Show($"Delete '{name}'?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _publisherService.Delete(id);
                LoadPublishers();
                Status(lblPublisherStatus, $"'{name}' deleted.");
            }
            catch (Exception ex) { Status(lblPublisherStatus, "Error: " + ex.Message, false); }
        }

        private void ClearPublisherFields()
        {
            txtPublisherName.Clear(); txtPublisherCountry.Clear(); txtPublisherFounded.Clear();
        }

        private void LoadAll()
        {
            LoadGames(); LoadStudios(); LoadGenres(); LoadPlatforms(); LoadPublishers();
        }
    }
}
