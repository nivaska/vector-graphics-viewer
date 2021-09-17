﻿using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicsViewer.ViewModels;

namespace VectorGraphicsViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var vm = new MainViewModel();
            DataContext = vm;
            InitializeComponent();
            itemsControl.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }

        private async void ItemContainerGenerator_StatusChanged(object sender, System.EventArgs e)
        {
            if (itemsControl.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                await Task.Run(() => {
                    Thread.Sleep(100);
                    this.Dispatcher.Invoke(() => AdaptCanvasElementsToWindow());
                });
            }
        }

        //private void Primitive_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    var senderElement = sender as Shape;
        //    var primitiveData = senderElement.DataContext as IPrimitive;


        //}

        /// <summary>
        /// Event handler for the Resize event of the Main Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Resize(object sender, SizeChangedEventArgs e)
        {
            this.AdaptCanvasElementsToWindow();
        }

        /// <summary>
        /// Adapts canvas elements to the window by applying scale and shift transforms to the canvas element
        /// </summary>
        private void AdaptCanvasElementsToWindow()
        {
            Canvas primitiveCanvas = UIHelper.FindChild<Canvas>(Application.Current.MainWindow, "primitiveCanvas");
            if (primitiveCanvas == null)
                return;

            // width and height values of the parent element of the Canvas
            var containerWidth = this.canvasContainer.ActualWidth;
            var containerHeight = this.canvasContainer.ActualHeight;

            double minXScalingFactor = 0;
            double minYScalingFactor = 0;
            // determine a scaling factor such that the largest primitve in the canvas can fit inside the container
            foreach (FrameworkElement fe in primitiveCanvas.Children)
            {
                if (fe.ActualHeight == 0 || fe.ActualWidth == 0)
                    continue;

                var xScalingFactor = containerHeight / fe.ActualHeight;
                var yScalingFactor = containerWidth / fe.ActualWidth;

                if (minXScalingFactor == 0 || minYScalingFactor > xScalingFactor)
                    minXScalingFactor = xScalingFactor;

                if (minYScalingFactor == 0 || minYScalingFactor > xScalingFactor)
                    minYScalingFactor = xScalingFactor;
            }

            var scalingFactor = minXScalingFactor > minYScalingFactor ? minYScalingFactor : minXScalingFactor;
            
            TransformGroup transformGroup = new TransformGroup();
            TranslateTransform shift = new TranslateTransform(containerWidth / 2, containerHeight / 2);
            if (scalingFactor != 0)
            {
                ScaleTransform scale = new ScaleTransform(scalingFactor, scalingFactor);
                transformGroup.Children.Add(scale);
            }
            transformGroup.Children.Add(shift);
            primitiveCanvas.RenderTransform = transformGroup;
            primitiveCanvas.UpdateLayout();
        }
    }
}
