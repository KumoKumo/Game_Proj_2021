using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float aliveTime;
    private Vector3 _direction;

    public Action<Bullet> OnTimeOut; 

    public float Speed
    {
        get => speed;
        set { speed = value; }
    }

    public Vector3 Direction
    {
        get => _direction;
        set { _direction = value; }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    float timer;
    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        ReturnToBulletPoolWhenTimesUp();
        MoveInInputDirection();
    }

    private void MoveInInputDirection()
    {
        if (Direction != null)
            transform.Translate(speed * Time.deltaTime * _direction);
    }

    private void ReturnToBulletPoolWhenTimesUp()
    {
        if (timer > aliveTime)
        {
            timer = 0;
            OnTimeOut?.Invoke(this);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        OnTimeOut = null;
    }
}
