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
        // Textos para las preguntas del paciente
        dictionaryTextsPatient.Add(0, "1111 Doctor estoy fatal......");
        dictionaryTextsPatient.Add(1, "2222 Doctor estoy fatal......");
        dictionaryTextsPatient.Add(2, "3333 Doctor estoy fatal......");
        dictionaryTextsPatient.Add(3, "4444 Doctor estoy fatal......");
        dictionaryTextsPatient.Add(4, "5555 Doctor estoy fatal......");
        dictionaryTextsPatient.Add(5, "");

        // Textos para las repuestas del doctor
        dictionaryTextsDoctor.Add(0, "111");
        dictionaryTextsDoctor.Add(1, "222");
        dictionaryTextsDoctor.Add(2, "333");

        dictionaryTextsDoctor.Add(3, "444");
        dictionaryTextsDoctor.Add(4, "555");
        dictionaryTextsDoctor.Add(5, "666");

        dictionaryTextsDoctor.Add(6, "777");
        dictionaryTextsDoctor.Add(7, "888");
        dictionaryTextsDoctor.Add(8, "999");

        dictionaryTextsDoctor.Add(9, "1000");
        dictionaryTextsDoctor.Add(10, "1100");
        dictionaryTextsDoctor.Add(11, "1200");

        dictionaryTextsDoctor.Add(12, "1300");
        dictionaryTextsDoctor.Add(13, "1400");
        dictionaryTextsDoctor.Add(14, "1500");
    }

    public enum TextKey
    {
        TxtPatient,
        TxtDoctor

    }
 }
