using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    [SerializeField]
    private int speed = 100; //Variable que indica la velocidad de la bala.

    private void Movement() 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //Función que indica la velocidad del objeto.
    }

    void Update() 
    {
        Movement(); //Función que llama al movimiento.
    }

    private void Start() 
    {
        Destroy(gameObject, 5.0f); //Destruye al objeto a los 5 segundos que generarse.
    }

}
