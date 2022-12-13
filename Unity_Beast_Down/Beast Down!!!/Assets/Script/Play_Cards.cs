using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Crads : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 myPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            myPos = new Vector2(mousePos.x, mousePos.y);
        }
        else
        {

        }
    }
}
