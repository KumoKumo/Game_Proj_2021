using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collider = collision.collider;
        if (collider.tag == "Enemy")
        {
            collider.gameObject.SetActive(false);
            _player?.OnCollisionWithEnemy.Invoke();
        }
    }
}
