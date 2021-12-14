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
        private bool CanOpenExecTOCommand(object p)
        {
            return CurrentReglTO?.DateSet.Year < 2000;
        }
        private void OnOpenExecTOCommandExecuted(object p)
        {
            if (CurrentReglTO != null)
            {
                ExecTOWindowViewModel vm = new ExecTOWindowViewModel(CurrentReglTO, repo);
                ExecTOWindow win = (ExecTOWindow)(Application.Current as App).displayRootRegistry.CreateWindowWithVM(vm);
                vm.win = win;
                win.ShowDialog();
                if(vm.result)
                {
                    // ТО было полностью выполнено
                    MessageBox.Show("ТО завершено. Гарантия продлевается.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    AddNewReglamentTO();

                }
            }
        }

        public ICommand OpenExecPlanTOCommand { get; }
        private bool CanOpenExecPlanTOCommand(object p)
        {
            return CurrentPlanTO?.DateSet.Year < 2000;
        }

        private void OnOpenExecPlanTOCommandExecuted(object p)
        {
            if (CurrentPlanTO != null)
            {
                ExecTOWindowViewModel vm = new ExecTOWindowViewModel(CurrentPlanTO, repo);
                ExecTOWindow win = (ExecTOWindow)(Application.Current as App).displayRootRegistry.CreateWindowWithVM(vm);
                vm.win = win;
                win.ShowDialog();
                if (vm.result)
                {
                    // ТО было полностью выполнено
                    MessageBox.Show("Плановое ТО завершено. Назначено новое.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    AddNewPlanTO();
                }
            }
        }

        #endregion

        IRepository repo;
        public EquipTO CurrentReglTO { get; set; }
        public EquipTO CurrentPlanTO { get; set; }

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
            OpenExecPlanTOCommand = new LambdaCommand(OnOpenExecPlanTOCommandExecuted, CanOpenExecPlanTOCommand);

        }

        public void AddNewReglamentTO()
        {
            KindTO nextKind;

            if (equip.ReglamentTO.kindTO == KindTO.TO1)
                nextKind = KindTO.TO2;
            else
                nextKind = KindTO.TOLong;

            TO t = repo.GetListTO().Where(w => w.kindTO == nextKind).FirstOrDefault();

            CurrentReglTO.DateSet = DateTime.Now;

            equip.ReglamentTO = new EquipTO(t);
            equip.ReglamentTO.NumTO = CurrentReglTO.NumTO + 1;
            equip.ReglamentTO.Name = "ТО-" + (equip.ReglamentTO.NumTO);
            equip.ReglamentTO.equip = equip;
            equip.ReglamentTO.DatePlan = DateTime.Now.AddMonths(equip.ReglamentTO.WarrantyMonth);
            equip.listReglamnetTO.Add(equip.ReglamentTO);
            equip.EndWarranty = equip.ReglamentTO.DatePlan;

        }

        public void AddNewPlanTO()
        {
            TO t = repo.GetListTO().Where(w => w.kindTO == KindTO.Planned).FirstOrDefault();

            CurrentPlanTO.DateSet = DateTime.Now;
            equip.PlanTO = new EquipTO(t);
            equip.PlanTO.NumTO = CurrentPlanTO.NumTO + 1;
            equip.PlanTO.Name = "Плановое ТО";
            equip.PlanTO.equip = equip;
            equip.PlanTO.DatePlan = DateTime.Now.AddMonths(equip.PlanTO.WarrantyMonth);
            equip.listPlanTO.Add(equip.PlanTO);

        }

    }
}
