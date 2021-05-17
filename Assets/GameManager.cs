using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxNumberOfEnemy;
    private List<Enemy> _enemyList;

    public int Score { get; private set; }
    public int PlayerHealth { get; private set; }
    public bool IsTooManyEnemies => _enemyList == null ? 
        true : _enemyList.Count >= maxNumberOfEnemy;

    public void AddNewEnemyToManage(Enemy enemy)
    {
        enemy.OnEnemyHitByBullet += OnEnemyHitByBullet;
        _enemyList?.Add(enemy);
    }

    public void OnEnemyHitByBullet(Enemy enemy)
    {
        Score++;
        Debug.Log(Score);
    }

    private void Awake()
    {
        Score = 0;
        PlayerHealth = 0;
        _enemyList = new List<Enemy>();
    }


}
