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
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Configure();
            DisplayRootViewFor<MainViewModel>();
        }

        public override void Configure()
        {
            IoC.AddInContainer<SampleViewModel>();
            IoC.AddInContainer<MainViewModel>();
        }

    }
}
