using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int Speed;


    private GameObject Player;
    private Rigidbody EnemyRB;
    private NavMeshAgent EnemyNMA;
    private float _Time;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemyNMA = GetComponent<NavMeshAgent>();
        EnemyNMA.speed = Speed;
        EnemyNMA.SetDestination(Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyNMA.speed += Time.deltaTime;
    }
}
