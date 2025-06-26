using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DigimonStats : MonoBehaviour
{
    public int Hunger;
    public float hungerTickSpeed;
    public int Cleanliness;
    public float cleanlinessTickSpeed;
    public int Happiness;
    public float happinessTickSpeed;


    private Urge _hunger;
    private Urge _cleanliness;
    private Urge _happiness;

    public void InitializeUrges(GameObject owner)
    {
        hungerTickSpeed = Random.Range(0.5f, 2f);
        cleanlinessTickSpeed = Random.Range(0.5f, 2f);
        happinessTickSpeed = Random.Range(5f, 5f);
        _hunger = new Urge("Hunger", hungerTickSpeed, (new SearchAction(), () => new SearchContext(owner, "Food")));
        _cleanliness = new Urge("Cleanliness", cleanlinessTickSpeed);
        _happiness = new Urge("Happiness", happinessTickSpeed,
            (new SearchAction(), () => new SearchContext(owner, "Ball")));
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