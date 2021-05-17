using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Action OnPlayerCollideWithEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if (collider.tag == "Enemy")
        {
            OnPlayerCollideWithEnemy?.Invoke();
        }
    }
}
