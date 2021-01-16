using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private int maxNumberOfEnemy;
    [SerializeField] private GameObject enemyPrefab;

    private int _enemyCounter;

    private void Awake()
    {
        _enemyCounter = 0;
    }

    public Enemy Create(Transform parent)
    {
        if (IsTooManyEnemies()) return null;
        _enemyCounter++;
        var newEnemy = Instantiate(
                    enemyPrefab,
                    parent.position,
                    parent.rotation).GetComponent<Enemy>();
        newEnemy.Hide();
        newEnemy.transform.SetParent(parent);
        return newEnemy;
    }

    private bool IsTooManyEnemies()
    {
        return _enemyCounter >= maxNumberOfEnemy;
    }
}
