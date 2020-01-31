using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    private int escenaActiva;
    // La posición del array corresponde con la posición de la pregunta, el valor indica cuál es la respuesta correcta
    private int[] respuestasCorrectas = { 0, 2, 1, 0, 0 };

// Start is called before the first frame update
    void Start()
    {
        escenaActiva = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReiniciarNivel()
    {
        CargarNivel(escenaActiva);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// Busca nivel actual y lo carga.
        //ResetearValores();
    }

    public void CargarNivel(int numNivel)
    {
        SceneManager.LoadScene(numNivel, LoadSceneMode.Single);
    }


}
