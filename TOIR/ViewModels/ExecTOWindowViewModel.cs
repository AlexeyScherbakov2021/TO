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
            if (to.to.listWorkTO == null)
            {
                to.to.listWorkTO = new List<WorkForTO>();
                foreach(Works w in to.to.listWorks)
                {
                    WorkForTO wt = new WorkForTO();
                    wt.TOID = w.ID;
                    wt.work = w;
                    wt.WorkID = w.ID;
                    to.to.listWorkTO.Add(wt);
                }
            }
        }

    }
}
