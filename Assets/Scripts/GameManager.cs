using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    
    private BoardManager boardScript;
    private Button _StartButton;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        boardScript = GetComponent<BoardManager>();
        



         _StartButton = GameObject.Find("StartButton").GetComponent<Button>();
        _StartButton.onClick.AddListener(InitGame);


        //InitGame();
    }




    //Initializes the game for each level.
    public void InitGame()
    {
        Destroy(GameObject.Find("StartConvas"));
        Destroy(GameObject.Find("EventSystem"));
        boardScript.SetupScene();
        

    }

    public void GameOver()
    {
        enabled = false;
    }


    //Hides black image used between levels

    void Update()
    {

    }

}


