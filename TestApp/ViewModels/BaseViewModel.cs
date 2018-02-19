using MvvmCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace TestApp.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public override Application ThisApp
        {
            get { return Application.Current; }
        }
    }
}
