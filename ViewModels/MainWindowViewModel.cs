using MyTestOne.Models;
using System.Windows.Input;

namespace MyTestOne.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ShapeType _currentShapeType;
    public ShapeType CurrentShapeType
    {
        get => _currentShapeType;
        set => SetField(ref _currentShapeType, value);
    }

    public RectangleSettings Rectangle { get; } = new();
    public CircleSettings Circle { get; } = new();

    public ShapeSettings CurrentShape => CurrentShapeType == ShapeType.Rectangle ? Rectangle : Circle;

    public ICommand SwitchToRectangleCommand { get; }
    public ICommand SwitchToCircleCommand { get; }

    public MainWindowViewModel()
    {
        CurrentShapeType = ShapeType.Rectangle;

        SwitchToRectangleCommand = new RelayCommand(_ => CurrentShapeType = ShapeType.Rectangle);
        SwitchToCircleCommand = new RelayCommand(_ => CurrentShapeType = ShapeType.Circle);
    }
}
