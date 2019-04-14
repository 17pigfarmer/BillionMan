

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.



public class BoardManager : MonoBehaviour
{
    private enum Towards { kLEFT, kRIGHT, kUP, kDOWN };
    private enum Corners { kLU, kRU, kLD, kRD };
    public Vector3[] Positions;
    
    public int columns = 11;                                        
    public int rows = 11;                                           

    public GameObject[] roads;
    public GameObject[] corners;
    public GameObject[] houses;
    public GameObject snowfloor;
    public GameObject convas;
    public GameObject sys;
    public GameObject dice;
    public GameObject button;
    public GameObject text;
    public GameObject[] players;



    private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.

    void SetRoads(Transform parent)
    {
        //LEFT
        for (int y = 2; y < rows - 2; y++)
        {
            int x = 1;
            GameObject toInstantiate = roads[(int)Towards.kLEFT];
            GameObject instance =
                Instantiate(toInstantiate, GetVector3(new Vector3(x, y, 0)), Quaternion.identity) as GameObject;

            instance.transform.SetParent(parent);
        }

        //RIGHT
        for (int y = 2; y < rows - 2; y++)
        {
            int x = columns - 2;
            GameObject toInstantiate = roads[(int)Towards.kRIGHT];
            GameObject instance =
                Instantiate(toInstantiate, GetVector3(new Vector3(x, y, 0)), Quaternion.identity) as GameObject;

            instance.transform.SetParent(parent);
        }

        //UP
        for (int x = 2; x < columns - 2; x++)
        {
            int y = rows - 2;
            GameObject toInstantiate = roads[(int)Towards.kUP];
            GameObject instance =
                Instantiate(toInstantiate, GetVector3(new Vector3(x, y, 0)), Quaternion.identity) as GameObject;

            instance.transform.SetParent(parent);
        }

        //DOWN
        for (int x = 2; x < columns - 2; x++)
        {
            int y = 1;
            GameObject toInstantiate = roads[(int)Towards.kDOWN];
            GameObject instance =
                Instantiate(toInstantiate, GetVector3(new Vector3(x, y, 0)), Quaternion.identity) as GameObject;

            instance.transform.SetParent(parent);
        }
    }

    void SetFloors(Transform parent)
    {
        //LEFT
        for (int y = 0; y < rows; y++)
        {
            int x = 0;
            GameObject toInstantiate = snowfloor;
            GameObject instance =
                Instantiate(toInstantiate, GetVector3(new Vector3(x, y, 0)), Quaternion.identity) as GameObject;

            instance.transform.SetParent(parent);
        }

        //RIGHT
        for (int y = 0; y < rows; y++)
        {
            int x = columns - 1;
            GameObject toInstantiate = snowfloor;
            GameObject instance =
                Instantiate(toInstantiate, GetVector3(new Vector3(x, y, 0)), Quaternion.identity) as GameObject;

            instance.transform.SetParent(parent);
        }

        //UP
        for (int x = 0; x < columns; x++)
        {
            int y = rows - 1;
            GameObject toInstantiate = snowfloor;
            GameObject instance =
                Instantiate(toInstantiate, GetVector3(new Vector3(x, y, 0)), Quaternion.identity) as GameObject;

            instance.transform.SetParent(parent);
        }

        //DOWN
        for (int x = 0; x < columns; x++)
        {
            int y = 0;
            GameObject toInstantiate = snowfloor;
            GameObject instance =
                Instantiate(toInstantiate, GetVector3(new Vector3(x, y, 0)), Quaternion.identity) as GameObject;

            instance.transform.SetParent(parent);
        }
    }


    void SetCorners(Transform parent)
    {
        GameObject toInstantiate1 = corners[(int)Corners.kLD];
        GameObject instance1 =
            Instantiate(toInstantiate1, GetVector3(new Vector3(1, 1, 0)), Quaternion.identity) as GameObject;

        instance1.transform.SetParent(parent);

        GameObject toInstantiate2 = corners[(int)Corners.kLU];
        GameObject instance2 =
            Instantiate(toInstantiate2, GetVector3(new Vector3(1, rows - 2, 0)), Quaternion.identity) as GameObject;

        instance2.transform.SetParent(parent);

        GameObject toInstantiate3 = corners[(int)Corners.kRD];
        GameObject instance3 =
            Instantiate(toInstantiate3, GetVector3(new Vector3(columns - 2, 1, 0)), Quaternion.identity) as GameObject;

        instance3.transform.SetParent(parent);

        GameObject toInstantiate4 = corners[(int)Corners.kRU];
        GameObject instance4 =
            Instantiate(toInstantiate4, GetVector3(new Vector3(columns - 2, rows - 2, 0)), Quaternion.identity) as GameObject;

        instance4.transform.SetParent(parent);
    }

    void SetHouses(Transform parent)
    {
        //LEFT
        float scaleTime = 2.0f;
        for (int y = 2; y < rows - 2; y++)
        {
            if (y != rows / 2)
            {
                int x = 0;
                GameObject toInstantiate = houses[(int)Towards.kLEFT];
                toInstantiate.transform.localScale = new Vector3(scaleTime, scaleTime, scaleTime);
                Vector3 adjustedVec = GetVector3(new Vector3(x, y, 0));
                adjustedVec.x += 0.58f;
                adjustedVec.y += 0.07f;
                GameObject instance =
                    Instantiate(toInstantiate, adjustedVec, Quaternion.identity) as GameObject;

                instance.transform.SetParent(parent);
            }
        }

        //RIGHT
        for (int y = 2; y < rows - 2; y++)
        {
            if (y != rows / 2)
            {
                int x = columns - 1;
                GameObject toInstantiate = houses[(int)Towards.kRIGHT];
                toInstantiate.transform.localScale = new Vector3(scaleTime, scaleTime, scaleTime);
                Vector3 adjustedVec = GetVector3(new Vector3(x, y, 0));
                adjustedVec.x += -0.4f;
                adjustedVec.y += 0.76f;
                GameObject instance =
                    Instantiate(toInstantiate, adjustedVec, Quaternion.identity) as GameObject;

                instance.transform.SetParent(parent);
            }
        }

        //UP
        for (int x = 2; x < columns - 2; x++)
        {
            if (x != columns / 2)
            {
                int y = rows - 1;
                GameObject toInstantiate = houses[(int)Towards.kUP];
                toInstantiate.transform.localScale = new Vector3(scaleTime, scaleTime, scaleTime);
                Vector3 adjustedVec = GetVector3(new Vector3(x, y, 0));
                adjustedVec.x += -0.55f;
                adjustedVec.y += 0.11f;
                GameObject instance =
                    Instantiate(toInstantiate, adjustedVec, Quaternion.identity) as GameObject;

                instance.transform.SetParent(parent);
            }
        }

        //DOWN
        for (int x = 2; x < columns - 2; x++)
        {
            if (x != columns / 2)
            {
                int y = 0;
                GameObject toInstantiate = houses[(int)Towards.kDOWN];
                toInstantiate.transform.localScale = new Vector3(scaleTime, scaleTime, scaleTime);
                Vector3 adjustedVec = GetVector3(new Vector3(x, y, 0));
                adjustedVec.x += 0.42f;
                adjustedVec.y += 0.70f;
                GameObject instance =
                    Instantiate(toInstantiate, adjustedVec, Quaternion.identity) as GameObject;

                instance.transform.SetParent(parent);
            }
        }
    }


    void SetDice()
    {
        GameObject toInstantiate = convas;
        GameObject instance =
            Instantiate(toInstantiate, GetVector3(new Vector3(0, 0, 0)), Quaternion.identity) as GameObject;


        GameObject toInstantiate1 = sys;
        GameObject instance1 =
            Instantiate(toInstantiate1, GetVector3(new Vector3(0, 0, 0)), Quaternion.identity) as GameObject;

        GameObject diceButton = Instantiate(button);
        diceButton.transform.SetParent(instance.transform);
        diceButton.name = "diceButton";
        diceButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(391, -90);
        diceButton.transform.Find("Text").GetComponent<Text>().text = "骰子";

        GameObject stepText = Instantiate(text);
        stepText.transform.SetParent(instance.transform);
        stepText.name = "stepText";
        stepText.GetComponent<RectTransform>().anchoredPosition = new Vector2(394, -141);
        stepText.GetComponent<Text>().text = "step";


        GameObject toInstantiate2 = dice;
        GameObject instance2 =
            Instantiate(toInstantiate2, GetVector3(new Vector3(0, 0, 0)), Quaternion.identity) as GameObject;

        instance2.GetComponent<Dice>().Init("diceButton", "stepText");
        GameManager.instance.dice = instance2;
    }

    void SetPlayers()
    {

        GameObject pl0to = players[0];
        GameObject pl0 = Instantiate(pl0to, Positions[0] + GetVector3(new Vector3(-0.13f, 0.13f, 0)), Quaternion.identity) as GameObject;
        GameManager.instance.players[0] = pl0;

        GameObject pl1to = players[1];
        GameObject pl1 = Instantiate(pl1to, Positions[0] + GetVector3(new Vector3(0.13f, -0.13f, 0)), Quaternion.identity) as GameObject;
        GameManager.instance.players[1] = pl1;

        GameObject pl2to = players[2];
        GameObject pl2 = Instantiate(pl2to, Positions[0] + GetVector3(new Vector3(-0.13f, -0.13f, 0)), Quaternion.identity) as GameObject;
        GameManager.instance.players[2] = pl2;

        GameObject pl3to = players[3];
        GameObject pl3 = Instantiate(pl3to, Positions[0] + GetVector3(new Vector3(0.13f, 0.13f, 0)), Quaternion.identity) as GameObject;
        GameManager.instance.players[3] = pl3;

    }


    void SetPositions()
    {
        Vector3[] pos = {
            new Vector3(2, 0.3f, 0),new Vector3(3, 1, 0),new Vector3(4, 1.7f, 0),new Vector3(5, 2.4f, 0),
        new Vector3(6, 3.1f, 0),new Vector3(7, 3.8f, 0),new Vector3(8, 4.5f, 0),new Vector3(9, 5.2f, 0),
        new Vector3(10, 5.9f, 0),new Vector3(11, 5.2f, 0),new Vector3(12, 4.5f, 0),new Vector3(13, 3.8f, 0),
        new Vector3(14, 3.1f, 0),new Vector3(15, 2.4f, 0),new Vector3(16, 1.7f, 0),new Vector3(17, 1f, 0),
        new Vector3(18, 0.3f, 0),new Vector3(17, -0.4f, 0),new Vector3(16, -1.1f, 0),new Vector3(15, -1.8f, 0),
        new Vector3(14, -2.5f, 0),new Vector3(13, -3.2f, 0),new Vector3(12, -3.9f, 0),new Vector3(11, -4.6f, 0),
        new Vector3(10, -5.3f, 0),new Vector3(9, -4.6f, 0),new Vector3(8, -3.9f, 0),new Vector3(7, -3.2f, 0),
        new Vector3(6, -2.5f, 0),new Vector3(5, -1.8f, 0),new Vector3(4, -1.1f, 0),new Vector3(3, -0.4f, 0),
    };
        Positions = pos;
    }


    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        SetPositions();

        SetRoads(boardHolder);

        SetFloors(boardHolder);

        SetCorners(boardHolder);

        SetHouses(boardHolder);

        SetDice();

        SetPlayers();
    }



    Vector3 GetVector3(Vector3 old)
    {
        Vector3 newvec = new Vector3(old.x + old.y, (old.y - old.x) * 0.71f, old.y - old.x);

        return newvec;
    }


    //SetupScene initializes our level and calls the previous functions to lay out the game board
    public void SetupScene()
    {
        //Creates the outer walls and floor.
        BoardSetup();

    }
}

