using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseCard5 : MonoBehaviour
{
    // Start is called before the first frame update
    int i = 5;
    bool open = true;
    public GameObject choosecard;
    
    public static bool OriLocation = false;
    public void OnMouseDown()
    {
        if (OriLocation == false)
        {
            play_cards.hitcard++;
            OriLocation = true;
            play_cards.sequenceCardOneToFive[i - 1] = play_cards.hitcard;
        }

        play_cards.positionchoosecard = i;

        if (OriLocation == true)
        {
            chooseCard1.OriLocation = false;
            chooseCard2.OriLocation = false;
            chooseCard3.OriLocation = false;
            chooseCard4.OriLocation = false;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (play_cards.availableCaedInDeck[i - 1] == true && open == true)
        {
            choosecard.transform.Rotate(0, 180, 0);
            open = false;
        }
        else if (play_cards.availableCaedInDeck[i - 1] == false && open == false)
        {
            choosecard.transform.Rotate(0, 180, 0);
            open = true;
        }
    }
}
