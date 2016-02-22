using System;
using System.Collections.Generic;

namespace Launcher
{
    public interface IGameEngine<in TPlayerScoreInput, TPlayerScoreOutput>
    {
        event EventHandler<EventArgs<Player>> PlayerAdded;
        event EventHandler<EventArgs<Player>> GameStarted;
        event EventHandler<EventArgs<Player>> PlayerChanged;
        event EventHandler<EventArgs<Tuple<Player, TPlayerScoreOutput>>> PlayerScored;
        event EventHandler NewMatch;

        ICollection<Player> Players { get; }

        void Start();

        void AddScore(Player player, TPlayerScoreInput dices);
    }
}