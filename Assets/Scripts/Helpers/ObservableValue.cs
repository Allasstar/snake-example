using System;

public struct ObservableValue<T>
{
    public T Value { get; private set; }
    public Action<T> ValueChanged;

    public void SetValue(T value)
    {
        Value = value;
        ValueChanged?.Invoke(Value);
    }
}
