using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector3 GetMovementInput()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        return moveDirection;
    }
}
