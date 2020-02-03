using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    private Button btn_StartGame;
    private Level_Manager level_Manager;
    private Image img_Introduction, img_Main;
    private bool onePressed = false;
    // Start is called before the first frame update
    void Start()
    {
        level_Manager = GameObject.Find("Level_Manager").GetComponent<Level_Manager>();
        btn_StartGame = transform.Find("Btn_StartGame").GetComponent<Button>();
        img_Introduction = transform.Find("Img_Introduction").GetComponent<Image>();
        img_Main = transform.Find("Img_Main").GetComponent<Image>();
        btn_StartGame.onClick.AddListener(Btn_Function_StartGame);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && !level_Manager.GameFiniched)
        {
            ShowIntroduction();
            onePressed = true;
        }

    }

    private void ShowIntroduction()
    {
        img_Main.enabled = false;
        img_Introduction.enabled = true;
        if (onePressed)
        {
            level_Manager.CargarNivel(1);
        }
    }

    private void Btn_Function_StartGame()
    {
        Debug.Log("ddddddd");
        level_Manager.CargarNivel(1);
    }

}
