using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class play_cards : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>(); //deck
    GameObject randCard;
    public List<GameObject> playedDeck = new List<GameObject>(); //การ์ดที่เล่นแล้ว
    public Transform[] cardSlots; // ตำแหน่งที่วางการ์ด(ไม่ได้บอกลำดับ)
    public bool[] availableCaedInDeck; //ตำแหน่งที่วางการ์ดว่างหรือไม่
    public Text deckSizeText; //จำนวนการที่เหลือใน deck

    public static bool choosecard = false; //ได้เลือกการ์ดอยู่หรือเปล่า
    public static int hitcard = 0; //จับการใบที่เท่าไร(มีการเปลี่ยนแปลงทุกครั้งที่เลือกการ์ด)
    public static int positionchoosecard; //ตำแหน่งที่จับการ์ด

    public GameObject[] number;//สัญฃลักษณ์ตัวเลข 1-5
    public Transform[] numSlotsAll; //ตำแหน่งที่วาง สัญฃลักษณ์ตัวเลข

    public static int[] sequenceCardOneToFive = new int[] { 0, 0, 0, 0, 0 }; //ลำดับตามตัวเลข
    public static GameObject[] cardOnHead;

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
                    randCard.gameObject.SetActive(true);
                    randCard.transform.position = cardSlots[i].position;
                    availableCaedInDeck[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
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
    }
    void Update()
    {
        if (availableCaedInDeck.Length <= 0)
        {
            ShuffleCaed();
        }

        deckSizeText.text = deck.Count.ToString();

        if (choosecard)
        {
            number[hitcard-1].transform.position = numSlotsAll[positionchoosecard - 1].position;

            //cardOnHead[sequenceCardOneToFive[hitcard - 1]] = randCard.gameObject;

            Debug.Log("hitcard : " + hitcard);
            Debug.Log("sequenceCardOneToFive[1] : " + sequenceCardOneToFive[0]);
            Debug.Log("sequenceCardOneToFive[2] : " + sequenceCardOneToFive[1]);
            Debug.Log("sequenceCardOneToFive[3] : " + sequenceCardOneToFive[2]);
            Debug.Log("sequenceCardOneToFive[4] : " + sequenceCardOneToFive[3]);
            Debug.Log("sequenceCardOneToFive[5] : " + sequenceCardOneToFive[4]);
            choosecard = false;
        }
    }
}
