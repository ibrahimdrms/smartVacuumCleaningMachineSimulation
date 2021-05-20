using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collliderwall : MonoBehaviour
{
    public GameObject dirt;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "wall")
        {
            
            
            Vector3 pos = new Vector3(Random.Range(13, -14), 0.8f, Random.Range(13, -12));
            Quaternion q = new Quaternion(0, 0, 0, 0);
            dirt.transform.position = pos;
            dirt.transform.rotation = q;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
