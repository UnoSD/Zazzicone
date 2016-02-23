using System;
using System.Collections.Generic;

namespace Launcher
{
    public interface IZazziconeView<TPlayerViewModel>
    {
        event EventHandler<EventArgs<string>> AddPlayerRequest;
        event EventHandler StartGameRequest;
        event EventHandler CloseRequest;
        event EventHandler<EventArgs<Tuple<TPlayerViewModel, IEnumerable<int>>>> AddScoreRequest;

        void Display();

        TPlayerViewModel AddPlayer(string name);

        void SetGameSetupEnabled(bool enabled);
        void SetEnabled(bool enabled);
        void SetCurrentPlayer(TPlayerViewModel playerViewModel);
        void AddScore(TPlayerViewModel playerViewModel, int score);
        void NewScoreSet();
        void Log(string message);
    }
}