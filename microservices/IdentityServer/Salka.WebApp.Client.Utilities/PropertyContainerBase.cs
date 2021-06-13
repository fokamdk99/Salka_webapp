

namespace Salka.WebApp.Client.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PropertyContainerBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected readonly IEventDispatcher dispatcher;

        protected PropertyContainerBase(IEventDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

                /* AT
                handler( this, args );
                */
                Action action = () => handler(this, args);

                this.dispatcher.Dispatch(action);
            }
        }
    }
}
