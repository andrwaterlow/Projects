using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject EnemyPref;

    public Transform EnemyStartPosition;

    public bool ActiveBoss { get;  set; } = false;

    int boss = 0;



    private void Awake()
    {
      
    }
    // Start is called before the first frame update
    void Start()
    {
        /*CreateEnemy();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (boss <= 0 && ActiveBoss)
        {
            CreateEnemy();
        }
    }

    public void CreateEnemy()
    {

        var enemy = Instantiate(EnemyPref, EnemyStartPosition.position, Quaternion.identity).GetComponent<Enemy>();
        boss++;



    }

}
