using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace MvvmCore
{
    /// <summary>
    /// This class generates View from ViewModel and apply bindings respectively
    /// </summary>
    public abstract class ViewModelBase : PropertyChangeNotifier
    {
        /// <summary>
        /// Initializes an Instance of ViewModelBase
        /// </summary>
        public ViewModelBase()
        {
            if (ThisApp != null)
                GenerateView();
        }

        /// <summary>
        /// To execute an action on UI thread
        /// </summary>
        /// <param name="action">The action to be executed on UI thread</param>
        protected virtual void ExecuteOnUIThread(Action action)
        {
            try
            {
                if (action != null)
                    Dispatcher.CurrentDispatcher.Invoke(action);
            }
            catch { }
        }

        /// <summary>
        /// Holds View of the ViewModel
        /// </summary>
        public object View { get; private set; }
        private string AppNamespace
        {
            get
            {
                return ThisApp == null ? "" : ThisApp.GetType().Namespace;
            }
        }

        /// <summary>
        /// Holds the current running application
        /// </summary>
        public abstract Application ThisApp { get; }

        private void GenerateView()
        {
            try
            {
                var typeName = this.GetType().FullName.Replace("ViewModel", "View");

                if (typeName.Contains("View"))
                {
                    var type = Type.GetType(typeName + ", " + AppNamespace);
                    if (type == null)
                        typeName = typeName.Replace(".Views", "");
                    type = Type.GetType(typeName + ", " + AppNamespace);
                    if (type == null)
                        return;
                    IoC.AddInContainer(type);
                    View = IoC.Get(type);

                    if (View != null)
                    {
                        try { View.GetType().GetEvent("Loaded").AddEventHandler(View, new RoutedEventHandler(OnViewLoaded)); }
                        catch { }
                        try { View.GetType().GetProperty("DataContext").SetValue(View, this, null); }
                        catch { }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// This method can be used when something is to be done when view loads
        /// </summary>
        /// <param name="view">Holds View of the ViewModel</param>
        protected virtual void OnViewLoaded(object view) { }

        private void OnViewLoaded(object sender, RoutedEventArgs e)
        {
            OnViewLoaded(sender);
        }
    }
}