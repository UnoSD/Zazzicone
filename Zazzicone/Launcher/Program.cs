using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var zazziconeView = new ZazziconeView();

            IZazziconeController zazziconeController =
                new ZazziconeController<ColumnHeader>
                (
                    zazziconeView,
                    new ZazziconeEngine
                    (
                        new ScoreGenerator<IEnumerable<int>, int>
                        (
                            new ZazziconeRulesAggregator()
                        ),
                        new ZazziconeRulesFactory(),
                        new Logger(zazziconeView.Log)
                    )
                );

            zazziconeController.AfterStart += (_, __) => Application.Run();
            zazziconeController.Closing += (_, __) => Application.Exit();

            zazziconeController.Start();
        }
    }
}
