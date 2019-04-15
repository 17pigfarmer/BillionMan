using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject 
{
    private Animator animator;
    public int pos;
    private Rigidbody2D rb2D;

    private float inverseMoveTime;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
        rb2D = GetComponent<Rigidbody2D>();
        pos = 0;
        inverseMoveTime = 1f / moveTime;
        
    }

    public IEnumerator playerMove(int x, Vector3[] Positions,int turn)
    {
        for(int i = 0; i < x; i++)
        {
            if (pos + 1 != 32)
            {
                Vector3 end = Positions[pos + 1];
 
                float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
                
                while (sqrRemainingDistance > Mathf.Epsilon)
                {
                    
                    
                    Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
                    rb2D.MovePosition(newPosition);//注意z轴，否则会死循环
 
                    sqrRemainingDistance = (transform.position - end).sqrMagnitude;
                    yield return null;
                }
                
                pos++;
                
            }
            else
            {
                Vector3 end = Positions[0];
                float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

                while (sqrRemainingDistance > Mathf.Epsilon)
                {
                    Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
                    rb2D.MovePosition(newPosition);
                    
                    sqrRemainingDistance = (transform.position - end).sqrMagnitude;
                    yield return null;
                }

                pos = 0;
            }
        }
        
        yield break;

    }
 

    Vector3 GetVector3(Vector3 old)
    {
        Vector3 newvec = new Vector3(old.x + old.y, (old.y - old.x) * 0.71f, old.y - old.x);

        return newvec;
    }
}
