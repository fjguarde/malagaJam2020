using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    private Button btn_StartGame;
    private Level_Manager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level_Manager").GetComponent<Level_Manager>();
        btn_StartGame = transform.Find("Btn_StartGame").GetComponent<Button>();
        btn_StartGame.onClick.AddListener(Btn_Function_StartGame);

    }
    private void Btn_Function_StartGame()
    {
        Debug.Log("ddddddd");
        levelManager.CargarNivel(1);
    }

}
