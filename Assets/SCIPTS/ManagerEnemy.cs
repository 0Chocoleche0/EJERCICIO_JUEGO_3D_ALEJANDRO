using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform[] posRotEnemy;
    [SerializeField]
    private float timeBetweenEnemies = 5.0f;

    private void Start()
    {
            InvokeRepeating("CreateEnemies", 1.0f, timeBetweenEnemies);
    }

    private void CreateEnemies()
    {
        int n = Random.Range(0, posRotEnemy.Length);
        Instantiate(enemyPrefab, posRotEnemy[n].position, posRotEnemy[n].rotation);
    }
}
