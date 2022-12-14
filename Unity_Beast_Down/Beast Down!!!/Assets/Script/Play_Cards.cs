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

        //if (Input.GetMouseButton(0))
        //{
        //    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    //myPos = new Vector2(mousePos.x, mousePos.y);
        //}
        //else
        //{

        //}
    }
}
