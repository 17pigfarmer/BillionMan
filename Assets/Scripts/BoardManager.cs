﻿

using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.



	public class BoardManager : MonoBehaviour
	{
        private enum Towards { kLEFT,kRIGHT,kUP,kDOWN};
        private enum Corners { kLU,kRU,kLD,kRD};
		public int columns = 11; 										//Number of columns in our game board.
		public int rows = 11;                                           //Number of rows in our game board.

        public GameObject[] roads;
        public GameObject[] corners;
        public GameObject[] houses;
        public GameObject snowfloor;

		private Transform boardHolder;									//A variable to store a reference to the transform of our Board object.

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
                Instantiate(toInstantiate4, GetVector3(new Vector3(columns-2, rows-2, 0)), Quaternion.identity) as GameObject;

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
                    toInstantiate.transform.localScale=new Vector3(scaleTime, scaleTime, scaleTime);
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
                        Instantiate(toInstantiate, adjustedVec , Quaternion.identity) as GameObject;

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


        //Sets up the outer walls and floor (background) of the game board.
        void BoardSetup ()
        { 
			boardHolder = new GameObject ("Board").transform;

            SetRoads(boardHolder);

            SetFloors(boardHolder);

            SetCorners(boardHolder);

            SetHouses(boardHolder);
        }



        Vector3 GetVector3(Vector3 old)
        {
            Vector3 newvec = new Vector3(old.x + old.y, (old.y - old.x) * 0.71f, old.y-old.x);

            return newvec;
        }
		
		
		//SetupScene initializes our level and calls the previous functions to lay out the game board
		public void SetupScene ()
		{
			//Creates the outer walls and floor.
			BoardSetup ();
		
		}
	}
