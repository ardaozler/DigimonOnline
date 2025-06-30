using UnityEngine;
using UnityEngine.Tilemaps;

public class Egg : MonoBehaviour
{
    public GameObject digimonPrefab;

    public float hatchTime = 5f; // Time in seconds before the egg hatches
    private float hatchTimer;

    private bool isHatching = false;

    private Tilemap _tilemap;

    private void Start()
    {
        hatchTimer = hatchTime;
    }

    private void Update()
    {
        if (isHatching)
        {
            hatchTimer -= Time.deltaTime;
            if (hatchTimer <= 0f)
            {
                Hatch();
            }
        }
    }

    public void StartHatching(Tilemap tilemap)
    {
        if (!isHatching)
        {
            isHatching = true;
            hatchTimer = hatchTime;

            _tilemap = tilemap;
        }
    }

    private void Hatch()
    {
        isHatching = false;
        hatchTimer = hatchTime;

        if (digimonPrefab != null)
        {
            DigimonMover mover = Instantiate(digimonPrefab, transform.position, digimonPrefab.transform.rotation)
                .GetComponent<DigimonMover>();
            mover.tilemap = _tilemap; // Assign the tilemap to the DigimonMover

            Destroy(gameObject); // Destroy the egg after hatching
        }
        else
        {
            Debug.LogError("Digimon prefab is not assigned.");
        }
    }
}