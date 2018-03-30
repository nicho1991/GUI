using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using I4GUI;
using MvvmFoundation.Wpf;
using System.Xml.Serialization;
using menu;

namespace _06AgentAssignment
{
    public class Agents : ObservableCollection<Agent>, INotifyPropertyChanged
    {
        string filename = "";
        public Agents()
        {
            
        }

        #region Commands

        ICommand _newCommand;
        public ICommand NewCommand
        {
            get { return _newCommand ?? (_newCommand = new RelayCommand(NewAgents)); }
        }

        private void NewAgents()
        {

            Clear();
            filename = "";
            NotifyPropertyChanged("Count");
        }

        ICommand _openCommand;

        public ICommand OpenCommand
        {
            get { return _openCommand ?? (_openCommand = new RelayCommand<string>(openCommand)); }
        }

        private void openCommand(string argName)
        {
            if (argName == "")
                MessageBox.Show("write a fucking path");
            else
            {
                filename = argName;
                XmlSerializer serialiser = new XmlSerializer(typeof(Agents));
                Agents tempagent =  new Agents();

                try
                {
                    TextReader reader = new StreamReader(filename);
                    tempagent = (Agents)serialiser.Deserialize(reader);
                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("unable to load file");
                }

                Clear();
                foreach (var agent in tempagent)
                    Add(agent);
                NotifyPropertyChanged("Count");
            }
        }
        ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(saveCommand_execute,saveCommand_CanExecute)); }
        }

        private void saveCommand_execute()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Agents));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer,this);
            writer.Close();
        }

        private bool saveCommand_CanExecute()
        {
            return (filename != "") && (Count > 0);
        }

        ICommand _saveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _saveAsCommand ?? (_saveAsCommand = new RelayCommand<string>(saveAsComman_Execute)); }
        }

        private void saveAsComman_Execute(string argFileName)
        {
            if (argFileName == "")
            {
                MessageBox.Show("enter valid filename u dumb fuck");
            }

            else
            {
                filename = argFileName;
                saveCommand_execute();
            }
        }

        ICommand _exitCommand;
        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new RelayCommand(Exit)); }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddAgent)); }
        }

        private void AddAgent()
        {
            // Show Modal Dialog
            var dlg = new EditDialog();
            dlg.Title = "Add New Agent";
            Agent newAgent = new Agent();
            dlg.DataContext = newAgent;
            if (dlg.ShowDialog() == true)
            {
                Add(newAgent);
                CurrentIndex = Count - 1;
                NotifyPropertyChanged("Count");
            }

        }

        ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteAgent, DeleteAgent_CanExecute)); }
        }

        private void DeleteAgent()
        {
            RemoveAt(CurrentIndex);
            NotifyPropertyChanged("Count");
        }

        private bool DeleteAgent_CanExecute()
        {
            if (Count > 0 && CurrentIndex >= 0)
                return true;
            else
                return false;
        }

        ICommand _nextCommand;
        public ICommand NextCommand
        {
            get
            {
                return _nextCommand ?? (_nextCommand = new RelayCommand(
                    () => ++CurrentIndex,
                    () => CurrentIndex < (Count - 1)));
            }
        }

        ICommand _PreviusCommand;
        public ICommand PreviusCommand
        {
            get { return _PreviusCommand ?? (_PreviusCommand = new RelayCommand(PreviusCommandExecute, PreviusCommandCanExecute)); }
        }

        private void PreviusCommandExecute()
        {
            if (CurrentIndex > 0)
                --CurrentIndex;
        }

        private bool PreviusCommandCanExecute()
        {
            if (CurrentIndex > 0)
                return true;
            else
                return false;
        }

        #endregion // Commands

        #region Properties

        int currentIndex = -1;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
