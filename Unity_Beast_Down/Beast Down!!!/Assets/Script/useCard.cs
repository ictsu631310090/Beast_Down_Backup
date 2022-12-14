using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class useCard : MonoBehaviour
{
    public bool hasplay;
    public bool onHand;
    public Transform cardplay;
    public Transform cardplayed;
    public Transform dackCard;

    public void OnMouseDown()
    {
        if (hasplay == false)
        {
            transform.position = cardplay.position;
            onHand = true;
        }
        Debug.Log("Hi");
    }
    public void UseCard()
    {
        transform.position = cardplayed.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
    
    }
}
