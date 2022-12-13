using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _camera1;
    public float running_speed = 6.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "map")
        {
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        _camera1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _camera1.SetActive(false);
            Time.timeScale = 0.5f;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            _camera1.SetActive(true);
            Time.timeScale = 1;
        }
        transform.Translate(1 * Time.deltaTime * running_speed, 0, 0);
    }
}
