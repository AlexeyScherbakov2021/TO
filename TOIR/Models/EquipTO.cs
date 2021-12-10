using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TOIR.Models
{
    // ТО с указанными датами для оборудования
    internal class EquipTO : TO
    {
        //public int ID { get; set; }
        public int EqipID { get; set; }             // ID обрудования
        public Equip equip { get; set; }
        //public int TOID { get; set; }               // ID ТО
        public DateTime DatePlan { get; set; }      // конечная дата выполенения ТО
        DateTime _DateSet;
        public DateTime DateSet
        {
            get => _DateSet;
            set { _DateSet = value; OnPropertyChanged(); }
        }       // Дата выполненного проведения ТО
        //public TO to { get; set; }                  // ссылка на ТО
        public ObservableCollection<WorkForTO> listWorkTO { get; set; } // список работ на выполнение


        public EquipTO( TO parent)
        {
            ID = parent.ID;
            kindTO = parent.kindTO;
            Name = parent.Name;
            NumTO = parent.NumTO;
            WarrantyMonth = parent.WarrantyMonth;
            listWorks = parent.listWorks;
            listWorkTO = new ObservableCollection<WorkForTO>();
        }

    }
}
