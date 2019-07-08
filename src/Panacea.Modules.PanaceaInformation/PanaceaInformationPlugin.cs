using Panacea.Core;
using Panacea.Modularity.UiManager;
using Panacea.Modules.PanaceaInformation.Models;
using Panacea.Modules.PanaceaInformation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Panacea.Modules.PanaceaInformation
{
    public class PanaceaInformationPlugin : ICallablePlugin
    {
        private readonly PanaceaServices _core;

        public PanaceaInformationPlugin(PanaceaServices core)
        {
            _core = core;
        }

        public Task BeginInit()
        {
            return Task.CompletedTask;
        }

        public void Call()
        {
            if (_core.TryGetUiManager(out IUiManager ui))
            {
                ui.Navigate(new PanaceaInformationPageViewModel(_core));
            }
        }

        public void Dispose()
        {

        }

        public Task EndInit()
        {
            return Task.CompletedTask;
        }

        public Task Shutdown()
        {
            return Task.CompletedTask;
        }
    }
}
