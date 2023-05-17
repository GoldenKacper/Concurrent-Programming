using Data;
using Presentation.Commands;
using Presentation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Presentation.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _movingSpeed = 5;
        private string _ballsNumber;
        private string _ballsCounter;
        private string _borderColorDuringGame;
        private int _tempBallRadius = 25;
        private Canvas _canvas;
        private IModel _model;
        private ILog _log;
        private DateTime _dateTime;


        //readonly int _radius = 25; // TODO draw from the range e.g. 15 - 40

        private DispatcherTimer timer = new DispatcherTimer(); // allows you to change some value at regular time intervals
        public event PropertyChangedEventHandler? PropertyChanged;

        private DispatcherTimer logTimer = new DispatcherTimer();


        public MainViewModel(IModel model, ILog log)
        {
            _model = model;
            _log = log;

            _log.ClearLog();

            BallsNumber = "0";
            BallsCounter = BallsNumber;
            BorderColorDuringGame = "Black";
            GenerateBallsCommand = new RelayCommand(GenerateBalls);
        }

        public ICommand GenerateBallsCommand { get; set; }

        public DateTime DateTime
        {
            get => _dateTime; set => _dateTime = value;
        }

        public void GenerateBalls(object obj)
        {
            _canvas = (obj as Canvas);
            _canvas.Focus();

            int ballsNumber = int.Parse(BallsNumber);

            MessageBox.Show("Let's start");
            BorderColorDuringGame = "Red";
            BallsCounter = BallsNumber;

            _model.InitializeModel((int)_canvas.Width, (int)_canvas.Height, ballsNumber, _tempBallRadius, _movingSpeed);
            for (int i = 0; i < ballsNumber; i++)
            {
                Random random = new Random();
                Border ball = new Border();
                Brush color = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255),
                  (byte)random.Next(1, 255), (byte)random.Next(1, 233)));

                ball.BorderBrush = Brushes.Black;
                ball.Width = 2 * _tempBallRadius;
                ball.Height = 2 * _tempBallRadius;
                ball.Background = color;
                ball.CornerRadius = new CornerRadius(50);
                ball.BorderThickness = new Thickness(3);
                ball.Name = "Ball" + i.ToString();

                _canvas.Children.Add(ball);

                Canvas.SetLeft(ball, _model.GetLocation(i).X - _tempBallRadius);
                Canvas.SetTop(ball, _model.GetLocation(i).Y - _tempBallRadius);
            }
            MoveBall();
            Logging();
        }

        public string BallsNumber
        {
            get => _ballsNumber;
            set
            {
                _ballsNumber = value;
                OnPropertyChanged();
            }
        }

        public string BallsCounter
        {
            get => _ballsCounter;
            set
            {
                _ballsCounter = value;
                OnPropertyChanged();
            }
        }

        public string BorderColorDuringGame
        {
            get => _borderColorDuringGame;
            set
            {
                _borderColorDuringGame = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // ?. if not null
        }

        private void MoveBall()
        {
            timer.Tick += TimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(20);

            timer.Start();
        }

        private void TimerEvent(object? sender, EventArgs e)
        {
            int value = int.Parse(BallsNumber);
            _model.UpdateLocation();
            for (int i = 0; i < value; i++)
            {
                Canvas.SetLeft(_canvas.Children[i], _model.GetLocation(i).X - _tempBallRadius);
                Canvas.SetTop(_canvas.Children[i], _model.GetLocation(i).Y - _tempBallRadius);
            }
        }

        public void StopBalls()
        {
            _model.StopLogic();
        }

        private void Logging()
        {
            logTimer.Tick += LogTimerEvent;
            logTimer.Interval = TimeSpan.FromMilliseconds(5000);

            logTimer.Start();
        }

        private void LogTimerEvent(object? sender, EventArgs e)
        {
            _dateTime = DateTime.Now;
            _log.WriteLog(_dateTime);
        }
    }
}
