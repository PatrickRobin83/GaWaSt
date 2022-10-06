/*
*----------------------------------------------------------------------------------
*          Filename:	PowerView.cs
*          Date:        2022.10.05
*          All rights reserved
*
*----------------------------------------------------------------------------------
* @author Patrick Robin <support@rietrob.de>
*/

using System;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Printing;
using System.Runtime.InteropServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GaWaSt.Core;
using GaWaSt.Core.Constants;
using GaWaSt.Core.Models;

namespace GaWaSt.WPF.ViewModels;

[ObservableObject]
public partial class PowerViewModel
{
    #region Fields

    private IniFileReader _iniReader = new IniFileReader(ConstantStrings.INIFILEPATH);
    #endregion

    #region Properties

    [ObservableProperty]
    private double _basicPricePerYear;
    [ObservableProperty]
    private double _pricePerKWh;
    [ObservableProperty]
    private double _basicPricePerMonth = 0;
    [ObservableProperty]
    private bool _isChangePricePerYearChecked;
    [ObservableProperty]
    private bool _isChangePricePerKWhChecked;
    [ObservableProperty] 
    private bool _isPricePerKWhChangeSaved;
    [ObservableProperty] 
    private bool _isBasicPricePerYearChangeSaved;

    [ObservableProperty] 
    private ObservableCollection<PowerEntryModel> _powerEntrys = new ObservableCollection<PowerEntryModel>();

    #endregion

    #region Constructor

    public PowerViewModel()
    {
        IsPricePerKWhChangeSaved = true;
        IsBasicPricePerYearChangeSaved = true;
        BasicPricePerYear = Convert.ToDouble(_iniReader.Read("basicpricePerYear", "power"));
        PricePerKWh = Convert.ToDouble(_iniReader.Read("consumingpricePerKWh", "Power"));
        PowerEntrys.Add(new PowerEntryModel(DateTime.Now.AddMonths(-5).ToShortDateString(), 12.43 ));
        PowerEntrys.Add(new PowerEntryModel(DateTime.Now.AddMonths(-4).ToShortDateString(), 14.43));
        PowerEntrys.Add(new PowerEntryModel(DateTime.Now.AddMonths(-3).ToShortDateString(), 16.43));
        PowerEntrys.Add(new PowerEntryModel(DateTime.Now.AddMonths(-2).ToShortDateString(), 18.43));
        PowerEntrys.Add(new PowerEntryModel(DateTime.Now.AddMonths(-1).ToShortDateString(), 20.43));
        PowerEntrys.Add(new PowerEntryModel(DateTime.Now.ToShortDateString(), 24.43));
    }
    #endregion

    #region Methods
    partial void OnBasicPricePerYearChanged(double value)
    {
        BasicPricePerMonth = BasicPricePerYear / 12;
    }

    partial void OnIsChangePricePerYearCheckedChanged(bool value)
    {
        IsBasicPricePerYearChangeSaved = !value;
    }

    partial void OnIsChangePricePerKWhCheckedChanged(bool value)
    {
        IsPricePerKWhChangeSaved = !value;
    }

    #endregion

    #region Commands
    [RelayCommand]
    private void SaveBasicPricePerYear()
    {
        IsChangePricePerYearChecked = false;
       _iniReader.Write("basicpricePerYear", Convert.ToString(BasicPricePerYear),"Power");
    }

    [RelayCommand]
    private void SavePricePerKWh()
    {
        IsChangePricePerKWhChecked = false;
        _iniReader.Write("consumingpricePerKWh", Convert.ToString(PricePerKWh), "Power");
    }

    #endregion
}