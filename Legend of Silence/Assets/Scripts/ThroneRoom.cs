using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroneRoom : MonoBehaviour
{

    private Animator animator;
    private float counter;
    private bool pedestalGone;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0.0f;
        pedestalGone = GameObject.Find("Pedestal").GetComponent<Pedestal>().pedestalGone;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pedestalGone = GameObject.Find("Pedestal").GetComponent<Pedestal>().counterCheck;
        if (pedestalGone ==true)
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Throne Room");
            
        }
    }
}
