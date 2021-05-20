using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class collisionControl : MonoBehaviour
{
    public GameObject sonarBase;
    raycasting1 sonarBaseScript;
    public bool searchBool ;
    public GameObject dirt;
    public NavMeshAgent agent;
    public Image chargeImg;
    public float rotationSpeed = 2.0f;
    public GameObject chargeStable;
    userControl userControlScript;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "chargingPlace"&&sonarBaseScript.searchDirt==false)
        {
            
           chargeImg.fillAmount += 0.1f * Time.deltaTime;
            if (chargeImg.fillAmount<0.95f)
            {
               
                userControlScript.isWorking = false;
                userControlScript.chargeWorking = true;

            }
        }
    }
   
    void OnCollisionEnter(Collision collision)
    {

       
        if (collision.collider.tag == "dirt") {
            agent.ResetPath();
        
        searchBool = true;
        sonarBaseScript.searchDirt = searchBool;
         Vector3 pos = new Vector3(Random.Range(13,-14), 0.8f, Random.Range(13, -12));
        Quaternion q = new Quaternion(0, 0, 0, 0);
            dirt.transform.position = pos;
            dirt.transform.rotation = q;


        }
      
    }
    // Start is called before the first frame update
    void Start()
    {
        userControlScript = chargeStable.GetComponent<userControl>();
        sonarBaseScript = sonarBase.GetComponent<raycasting1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
