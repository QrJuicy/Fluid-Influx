using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StatusHandler : MonoBehaviour
{
    //GetComponent
    Transform objectPosition;

    //Timers
    [SerializeField] float deathTimer = 0f;




    //Fall to death minimum
    [SerializeField] float fallToDeath = 0f;

    //booleans
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        objectPosition = gameObject.GetComponent<Transform>();
    }

    void OnCollisionEnter(Collision other) 
    {
        //todo add take damage when collide with heaters
        //todo add blue switch interaction
        //todo add red switch interaction
        //todo add lightbulb interaction
        //todo kill when got hit by piston
    }

    // Update is called once per frame
    void Update()
    {
        FallToDeath();
        //todo add hp bar system
    }
    //todo add DeclareWin function



    private void FallToDeath()
    {
        if (objectPosition.position.y <= fallToDeath)
        {
            Invoke("ReloadScene", deathTimer);
            DeclareDeath();
        }
    }

    private void DeclareDeath()
    {
        if (isAlive)
        {
            isAlive = false;
            Debug.Log("You Died");
        }
    }

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
