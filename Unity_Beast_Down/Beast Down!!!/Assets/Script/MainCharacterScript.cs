using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _camera1;
    public GameObject canva;
    public float running_speed = 6.0f;
    public static float _SpeedTime = 1.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "map")
        {
            Destroy(other.gameObject);
        }
    }
    public void zoomin()
    {
        _camera1.SetActive(false);
        _SpeedTime = 0.5f;
        canva.transform.position = new Vector3 (0, 50, 0);
    }
    public void zoomout()
    {
        _camera1.SetActive(true);
        _SpeedTime = 1;
        canva.transform.position = new Vector3(0, 0, 0);
    }
    void Start()
    {
        _SpeedTime = 1.0f;
        _camera1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = _SpeedTime;
        if (Input.GetKeyDown(KeyCode.W))
        {
            zoomin();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            zoomout();
        }
        //transform.Translate(1 * Time.deltaTime * running_speed, 0, 0);//เดินไปข้างหน้าตลอดเวลา
    }
}
