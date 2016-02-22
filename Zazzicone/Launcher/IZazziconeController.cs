using System;

namespace Launcher
{
    public interface IZazziconeController
    {
        event EventHandler BeforeStart;
        event EventHandler AfterStart;
        event EventHandler Closing;

        void Start();
    }
}