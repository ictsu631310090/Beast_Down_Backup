using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_in_game : MonoBehaviour
{
    public GameObject pauseUI;
    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        MainCharacterScript._SpeedTime = 1;
    }
    public void Restar_Buttom()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)//หยุด
        {
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale <= 1)//เดิน
        {
            pauseUI.SetActive(true);
            MainCharacterScript._SpeedTime = 0;
        }
    }
}
