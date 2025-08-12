using Avalonia.Media;
using MyTestOne.Models;
using ReactiveUI;
using System;
using System.Reactive;

namespace MyTestOne.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ShapeType _currentShapeType;
    public ShapeType CurrentShapeType
    {
        get => _currentShapeType;
        set => this.RaiseAndSetIfChanged(ref _currentShapeType, value);
    }

    public RectangleSettings RectangleSettings { get; } = new();
    public CircleSettings CircleSettings { get; } = new();

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