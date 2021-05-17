using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    public Action OnEnemyHitByBullet;
    public Action<Enemy> OnHideEnemy;
    public Vector3 Position { set { transform.position = value; } }

    //If IsTrigger is checked then OnCollisionEnter2D won't be called.
    //OnTriggerEnter2D will be called instead.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if (collider.tag == "Bullet")
        {
            Destroy(collider.gameObject);
            OnEnemyHitByBullet?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        var moveDirection = Target.position - transform.position;
        transform.Translate(moveDirection.normalized * Time.deltaTime);
    }

    private void OnDisable()
    {
        OnHideEnemy?.Invoke(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
