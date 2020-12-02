using Bibliotekarz.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows.Input;

namespace Bibliotekarz.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///
            //Timer timer = new Timer();
            //timer.Interval = 1000;
            //timer.Elapsed += Timer_Elapsed;
            //timer.Start();

            GenerateFakeData();
        }



        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CanClose = !CanClose;
        }

        public string FilterText { get; set; }

        public bool CanClose { get; set; } = true;

        public ICommand CloseCommand => new RelayCommand(Close, () => CanClose);

        private void Close()
        {
            Environment.Exit(0);
        }

        public ObservableCollection<Book> BookList { get; set; }

        private void GenerateFakeData()
        {
            BookList = new ObservableCollection<Book>
            {
                new Book
                {
                    Id = 1,
                    Author = "Leszek Lewandowski",
                    PageCount = 456,
                    Title = "Programowanie w C#",
                    IsBorrowed = true,
                    Borrower = new Customer
                    {
                        Id = 1,
                        FirstName = "Adam",
                        LastName = "Nowak"
                    }

                }
            };


        }
    }
}