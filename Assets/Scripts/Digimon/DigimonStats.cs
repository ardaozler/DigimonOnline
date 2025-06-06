using System;
using System.Collections.Generic;
using UnityEngine;

public class DigimonStats : MonoBehaviour
{
    public int Hunger;
    public int Cleanliness;
    public int Happiness;

    private Urge _hunger;
    private Urge _cleanliness;
    private Urge _happiness;

    public void InitializeUrges(GameObject owner)
    {
        _hunger = new Urge("Hunger", 0.1f, (new SearchAction(), () => new SearchContext(owner, "Food")));
        _cleanliness = new Urge("Cleanliness", 0.1f);
        _happiness = new Urge("Happiness", 6f, (new SearchAction(), () => new SearchContext(owner, "Ball")));
    }

    public void UpdateUrge(string name, float amount)
    {
        foreach (var urge in GetUrges())
        {
            if (urge.Name == name)
            {
                urge.UpdateValue(amount);
                return;
            }
        }
    }

    private void Update()
    {
        Hunger = _hunger.GetUrgePercentage();
        Cleanliness = _cleanliness.GetUrgePercentage();
        Happiness = _happiness.GetUrgePercentage();
    }

    public IEnumerable<Urge> GetUrges() => new[] { _hunger, _cleanliness, _happiness };
}