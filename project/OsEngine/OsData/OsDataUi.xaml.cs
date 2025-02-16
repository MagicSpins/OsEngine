﻿/*
 * Your rights to use code governed by this license https://github.com/AlexWan/OsEngine/blob/master/LICENSE
 * Ваши права на использование кода регулируются данной лицензией http://o-s-a.net/doc/license_simple_engine.pdf
*/

using OsEngine.Entity;
using System.Windows;
using OsEngine.Language;
using OsEngine.Layout;

namespace OsEngine.OsData
{
    /// <summary>
    /// Interaction Logic for OsDataUi.xaml
    /// Логика взаимодействия для OsDataUi.xaml
    /// </summary>
    public partial class OsDataUi
    {
        OsDataMaster _osDataMaster;
        public OsDataUi()
        {
            
            InitializeComponent();
            OsEngine.Layout.StickyBorders.Listen(this);
            _osDataMaster = new OsDataMaster(ChartHostPanel, HostLog, HostSource,
                HostSet, ComboBoxSecurity,ComboBoxTimeFrame,RectChart, GreedChartPanel);
            CheckBoxPaintOnOff.IsChecked = _osDataMaster.IsPaintEnabled;
            CheckBoxPaintOnOff.Click += CheckBoxPaintOnOff_Click;
            LabelOsa.Content = "V_" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Closing += OsDataUi_Closing;
            Label4.Content = OsLocalization.Data.Label4;
            Label24.Content = OsLocalization.Data.Label24;
            CheckBoxPaintOnOff.Content = OsLocalization.Data.Label25;
            Label26.Header = OsLocalization.Data.Label26;
            NewDataSetButton.Content = OsLocalization.Data.Label30;

            this.Activate();
            this.Focus();
        }

        void CheckBoxPaintOnOff_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxPaintOnOff.IsChecked.HasValue &&
                CheckBoxPaintOnOff.IsChecked.Value)
            {
                _osDataMaster.StartPaint();
                _osDataMaster.SaveSettings();
            }
            else
            {
                _osDataMaster.StopPaint();
                _osDataMaster.SaveSettings();
            }
            GlobalGUILayout.Listen(this, "osData");
        }

        void OsDataUi_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AcceptDialogUi ui = new AcceptDialogUi(OsLocalization.Data.Label27);
            ui.ShowDialog();

            if (ui.UserAcceptActioin == false)
            {
                e.Cancel = true;
            }
        }

        private void NewDataSetButton_Click(object sender, RoutedEventArgs e)
        {
            _osDataMaster.CreateNewSet();
        }
    }
}
