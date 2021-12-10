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
    // Оборудование для списка оборудования
    internal class Equip : INotifyPropertyChanged
    {
        public int ID { get; set; }
        //string _Name;
        public string Name { get; set; }
        //{
        //    get => _Name;
        //    set { _Name = value; OnPropertyChanged(); }
        //}                    // наименование оборудования
        public DateTime DateStart { get; set; }             // дата ввода в эксплуатацию
        DateTime _EndWarranty;
        public DateTime EndWarranty
        {
            get => _EndWarranty;
            set { _EndWarranty = value; OnPropertyChanged(); }
        }           // дата окончания гарантии
        public EquipTO PlanTO { get; set; }                 // текущее поановое ТО
        EquipTO _ReglamentTO;
        public EquipTO ReglamentTO
        {
            get => _ReglamentTO;
            set { _ReglamentTO = value; OnPropertyChanged(); }
        }            // текущее регламентное ТО
        public ObservableCollection<EquipTO> listPlanTO { get; set; }       // ссылка нв список плановое ТО
        public ObservableCollection<EquipTO> listReglamnetTO { get; set; }  // ссылка на список регламентных ТО

        #region
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
        #endregion


    }
}
