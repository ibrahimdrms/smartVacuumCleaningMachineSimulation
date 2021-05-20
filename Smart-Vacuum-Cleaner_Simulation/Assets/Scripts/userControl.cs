using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class userControl : MonoBehaviour
{
  
    public Button stopBtn;
    public Button resumeBtn;
    public Button chargeBtn;
    public Button restartBtn; 
    public NavMeshAgent agent;
    public GameObject sonarBase;
    raycasting1 sonarBaseScript;
    public Image charge;
    public Text textCharge;
    public bool isWorking=true;
    public GameObject chargePlace;
    public Button scanBtn;
    public bool chargeWorking = false;
   
  
    Vector3 pos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        sonarBaseScript = sonarBase.GetComponent<raycasting1>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking == true) {
            if (charge.fillAmount == 1.0f)
            {
                textCharge.text = (charge.fillAmount * 100).ToString().Substring(0, 3);
                charge.fillAmount -= 0.01f * Time.deltaTime;

                charge.color = Color.Lerp(Color.red, Color.green, charge.fillAmount);
            }
            else
            if (charge.fillAmount >= 0.1f) 
            {
                textCharge.text = (charge.fillAmount * 100).ToString().Substring(0, 2);
                charge.fillAmount -= 0.01f * Time.deltaTime;

                charge.color = Color.Lerp(Color.red, Color.green, charge.fillAmount);
            }

            if (charge.fillAmount <= 0.12f) 
            {
                if (charge.fillAmount <= 0.12f && charge.fillAmount > 0.1f)
                    textCharge.text = (charge.fillAmount * 100).ToString().Substring(0, 2);
                if (charge.fillAmount < 0.1f)
                {
                    textCharge.text = (charge.fillAmount * 100).ToString().Substring(0, 1);
                }
                    agent.SetDestination ( chargePlace.transform.position);
                
                charge.fillAmount -= 0.01f * Time.deltaTime;

                charge.color = Color.Lerp(Color.red, Color.green, charge.fillAmount);
            }
            
           
        }
        if (chargeWorking == true)
        {
            if (charge.fillAmount == 1.0f)
            {
                textCharge.text = (charge.fillAmount * 100).ToString().Substring(0, 3);
                charge.fillAmount += 0.01f * Time.deltaTime;

                charge.color = Color.Lerp(Color.red, Color.green, charge.fillAmount);
            }
            else
           if (charge.fillAmount >= 0.1f)
            {
                textCharge.text = (charge.fillAmount * 100).ToString().Substring(0, 2);
                charge.fillAmount += 0.01f * Time.deltaTime;

                charge.color = Color.Lerp(Color.red, Color.green, charge.fillAmount);
            }

            if (charge.fillAmount <= 0.12f)
            {
                if (charge.fillAmount <= 0.12f && charge.fillAmount > 0.1f)
                    textCharge.text = (charge.fillAmount * 100).ToString().Substring(0, 2);
                if (charge.fillAmount < 0.1f)
                {
                    textCharge.text = (charge.fillAmount * 100).ToString().Substring(0, 1);
                }
                

                charge.fillAmount += 0.01f * Time.deltaTime;

                charge.color = Color.Lerp(Color.red, Color.green, charge.fillAmount);
            }
        }
    }
    public void stopButton()
    {
        agent.isStopped = true;
       
        sonarBaseScript.searchDirt = false;
        isWorking = false;

    }
    public void resumeButton()
    {
        agent.isStopped=false;
        isWorking = true;
        chargeWorking = false;
        
        if (agent.hasPath==true)

            sonarBaseScript.searchDirt = false;
        else

            sonarBaseScript.searchDirt = true;
    }
    public void chargeButton()
    {
        agent.isStopped = false;
        isWorking = true;
        sonarBaseScript.searchDirt = false;
        agent.SetDestination(chargePlace.transform.position);

    }
    public void restartButton()
    {
        SceneManager.LoadScene("Pathfinder");
    }
    public void scanButton()
    {
        isWorking = true;
        sonarBaseScript.searchDirt = true;
    }
}

