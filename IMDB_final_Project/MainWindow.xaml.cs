using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IMDB_final_Project.ViewModels;

namespace IMDB_final_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //scaffold-dbcontext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook;Integrated Security=True;Trust Server Certificate=False;" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models/Generated -contextdir Data -namespace PROG2500_A2_Chinook.Models -contextnamespace PROG2500_A2_Chinook.Data -force

    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}