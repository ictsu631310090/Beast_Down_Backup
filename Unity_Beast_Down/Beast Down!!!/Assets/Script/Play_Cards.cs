using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class play_cards : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> playedDeck = new List<GameObject>();
    public Transform[] cardSlots;
    public bool[] availableCaedInDeck;
    public Text deckSizeText;

    public static bool choosecard = false;
    public static int hitcard = 0;

    public GameObject[] number;
    public Transform[] numSlotsAll;

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            GameObject randCard = deck[Random.Range(0, deck.Count)];
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
            Debug.Log(hitcard);
            Debug.Log(useCard.positionchoosecard);
            number[hitcard - 1].transform.position = numSlotsAll[useCard.positionchoosecard - 1].position;
            
            choosecard = false;
        }
    }
}