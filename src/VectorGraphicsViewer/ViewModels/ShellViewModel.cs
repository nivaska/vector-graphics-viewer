using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using VectorGraphicsViewer.Interfaces;
using VectorGraphicsViewer.Services;
using VectorGraphicsViewer.UI;

namespace VectorGraphicsViewer.ViewModels
{
    /// <summary>
    /// View Model bound to the Main Window
    /// </summary>
    public class ShellViewModel: ViewModelBase
    {
        private readonly IInputReader _inputReader;
        private RelayCommand _selectInputCommand;
        private string _selectedFile;
        private string _statusMessage;
        private ObservableCollection<IPrimitive> _primitives;

        public ShellViewModel(IInputReader inputReader)
        {
            _inputReader = inputReader;
            _selectInputCommand = new RelayCommand(param => ExecuteSelectInputCommand(), null);
            _primitives = new ObservableCollection<IPrimitive>();
            this.StatusMessage = "Select an input file";
        }

        /// <summary>
        /// Command bound to select button in the UI to help select the input file
        /// </summary>
        public RelayCommand SelectInputCommand
        {
            get
            {
                return _selectInputCommand;
            }
        }

        /// <summary>
        /// Name of the selected input file
        /// </summary>
        public string SelectedFile
        {
            get { return _selectedFile; }
            set { _selectedFile = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Application status displayed at the bottom of the Window
        /// </summary>
        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Collection of Primitive shapes bound to the Canvas
        /// </summary>
        public ObservableCollection<IPrimitive> Primitives
        {
            get { return _primitives; }
            set { _primitives = value; OnPropertyChanged(); }
        }

        private void ExecuteSelectInputCommand()
        {
            this.StatusMessage = "Select an input file";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.SelectedFile = openFileDialog.FileName;
                LoadInputToView();
            }
        }

        /// <summary>
        /// Fetches the primitives from the input file and binds to UI
        /// </summary>
        private void LoadInputToView()
        {
            this.StatusMessage = "Parsing input file";

            try
            {
                this.Primitives = new ObservableCollection<IPrimitive>(
                    this._inputReader.GetAllPrimitives(this._selectedFile));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                this.StatusMessage = $"Error: {ex.Message}";
                return;
            }

            this.StatusMessage = "Parsing done";
        }
    }
}
