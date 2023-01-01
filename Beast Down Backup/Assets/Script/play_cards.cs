using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

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
    public static bool[] availableCaedInDeck = new bool[] { true, true, true, true, true }; //ตำแหน่งที่วางการ์ดว่างหรือไม่
    public Text deckSizeText; //ข้อความจำนวนการที่เหลือใน deck

    public static int hitcard = 0; //จับการใบที่เท่าไร(มีการเปลี่ยนแปลงทุกครั้งที่เลือกการ์ด)
    public static List<int> positionchoosecard; //ตำแหน่งที่จับการ์ดล่าสุด

    public GameObject[] number;//สัญฃลักษณ์ตัวเลข 1-5
    public Transform[] numSlotsAll; //ตำแหน่งที่วาง สัญฃลักษณ์ตัวเลข

    public static int[] sequenceCardOneToFive = new int[] { 0, 0, 0, 0, 0 }; //ลำดับตามตัวเลข
    public static int numCard; //การ์ดใบที่เท่าไร

    public static bool willruncard = false;

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
                    play[i] = randCard;
                    deck.Remove(randCard);

                    return;
                }
            }
        }
    }
    public void moveCard(int num, GameObject card, Transform go)
    {
        card.transform.position = go.position;
    }
    public void runCard()//ย้ายการ์ด
    {
        for (int i = 0; i < 5; i++)
        {
            if (sequenceCardOneToFive[i] == 1)
            {
                moveCard(numCard, play[i], cardPlay);
                wait_to_discard(2,i);

                availableCaedInDeck[i] = true;

            }
        }
    }
    public async void wait_to_discard(int s,int i)
    {
        await Task.Delay((int)(s * 1000));

        play[i].transform.position = cardPlayed.position;
        playedDeck.Add(play[i]);
        play[i] = null;

        await Task.Delay((int)(10));
        DrawCard();
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
            if (sequenceCardOneToFive[j] != 0 )//แสดงว่าเลือกอยู่
            {
                number[sequenceCardOneToFive[j] - 1].transform.position = numSlotsAll[j].position;
            }
            else if (sequenceCardOneToFive[j] == 0)//เอาเลขที่ไม่ได้เลือกออกนอกเจอ
            {
                number[j].transform.position = numSlotsAll[5].position;//นอกจอ
            }
        }
    }
    public void showsequenceCardOneToFive()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("sequenceCardOneToFive[" + i + "] : " + sequenceCardOneToFive[i]);
        }        
        Debug.Log("hitcard : " + hitcard);
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("availableCaedInDeck [" + i + "]: " + availableCaedInDeck[i]);
        }
    }
    public void ShuffleCaed()
    {
        for (int i = 0; i < playedDeck.Count; i++)
        {
            deck.Add(playedDeck[i]);
        }
        playedDeck.Clear();
    }

    void Start()
    {
        positionchoosecard = new List<int>() { 0, 0, 0, 0, 0 };
        hitcard = 0;
        sequenceCardOneToFive = new int[] { 0, 0, 0, 0, 0 };
        availableCaedInDeck = new bool[] { true, true, true, true, true };

        for (int i = 0; i < 5; i++)
        {
            play.Add(null);
            DrawCard();
        }
    }
    void Update()
    {
        //showsequenceCardOneToFive();
        updateNum(); //ดับเดดตัวเลขที่แสดง
        deckSizeText.text = deck.Count.ToString(); // อับเดดจำนวนการ์ดที่เหลือใน deck

        if (deck.Count <= 0)
        {
            ShuffleCaed();
        }

        if (willruncard)
        {
            willruncard = false;

            runCard();
            changeNum(); //เปลี่ยนลำดับเลือก

            MainCharacterScript.getzoom = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            showsequenceCardOneToFive();
        }
        return;
    }
}
