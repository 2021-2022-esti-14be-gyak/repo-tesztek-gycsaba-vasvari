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
using Vizsgaremek.ViewModels;

namespace Vizsgaremek.Views.Pages
{
    /// <summary>
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : UserControl
    {
        public TeacherPage(TeacherPageViewModel teacherPageViewModel)
        {
            InitializeComponent();
            this.DataContext = teacherPageViewModel;
        }

        private void UpdatePageBackImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            Navigation.Navigete(welcomePage);
        }
    }
}
