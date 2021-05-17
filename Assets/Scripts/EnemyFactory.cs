using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform target;

    public Enemy Create(Transform parent)
    {
        if (gameManager.IsTooManyEnemies) return null;
        var newEnemy = Instantiate(
                    enemyPrefab,
                    parent.position,
                    parent.rotation).GetComponent<Enemy>();
        newEnemy.gameObject.SetActive(false);
        newEnemy.Target = target;
        newEnemy.transform.SetParent(parent);
        gameManager.AddNewEnemyToManage(newEnemy);
        return newEnemy;
    }
}
