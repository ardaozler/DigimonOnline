public class Urge
{
    public string Name;
    private float _tickSpeed;
    private float _percentage;

    public Urge(string name, float tickSpeed)
    {
        Name = name;
        _tickSpeed = tickSpeed;
        _percentage = 0;
    }

    public float Tick()
    {
        _percentage -= _tickSpeed;
        return _percentage;
    }

    public float UpdatePercentage(float val)
    {
        _percentage += val;
        return _percentage;
    }

    public int GetUrgePercentage()
    {
        return (int)_percentage;
    }
}