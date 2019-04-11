using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


	using System.Collections.Generic;		//Allows us to use Lists. 
	using UnityEngine.UI;                   //Allows us to use UI.

    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;


        private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.




        //Awake is always called before any Start functions
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else if (instance != this){
                Destroy(gameObject);
            }

            boardScript = GetComponent<BoardManager>();

            InitGame();
        }




        //Initializes the game for each level.
        void InitGame()
        {

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


