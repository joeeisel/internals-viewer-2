using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using InternalsViewer.Internals.Engine.Interfaces.Services;
using InternalsViewer.Internals.Engine.Interfaces.Services.Engine;
using InternalsViewer.Internals.Models.Engine.Database;
using InternalsViewer.Ui.TestApp.Annotations;
using InternalsViewer.Ui.TestApp.Helpers;
using InternalsViewer.Ui.TestApp.Helpers.Extensions;
using InternalsViewer.Ui.TestApp.Models;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo.RegSvrEnum;
using Microsoft.SqlServer.Management.UI.ConnectionDlg;
using Microsoft.SqlServer.Management.UI.VSIntegration;
using Nito.AsyncEx;
using Prism.Commands;
using Prism.Mvvm;

namespace InternalsViewer.Ui.TestApp.ViewModels
{
    public class AllocationViewerViewModel : BindableBase
    {
        private ObservableCollection<string> databases;
        private string selectedDatabase;
        private DatabaseContainer databaseContainer;
        private AllocationLayers allocationLayers;

        public AllocationViewerViewModel(IDatabaseConnection connection, IDatabaseService databaseService,
            IServerService serverService)
        {
            DatabaseService = databaseService;
            DatabaseConnection = connection;
            ServerService = serverService;

            ConnectCommand = new DelegateCommand(Connect);
        }

        protected IDatabaseService DatabaseService { get; set; }

        protected IDatabaseConnection DatabaseConnection { get; set; }

        protected IServerService ServerService { get; set; }

        public ICommand ConnectCommand { get; set; }

        public DatabaseContainer DatabaseContainer
        {
            get => databaseContainer;
            set
            {
                databaseContainer = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> Databases
        {
            get => databases;
            set
            {
                databases = value;
                RaisePropertyChanged();
            }
        }

        public string SelectedDatabase
        {
            get => selectedDatabase;
            set
            {

                selectedDatabase = value;
                RaisePropertyChanged();
                NotifyTaskCompletion.Create(LoadDatabase(value));
            }
        }

        public AllocationLayers AllocationLayers
        {
            get => allocationLayers;

            set
            {
                allocationLayers = value;
                RaisePropertyChanged();
            }
        }

        private async void Connect()
        {
            using (var dialog = new ShellConnectionDialog())
            {
                IServerType serverType = new SqlServerType();

                dialog.AddServer(serverType);

                var connectionInfo = new UIConnectionInfo();

                var hwnd = Process.GetCurrentProcess().MainWindowHandle;

                var win32Window = new NativeWindow();

                win32Window.AssignHandle(hwnd);

                if (dialog.ShowDialogCollectValues(win32Window, ref connectionInfo) == DialogResult.OK)
                {
                    DatabaseConnection.ConnectionString = ConnectionStringHelper.CreateSqlConnectionInfo(connectionInfo).ConnectionString;

                    var result = await ServerService.GetDatabases();

                    Databases = result.ToObservableCollection();

                    if (Databases.Any())
                    {
                        SelectedDatabase = Databases[0];
                    }
                }
            }
        }

        private async Task LoadDatabase(string databaseName)
        {
            DatabaseConnection.SetDatabase(databaseName);

            DatabaseContainer = await DatabaseService.GetDatabase(databaseName);

            AllocationLayers = new AllocationLayers(new[] { DatabaseContainer.Gam.Values.FirstOrDefault() });

            RaisePropertyChanged($"AllocationLayers");
        }
    }
}
