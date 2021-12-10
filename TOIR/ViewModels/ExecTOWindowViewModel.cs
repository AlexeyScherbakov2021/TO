using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOIR.Models;
using TOIR.ViewModels.Base;

namespace TOIR.ViewModels
{
    class ExecTOWindowViewModel : ViewModel
    {
        public EquipTO to { get; set; }

        public ExecTOWindowViewModel() { }
        public ExecTOWindowViewModel(EquipTO t)
        {
            to = t;

            to.listWorkTO = MainWindowViewModel.repo.GetListWorkForTO(to);

            if (to.listWorkTO == null)
            {
                to.listWorkTO = new List<WorkForTO>();
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
