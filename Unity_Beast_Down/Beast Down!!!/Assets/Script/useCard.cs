using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class useCard : MonoBehaviour
{
    public static bool hasplay;
    public static bool onHand;
    public static Transform cardplay;
    public static Transform cardplayed;
    public static Transform dackCard;
    public static int positionchoosecard;

    public void UseCard()
    {
        transform.position = cardplayed.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        positionchoosecard = 0;
    }
    void Update()
    {
    
    }
}
