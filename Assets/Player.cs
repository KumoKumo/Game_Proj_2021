using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController input;
    [SerializeField] [Range(1, 10)] private float speed;

    void Update()
    {
        var newPos = transform.position
            + input.GetMovementInput() 
            * Time.deltaTime 
            * speed;

        if (IsPlayerStillInBound(newPos))
            transform.position = newPos;
    }

    private bool IsPlayerStillInBound(Vector3 position)
    {
        if (position.x < -8.5 || position.x > 8.5
            || position.y > 4.5 || position.y < -4.5)
            return false;
        return true;
    }
}
