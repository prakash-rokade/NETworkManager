﻿using MahApps.Metro.Controls.Dialogs;
using NETworkManager.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace NETworkManager.Views;

public partial class PingMonitorHostView
{
    private readonly PingMonitorHostViewModel _viewModel = new(DialogCoordinator.Instance);

    public PingMonitorHostView()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }
  
    private void ContextMenu_Opened(object sender, RoutedEventArgs e)
    {
        if (sender is ContextMenu menu)
            menu.DataContext = _viewModel;
    }

    private void ListBoxItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            _viewModel.AddHostProfileCommand.Execute(null);
    }

    public void AddHost(string host)
    {
        _viewModel.AddHost(host).ConfigureAwait(false);
    }

    public void OnViewHide()
    {
        _viewModel.OnViewHide();
    }

    public void OnViewVisible()
    {
        _viewModel.OnViewVisible();
    }      
}
