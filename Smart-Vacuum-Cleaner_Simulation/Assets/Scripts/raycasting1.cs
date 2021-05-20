using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class raycasting1 : MonoBehaviour
{
  
    public float rotationSpeed = 2.0f;
    public NavMeshAgent agent;
    public bool searchDirt = true;
 
  void  Search()
    {
       
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {


        if (searchDirt == true)
        {
            Vector3 rot = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(rot.x, rot.y + Time.deltaTime * rotationSpeed, rot.z);

        }
        int layerMask = 1 << 8;


        layerMask = ~layerMask;
        RaycastHit hit;
        if(searchDirt)
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {


            if (hit.collider.gameObject.tag == "dirt")
            {
                   
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                    agent.isStopped = false;


                    agent.SetDestination(hit.point);

                searchDirt = false;


            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            }

        }
        
       


    }
}

