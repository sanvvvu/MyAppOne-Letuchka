using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace MyTestOne;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is null) return null;
        
        var name = param.GetType().FullName!
            .Replace("ViewModels", "Views")
            .Replace("ViewModel", "View");
            
        var type = Type.GetType(name);
        return type != null ? (Control)Activator.CreateInstance(type)! : 
            new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data) => data is not null;
}
