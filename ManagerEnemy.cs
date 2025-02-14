using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //Variable que indica el prefab de la bala.
    [SerializeField]
    private Transform[] posRotEnemy; //Variable que indica la posición del spawn del enemigo.
    [SerializeField]
    private float timeBetweenEnemies = 5.0f; //Variable que que indica el tiempo ente enemigos.

    private void Start()  
    {
            InvokeRepeating("CreateEnemies", 1.0f, timeBetweenEnemies); //Bucle que hace que la creación de enemigos sea al segundo de empezar teniendo en cuenta el tiempo entre enemigos.
    }

    private void CreateEnemies() //Variable que almacena los datos de la creación de enemigos.
    {
        int n = Random.Range(0, posRotEnemy.Length); //Indica que los enemigos se generen de forma alteatoria en cada uno de los spawns.
        Instantiate(enemyPrefab, posRotEnemy[n].position, posRotEnemy[n].rotation); //Instancia el prefab del enemigo de la posición y rotación de los spawns.
    }
}
