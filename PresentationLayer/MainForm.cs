using BusinessLayer;
using ServiceLayer;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        private readonly GameService      _gameService;
        private readonly StudioService    _studioService;
        private readonly GenreService     _genreService;
        private readonly PlatformService  _platformService;
        private readonly PublisherService _publisherService;

        public MainForm()
        {
            InitializeComponent();

            _gameService      = new GameService();
            _studioService    = new StudioService();
            _genreService     = new GenreService();
            _platformService  = new PlatformService();
            _publisherService = new PublisherService();

            LoadAll();
        }

        private static void Status(Label lbl, string msg, bool ok = true)
        {
            lbl.Text      = msg;
            lbl.ForeColor = ok ? Color.ForestGreen : Color.Crimson;
        }

        private void LoadAll()
        {
            LoadGames();
            LoadStudios();
        }

        // ==========================
        // GAMES TAB LOGIC
        // ==========================
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
                    Multiplayer = g.Multiplayer,
                    Genres    = string.Join(", ", g.Genres?.Select(x => x.Name)    ?? []),
                    Platforms = string.Join(", ", g.Platforms?.Select(x => x.Name) ?? []),
                }).ToList();
            }
            catch (Exception ex) { Status(lblGameStatus, "Error: " + ex.Message, false); }
        }

        private void dgvGames_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null) return;
            var row = dgvGames.CurrentRow;
            txtGameTitle.Text      = row.Cells["Title"].Value?.ToString()       ?? "";
            txtGameYear.Text       = row.Cells["Year"].Value?.ToString()        ?? "";
            txtGameStudioId.Text   = row.Cells["Studio_id"].Value?.ToString()   ?? "";
            txtGamePrice.Text      = row.Cells["Price"].Value?.ToString()       ?? "";
            txtGameRating.Text     = row.Cells["Rating"].Value?.ToString()      ?? "";
            txtGameMultiplayer.Text = row.Cells["Multiplayer"].Value?.ToString() ?? "";
        }

        private void btnGameAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateGameInputs(out short year, out int studioId, out decimal price, out int rating)) return;

            try
            {
                var game = new Game(txtGameTitle.Text.Trim(), year, studioId, price, rating);
                game.Multiplayer = txtGameMultiplayer.Text.Trim();
                _gameService.Create(game);
                LoadGames();
                btnGameClear_Click(sender, e);
                Status(lblGameStatus, "Game added successfully!");
            }
            catch (Exception ex) { Status(lblGameStatus, "Error: " + ex.Message, false); }
        }

        private void btnGameUpdate_Click(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null)
            { Status(lblGameStatus, "Select a game first.", false); return; }

            if (!ValidateGameInputs(out short year, out int studioId, out decimal price, out int rating)) return;

            try
            {
                int id = (int)dgvGames.CurrentRow.Cells["Id"].Value;
                var game = _gameService.Read(id);
                game.Title = txtGameTitle.Text.Trim();
                game.ReleaseYear = year;
                game.Studio_id = studioId;
                game.Price = price;
                game.Rating = rating;
                game.Multiplayer = txtGameMultiplayer.Text.Trim();

                _gameService.Update(game);
                LoadGames();
                Status(lblGameStatus, "Game updated successfully!");
            }
            catch (Exception ex) { Status(lblGameStatus, "Error: " + ex.Message, false); }
        }

        private void btnGameDelete_Click(object sender, EventArgs e)
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

        private void btnGameRefresh_Click(object sender, EventArgs e) => LoadGames();
        
        private void btnGameClear_Click(object sender, EventArgs e)
        {
            txtGameTitle.Clear(); txtGameYear.Clear(); txtGameMultiplayer.Clear();
            txtGameStudioId.Clear(); txtGamePrice.Clear(); txtGameRating.Clear();
        }

        private bool ValidateGameInputs(out short year, out int studioId, out decimal price, out int rating)
        {
            year = 0; studioId = 0; price = 0; rating = 0;
            if (!short.TryParse(txtGameYear.Text, out year)) { Status(lblGameStatus, "Invalid year.", false); return false; }
            if (!int.TryParse(txtGameStudioId.Text, out studioId)) { Status(lblGameStatus, "Invalid Studio ID.", false); return false; }
            if (!decimal.TryParse(txtGamePrice.Text, out price)) { Status(lblGameStatus, "Invalid price.", false); return false; }
            if (!int.TryParse(txtGameRating.Text, out rating)) { Status(lblGameStatus, "Invalid rating.", false); return false; }
            return true;
        }

        // ==========================
        // STUDIOS TAB LOGIC
        // ==========================
        private void LoadStudios()
        {
            try
            {
                var list = _studioService.ReadAll().ToList();
                dgvStudios.DataSource = list.Select(s => new
                {
                    Id = s.Studio_id,
                    s.Name,
                    s.Country,
                    Founded = s.Founded_date,
                    s.Website
                }).ToList();
            }
            catch (Exception ex) { Status(lblStudioStatus, "Error: " + ex.Message, false); }
        }

        private void dgvStudios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudios.CurrentRow == null) return;
            var row = dgvStudios.CurrentRow;
            txtStudioName.Text    = row.Cells["Name"].Value?.ToString()    ?? "";
            txtStudioCountry.Text = row.Cells["Country"].Value?.ToString() ?? "";
            txtStudioFounded.Text = row.Cells["Founded"].Value?.ToString() ?? "";
            txtStudioWebsite.Text = row.Cells["Website"].Value?.ToString() ?? "";
        }

        private void btnStudioAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var studio = new Studio(txtStudioName.Text.Trim(), txtStudioCountry.Text.Trim(), 
                                        txtStudioFounded.Text.Trim(), txtStudioWebsite.Text.Trim());
                _studioService.Create(studio);
                LoadStudios();
                btnStudioClear_Click(sender, e);
                Status(lblStudioStatus, "Studio added successfully!");
            }
            catch (Exception ex) { Status(lblStudioStatus, "Error: " + ex.Message, false); }
        }

        private void btnStudioUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStudios.CurrentRow == null)
            { Status(lblStudioStatus, "Select a studio first.", false); return; }

            try
            {
                int id = (int)dgvStudios.CurrentRow.Cells["Id"].Value;
                var studio = _studioService.Read(id);
                studio.Name = txtStudioName.Text.Trim();
                studio.Country = txtStudioCountry.Text.Trim();
                studio.Founded_date = txtStudioFounded.Text.Trim();
                studio.Website = txtStudioWebsite.Text.Trim();

                _studioService.Update(studio);
                LoadStudios();
                Status(lblStudioStatus, "Studio updated successfully!");
            }
            catch (Exception ex) { Status(lblStudioStatus, "Error: " + ex.Message, false); }
        }

        private void btnStudioDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudios.CurrentRow == null)
            { Status(lblStudioStatus, "Select a studio first.", false); return; }

            int    id   = (int)dgvStudios.CurrentRow.Cells["Id"].Value;
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

        private void btnStudioRefresh_Click(object sender, EventArgs e) => LoadStudios();

        private void btnStudioClear_Click(object sender, EventArgs e)
        {
            txtStudioName.Clear(); txtStudioCountry.Clear(); 
            txtStudioFounded.Clear(); txtStudioWebsite.Clear();
        }
    }
}
