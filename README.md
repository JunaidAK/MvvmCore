# MvvmCore

MvvmCore is a simple yet powerful tool to make WPF apps on MVVM pattern. 


## Getting Started

Just follow the below easy guide to get started with MvvmCore.

### Setting up the project

- Create  a new WPF project "TestApp".
- Add reference to MvvMCore in it.
- Replace App.xaml with the below code:
		

	    <Application x:Class="TestApp.App"
	             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
	             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
	             xmlns:local="clr-namespace:TestApp">
	    <Application.Resources>
	        <ResourceDictionary>
	            <ResourceDictionary.MergedDictionaries>
	                <ResourceDictionary>
	                    <local:Bootstrapper x:Key="Bootstrapper" />
	                </ResourceDictionary>
	            </ResourceDictionary.MergedDictionaries>
	        </ResourceDictionary>
	    </Application.Resources>
	</Application>

- Delete MainWindow.xaml and MainWindow.xaml.cs.
- Add a file "Bootstrapper.cs" and insert the following code in it:

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

- Now Add two folders "Views" and "ViewModels".
- In ViewModels folder, Add a file "BaseViewModel.cs" and replace it with the following:

		public class BaseViewModel : ViewModelBase
	    {
	        public override Application ThisApp
	        {
	            get { return Application.Current; }
	        }
	    }
	
- Now add two User Controls namely "MainView" and "SampleView" in your "Views" folder and two classes namely "MainViewModel.cs" and "SampleViewModel.cs" in "ViewModels" folder.
##### 				MainView.xaml

	<Window x:Class="TestApp.Views.MainView"
	        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
	        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
	        Title="MainView" Height="300" Width="300">
	    <Grid>
	        <ContentControl Content="{Binding Sample}" />
	    </Grid>
	</Window>

####  SampleView.xaml

    <UserControl x:Class="TestApp.Views.SampleView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             mc:Ignorable="d"
             d:DesignHeight="300" d:DesignWidth="300">
    <Grid>
        <TextBlock Text="{Binding SampleText}" HorizontalAlignment="Center" VerticalAlignment="Center" FontSize="15" />
    </Grid>
</UserControl>

#### MainViewModel.cs

    public class MainViewModel : BaseViewModel
    {
        public object Sample { get { return IoC.Get<SampleViewModel>().View; } }
    }

#### SampleViewModel.cs

    public class SampleViewModel : BaseViewModel
    {
        public string SampleText { get { return "Sample Text"; } }
    }

### Running the project

- Build the project and run. You will see a Window having a Control saying "Sample Text" in it. 

- This "Sample Text" is actually coming from SampleViewModel.cs which is bound for the SampleView. 

- Similarly, the SampleView is shown in MainView because of the binding from MainViewModel.

- And MainView is set as Project's MainWindow from Bootstrapper.cs.

- Note the Configure Method which adds and registers the ViewModels (with their respective Views) in IoC Container for later use.

- You can add more Views and ViewModels and enjoy MvvmCore.

## Final Words

Hope you guys will appreciate the good work I am trying to do and forward this project to other devs out there.