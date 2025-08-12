using Avalonia.Data.Converters;
using MyTestOne.Converters; // Добавляем using
using MyTestOne.Models;
using ReactiveUI;
using System.Reactive;

namespace MyTestOne.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Добавляем статическое поле конвертера
        public static readonly ShapeTypeToVisibilityConverter ShapeTypeToVisibilityConverter = new();

        private ShapeType _currentShapeType;
        public ShapeType CurrentShapeType
        {
            get => _currentShapeType;
            set => this.RaiseAndSetIfChanged(ref _currentShapeType, value);
        }

        public RectangleSettings Rectangle { get; } = new();
        public CircleSettings Circle { get; } = new();

        public ShapeSettings CurrentShape => CurrentShapeType == ShapeType.Rectangle ? Rectangle : Circle;

        public ReactiveCommand<Unit, Unit> SwitchToRectangleCommand { get; }
        public ReactiveCommand<Unit, Unit> SwitchToCircleCommand { get; }

        public MainWindowViewModel()
        {
            CurrentShapeType = ShapeType.Rectangle;

            SwitchToRectangleCommand = ReactiveCommand.Create(() => 
            {
                CurrentShapeType = ShapeType.Rectangle;
            });
            
            SwitchToCircleCommand = ReactiveCommand.Create(() => 
            {
                CurrentShapeType = ShapeType.Circle;
            });
        }
    }
}