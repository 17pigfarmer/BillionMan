using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject 
{
    private Animator animator;
    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }


    // Update is called once per frame
    void Update()
    {
        int horizontal = 0;
        int vertical = 0;
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
            vertical = 0;

        if (horizontal != 0 || vertical != 0)
        {
           Move(horizontal, vertical);
        }
    }
    
}
