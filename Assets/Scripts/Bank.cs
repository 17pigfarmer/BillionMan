using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    private int[] account; //每位玩家的账户数组
    private int playerNum = 4; //玩家当前数量



    // Start is called before the first frame update
    void Awake()
    {
        account = new int[5]; //为4名玩家每位创建一个账户
        for (int i = 1; i <= 4; i++)
        {
            account[i] = 15000; //给每位玩家账户初始化为15000
        }
        
    }
    public bool IsBankrupt(int playerNum) //判断某位玩家是否破产，playerNum表示玩家标号
    {
        if (account[playerNum] >= 0)
        {
            return false;
        }
        else
        {
            playerNum--;
            return true;
        }
    }
    public bool IsGameFinish() //检测游戏是否结束
    {
        if (playerNum == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void moneyChange(int playerNum, int money)//改变某位玩家账户金额
    {
        account[playerNum] += money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
