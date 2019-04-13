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

    void playerMove(int x)
    {

    }
 

    Vector3 GetVector3(Vector3 old)
    {
        Vector3 newvec = new Vector3(old.x + old.y, (old.y - old.x) * 0.71f, old.y - old.x);

        return newvec;
    }
}
