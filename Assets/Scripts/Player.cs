using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject 
{
    private Animator animator;
    public int pos; 

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
        pos = 0;
    }

    public IEnumerator playerMove(int x, Vector3[] Positions)
    {
        for(int i = 0; i < x; i++)
        {
            if (pos + 1 != 32)
            {
                Vector3 vec = Positions[pos + 1] - Positions[pos];
                Move(vec.x, vec.y);
                yield return new WaitForSeconds(0.5f);
                pos++;
            }
            else
            {
                Vector3 vec = Positions[0] - Positions[pos];
                Move(vec.x, vec.y);
                yield return new WaitForSeconds(0.5f);
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
