using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    private int escenaActiva;
    private int actualQuestionCount = 0, actualPoints = 0;
    private bool gameFiniched = false, gameEnding = false;
    public Canvas canvasGameOver, canvasWin, canvasControl;
    private Animator animator_Patient;
    private Animation patient_arm_1;
    private AudioSource audioSource;

    // La posición del array corresponde con la posición de la pregunta, el valor indica cuál es la respuesta correcta
    private int[] respuestasCorrectas = { 0, 2, 1, 1, 0, 2 };

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

    public bool GameEnding
    {
        get { return gameEnding; }
    }

    // Start is called before the first frame update
    void Start()
    {
        escenaActiva = SceneManager.GetActiveScene().buildIndex;
        if (escenaActiva != 0)
        {
            canvasGameOver.GetComponent<Canvas>().enabled = false;
            canvasWin.GetComponent<Canvas>().enabled = false;
            animator_Patient = GameObject.Find("GO_Patient").GetComponent<Animator>();
            audioSource = transform.GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValidateAnswer(int buttonSelected)
    {
        animator_Patient.SetBool("middlePoints", false);

        //print("actualQuestionCount  " + actualQuestionCount);
        if (actualQuestionCount < CorrectAnswers.Length -1)
        {
            if (CorrectAnswers[actualQuestionCount] == buttonSelected)
            {
                actualPoints += 1;
            }
            actualQuestionCount++;
            // Si Hemos contestado a la mitad de las preguntas
            if (actualQuestionCount == (respuestasCorrectas.Length - 1) / 2)
            {
                ShowAnimationArms_1();
            }
        }
        else
        {
            print("JUEGO TERMINADO");
            gameEnding = true;
            CalculateWinOrLose(actualPoints);
        }
    }

    private void ShowAnimationArms_1()
    {
        animator_Patient.SetBool("middlePoints", true);
    }

    private void CalculateWinOrLose(int actualPoints)
    {
        print("actualPoints ---> "+ actualPoints);
        print("(respuestasCorrectas.Length - 1 / 2) ---> " + ((respuestasCorrectas.Length - 1) / 2));
        if (actualPoints > ((respuestasCorrectas.Length - 1) / 2))
        {
            gameEnding = true;
            print("HAS GANADO");
            StartCoroutine(ShowWinCanvas());
        }
        else
        {
            gameEnding = true;
            print("HAS PERDIDO");
            StartCoroutine(ShowGameOver());
        }
    }

    private IEnumerator ShowWinCanvas()
    {
        canvasControl.GetComponent<Canvas>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameFiniched = true;
        canvasWin.GetComponent<Canvas>().enabled = true;
        StartCoroutine(RestartGame());

    }

    private IEnumerator ShowGameOver()
    {
       // animator_Patient.enabled = true;
        //animator_Patient.Rebind();
        canvasControl.GetComponent<Canvas>().enabled = false;
        audioSource.Stop();
        animator_Patient.SetBool("gameOver", true);
        yield return new WaitForSeconds(3f);
        gameFiniched = true;
        canvasGameOver.GetComponent<Canvas>().enabled = true;
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);
        ReiniciarNivel();

    }

    // Reinicia el juego para volver a empezar
    public void ReiniciarNivel()
    {
        CargarNivel(0);
    }

    public void CargarNivel(int numNivel)
    {
        SceneManager.LoadScene(numNivel, LoadSceneMode.Single);
    }


}
