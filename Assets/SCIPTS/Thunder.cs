using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    [SerializeField]
    private int speed = 100;

    private void Movement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Update()
    {
        Movement();
    }

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

}
