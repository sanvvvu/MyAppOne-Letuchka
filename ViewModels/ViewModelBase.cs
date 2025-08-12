using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace MyTestOne.ViewModels;

public class ViewModelBase : ReactiveObject
{
    // Явно инициализируем событие как null
    public new event PropertyChangedEventHandler? PropertyChanged = null;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        // Добавляем проверку на null перед вызовом
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}