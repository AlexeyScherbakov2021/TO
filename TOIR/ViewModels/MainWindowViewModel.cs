using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TOIR.Commands;
using TOIR.Models;
using TOIR.Repository;
using TOIR.ViewModels.Base;
using TOIR.Views;

namespace TOIR.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        IRepository repo = new RepoGen();
        public List<Equip> listEquipment { get; set; }
        public Equip CurrentEquip { get; set; }


        #region Команды
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommand(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        public ICommand OpenEquipmentWindow { get; }
        private bool CanOpenEquipmentWindow(object p) => CurrentEquip != null;
        private void OnOpenEquipmentWindowExecuted(object p)
        {
            EquipmentWindowViewModel vm = new EquipmentWindowViewModel(CurrentEquip);
            EquipmentWindow win = (EquipmentWindow)(Application.Current as App).displayRootRegistry.CreateWindowWithVM(vm);
            win.ShowDialog();
        }



        #endregion



        public MainWindowViewModel()
        {
            // инициализация команд
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommand);
            OpenEquipmentWindow = new LambdaCommand(OnOpenEquipmentWindowExecuted, CanOpenEquipmentWindow);

            // получение списка оборудования
            listEquipment = repo.GetListEquipment();



        }

    }
}
