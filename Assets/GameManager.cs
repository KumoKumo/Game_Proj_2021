using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxNumberOfEnemy;
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private Player player;

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
        Debug.Log("<color=blue>Score: </color>" + Score);
    }

    private void Awake()
    {
        Score = 0;
        PlayerHealth = 5;
        _enemyList = new List<Enemy>();
        player.OnCollisionWithEnemy += OnPlayerCollideWithEnemy;
    }

    private void OnPlayerCollideWithEnemy()
    {
        PlayerHealth--;
        Debug.Log("<color=green>Health: </color>" + PlayerHealth);
        if (PlayerHealth == 0)
            StopTheGame();
    }

    private void StopTheGame()
    {
        player.StopPlaying();
        enemyPool.enabled = false;
        Debug.Log("<color=red>GAME OVER!!!</color>");

    }
}
