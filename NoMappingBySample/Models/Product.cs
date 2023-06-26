using System.ComponentModel;

namespace NoMappingBySample.Models;

public class Product : INotifyPropertyChanged
{
    private int id;
    private string name = null!;
    private decimal price;

    public int Id
    {
        get { return id; }
        set
        {
            if (id != value)
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    public decimal Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
