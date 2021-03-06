﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Diccionary;

public class Player_Control : MonoBehaviour
{
    private Text txt_Dialog;
    private Button[] butons_Options;
    private int buttonSelected = 0;
    private Level_Manager levelManager;
    private bool textLoaded;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level_Manager").GetComponent<Level_Manager>();
        txt_Dialog = transform.Find("Txt_Dialog").GetComponent<Text>();
        butons_Options = transform.Find("GO_Options").GetComponentsInChildren<Button>();

        LoadNextCuestion(levelManager.ActualQuestionCount);

    }

    void Update()
    {
        if (!levelManager.GameFiniched)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CalculateButtonPosition(buttonSelected + 1);
                ChangeButtonSelected(buttonSelected);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CalculateButtonPosition(buttonSelected - 1);
                ChangeButtonSelected(buttonSelected);

            }
            if (Input.GetKeyDown(KeyCode.Space) && !levelManager.GameEnding && textLoaded)
            {
                levelManager.ValidateAnswer(buttonSelected);
                LoadNextCuestion(levelManager.ActualQuestionCount);
            }
        } 
        else
        {
            // Reiniciar juego, mostrar puntos, etc
        }

    }

    private void LoadNextCuestion(int actualQuestionCount)
    {
       StartCoroutine( ShowTextPatient(actualQuestionCount) );
       StartCoroutine( ShowTextDoctor(actualQuestionCount) );

    }

    // Cambia el color de los botones para indicar cual está seleccionado y cuales no
    private void ChangeButtonSelected(int buttonSelected)
    {
        var tempColor = butons_Options[0].GetComponent<Image>().color;
        tempColor.a = 0;
        butons_Options[0].transform.Find("Image").GetComponent<Image>().color = tempColor;
        butons_Options[1].transform.Find("Image").GetComponent<Image>().color = tempColor;
        butons_Options[2].transform.Find("Image").GetComponent<Image>().color = tempColor;
        tempColor.a = 1f;
        butons_Options[buttonSelected].transform.Find("Image").GetComponent<Image>().color = tempColor;
    }

    // Calcula la posición, cuando está en el mínimo y se presiona abajo pasa al máximo y viceversa
    private void CalculateButtonPosition(int newPosition)
    {
        buttonSelected = newPosition;
        if (newPosition < 0)
        {
            buttonSelected = 2;
        } 
        else if (newPosition > 2)
        {
            buttonSelected = 0;
        }
    }

    // Diálogo del paciente 
    private IEnumerator ShowTextPatient(int actualQuestion)
    {
        textLoaded = false;
        string text_DialogToShow = Diccionary.ObtenerTextoPatient(actualQuestion); ;
        txt_Dialog.text = "";
        System.Random rnd = new System.Random();
        float randomFloat = rnd.Next(3, 6) / 10;

        foreach (char c in text_DialogToShow)
        {
            Console.Write(c);
            yield return new WaitForSeconds(randomFloat);
            txt_Dialog.text += c; 
        }
        textLoaded = true;
    }

    // Posibles respuestas del doctor, de momento son 3 posibles respuestas
    private IEnumerator ShowTextDoctor(int actualAnswer)
    {
        int actualAnswerAux = actualAnswer * 3;
        butons_Options[0].GetComponentInChildren<Text>().text = "";
        butons_Options[1].GetComponentInChildren<Text>().text = "";
        butons_Options[2].GetComponentInChildren<Text>().text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 3; i++)
        {
            butons_Options[i].GetComponentInChildren<Text>().text = Diccionary.ObtenerTextoDoctor(actualAnswerAux + i);
        }
    }
}
