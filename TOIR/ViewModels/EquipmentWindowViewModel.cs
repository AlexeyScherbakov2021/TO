using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TOIR.Commands;
using TOIR.Infrastructure;
using TOIR.Models;
using TOIR.Repository;
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
            //EquipTO to;

            if (p.ToString() == "Regl")
            {
                CurrentTO = CurrentReglTO;
            }
            else if (p.ToString() == "Plan")
            {
                CurrentTO = CurrentPlanTO;
            }
            else
                return;

            if (CurrentTO != null)
            {
                ExecTOWindowViewModel vm = new ExecTOWindowViewModel(CurrentTO, repo);
                ExecTOWindow win = (ExecTOWindow)(Application.Current as App).displayRootRegistry.CreateWindowWithVM(vm);
                win.ShowDialog();
                if(vm.result)
                {
                    // ТО было полностью выполнено
                    AddNewReglamentTO();
                }
            }
        }

        #endregion

        IRepository repo;
        public EquipTO CurrentReglTO { get; set; }
        public EquipTO CurrentPlanTO { get; set; }
        public EquipTO CurrentTO;

        public Equip equip
        {
            get;
            set;
        }

        public EquipmentWindowViewModel() { }

        public EquipmentWindowViewModel(Equip eq, IRepository rep) : this()
        {
            equip = eq;
            repo = rep;
            OpenExecTOCommand = new LambdaCommand(OnOpenExecTOCommandExecuted, CanOpenExecTOCommand);

        }

        public void AddNewReglamentTO()
        {
            KindTO nextKind;

            if (equip.ReglamentTO.kindTO == KindTO.TO1)
                nextKind = KindTO.TO2;
            else
                nextKind = KindTO.TOLong;

            TO t = repo.GetListTO().Where(w => w.kindTO == nextKind).FirstOrDefault();

            CurrentTO.DateSet = DateTime.Now;

            equip.ReglamentTO = new EquipTO(t);
            equip.ReglamentTO.NumTO = CurrentTO.NumTO + 1;
            equip.ReglamentTO.Name = "ТО-" + (equip.ReglamentTO.NumTO);
            equip.ReglamentTO.equip = equip;
            equip.ReglamentTO.DatePlan = DateTime.Now.AddMonths(equip.ReglamentTO.WarrantyMonth);
            equip.listReglamnetTO.Add(equip.ReglamentTO);
            equip.EndWarranty = equip.ReglamentTO.DatePlan;

        }

    }
}
