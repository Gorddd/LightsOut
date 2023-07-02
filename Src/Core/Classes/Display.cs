namespace Core.Classes;

public class Display
{
    public string Name { get; set; } = null!;

    public double Left { get; set; }
    public double Top { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public bool? IsCovered { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Display other)
        {
            return Name == other.Name && Left == other.Left && Top == other.Top && Width == other.Width && Height == other.Height;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Left, Top, Width, Height);
    }
}
