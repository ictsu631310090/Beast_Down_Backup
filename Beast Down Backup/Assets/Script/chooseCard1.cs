using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseCard1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int i;
    
    public void OnMouseDown()
    {
        if (play_cards.positionchoosecard[i - 1] != i)
        {
            play_cards.hitcard++;
            play_cards.sequenceCardOneToFive[i - 1] = play_cards.hitcard; //ระบุตำแหน่ง

            play_cards.positionchoosecard[i - 1] = i; //ลำดับการกด
            
        }
        else
        {
            //play_cards.hitcard--;
            play_cards.sequenceCardOneToFive[i - 1] = 0;

            play_cards.positionchoosecard[i - 1] = 0;
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
