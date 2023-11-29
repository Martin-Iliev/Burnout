using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnfoldAnimation : MonoBehaviour
{
    public Transform character;
    private Animator animator;
    public float proximityDistance = 5.0f;
    public string animationParameter = "Unfold";
    private bool hasPlayedAnimation = false;
    private bool collected = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPlayedAnimation)
        {
            float distance = Vector3.Distance(transform.position, character.position);

            if (distance <= proximityDistance)
            {
                if(!collected) { 
                    character.GetComponent<ExplorationController>().collectOne();
                }
                collected = true;
                animator.enabled = true;
                
                hasPlayedAnimation = true;
            }
        }
    }
}
