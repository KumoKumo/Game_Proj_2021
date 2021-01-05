using UnityEngine;

public class Enemy : MonoBehaviour
{
    //If IsTrigger is checked then OnCollisionEnter2D won't be called.
    //OnTriggerEnter2D will be called instead.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if(collider.tag == "Bullet")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
