using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Launcher
{
    public class ZazziconeEngine : IZazziconeEngine
    {
        readonly IScoreGenerator<IEnumerable<int>, int> _scoreGenerator;
        readonly IZazziconeRulesFactory _zazziconeRulesFactory;
        readonly ILogger _logger;

        public event EventHandler<EventArgs<Player>> PlayerAdded;
        public event EventHandler<EventArgs<Player>> GameStarted;
        public event EventHandler<EventArgs<Player>> PlayerChanged;
        public event EventHandler<EventArgs<Tuple<Player, int>>> PlayerScored;
        public event EventHandler NewMatch;

        readonly ObservableCollection<Player> _players = new ObservableCollection<Player>();

        readonly IDictionary<Player, List<IRule<IEnumerable<int>, int>>> _playersUsedRules = new Dictionary<Player, List<IRule<IEnumerable<int>, int>>>();

        public ICollection<Player> Players => _players;

        public ZazziconeEngine(IScoreGenerator<IEnumerable<int>, int> scoreGenerator, IZazziconeRulesFactory zazziconeRulesFactory, ILogger logger)
        {
            _scoreGenerator = scoreGenerator;
            _zazziconeRulesFactory = zazziconeRulesFactory;
            _logger = logger;

            _players.CollectionChanged += PlayersOnCollectionChanged;
        }

        void PlayersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            if (eventArgs.Action != NotifyCollectionChangedAction.Add) return;

            var newPlayer = _players[eventArgs.NewStartingIndex];

            _playersUsedRules.Add(newPlayer, new List<IRule<IEnumerable<int>, int>>());

            this.PlayerAdded?.Invoke(this, new EventArgs<Player>(newPlayer));
        }

        public void Start()
        {
            var firstRulesSet = _zazziconeRulesFactory.GetNextRulesSet().ToArray();

            foreach (var list in _playersUsedRules.Values)
                list.AddRange(firstRulesSet);

            //_scoreGenerator.Rules.AddRange(firstRulesSet);

            this.GameStarted?.Invoke(this, new EventArgs<Player>(_players.First()));

            this.NewMatch?.Invoke(this, EventArgs.Empty);
        }

        public void AddScore(Player player, IEnumerable<int> dices)
        {
            dices = dices.ToArray();

            _scoreGenerator.Rules.Clear();
            _scoreGenerator.Rules.AddRange(_playersUsedRules[player]);

            var applicableRules = _scoreGenerator.GetApplicableRules(dices);

            // TODO: Choose which one, for now we will choose the best.
            var highestScoreRule = applicableRules.Select(rule => new { Rule = rule, Result = rule.Apply(dices) }).OrderBy(arg => arg.Result).LastOrDefault();

            var scores = highestScoreRule?.Result;
            //var scores = _scoreGenerator.GenerateScore(dices);

            // Now this rule has been used, the user cannot do it again.
            _playersUsedRules[player].Remove(highestScoreRule?.Rule);

            this.PlayerScored?.Invoke(this, new EventArgs<Tuple<Player, int>>(new Tuple<Player, int>(player, scores ?? 0)));

            this.SetNextPlayer(player);
        }

        void SetNextPlayer(Player player)
        {
            var indexOfPlayer = _players.IndexOf(player);

            indexOfPlayer++;

            if (indexOfPlayer >= _players.Count)
            {
                indexOfPlayer = 0;

                //_scoreGenerator.Rules.Clear();
                //_scoreGenerator.Rules.AddRange(_zazziconeRulesFactory.GetNextRulesSet());
                // If no rules are available, it means this round has ended, let's add the new rules.
                if (! _playersUsedRules.Values.Any(list => list.Any()))
                {
                    var nextRulesSet = _zazziconeRulesFactory.GetNextRulesSet().ToArray();
                    foreach (var list in _playersUsedRules.Values)
                        list.AddRange(nextRulesSet);
                }

                this.NewMatch?.Invoke(this, EventArgs.Empty);
            }

            this.PlayerChanged?.Invoke(this, new EventArgs<Player>(_players[indexOfPlayer]));
        }
    }
}