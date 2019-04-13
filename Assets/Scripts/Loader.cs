using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
   
    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

       
        
    }

   

}
