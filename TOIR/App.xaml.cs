using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TOIR.Infrastructure;
using TOIR.ViewModels;
using TOIR.Views;

namespace TOIR
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();

        public App()
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            displayRootRegistry.RegisterWindowType<EquipmentWindowViewModel, EquipmentWindow>();
            displayRootRegistry.RegisterWindowType<ExecTOWindowViewModel, ExecTOWindow>();
        }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //}

    }
}
