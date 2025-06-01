using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject foodPrefab;
    public Tilemap tilemap;
    public float zDepth = 5f;


    public void SpawnBallOnMouse()
    {
        SpawnBall(GetMouseWorldPoint());
    }

    private Vector3 GetMouseWorldPoint()
    {

        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDepth)
        );
        
        mouseWorldPoint.y = DragAndDrop.FixedY;
        return mouseWorldPoint;
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
        SpawnFood(GetMouseWorldPoint());
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