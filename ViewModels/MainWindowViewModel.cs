using Avalonia.Media;
using MyTestOne.Models;
using ReactiveUI;
using System;
using System.Reactive;

namespace MyTestOne.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private RectangleSettings _rectangleSettings = new();
    private CircleSettings _circleSettings = new();
    
    private ShapeSettings _currentSettings;
    public ShapeSettings CurrentSettings
    {
        get => _currentSettings;
        set => this.RaiseAndSetIfChanged(ref _currentSettings, value);
    }

    private ShapeType _currentShapeType;
    public ShapeType CurrentShapeType
    {
        get => _currentShapeType;
        set
        {
            if (CurrentSettings != null)
            {
                if (CurrentShapeType == ShapeType.Rectangle)
                {
                    _rectangleSettings = (RectangleSettings)CurrentSettings;
                }
                else
                {
                    _circleSettings = (CircleSettings)CurrentSettings;
                }
            }

            this.RaiseAndSetIfChanged(ref _currentShapeType, value);
            CurrentSettings = value == ShapeType.Rectangle 
                ? _rectangleSettings 
                : _circleSettings;
        }
    }

    public ReactiveCommand<Unit, Unit> SwitchToRectangleCommand { get; }
    public ReactiveCommand<Unit, Unit> SwitchToCircleCommand { get; }

    public MainWindowViewModel()
    {
        CurrentShapeType = ShapeType.Rectangle;
        CurrentSettings = _rectangleSettings;

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