using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OpenBrowserApp.Core.ViewModels;
using ReactiveUI;


namespace OpenBrowserApp.WPA.Views
{
    public sealed partial class HomeView : IViewFor<HomeViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel",
            typeof(HomeViewModel),
            typeof(HomeView),
            new PropertyMetadata(default(HomeViewModel)));

        public HomeView()
        {
            InitializeComponent();

            ViewModel = new HomeViewModel();

            this.WhenActivated(
                dispose =>
                {
                    dispose(this.Bind(ViewModel, vm => vm.WebsiteAddress, v => v.WebsiteAddress.Text));
                    dispose(this.BindCommand(ViewModel, vm => vm.OpenWebPage, v => v.OpenBrowserButton));
                });
        }

        private HomeViewModel BindingRoot => ViewModel;

        public HomeViewModel ViewModel
        {
            get { return (HomeViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (HomeViewModel)value; }
        }
    }
}
