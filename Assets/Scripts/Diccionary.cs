using System;
using System.Collections.Generic;
using UnityEngine;

public class Diccionary : MonoBehaviour {
    private static Dictionary<int, string> dictionaryTextsPatient = new Dictionary<int, string>();
    private static Dictionary<int, string> dictionaryTextsDoctor = new Dictionary<int, string>();

    private const SystemLanguage defaultLanguaje = SystemLanguage.Spanish;

    public static string ObtenerTextoPatient(int posText)
    {

        if (dictionaryTextsPatient.Count == 0)
        {
            ObtenerIdioma();
        }

        if (dictionaryTextsPatient.ContainsKey(posText))
        {
            return dictionaryTextsPatient[posText];
        }
        else
        {
            Debug.LogWarning(String.Concat("Key (text) not found: ", posText.ToString()));
            return "Error cargando texto";
        }
    }

    public static string ObtenerTextoDoctor(int posText)
    {

        if (dictionaryTextsDoctor.Count == 0)
        {
            ObtenerIdioma();
        }

        if (dictionaryTextsDoctor.ContainsKey(posText))
        {
            return dictionaryTextsDoctor[posText];
        }
        else
        {
            Debug.LogWarning(String.Concat("Key (text) not found: ", posText.ToString()));
            return "Error cargando texto";
        }
    }

    public static void ObtenerIdioma()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.English:
                //FillDictEnglish();
                break;

            case SystemLanguage.Spanish:
                FillDictSpanish();
                break;

            default:
                break;
        }
    }

    private static void FillDictSpanish()
    {
        dictionaryTextsPatient.Add(0, "Doctor estoy fatal......");

        dictionaryTextsDoctor.Add(0, "Hola qué tal te encuentras?");
    }

    public enum TextKey
    {
        TxtPatient,
        TxtDoctor

    }
 }
