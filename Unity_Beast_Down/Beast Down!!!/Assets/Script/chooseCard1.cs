using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseCard1 : MonoBehaviour
{
    // Start is called before the first frame update
    int i = 1;
    public void OnMouseDown()
    {
        useCard.positionchoosecard = i;
        //if (useCard.hasplay == false)
        //{
        //    transform.position = useCard.cardplay.position;
        //    useCard.onHand = true;
        //}
        play_cards.choosecard = true;
        play_cards.hitcard++;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
