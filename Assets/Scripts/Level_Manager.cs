using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    private int escenaActiva;
    private int actualQuestionCount = 0, actualPoints = 0;
    private bool gameFiniched = false;
    public Canvas canvasGameOver, canvasWin, canvasControl;

    // La posición del array corresponde con la posición de la pregunta, el valor indica cuál es la respuesta correcta
    private int[] respuestasCorrectas = { 0, 1, 2, 0, 1, 2 };

    public int[] CorrectAnswers
    {
      get {return respuestasCorrectas;}  
    }

    public int ActualQuestionCount
    {
        get { return actualQuestionCount; }
    }

    public bool GameFiniched
    {
        get { return gameFiniched; }
    }

    // Start is called before the first frame update
    void Start()
    {
        escenaActiva = SceneManager.GetActiveScene().buildIndex;
        canvasGameOver.GetComponent<Canvas>().enabled = false;
        canvasWin.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValidateAnswer(int buttonSelected)
    {
        //print("actualQuestionCount  " + actualQuestionCount);
        if (actualQuestionCount < CorrectAnswers.Length -1)
        {

            if (CorrectAnswers[actualQuestionCount] == buttonSelected)
            {
                print("RESPUESTA CORRECTA!!!!");
                actualPoints += 1;
            }
            else
            {
                print("LA RESPUESTA NOOOO ES CORRECTA :(");
                //actualPoints -= 1;


            }
            //LoadNextCuestion(actualQuestionCount);
            actualQuestionCount++;
        }
        else
        {
            print("JUEGO TERMINADO");
            gameFiniched = true;
            CalculateWinOrLose(actualPoints);
        }


    }

    private void CalculateWinOrLose(int actualPoints)
    {
        print("actualPoints ---> "+ actualPoints);
        print("(respuestasCorrectas.Length - 1 / 2) ---> " + ((respuestasCorrectas.Length - 1) / 2));
        if (actualPoints > ((respuestasCorrectas.Length - 1) / 2))
        {
            print("HAS GANADO");
            canvasControl.GetComponent<Canvas>().enabled = false;
            canvasWin.GetComponent<Canvas>().enabled = true;

        }
        else
        {
            print("HAS PERDIDO");
            canvasControl.GetComponent<Canvas>().enabled = false;
            canvasGameOver.GetComponent<Canvas>().enabled = true;

        }
    }

    public void ReiniciarNivel()
    {
        CargarNivel(escenaActiva);
    }

    public void CargarNivel(int numNivel)
    {
        SceneManager.LoadScene(numNivel, LoadSceneMode.Single);
    }


}
