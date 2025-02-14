using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameOver; //Variable que indica el panel de GameOver.
    [SerializeField]
    private ManagerEnemy enemyManager; //Varible que indica el manager del enemigo.
    [SerializeField]
    private Enemy enemy; //Variable que define al enemigo.

    
    public void GameOver() //Variable que almacena los datos del GameOver.
    {
        panelGameOver.SetActive(true); //Función que activa el panel de GameOver.
        enemyManager.enabled = false; //Función que desactiva el manager del enemigo.
        Cursor.lockState = CursorLockMode.Confined; //Función que desactiva el cursor, bloqueándolo mientras se está en la pestaña de juego.
    }

    public void _Restart() //Variable que almacena los datos del botón de restart.
    {
        SceneManager.LoadScene("Level_01"); //Función que carga la escena llamada nivel 01.
    }
    
}
