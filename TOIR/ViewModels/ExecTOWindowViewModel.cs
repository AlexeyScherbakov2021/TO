using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TOIR.Commands;
using TOIR.Models;
using TOIR.Repository;
using TOIR.ViewModels.Base;

namespace TOIR.ViewModels
{
    class ExecTOWindowViewModel : ViewModel
    {
        public EquipTO to { get; set; }
        //private EquipmentWindowViewModel model;
        private IRepository repo;
        public bool result = false;

        #region Команды
        public ICommand FinalTOCommand { get; }
        private bool CanFinalTOCommand(object p) => true;
        private void OnFinalTOCommandExecuted(object p)
        {
            if(to.listWorkTO.Where(w => w.CheckedTO == false).Count() == 0)
            {
                // все работы выполнены
                result = true;
                MessageBox.Show("ТО завершено. Гарантия продлевается.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion


        public ExecTOWindowViewModel() { }
        public ExecTOWindowViewModel(EquipTO t, /*EquipmentWindowViewModel mod,*/ IRepository rep)
        {
            FinalTOCommand = new LambdaCommand(OnFinalTOCommandExecuted, CanFinalTOCommand);
            repo = rep;
            //model = mod;
            to = t;

            to.listWorkTO = repo.GetListWorkForTO(to);

            if (to.listWorkTO == null)
            {
                to.listWorkTO = new ObservableCollection<WorkForTO>();
                foreach(Works w in to.listWorks)
                {
                    WorkForTO wt = new WorkForTO(w);
                    wt.TO_ID = to.ID;
                    to.listWorkTO.Add(wt);
                }
            }
        }

    }
}
