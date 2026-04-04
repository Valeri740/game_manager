// КОРЕКЦИЯ спрямо предишната версия:
// - Namespace: Business_layer -> BusinessLayer (промяна в проекта на съучениците)
// - Вместо DataLayer контексти директно, използваме ServiceLayer
// - GameManagerDbContext вместо AppDbContext

using BusinessLayer;
using ServiceLayer;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        // Използваме ServiceLayer — той се грижи за DataLayer вместо нас
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

        // Показва статус съобщение — зелено OK, червено грешка
        private static void Status(Label lbl, string msg, bool ok = true)
        {
            lbl.Text      = msg;
            lbl.ForeColor = ok ? Color.ForestGreen : Color.Crimson;
        }



        private void LoadAll()
        {
            LoadGames();
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

        private void dgvGames_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGames.CurrentRow == null) return;
            var row = dgvGames.CurrentRow;
            txtGameTitle.Text    = row.Cells["Title"].Value?.ToString()     ?? "";
            txtGameYear.Text     = row.Cells["Year"].Value?.ToString()      ?? "";
            txtGameStudioId.Text = row.Cells["Studio_id"].Value?.ToString() ?? "";
            txtGamePrice.Text    = row.Cells["Price"].Value?.ToString()     ?? "";
            txtGameRating.Text   = row.Cells["Rating"].Value?.ToString()    ?? "";
        }

        private void btnGameAdd_Click(object sender, EventArgs e)
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
                btnGameClear_Click(sender, e);
                Status(lblGameStatus, "Game added successfully!");
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

        private void btnGameRefresh_Click(object sender, EventArgs e)
        {
            LoadGames();
        }

        private void btnGameClear_Click(object sender, EventArgs e)
        {
            txtGameTitle.Clear(); txtGameYear.Clear();
            txtGameStudioId.Clear(); txtGamePrice.Clear(); txtGameRating.Clear();
        }
    }
}
