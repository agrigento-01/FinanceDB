using FinanceDB.Commands;
using FinanceDB.Domain;
using FinanceDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinanceDB.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _tickerQuery;

        public SearchCommand SearchCommand { get; set; }

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
        public event TextChangedEventHandler TextChanged;

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

        /// <summary>
        /// Loads the funds from the dbo
        /// </summary>
        public async Task LoadFunds()
        {
            using (var context = new FinanceDbContext())
            {
                context.Database.EnsureCreated();       // ensure the database is created if .dbo doesn't exist

                var funds = await context.Funds.ToListAsync();

                Funds.Clear();
                foreach (var fund in funds)
                {
                    Funds.Add(fund);
                }
            }
        }

        /// <summary>
        /// Search by by the 'Fund' (i.e. ticker) header
        /// </summary>
        public async Task SearchFunds(string? query)
        {
            using (var context = new FinanceDbContext())
            {
                context.Database.EnsureCreated();

                // index first char, so no % on left of query
                var funds = context.Funds.Where(x => EF.Functions.Like(x.Fund1, $"%{query}%")).ToList();

                Funds.Clear();
                if (!funds.IsNullOrEmpty())
                {
                    foreach (var fund in funds)
                    {
                        Funds.Add(fund);
                    }
                }
            }
        }

        public MainWindowViewModel()
        {
            SearchCommand = new SearchCommand(this);
        }
    }
}
