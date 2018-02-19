using MvvmCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using TestApp.ViewModels;

namespace TestApp
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            Configure();
            DisplayRootViewFor<MainViewModel>();
        }

        private void Configure()
        {
            IoC.AddInContainer<SampleViewModel>();
            IoC.AddInContainer<MainViewModel>();
        }

        public void DisplayRootViewFor<T>()
        {
            try
            {
                Application.Current.MainWindow = (Window)(IoC.Get<T>().GetType().GetProperty("View").GetValue(IoC.Get<T>(), null));
                Application.Current.MainWindow.Show();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }
    }
}
