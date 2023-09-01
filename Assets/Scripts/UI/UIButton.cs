using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    //GameObject ins;
    //GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        //loadScene();
        //ins = GameObject.Find("Instructions");
        //ins.SetActive(false);

        //menu = GameObject.Find("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    //public void showInstructions()
    //{
    //    ins.SetActive(true);
    //    menu.SetActive(false);
    //}

    //public void backToMenu()
    //{
    //    ins.SetActive(false);
    //    menu.SetActive(true);
    //}
}
