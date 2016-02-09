using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OpenBrowserApp.Core.ViewModels;
using ReactiveUI;

namespace OpenBrowserApp.WP8.Views
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