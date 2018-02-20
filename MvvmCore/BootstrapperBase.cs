using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MvvmCore
{
    /// <summary>
    /// Bootstrapper for Application
    /// </summary>
    public abstract class BootstrapperBase
    {
        /// <summary>
        /// Add ViewModels in IoC Container here
        /// </summary>
        public abstract void Configure();

        /// <summary>
        /// Assigns and Displays MainWindow of the project
        /// </summary>
        /// <typeparam name="W">View to be MainWindow</typeparam>
        public void DisplayRootViewFor<W>()
        {
            try
            {
                Application.Current.MainWindow = (Window)(IoC.Get<W>().GetType().GetProperty("View").GetValue(IoC.Get<W>(), null));
                Application.Current.MainWindow.Show();
            }
            catch { }
        }
    }
}
