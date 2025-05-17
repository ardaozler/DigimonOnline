using UnityEngine;
using UnityEngine.Serialization;

public class Urge
{
    public string name;
    private float _tickSpeed;
    private float _percentage;
    private DigimonAction[] _possibleActions;

    public Urge(string name, float tickSpeed, params DigimonAction[] possibleActions)
    {
        this.name = name;
        _tickSpeed = tickSpeed;
        _percentage = 100;
        _possibleActions = possibleActions;
    }
    
    public DigimonAction GetPossibleAction()
    {
        if (_possibleActions.Length == 0)
            return null;

        int randomIndex = Random.Range(0, _possibleActions.Length);
        return _possibleActions[randomIndex];
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

    public static bool operator <(Urge urge, float value)
    {
        return urge._percentage < value;
    }

    public static bool operator >(Urge urge, float value)
    {
        return urge._percentage > value;
    }

    public static bool operator <(Urge first, Urge second)
    {
        return first._percentage < second._percentage;
    }

    public static bool operator >(Urge first, Urge second)
    {
        return first._percentage > second._percentage;
    }
}