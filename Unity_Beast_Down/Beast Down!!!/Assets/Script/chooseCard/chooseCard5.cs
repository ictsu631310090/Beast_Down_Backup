using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseCard5 : MonoBehaviour
{
    // Start is called before the first frame update
    int i = 5;
    public static int sequenceCard;
    public static bool OriLocation = false;
    public void OnMouseDown()
    {
        if (OriLocation == false)
        {
            play_cards.hitcard++;
            OriLocation = true;
            play_cards.sequenceCardOneToFive[play_cards.hitcard - 1] = i;
        }

        play_cards.positionchoosecard = i;
        play_cards.choosecard = true;
        sequenceCard = play_cards.hitcard;

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
        
    }
}
