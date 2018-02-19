using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MvvmCore
{
    /// <summary>
    /// This class can be used to notify UI changes
    /// </summary>
    public abstract class PropertyChangeNotifier : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="exp">The property expression.</param>
        protected virtual void NotifyOfPropertyChange<T>(Expression<Func<T>> exp)
        {
            try
            {
                string name = ((LambdaExpression)exp).Body.ToString().Split('.').Last();
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
            catch { }
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        protected virtual void NotifyOfPropertyChange(string name)
        {
            try
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
            catch { }
        }
    }
}
