using System;

public class Shape
{
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter and Setter for color
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method to be overridden by derived classes
    public virtual double GetArea()
    {
        return 0; // Default (no area for base shape)
    }
}
