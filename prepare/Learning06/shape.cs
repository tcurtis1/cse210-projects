using System;

public abstract class Shape
{
    protected string _color;
    
    public string GetColor()
    {
        return _color;
    }
    public Shape(string color)
    {
        _color = color;
    }
    public void SetColor(string color)
    {
        _color = color;
    }

    public abstract double GetArea();
    
}