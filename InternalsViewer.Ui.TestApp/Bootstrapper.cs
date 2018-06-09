using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InternalsViewer.Internals.Engine.Interfaces.Readers;
using InternalsViewer.Internals.Engine.Interfaces.Services;
using InternalsViewer.Internals.Engine.Interfaces.Services.Engine;
using InternalsViewer.Internals.Engine.Interfaces.Services.Metadata;
using InternalsViewer.Internals.Engine.Readers.Pages;
using InternalsViewer.Internals.Engine.Services.Engine;
using InternalsViewer.Internals.Engine.Services.Metadata;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace InternalsViewer.Ui.TestApp
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow?.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IDatabaseConnection, DatabaseConnection>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<IMetadataService, MetadataService>();
            Container.RegisterType<IAllocationService, AllocationService>();
            Container.RegisterType<IIndexAllocationMapService, IndexAllocationMapService>();
            Container.RegisterType<IPageFreeSpaceService, PageFreeSpaceService>();
            Container.RegisterType<IServerService, ServerService>();

            Container.RegisterType<IDatabasePageReader, DatabasePageReader>();
        }
    }
}
