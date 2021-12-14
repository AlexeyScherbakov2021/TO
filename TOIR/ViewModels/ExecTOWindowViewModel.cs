using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class ExecTOWindowViewModel : ViewModel
    {
        public EquipTO to { get; set; }
        //private EquipmentWindowViewModel model;
        private IRepository repo;
        public bool result = false;

        #region Команды
        public ICommand FinalTOCommand { get; }
        private bool CanFinalTOCommand(object p)
        {
            return to.listWorkTO.Where(w => w.CheckedTO == false).Count() == 0;
        }
        private void OnFinalTOCommandExecuted(object p)
        {
            //if(to.listWorkTO.Where(w => w.CheckedTO == false).Count() == 0)
            //{
            //    // все работы выполнены
            //}
            result = true;
            win.Close();
        }

        public ICommand CloseCommand { get; }
        private bool CanCloseCommand(object p) => true;
        private void OnCloseCmmandExecuted(object p)
        {
            result = false;
            win.Close();
        }

        public ICommand FromFileCommand { get; }
        private bool CanFromFileCommand(object p) => true;
        private void OnFromFileCmmandExecuted(object p)
        {
            ImportFromCSV csv = new ImportFromCSV(to);
            csv.LoadFromCSV(@"c:\Work\VisualC#\TO\Документы\book.csv");
        }

        #endregion

        public ExecTOWindow win;

        public ExecTOWindowViewModel() { }
        public ExecTOWindowViewModel(EquipTO t, /*EquipmentWindowViewModel mod,*/ IRepository rep)
        {
            FinalTOCommand = new LambdaCommand(OnFinalTOCommandExecuted, CanFinalTOCommand);
            CloseCommand = new LambdaCommand(OnCloseCmmandExecuted, CanCloseCommand);
            FromFileCommand = new LambdaCommand(OnFromFileCmmandExecuted, CanFromFileCommand);
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
