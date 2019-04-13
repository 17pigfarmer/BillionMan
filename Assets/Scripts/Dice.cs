using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice: MonoBehaviour
{
    private int stepNum = 1; //每次走的步数
    private Text stepNumText;
    private Button _diceButton;

    void Awake()
    {
        
        

    }


    public void Init(string n,string s)
    {

        _diceButton = GameObject.Find(n).GetComponent<Button>();
        _diceButton.onClick.AddListener(delegate () { OnClick(s); } );
    }

    public void OnClick(string s)
    {
        
        randomStep();
        stepNumText = GameObject.Find(s).GetComponent<Text>();
        stepNumText.text = ""+stepNum;
    }

    public void randomStep()
    {
        stepNum = Random.Range(1, 7); //获取随机数1到6
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
