using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;
using VectorGraphicsViewer.Interfaces;
using VectorGraphicsViewer.Services;
using VectorGraphicsViewer.ViewModels;

namespace VectorGraphicsViewer
{
    /// <summary>
    /// Calibrum Micro Bootstrapper for IOC
    /// </summary>
    public class Bootstrapper: BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);
            _container.Singleton<IWindowManager, WindowManager>();

            // Register JsonInputReader to get instances of type IInputReader
            _container.PerRequest<IInputReader, JsonInputReader>();
            _container.RegisterPerRequest(typeof(ShellViewModel), 
                typeof(ShellViewModel).ToString(), typeof(ShellViewModel));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
