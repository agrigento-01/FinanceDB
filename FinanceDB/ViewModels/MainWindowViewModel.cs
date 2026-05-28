using FinanceDB.Domain;
using FinanceDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FinanceDB.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _tickerQuery;

        private ObservableCollection<Fund> _funds = new ObservableCollection<Fund>();
        public ObservableCollection<Fund> Funds
        {
            get { return _funds; }
            set {
                _funds = value;
                OnPropertyChanged(nameof(_funds));
                }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        public async Task LoadFunds()
        {
            using (var context = new FinanceDbContext())
            {
                context.Database.EnsureCreated();

                var funds = await context.Funds.ToListAsync();

                Funds.Clear();
                foreach (var fund in funds)
                {
                    Funds.Add(fund);
                }
                //context.SaveChanges();

            }
        }

        public MainWindowViewModel()
        {
            LoadFunds();
        }
    }
}
