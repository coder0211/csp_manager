﻿using csp_manager.DataQuery;
using csp_manager.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace csp_manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            QueryData QD = new QueryData();
            _ = QD.TestConnect();
            MainWindow = new MainWindow
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            MainWindow.Show();
            base.OnStartup(e);


            //base.OnStartup(e);
            //SplashScreenWindow splashScreen = new SplashScreenWindow();
            //MainWindow = splashScreen;
            //splashScreen.Show();
            ////in order to ensure the UI stays responsive, we need to do the work on a different thread
            //Task.Factory.StartNew(() =>
            //{
            //    //we need to do the work in batches so that we can report progress
            //    for (int i = 1; i <= 100; i++)
            //    {
            //        //simulate a part of work being done
            //        System.Threading.Thread.Sleep(30);
            //        //because we're not on the UI thread, we need to use the Dispatcher
            //        //associated with the splash screen to update the progress bar
            //        splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = i);
            //    }
            //    //once we're done we need to use the Dispatcher to create and show the main window
            //    Dispatcher.Invoke(() =>
            //    {
            //        //initialize the main window, set it as the application main window and close the splash screen
            //        var mainWindow = new MainWindow();
            //        MainWindow = mainWindow;
            //        mainWindow.Show();
            //        splashScreen.Close();
            //    });
            //});
        }
    }
}
