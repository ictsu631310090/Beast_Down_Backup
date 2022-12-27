using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBasic : MonoBehaviour
{
    // Start is called before the first frame update
    public int HPenemy = 6;
    public static bool die = false;
    public GameObject enemywilldie;
    public static bool getdamage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && getdamage == false)
        {
            if (play_cards.sequenceCardOneToFive[0] == 0 && play_cards.sequenceCardOneToFive[1] == 0 && play_cards.sequenceCardOneToFive[2] == 0
                && play_cards.sequenceCardOneToFive[3] == 0 && play_cards.sequenceCardOneToFive[4] == 0 )//ไม่ได้เลือกการ์ด
            {
                MainCharacterScript.HP = MainCharacterScript.HP - HPenemy;
                getdamage = true;
            }
            else
            {
                play_cards.willruncard = true;
            }
        }
    }
    void Start()
    {
        //enemyHitPlayer = true;
        //outenemy = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
