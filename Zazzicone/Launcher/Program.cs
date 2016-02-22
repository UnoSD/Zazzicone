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
            IZazziconeController zazziconeController =
                new ZazziconeController<ColumnHeader>
                (
                    new ZazziconeView(),
                    new ZazziconeEngine
                    (
                        new ScoreGenerator<IEnumerable<int>, int>
                        (
                            new ZazziconeRulesAggregator()
                        ),
                        new ZazziconeRulesFactory(),
                        new Logger()
                    )
                );

            zazziconeController.AfterStart += (_, __) => Application.Run();
            zazziconeController.Closing += (_, __) => Application.Exit();

            zazziconeController.Start();
        }
    }
}
