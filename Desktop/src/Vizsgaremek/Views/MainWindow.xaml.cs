using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using Vizsgaremek.Views.Navigations;
using Vizsgaremek.Views.Pages;
using Vizsgaremek.ViewModels;
using Vizsgaremek.Stores;

using System.Globalization;
using System.Threading;

namespace Vizsgaremek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        private DatabaseSourceViewModel databaseSourceViewModel;
        private TeacherPageViewModel teacherPageViewModel;

        private ApplicationStore applicationStore;

        public MainWindow()
        {
            // Program adatok alapértelmezett kezdőértékkel
            applicationStore = new ApplicationStore();
            // Különböző ablakok adatai
            mainWindowViewModel = new MainWindowViewModel();
            databaseSourceViewModel = new DatabaseSourceViewModel();
            teacherPageViewModel = new TeacherPageViewModel(applicationStore);

            // A program adatok is az elmentett adatbázis forrást tárolják
            applicationStore.DbSource = databaseSourceViewModel.DbSource;
            // A nyelvet is itt fell lehet venni, ha a különböző Pageken ez fontos;
            
            // Az elmenetett adatbázis forrás megjelenítése
            mainWindowViewModel.SelectedSource = databaseSourceViewModel.SelectedDatabaseSource.Name;

            // Feliratkozunk az eseményre. Ha változik az adat az adott osztályba tudni fogunk róla!
            databaseSourceViewModel.ChangeDatabaseSource += DatabaseSourceViewModel_ChangeDatabaseSource;

            InitializeComponent();
            // A MainWindow ablakban megjelenő adatok a MainWindowViewModel-ben vannak
            this.DataContext = mainWindowViewModel;
            // Statikus osztály a Navigate
            // Eltárolja a nyitó ablakt, hogy azon tudjuk módosítani a "page"-ket
            Navigation.mainWindow = this;
            // Létrehozzuk a nyitó "UsuerControl" (WelcomPage)
            WelcomePage welcomePage = new WelcomePage();
            // Megjelnítjük a WelcomePage-t
            Navigation.Navigete(welcomePage);
        }

        private void DatabaseSourceViewModel_ChangeDatabaseSource(object sender, EventArgs e)
        {
            DatabaseSourceEventArg dsea = (DatabaseSourceEventArg) e;
            mainWindowViewModel.SelectedSource = dsea.DatabaseSource;
            applicationStore.DbSource= databaseSourceViewModel.DbSource;
        }


        /// <summary>
        /// ListView elemen bal egér gomb fel lett engedve
        /// </summary>
        /// <param name="sender">ListView amin megnyomtuk a bal egér gombot</param>
        /// <param name="e"></param>
        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView lvMenu = sender as ListView;
            ListViewItem lvMenuItem = lvMenu.SelectedItem as ListViewItem;
            if (lvMenuItem != null)
            {
                // x:Name tulajdonságot vizsgáljuk
                switch (lvMenuItem.Name)
                {
                    case "lviExit":
                        Close();
                        break;
                    case "lviTeacher":
                        teacherPageViewModel.Update();
                        TeacherPage teacherPage = new TeacherPage(teacherPageViewModel);
                        Navigation.Navigete(teacherPage);
                        break;
                    case "lviDatabaseSouceSelection":
                        DatabaseSourcePage databaseSourcePage = new DatabaseSourcePage(databaseSourceViewModel);
                        Navigation.Navigete(databaseSourcePage);
                        break;

                }                
            }
        }
    }
}

