using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Action<Enemy> OnEnemyHitByBullet;
    public Vector3 Position { set { transform.position = value; } }

    //If IsTrigger is checked then OnCollisionEnter2D won't be called.
    //OnTriggerEnter2D will be called instead.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if(collider.tag == "Bullet")
        {
            Destroy(collider.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        OnEnemyHitByBullet?.Invoke(this);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
