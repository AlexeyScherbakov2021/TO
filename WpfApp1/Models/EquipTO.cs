using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOIR.Models
{
    internal class EquipTO
    {
        public int ID { get; set; }
        public int EqipID { get; set; }             // ID обрудования
        public int TOID { get; set; }               // ID ТО
        public DateTime DatePlan { get; set; }      // конечная дата выполенения ТО
        public DateTime DateSet { get; set; }       // Дата выполненного проведения ТО
        public TO to { get; set; }                  // ссылка на ТО
    }
}
