using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    Animator myAnimator;
    [Header("Animator")]
    [SerializeField] float awakeAt = 0f;
    [SerializeField] float animationDelay = 0f;
    [SerializeField] float animationSpeed = 0f;
    [SerializeField] float animationProgress = 0f;
    bool onTransition = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Animate", awakeAt);
    }

    private void Animate()
    {
        if (animationProgress < animationDelay)
        {
            animationProgress += animationSpeed * Time.deltaTime;
        }

        if (animationProgress >= animationDelay)
        {
            onTransition = true;
            Invoke("Wait", 0.01f);
            animationProgress = 0;
        }

        if (onTransition == true)
        {
            myAnimator.SetTrigger("TrCrush");
        }
    }

    void Wait()
    {
        onTransition = false;
    }
}
