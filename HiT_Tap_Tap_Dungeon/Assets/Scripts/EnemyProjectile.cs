using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody RB;
    public int Speed;
    private GameObject Player;
    private Manager _Manager;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.LookAt(Player.transform.position);
        RB = GetComponent<Rigidbody>();
        _Manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime); 
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _Manager.TakeDamage();
        Destroy(gameObject);
        } else if (!col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
