using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp1.MojServiceNameSpace;
using MessageBox = System.Windows.MessageBox;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(txtX.Text);
            int y = int.Parse(txtY.Text);
            int result = 0;
            result = await Calculate(x, y);
            MessageBox.Show("Wynik to: " + result);
        }

        private async Task<int> Calculate(int x, int y)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                return x + y;
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MojServiceNameSpace.IService1 client = new MojServiceNameSpace.Service1Client();
            int val = int.Parse(txtTekst.Text);
            //var result = client.GetData(int.Parse(txtTekst.Text));
            //txtWynik.Text = result;


            client.BeginGetData(val, GetDataCallback, client);
            Cursor = Cursors.Wait;
        }

        private void GetDataCallback(IAsyncResult ar)
        {
            var service = ar.AsyncState as IService1;
            var message = service.EndGetData(ar);

            //App.Current.MainWindow.Dispatcher
            this.Dispatcher.Invoke(() =>
            {
                txtWynik.Text = message;
                Cursor = Cursors.Arrow;
            }, DispatcherPriority.Normal);
            
        }

        private BackgroundWorker bgWorker;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //for (int i = 0; i < 10000; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(state => { Console.WriteLine(i); Thread.Sleep(new Random().Next() % 1000); });
            //}
             
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorkerDoWork;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.WorkerReportsProgress = true;
            bgWorker.RunWorkerAsync();
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStop.IsEnabled = false;
            MessageBox.Show("Zadanie zakończone");

        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbBar.Value = e.ProgressPercentage;
        }

        private void BgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(() => btnStop.IsEnabled = true, DispatcherPriority.Normal);
            
            BackgroundWorker myBgWorker = sender as BackgroundWorker;
            for (int i = 0; i < 100; i++)
            {
                if (myBgWorker.CancellationPending)
                    break;
                Thread.Sleep(1000);
                myBgWorker.ReportProgress(i);
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (bgWorker != null)
                bgWorker.CancelAsync();
        }
    }
}
