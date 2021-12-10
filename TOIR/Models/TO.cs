using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TOIR.Infrastructure;

namespace TOIR.Models
{
    // ТО для списка
    internal class TO: INotifyPropertyChanged
    {
        public int ID { get; set; }
        public KindTO kindTO { get; set; }               // вид ТО
        public int NumTO { get; set; }
        string _Name;
        public string Name
        {
            get => _Name;
            set { _Name = value; OnPropertyChanged(); }
        }                // наименование ТО
        public int WarrantyMonth { get; set; }          // действие гарантии в месяцах
        public ObservableCollection<Works> listWorks { get; set; }      // список работ для ТО

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
