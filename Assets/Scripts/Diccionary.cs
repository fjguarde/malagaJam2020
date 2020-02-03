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
        dictionaryTextsPatient.Add(0, "Hola doctora, necesito que me ayudes. No sé qué me pasa, estoy muy mal de lo mío.\n"
        + "¿Qué podría hacer para mejorar?.");
        dictionaryTextsPatient.Add(1, "No tengo ningún problema en mi vida personal, pero siento un gran vacío interior,\n como si me faltase algo.");
        dictionaryTextsPatient.Add(2, "No tengo apenas amigos, a veces creo que todo esto es una pesadilla y que pronto despertaré.");
        dictionaryTextsPatient.Add(3, "Creo que todos piensan que soy un fracasado, por más que me esfuerzo por caerles bien, no lo consigo.");
        dictionaryTextsPatient.Add(4, "Doctora, ¿Que puedo hacer para salir de este agujero emocional en el que me encuentro?.");
        dictionaryTextsPatient.Add(5, "Pero Doctora....¿Está segura de que esa es la mejor solución?. No estoy convencido del todo.");

        // Textos para las repuestas del doctor
        dictionaryTextsDoctor.Add(0, "Cuéntame más acerca de tu problema.");
        dictionaryTextsDoctor.Add(1, "¿Tienes planes para este fin de semana?.");
        dictionaryTextsDoctor.Add(2, "Yo no te veo tan mal...todos tenemos problemas.");

        dictionaryTextsDoctor.Add(3, "Tienes que salir más a menudo con tus amigos.");
        dictionaryTextsDoctor.Add(4, "Pedir ayuda ya es un gran paso para mejorar.");
        dictionaryTextsDoctor.Add(5, "La vida es una oportunidad y deberías tratar de aprovechar cada segundo.");

        dictionaryTextsDoctor.Add(6, "Es más fácil pensar que no es real.");
        dictionaryTextsDoctor.Add(7, "Es normal sentirse así. Son sentimientos muy comunes.");
        dictionaryTextsDoctor.Add(8, "Observa tu entorno, ¿te parece lo suficientemente real?.");

        dictionaryTextsDoctor.Add(9, "Tal vez no te esfuerzas lo suficiente.");
        dictionaryTextsDoctor.Add(10, "No debería de preocuparte la opinión de los demás.");
        dictionaryTextsDoctor.Add(11, "La gente es malvada por naturaleza.");

        dictionaryTextsDoctor.Add(12, "Encuentra algo que te apasione.");
        dictionaryTextsDoctor.Add(13, "¡Tómate unas vacaciones!.");
        dictionaryTextsDoctor.Add(14, "Debemos aumentar su medicación.");

        dictionaryTextsDoctor.Add(15, "Por supuesto. Mi secretario le cobrará a la salida. Gracias por venir.");
        dictionaryTextsDoctor.Add(16, "Soy una prestigiosa psicóloga, se lo que me hago.");
        dictionaryTextsDoctor.Add(17, "Estoy completamente segura. Estaré aquí para ayudarte cuando lo necesites.");
    }

    public enum TextKey
    {
        TxtPatient,
        TxtDoctor

    }
 }
