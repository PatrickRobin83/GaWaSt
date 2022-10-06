/*
*----------------------------------------------------------------------------------
*          Filename:	BaseEntryModel.cs
*          Date:        2022.10.06
*          All rights reserved
*
*----------------------------------------------------------------------------------
* @author Patrick Robin <support@rietrob.de>
*/

namespace GaWaSt.Core.Models;

public class BaseEntryModel
{
    #region Fields

    #endregion

    #region Properties

    public string ReadingDate { get; set; }
    public double MeterValue { get; set; }

    #endregion

    #region Constructor

    public BaseEntryModel(string readingDate, double meterValue)
    {
        ReadingDate = readingDate;
        MeterValue = meterValue;
    }
    #endregion

    #region Methods

    #endregion

    #region Commands

    #endregion
}