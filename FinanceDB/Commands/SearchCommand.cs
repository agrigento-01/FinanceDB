using FinanceDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FinanceDB.Commands
{
    public class SearchCommand : ICommand
    {
        public MainWindowViewModel VM { get; set; }

        public SearchCommand(MainWindowViewModel vm)
        {
            VM = vm;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        async public void Execute(object parameter)
        {
            await VM.LoadFunds();
        }
    }
}
