using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [Header("Movimiento")]
    [SerializeField]
    private int speed = 12;
    [SerializeField]
    private float distanceToPlayer = 6;
    private GameObject player;
    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;
    [SerializeField]
    private float timeBetweenBullets = 3.0f;
    private AudioSource shootAudio;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Attack", 1, timeBetweenBullets);
        shootAudio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if(player == null)
            return;
        transform.LookAt(player.transform.position);
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > distanceToPlayer)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Attack()
    {    
            shootAudio.Play();
            for(int i = 0; i < posRotBullet.Length; i++)
            {   
            Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
            }
        
    }
}
