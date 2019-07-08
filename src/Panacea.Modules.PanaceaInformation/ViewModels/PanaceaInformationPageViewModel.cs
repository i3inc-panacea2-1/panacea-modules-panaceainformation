using Panacea.Core;
using Panacea.Modularity.UiManager;
using Panacea.Modules.PanaceaInformation.Models;
using Panacea.Modules.PanaceaInformation.Views;
using Panacea.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Panacea.Modules.PanaceaInformation.ViewModels
{
    [View(typeof(PanaceaInformationPage))]
    class PanaceaInformationPageViewModel : ViewModelBase
    {
        private readonly PanaceaServices _core;

        public PanaceaInformationPageViewModel(PanaceaServices core)
        {
            _core = core;
        }

        public override async void Activate()
        {
            try
            {
                if (_core.TryGetUiManager(out IUiManager ui))
                {
                    await ui.DoWhileBusy(async () =>
                    {
                        var resp = await _core.HttpClient.GetObjectAsync<GetPanaceaSettingsResponse>("panaceainfo/get_panacea_categories/");
                        if (resp.Success)
                        {
                            var obj = resp.Result;
                            //if (resp.Result.PanaceaInfo.Settings != null)
                            //    _showPopup = resp.Result.PanaceaInfo.Settings.ShowPopup;
                            var url =
                                _core.HttpClient.RelativeToAbsoluteUri(
                                    obj.PanaceaInfo.PanaceaCategories[0].Items[0].Item.DataUrl);

                            var data = await _core.HttpClient.DownloadDataAsync(url);

                            Document = new FlowDocument();
                            var range = new TextRange(Document.ContentStart, Document.ContentEnd);
                            using (var ms = new MemoryStream(data))
                                range.Load(ms, DataFormats.Rtf);


                            //Host.HospitalServer.PopularNotifyPage("PanaceaInformation");
                            //if (_showPopup)
                            //    Host.ThemeManager.ShowPopup(new BuyServicePopup());
                        }
                    });
                }
            }
            catch
            {
            }
        }


        FlowDocument _document;
        public FlowDocument Document
        {
            get => _document;
            set
            {
                _document = value;
                OnPropertyChanged();
            }
        }
    }
}
