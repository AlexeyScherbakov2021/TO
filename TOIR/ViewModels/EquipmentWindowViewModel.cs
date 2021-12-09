using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TOIR.Commands;
using TOIR.Models;
using TOIR.ViewModels.Base;
using TOIR.Views;

namespace TOIR.ViewModels
{
    internal class EquipmentWindowViewModel : ViewModel
    {
        #region Команды
        public ICommand OpenExecTOCommand { get; }
        private bool CanOpenExecTOCommand(object p) => true;
        private void OnOpenExecTOCommandExecuted(object p)
        {
            EquipTO to;

            if (p.ToString() == "Regl")
            {
                to = CurrentReglTO;
            }
            else if (p.ToString() == "Plan")
            {
                to = CurrentPlanTO;
            }
            else
                return;

            if (to != null)
            {
                ExecTOWindowViewModel vm = new ExecTOWindowViewModel(to);
                ExecTOWindow win = (ExecTOWindow)(Application.Current as App).displayRootRegistry.CreateWindowWithVM(vm);
                win.ShowDialog();
            }
        }
        #endregion


        public EquipTO CurrentReglTO { get; set; }
        public EquipTO CurrentPlanTO { get; set; }
        public Equip equip { get; set; }

        public EquipmentWindowViewModel() { }

        public EquipmentWindowViewModel(Equip eq) : this()
        {
            equip = eq;
            OpenExecTOCommand = new LambdaCommand(OnOpenExecTOCommandExecuted, CanOpenExecTOCommand);

        }
    }
}
