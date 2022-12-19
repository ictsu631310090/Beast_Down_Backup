using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBasic : MonoBehaviour
{
    // Start is called before the first frame update
    public static int HPenemy = 6;
    public static bool enemyHitPlayer = false;
    public static bool outenemy = false;
    public static bool die = false;
    public GameObject enemywilldie;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyHitPlayer = true;
        }
        if (die)
        {
            Destroy(enemywilldie.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            outenemy = true;
        }
        if (die)
        {
            Destroy(enemywilldie.gameObject);
        }
    }
    void Start()
    {
        //enemyHitPlayer = true;
        //outenemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(outenemy);
    }
}
