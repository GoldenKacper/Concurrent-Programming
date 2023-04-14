using Logic;
using Data;
using Presentation.Model;
using Presentation.ViewModel;
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
using System.Windows.Threading;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBallsManager _ballsManager;
        ILogic _logic;
        IModel _model;

        public MainWindow()
        {
            InitializeComponent();

            _ballsManager = new BallsManager();
            _logic = new Logic.Logic(_ballsManager);
            _model = new Model.Model(_logic);


            DataContext = new MainViewModel(_model);
        }
    }
}
