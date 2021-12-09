using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOIR.Models
{
    internal class Equip
    {
        public int ID { get; set; }
        public string Name { get; set; }                    // наименование оборудования
        public DateTime DateStart { get; set; }             // дата ввода в эксплуатацию
        public DateTime EndWarranty { get; set; }           // дата окончания гарантии
        public EquipTO PlanTO { get; set; }                 // текущее поановое ТО
        public EquipTO ReglamentTO { get; set; }            // текущее регламентное ТО
        public List<EquipTO> listPlanTO { get; set; }       // ссылка нв список плановое ТО
        public List<EquipTO> listReglamnetTO { get; set; }  // ссылка на список регламентных ТО

    }
}
