using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV.WpfClient
{
    public class SiteNonCrudViewModel : ObservableRecipient
    {
        private JSonDownloader downloader = new JSonDownloader("http://localhost:55762/");

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        private List<Site> sites;

        public List<Site> Sites
        {
            get { return sites; }
            set
            {
                sites = value;
                OnPropertyChanged(nameof(Sites));
            }
        }

        private string nonCrudValue;

        public string NonCrudValue
        {
            get { return nonCrudValue; }
            set { nonCrudValue = value; }
        }

        private Site selectedSite;

        public Site SelectedSite
        {
            get { return selectedSite; }
            set
            {
                if (value != null)
                {
                    selectedSite = value;
                    OnPropertyChanged();
                   
                }
            }
        }
        public ICommand SitesSizeCommand { get; set; }

        public ICommand SiteInCityCommand { get; set; }
        public SiteNonCrudViewModel()
        {
            if (!IsInDesignMode)
            {
                SitesSizeCommand = new RelayCommand(async () =>
                {
                    var sitesNon = await downloader.Download<Site>("SiteNon/SiteInCity?city=" + nonCrudValue);
                    Sites = sitesNon;
                });
                SiteInCityCommand = new RelayCommand(async () =>
                {
                    var sitesNon = await downloader.Download<Site>("SiteNon/SitesSize?size=" + nonCrudValue);
                    Sites = sitesNon;
                });
            }
        }
    }
}
