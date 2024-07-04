using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] private Enemy[] Enemies;
    [SerializeField] private GameObject[] SpawnPoints;

    [SerializeField] private Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ////PC
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Debug.DrawRay(ray.origin, ray.direction * 30, Color.red);
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray.origin,ray.direction, out hit))
        //    {
        //        if (hit.transform.gameObject.CompareTag("Enemy"))
        //        {
        //            Destroy(hit.transform.gameObject);
        //        }
        //    }
        //}

        //Mobile

        for (int i = 0; i < Input.touchCount && Input.GetTouch(i).phase == TouchPhase.Began; i++) 
            { 
            Touch touch = Input.GetTouch(i);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;


            Debug.DrawRay(ray.origin, ray.direction, Color.red);

            if (Physics.Raycast(ray.origin,ray.direction,out hit))
            {

                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.CompareTag("Projectile"))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            }
        } 

    public void TakeDamage()
    {
        Debug.Log("Hit!");
    }

}
