using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataCard : MonoBehaviour
{
    int[] numOfCard = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 
                                21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                                31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };
    public static int attack = 0;
    public static bool fight = false;
    public static bool dodge_or_defense = false;//false = defense , true = dodge
    public static int type = 0;//0 = P ,1 = S ,2 = I

    public void _data_card_1_10(int x)//now 1-8
    {
        if (x == 1)
        {
            attack = 6;
            type = 0;
        }
        else if (x == 2)
        {
            attack = 6;
            type = 1;
        }
        else if (x == 3)
        {
            attack = 6;
            type = 2;
        }
        else if ( x == 4)
        {
            attack = 6;
            type = 0;
        }
        else if (x == 5)
        {
            attack = 6;
            type = 1;
        }
        else if (x == 6)
        {
            attack = 6;
            type = 2;
        }
        else if (x== 7)
        {
            fight = false;
            dodge_or_defense = false;//defense
        }
        else if (x == 8)
        {
            fight = false;
            dodge_or_defense = true;//dodge
        }
        else if (x == 9)
        {
            fight = false;
            dodge_or_defense = true;//dodge
        }
        else if (x == 10)
        {
            fight = false;
            dodge_or_defense = true;//dodge
        }
        fight = true;
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
