using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Diccionary;

public class Player_Control : MonoBehaviour
{
    private Text txt_Dialog;
    private Button[] txts_Options;

    // Start is called before the first frame update
    void Start()
    {
        txt_Dialog = transform.Find("Txt_Dialog").GetComponent<Text>();
        txts_Options = transform.Find("GO_Options").GetComponents<Button>();

        OptionsAddListener();

        ShowTextPatient();
        ShowTextDoctor();

    }

    private void OptionsAddListener()
    {
        foreach (var option in txts_Options)
        {
            option.onClick.AddListener(Btn_Evento_prueba);

        }
    }

    private void Btn_Evento_prueba()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void ShowTextPatient()
    {
        txt_Dialog.text = Diccionary.ObtenerTextoPatient(0);

    }

    private void ShowTextDoctor()
    {
        txt_Options.text = Diccionary.ObtenerTextoDoctor(0);



    }
}
