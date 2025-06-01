using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject foodPrefab;
    public Tilemap tilemap;


    public void SpawnBallOnMouse()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(transform.position).z)
        );
        SpawnBall(mouseWorldPoint);
    }

    private void SpawnBall(Vector3 position)
    {
        if (ballPrefab == null)
        {
            Debug.LogError("Ball prefab is not assigned.");
            return;
        }

        GameObject ball = Instantiate(ballPrefab, position, Quaternion.identity);
        ball.GetComponent<Ball>().tilemap = tilemap;
        DragAndDrop dragAndDrop = ball.GetComponent<DragAndDrop>();
        dragAndDrop.StartDragExternally();
        ball.name = "Ball";
    }

    public void SpawnFoodOnMouse()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(transform.position).z)
        );
        SpawnFood(mouseWorldPoint);
    }

    private void SpawnFood(Vector3 position)
    {
        if (foodPrefab == null)
        {
            Debug.LogError("Food prefab is not assigned.");
            return;
        }

        GameObject food = Instantiate(foodPrefab, position, Quaternion.identity);
        DragAndDrop dragAndDrop = food.GetComponent<DragAndDrop>();
        dragAndDrop.StartDragExternally();
        food.name = "Food";
    }
}