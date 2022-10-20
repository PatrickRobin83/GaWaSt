/*
*----------------------------------------------------------------------------------
*          Filename:	MainWindowViewModel.cs
*          Date:        2022.10.05
*          All rights reserved
*
*----------------------------------------------------------------------------------
* @author Patrick Robin <support@rietrob.de>
*/

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GaWaSt.WPF.Views;

namespace GaWaSt.WPF.ViewModels;
[ObservableObject]
public partial class MainWindowViewModel
{
    #region Fields
    #endregion

    #region Properties

    [ObservableProperty] private object _currentView;

    private GasView _gasView = new GasView
    {
        DataContext = new GasViewModel()
    };

    private WaterView _waterView = new WaterView
    {
        DataContext = new WaterViewModel()
    };

    private PowerView _powerView = new PowerView
    {
        DataContext = new PowerViewModel()
    };
    #endregion

    #region Constructor

    public MainWindowViewModel()
    {
        CurrentView = _powerView;
    }
    #endregion

    #region Methods

    #endregion

    #region Commands

    [RelayCommand]
    private void ShowGasContent()
    {
        CurrentView = _gasView;
    }

    [RelayCommand]
    private void ShowWaterContent()
    {
        CurrentView = _waterView;
    }

    [RelayCommand]
    private void ShowPowerContent()
    {
        CurrentView = _powerView;
    }

    [RelayCommand]
    private void Exit()
    {
        Environment.Exit(0);
    }
    #endregion
}