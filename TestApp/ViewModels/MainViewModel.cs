using MvvmCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public object Sample { get { return IoC.Get<SampleViewModel>().View; } }
    }
}
