using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Launcher
{
    public partial class ZazziconeView : Form, IZazziconeView<ColumnHeader>
    {
        public event EventHandler<EventArgs<string>> AddPlayerRequest;
        public event EventHandler StartGameRequest;
        public event EventHandler CloseRequest;
        public event EventHandler<EventArgs<Tuple<ColumnHeader, IEnumerable<int>>>> AddScoreRequest;

        readonly NumericUpDown[] _dicesControls;

        ColumnHeader _currentPlayer;
        ListViewItem _currentScoreSet;

        public ZazziconeView()
        {
            InitializeComponent();

            _dicesControls = new[] { nud1, nud2, nud3, nud4, nud5 };
        }

        void btnAddNewPlayer_Click(object sender, EventArgs e) => this.AddPlayerRequest?.Invoke(this, new EventArgs<string>(txtPlayerName.Text));

        void btnStartGame_Click(object sender, EventArgs e) => this.StartGameRequest?.Invoke(this, EventArgs.Empty);

        public void Display() => this.Show();

        public ColumnHeader AddPlayer(string name) => lvwGame.Columns.Add(name);

        public void SetEnabled(bool enabled)
        {
            foreach (Control control in this.Controls)
                control.Enabled = enabled;
        }

        public void SetCurrentPlayer(ColumnHeader playerViewModel)
        {
            _currentPlayer = playerViewModel;

            this.Text = _currentPlayer.Text;
        }

        public void AddScore(ColumnHeader playerViewModel, int score) => _currentScoreSet.SubItems[playerViewModel.Index].Text = score.ToString();

        public void NewScoreSet()
        {
            var scores = new string[lvwGame.Columns.Count];

            var listViewItem = new ListViewItem(scores);

            lvwGame.Items.Add(listViewItem);

            _currentScoreSet = listViewItem;
        }

        public void SetGameSetupEnabled(bool enabled)
        {
            txtPlayerName.Enabled = enabled;
            btnAddNewPlayer.Enabled = enabled;
            btnStartGame.Enabled = enabled;
        }

        void txtPlayerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            if (string.IsNullOrEmpty(txtPlayerName.Text))
            {
                btnStartGame.PerformClick();
                return;
            }

            btnAddNewPlayer.PerformClick();
            txtPlayerName.Clear();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;

            this.CloseRequest?.Invoke(this, EventArgs.Empty);
        }

        void btnRollDices_Click(object sender, EventArgs e)
        {
            var random = new Random(DateTime.Now.Millisecond);

            foreach (var diceControl in _dicesControls)
                diceControl.Value = random.Next(1, 7);

            btnAddScore.Focus();
        }

        void btnAddScore_Click(object sender, EventArgs e)
        {
            var values = new Tuple<ColumnHeader, IEnumerable<int>>(_currentPlayer, this.GetCurrentScore());

            var eventArgs = new EventArgs<Tuple<ColumnHeader, IEnumerable<int>>>(values);

            this.AddScoreRequest?.Invoke(this, eventArgs);

            btnRollDices.Focus();
        }

        IEnumerable<int> GetCurrentScore() => _dicesControls.Select(down => (int)down.Value);
    }
}
