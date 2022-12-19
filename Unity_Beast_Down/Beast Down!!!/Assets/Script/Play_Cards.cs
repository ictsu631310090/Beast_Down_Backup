using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class play_cards : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>(); //deck
    public static GameObject randCard;

    public List<GameObject> play = new List<GameObject>();//กำลังเล่น

    public Transform cardDeck; //ตำแหน่งว่าการ์ดใน deck
    public Transform cardPlay; //ตำแหน่งเล่นการ์ด
    public Transform cardPlayed; //ตำแหน่งการ์ดที่เล่นแล้ว

    public List<GameObject> playedDeck = new List<GameObject>(); //การ์ดที่เล่นแล้ว

    public Transform[] cardSlots; // ตำแหน่งที่วางการ์ด(ไม่ได้บอกลำดับ)
    public static bool[] availableCaedInDeck = new bool[] {true, true, true, true, true }; //ตำแหน่งที่วางการ์ดว่างหรือไม่
    public Text deckSizeText; //จำนวนการที่เหลือใน deck

    public static int hitcard = 0; //จับการใบที่เท่าไร(มีการเปลี่ยนแปลงทุกครั้งที่เลือกการ์ด)
    public static int positionchoosecard; //ตำแหน่งที่จับการ์ด

    public GameObject[] number;//สัญฃลักษณ์ตัวเลข 1-5
    public Transform[] numSlotsAll; //ตำแหน่งที่วาง สัญฃลักษณ์ตัวเลข

    public static int[] sequenceCardOneToFive = new int[] { 0, 0, 0, 0, 0 }; //ลำดับตามตัวเลข
    public int numAvailableCaed; //ลำดับตำแหน่งว่างการ์ด
    public static int numCard; //การ์ดใบที่เท่าไร

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            numCard = Random.Range(0, deck.Count);//จะใช้ j ที่หลัง
            randCard = deck[numCard];
            for (int i = 0; i < availableCaedInDeck.Length; i++)
            {
                if (availableCaedInDeck[i] == true)
                {
                    moveCard(numCard, randCard, cardSlots[i]);
                    availableCaedInDeck[i] = false;
                    deck.Remove(randCard);
                    play.Add(randCard);
                    numAvailableCaed = i;
                    return;
                }
            }
        }
    }
    public void moveCard(int num, GameObject card,Transform go)
    {
        card.transform.position = go.position;
    }
    public void runCard()//ย้ายการ์ด
    {
        enemyBasic.enemyHitPlayer = false;
        for (int i = 0; i < 5; i++)
        {
            if (sequenceCardOneToFive[i] == 1)
            {
                moveCard(numCard, play[i], cardPlay);
            }
        }
        changeNum();//เปลี่ยนลำดับเลือก
        updateNum();//อับเดดลำดับการ์ดที่เลือก
        showsequenceCardOneToFive();
        enemyBasic.enemyHitPlayer = false;
    }
    public void discard()
    {
        for (int i = 0; i < 5; i++)
        {
            if (sequenceCardOneToFive[i] == 1)
            {
                play[i].transform.position = cardPlayed.position;
            }
        }
        playedDeck.Add(play[0]);
        play.Remove(play[0]);
    }
    public void changeNum()
    {
        for (int i = 0; i < 5; i++)
        {
            if (sequenceCardOneToFive[i] != 0)
            {
                sequenceCardOneToFive[i] = sequenceCardOneToFive[i] - 1;
            }
        }
        hitcard--;
    }
    public void updateNum()
    {
        for (int j = 0; j < 5; j++)
        {
            if (sequenceCardOneToFive[j] != 0)//แสดงว่าเลือกอยู่
            {
                number[sequenceCardOneToFive[j] - 1].transform.position = numSlotsAll[j].position;
            }
            else if (sequenceCardOneToFive[j] == 0)//เอาเลขที่ไม่ได้เลือกออกนอกเจอ
            {
                for (int i = 4; i > hitcard - 1; i--)
                {
                    number[i].transform.position = numSlotsAll[5].position;//นอกจอ
                }
            }
        }
    }
    public void showsequenceCardOneToFive()
    {
        Debug.Log("sequenceCardOneToFive[0] : " + sequenceCardOneToFive[0]);
        Debug.Log("sequenceCardOneToFive[1] : " + sequenceCardOneToFive[1]);
        Debug.Log("sequenceCardOneToFive[2] : " + sequenceCardOneToFive[2]);
        Debug.Log("sequenceCardOneToFive[3] : " + sequenceCardOneToFive[3]);
        Debug.Log("sequenceCardOneToFive[4] : " + sequenceCardOneToFive[4]);
        Debug.Log("hitcard : " + hitcard);
    }
    public void ShuffleCaed()
    {
        if (true)
        {

        }
    }

    void Start()
    {
        positionchoosecard = 0;
        hitcard = 0;
        sequenceCardOneToFive = new int[] { 0, 0, 0, 0, 0 };
        availableCaedInDeck = new bool[] { true, true, true, true, true };
    }
    void Update()
    {
        //if (availableCaedInDeck.Length <= 0)
        //{
        //    ShuffleCaed();
        //}
        updateNum();

        deckSizeText.text = deck.Count.ToString(); // อับเดดจำนวนการ์ดที่เหลือใน deck

        if (enemyBasic.enemyHitPlayer)
        {
            if (sequenceCardOneToFive[0] == 0 && sequenceCardOneToFive[1] == 0 && sequenceCardOneToFive[2] == 0
                && sequenceCardOneToFive[3] == 0 && sequenceCardOneToFive[4] == 0)//ไม่ได้เลือกการ์ด
            {
                MainCharacterScript.HP = MainCharacterScript.HP - enemyBasic.HPenemy;
            }
            else
            {
                runCard();

                availableCaedInDeck[numAvailableCaed] = true; //ทำให้ตำแหน่งว่าการ์ดว่าง(ไม่ได้บอกว่าลำดับที่เท่าไร) // ต้องมาแก้ทีหลัง

                //if (enemyBasic.enemyHitPlayer == true)
                //{
                //    discard();
                //}
            }
            enemyBasic.die = true;
            //MainCharacterScript.getzoom = true;//ใช้ได้แล้ว
        }
        if (enemyBasic.outenemy)
        {
            Debug.Log("bye");
            if (sequenceCardOneToFive[1] != 0)
            {
                discard();
            }

            MainCharacterScript.getzoom = false;
            enemyBasic.outenemy = false;
            enemyBasic.die = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            updateNum();
            showsequenceCardOneToFive();
        }
        //Debug.Log(enemyBasic.outenemy);
        //Debug.Log(enemyBasic.enemyHitPlayer);
    }
}
