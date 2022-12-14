using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject select_gamemode;
    public GameObject Credit;
    public void Play_Buttom()
    {
        select_gamemode.SetActive(true);
    }
    public void Play_Story_Buttom()
    {
        SceneManager.LoadScene("Play_Story");
    }
    //public void Play_Endless_Buttom()
    //{
    //    SceneManager.LoadScene("Play_Endless");
    //}
    public void How_to_Buttom()
    {
        SceneManager.LoadScene("How_to_Play");
    }
    public void Credit_Buttom()
    {
        Credit.SetActive(true);
    }
    public void MenuGame()
    {
        select_gamemode.SetActive(false);
        Credit.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); // จะทำงานได้ต่อเมื่อเป็น .exe
    }
    void Start()
    {
        select_gamemode.SetActive(false);
        Credit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
