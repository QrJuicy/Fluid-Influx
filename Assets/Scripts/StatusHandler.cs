using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StatusHandler : MonoBehaviour
{
    //GetComponent
    Transform objectPosition;

    [SerializeField] float winTimer = 0f;
    [SerializeField] float deathTimer = 0f;

    [SerializeField] float maxFluidity = 0f;
    [SerializeField] float fluidity = 0f;
    [SerializeField] float increaseRate = 0f;

    //Fall to death minimum
    [SerializeField] float fallToDeath = 0f;

    //booleans
    bool isAlive = true;
    bool transitioning = false;// to stop player from interacting with others while on timer
    // Start is called before the first frame update
    void Start()
    {
        objectPosition = gameObject.GetComponent<Transform>();
    }

    void OnCollisionEnter(Collision other) 
    {
        string objectTag = other.gameObject.tag;
        //todo add take damage when collide with heaters
        //todo add blue switch interaction
        //todo add red switch interaction
        //todo add lightbulb interaction
        //todo kill when got hit by piston
        if(!transitioning)
        {
            switch(objectTag)
            {
                case "Dispenser":
                    Debug.Log("This is Dispenser");
                    break;

                case "Heater":
                    Debug.Log("This is Heater");
                    break;
                
                case "B_Switch":
                    Debug.Log("This is Blue Switch");
                    break;

                case "R_Switch":
                    Debug.Log("This is Red Switch");
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        FallToDeath();
        FluidControl();
    }



    //Fluid Control
    private void FluidControl()
    {
        if (fluidity <= maxFluidity)
        {
            fluidity += increaseRate * Time.deltaTime;
        }

        if (fluidity >= maxFluidity)
        {
            DeclareDeath();
        }
    }

    //todo add DeclareWin function



    private void FallToDeath()
    {
        if (objectPosition.position.y <= fallToDeath)
        {
            DeclareDeath();
        }
    }



    //Progress conditions
    private void DeclareDeath()
    {
        if (isAlive)
        {
            isAlive = false;
            Invoke("ReloadScene", deathTimer);
            Debug.Log("You Died");
        }
    }

    private void DeclareWin()
    {
        Invoke("NextScene", winTimer);
        Debug.Log("ENtering Next Level");
    }
    
    

    //Scene management
    void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene+1);
        if(currentScene == SceneManager.sceneCountInBuildSettings)
        {
            currentScene = 0;
        }
    }


}
