using System;
using System.Collections.Generic;

namespace Launcher
{
    // TODO: Split the controller as it's growing too much.
    public class ZazziconeController<TPlayerViewModel> : IZazziconeController
    {
        readonly IZazziconeView<TPlayerViewModel> _zazziconeView;
        readonly IZazziconeEngine _zazziconeEngine;
        
        public event EventHandler BeforeStart;
        public event EventHandler AfterStart;
        public event EventHandler Closing;

        readonly IMap<Player, TPlayerViewModel> _players = new Map<Player, TPlayerViewModel>();

        public ZazziconeController(IZazziconeView<TPlayerViewModel> zazziconeView, IZazziconeEngine zazziconeEngine)
        {
            _zazziconeView = zazziconeView;
            _zazziconeEngine = zazziconeEngine;

            AddHandlers();
        }

        void AddHandlers()
        {
            _zazziconeView.AddPlayerRequest += (_, args) => _zazziconeEngine.Players.Add(new Player { Name = args.Value });
            _zazziconeView.StartGameRequest += (_, __) => _zazziconeEngine.Start();
            _zazziconeView.CloseRequest += (_, __) => this.Closing?.Invoke(this, EventArgs.Empty);
            _zazziconeView.AddScoreRequest += ZazziconeViewOnAddScoreRequest;

            _zazziconeEngine.PlayerAdded += ZazziconeEngineOnPlayerAdded;
            _zazziconeEngine.GameStarted += ZazziconeEngineOnGameStarted;
            _zazziconeEngine.PlayerChanged += ZazziconeEngineOnPlayerChanged;
            _zazziconeEngine.PlayerScored += ZazziconeEngineOnPlayerScored;
            _zazziconeEngine.NewMatch += ZazziconeEngineOnNewMatch;
        }

        void ZazziconeEngineOnNewMatch(object sender, EventArgs eventArgs)
        {
            _zazziconeView.NewScoreSet();
        }

        void ZazziconeEngineOnPlayerScored(object sender, EventArgs<Tuple<Player, int>> eventArgs)
        {
            var playerViewModel = _players[eventArgs.Value.Item1];

            _zazziconeView.AddScore(playerViewModel, eventArgs.Value.Item2);
        }

        void ZazziconeEngineOnPlayerChanged(object sender, EventArgs<Player> eventArgs)
        {
            var playerViewModel = _players[eventArgs.Value];

            _zazziconeView.SetCurrentPlayer(playerViewModel);
        }

        void ZazziconeViewOnAddScoreRequest(object sender, EventArgs<Tuple<TPlayerViewModel, IEnumerable<int>>> eventArgs)
        {
            var player = _players[eventArgs.Value.Item1];

            _zazziconeEngine.AddScore(player, eventArgs.Value.Item2);
        }

        void ZazziconeEngineOnPlayerAdded(object sender, EventArgs<Player> eventArgs)
        {
            var viewPlayer = _zazziconeView.AddPlayer(eventArgs.Value.Name);

            _players.Add(eventArgs.Value, viewPlayer);
        }

        void ZazziconeEngineOnGameStarted(object sender, EventArgs<Player> eventArgs)
        {
            _zazziconeView.SetEnabled(true);
            _zazziconeView.SetGameSetupEnabled(false);

            var playerViewModel = _players[eventArgs.Value];

            _zazziconeView.SetCurrentPlayer(playerViewModel);
        }

        public void Start()
        {
            this.BeforeStart?.Invoke(this, EventArgs.Empty);

            _zazziconeView.SetEnabled(false);
            _zazziconeView.SetGameSetupEnabled(true);

            _zazziconeView.Display();

            this.AfterStart?.Invoke(this, EventArgs.Empty);
        }
    }
}