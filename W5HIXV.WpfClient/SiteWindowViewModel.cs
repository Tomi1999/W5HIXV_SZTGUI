using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using W5HIXV_HFT_2023241.Models;

namespace W5HIXV.WpfClient
{
    internal class SiteWindowViewModel : ObservableRecipient
    {
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
        public RestCollection<Site> Sites { get; set; }

        private Site selectedSite;

        public Site SelectedSite
        {
            get { return selectedSite; }
            set
            {
                if (value != null)
                {
                    selectedSite = new Site()
                    {
                        Id = value.Id,
                        Address = value.Address,
                        Size = value.Size,
                        City = value.City,
                        Drivers = value.Drivers,
                        Cars = value.Cars
                    };
                    OnPropertyChanged();
                    (DeleteSiteCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateSiteCommand { get; set; }

        public ICommand UpdateSiteCommand { get; set; }

        public ICommand DeleteSiteCommand { get; set; }

        public SiteWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Sites = new RestCollection<Site>("http://localhost:55762/", "Site");
                CreateSiteCommand = new RelayCommand(() =>
                {
                    int id = Sites.Max(t => t.Id);
                    Sites.Add(new Site()
                    {
                        Id = id + 1,
                        Address = SelectedSite.Address,
                        City = SelectedSite.City,
                        Size = SelectedSite.Size,   

                    });
                }
               );
                DeleteSiteCommand = new RelayCommand(() =>
                {
                    Sites.Delete(SelectedSite.Id);
                },
                () =>
                {
                    return SelectedSite != null;
                }
                );
                UpdateSiteCommand = new RelayCommand(() =>
                {
                    Sites.Update(SelectedSite);
                });
            }
            
        }
    }
}
