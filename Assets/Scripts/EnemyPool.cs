using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private EnemyFactory enemyFactory;

    private Queue<Enemy> _enemyPool;

    private void ReturnEnemyToPool(Enemy enemy)
    {
        if (_enemyPool != null)
            _enemyPool.Enqueue(enemy);
    }

    private void Awake()
    {
        _enemyPool = new Queue<Enemy>();
        _timeSinceLastSpawn = 0;
    }

    private void Update()
    {
        if (IsTimeToSpawn())
            SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        _timeSinceLastSpawn = 0f;
        if (_enemyPool.Count == 0)
            AddEnemyToPool();
        else SpawnEnemyFromPool();
    }

    private void AddEnemyToPool()
    {
        var newEnemy = enemyFactory.Create(transform);
        if (newEnemy == null) return;
        newEnemy.OnEnemyHitByBullet += ReturnEnemyToPool;
        _enemyPool.Enqueue(newEnemy);
    }

    private void SpawnEnemyFromPool()
    {
        var enemy = _enemyPool.Dequeue();
        ShowEnemyAtRandomPosition(enemy);
    }

    private void ShowEnemyAtRandomPosition(Enemy enemy)
    {
        enemy.Position = GetRandomPositionInBound();
        enemy.Show();
    }

    private Vector3 GetRandomPositionInBound()
    {
        return new Vector3(
            Random.Range(-8.5f,8.5f),
            Random.Range(-4.5f, 4.5f));
    }

    private float _timeSinceLastSpawn;
    private bool IsTimeToSpawn()
    {
        if (_timeSinceLastSpawn >= timeBetweenSpawns)
            return true;

        _timeSinceLastSpawn += Time.deltaTime;
        return false;
    }
}
