using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InternalsViewer.Ui.TestApp.Models;

namespace InternalsViewer.Ui.TestApp.Controls
{
    /// <summary>
    /// Interaction logic for AllocationMapControl.xaml
    /// </summary>
    public partial class AllocationMapControl : UserControl
    {
        public AllocationMapControl()
        {
            InitializeComponent();
            ScrollBar.Maximum = 100;
        }

        public static readonly DependencyProperty LayersProperty = DependencyProperty.Register("Layers",
            typeof(AllocationLayers),
            typeof(AllocationMapControl),
            new PropertyMetadata(null, OnAllocationLayersChanged));

        private static void OnAllocationLayersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.Print(d.ToString());
        }

        public AllocationLayers Layers
        {
            get => (AllocationLayers)GetValue(LayersProperty);
            set => SetValue(LayersProperty, value);
        }

        private void ScrollBar_OnScroll(object sender, ScrollEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
