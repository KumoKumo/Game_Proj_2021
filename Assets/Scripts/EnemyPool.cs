using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private int maxNumberOfEnemy;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate;

    private Queue<Enemy> _enemyPool;

    private void ReturnEnemyToPool(Enemy enemy)
    {
        if (_enemyPool != null)
            _enemyPool.Enqueue(enemy);
    }

    private void Awake()
    {
        _enemyPool = new Queue<Enemy>();
        _timer = 0;
    }

    private void Update()
    {
        if (!IsTooManyEnemies() && IsTimeToSpawn())
            SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (_enemyPool.Count == 0)
            SpawnNewEnemy();
        else SpawnEnemyFromPool();
    }

    private void SpawnNewEnemy()
    {
        var newEnemy = Instantiate(
            enemyPrefab,
            transform.position,
            transform.rotation).GetComponent<Enemy>();
        newEnemy.OnEnemyHitSomething += ReturnEnemyToPool;
        newEnemy.transform.SetParent(transform);
        _enemyPool.Enqueue(newEnemy);

        SpawnEnemyFromPool();
    }

    private void SpawnEnemyFromPool()
    {
        var enemy = _enemyPool.Dequeue();
        enemy.OnEnemyHitSomething += ReturnEnemyToPool;
        ShowEnemyAtRandomPosition(enemy);
    }

    private void ShowEnemyAtRandomPosition(Enemy enemy)
    {
        enemy.Position = GetRandomPositionInBound();
        enemy.Show();
    }

    private Vector3 GetRandomPositionInBound()
    {
        return Vector3.zero;
    }

    private bool IsTooManyEnemies()
    {
        return _enemyPool.Count == maxNumberOfEnemy;
    }

    private float _timer;
    private bool IsTimeToSpawn()
    {
        if (_timer >= spawnRate)
        {
            _timer = 0;
            return true;
        }

        _timer += Time.deltaTime;
        return false;
    }
}
