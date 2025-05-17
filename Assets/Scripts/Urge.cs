using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Urge
{
    public string Name { get; }
    private float _tickSpeed;
    private float _percentage;
    private (DigimonAction Action, System.Func<ActContext> ContextProvider)[] _actions;

    public Urge(string name, float tickSpeed, params (DigimonAction, System.Func<ActContext>)[] actions)
    {
        Name = name;
        _tickSpeed = Mathf.Max(0f, tickSpeed);
        _percentage = 100f;
        _actions = actions ?? Array.Empty<(DigimonAction, Func<ActContext>)>();
    }

    public (DigimonAction, ActContext)? GetActionWithContext()
    {
        if (_actions.Length == 0)
            return null;
        int i = Random.Range(0, _actions.Length);
        var (action, contextFunc) = _actions[i];
        var context = contextFunc();
        if (context == null)
            return null;
        return (action, context);
    }

    public float Tick()
    {
        _percentage = Mathf.Clamp(_percentage - _tickSpeed, 0f, 100f);
        return _percentage;
    }

    public float UpdateValue(float value)
    {
        _percentage = Mathf.Clamp(_percentage + value, 0f, 100f);
        return _percentage;
    }

    public int GetUrgePercentage()
    {
        return Mathf.RoundToInt(_percentage);
    }

    public static bool operator <(Urge a, float v) => a._percentage < v;
    public static bool operator >(Urge a, float v) => a._percentage > v;
    public static bool operator <(Urge a, Urge b) => a._percentage < b._percentage;
    public static bool operator >(Urge a, Urge b) => a._percentage > b._percentage;
}