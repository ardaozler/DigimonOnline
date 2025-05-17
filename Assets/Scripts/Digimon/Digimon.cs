using UnityEngine;

public class Digimon : MonoBehaviour
{
    private void Start()
    {
        var mover = GetComponent<DigimonMover>();
        var animatorController = GetComponent<DigimonAnimator>();
        mover.OnMovementStart += animatorController.PlayWalkAnimation;
        mover.SetMovementStrategy(new TileWalkMovement());
    }
}