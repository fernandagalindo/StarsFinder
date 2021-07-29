using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVar : MonoBehaviour
{
    // --- variáveis de controle ---
    public static string Cena;
    public static bool tutorialOn = true;
    public static int imgAtiva = -1;
    public static List<int> ClassifiedStars = new List<int>();
    public static int totClassificadas = 0;
    public static float fuel = 14f;
    public static int score = 0;
    public static int resources = 50;
    public static float timeRemaining = 180; // tempo em segundos
    public static float volume = 0.05f;

    // --- variáveis fixas de parâmetro e configuração ---
    public static int cngResources = 50;
    public static float cngRemainingTime = 90;
    public static float cngMaxFuel = 14f;
}
