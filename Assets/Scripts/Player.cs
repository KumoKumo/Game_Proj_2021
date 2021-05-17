using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController input;
    [SerializeField] private PlayerCollision playerCollision;
    [SerializeField] [Range(1, 10)] private float speed;


    private bool _isPlaying;
    public void StartPlaying()
    {
        _isPlaying = true;
        gameObject.SetActive(true);
    }

    public void StopPlaying()
    {
        _isPlaying = false;
        gameObject.SetActive(false);
    }

    public Action OnCollisionWithEnemy;
    private void Awake()
    {
        playerCollision.OnPlayerCollideWithEnemy += 
            ()=> OnCollisionWithEnemy.Invoke();
        StartPlaying();
    }

    private void Update()
    {
        if (_isPlaying)
            MovePlayer();
    }

    private void MovePlayer()
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
