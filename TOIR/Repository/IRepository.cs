using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOIR.Models;

namespace TOIR.Repository
{
    interface IRepository
    {
        List<Equip> GetListEquipment();             // получение списка оборудования
        List<TO> GetListTO();                       // получение списка ТО
        List<Works> GetListWorks();                 // получение списка работ
        void GetListReglamentTO(Equip eqip);        // получение списка регламентных ТО для указанного оборудования
        void GetListPlanTO(Equip eqip);             // получение списка плановых ТО для указанного оборудования
        void GetListWorkForTO(TO to);               // получение списка работ для указанного ТО
        void GetCurrentReglamentTO(Equip eqip);      // получение текущего рагламентного ТО для указанного оборудования
        void GetCurrentPlanTO(Equip eqip);          // получение текущего планового ТО для указанного оборудования
        List<WorkForTO> GetListWorkForTO(EquipTO et);  // получение списка проведенных работ для ТО
    }
}
