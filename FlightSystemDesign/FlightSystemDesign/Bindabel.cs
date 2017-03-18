using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlightSystemDesign
{
    public abstract class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 侦听方法，在属性的设置器中直接调用此方法，参数为需要实时更新至界面的属性的名字
        /// </summary>
        /// <param name="propName"></param>
        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler propchanged = PropertyChanged;
            if (propchanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));//在侦听到更新时抛出更新事件(事件的处理程序及注册是WPF的内部机制)
            }
        }

        protected void SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(item, value))
            {
                item = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
