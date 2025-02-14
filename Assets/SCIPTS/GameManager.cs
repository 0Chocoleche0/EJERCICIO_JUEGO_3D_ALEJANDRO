using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameOver;
    [SerializeField]
    private ManagerEnemy enemyManager;
    [SerializeField]
    private Enemy enemy;

    
    public void GameOver()
    {
        panelGameOver.SetActive(true);
        enemyManager.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void _Restart()
    {
        SceneManager.LoadScene("Level_01");
    }
    
}
