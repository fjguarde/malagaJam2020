using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_Menu : MonoBehaviour
{
    private Button btn_reset;
    private Level_Manager level_Manager;
    // Start is called before the first frame update
    void Start()
    {
        level_Manager = GameObject.Find("Level_Manager").GetComponent<Level_Manager>();
        btn_reset = transform.Find("Btn_Reset").GetComponent<Button>();
        btn_reset.onClick.AddListener(Btn_reset);
    }

    private void Btn_reset()
    {
        print("-------------->");
        level_Manager.ReiniciarNivel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
