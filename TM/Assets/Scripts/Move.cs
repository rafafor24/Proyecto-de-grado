using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Animator animator;
    public bool walking;
    // Start is called before the first frame update
    void Start()
    {
        walking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleWalk() {
        walking = !walking;
        animator.SetBool("Walking", walking);
    }
}
