using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnGUI()
    {
        //开始按钮  
        if (GUI.Button(new Rect(0, 10, 100, 30), "qingjoin "))
        {
            //System.Console.WriteLine("hello world");
            print("hello qingjoin !");
            // Debug.Log("up.up");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
