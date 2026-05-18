using FinanceDB.Data;
using FinanceDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FinanceDB.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _tickerQuery;

        public string TickerQuery
        {
            get { return _tickerQuery; }
            set
            {
                _tickerQuery = value;
                OnPropertyChanged(nameof(_tickerQuery));
            }
        }
        private Fund _fund;
        public Fund Fund
        {
            get { return _fund; }
            set
            {
                _fund = value;
                OnPropertyChanged(nameof(_fund));
            }
        }

        private Funds

        public MainWindowViewModel()
        {
            Fund = new Fund
            {
                Fund1 = "SCHD",
                Desc = "dividend"
            };

            using (var context = new FinanceDbContext())
            {
                context.Database.EnsureCreated();

                //context.SaveChanges();
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
