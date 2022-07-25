using UnityEngine;
using UnityEngine.UI;


public class leaderboardController : MonoBehaviour
{
    //Variables publicas
    public Text score1, score2, score3, bestScore;
    
    //Variables
    int best, sc1, sc2, sc3;
    ranking rank = new ranking();

    //Metodo que recoje las tres ultimas puntuaciones y la mejor puntuaci�n y las muestra en el menu de leaderboard
    void Start()
    {
        sc1 = PlayerPrefs.GetInt("sc1");
        sc2 = PlayerPrefs.GetInt("sc2");
        sc3 = PlayerPrefs.GetInt("sc3");
        best = PlayerPrefs.GetInt("best");

        score1.text = "1� " + sc1;
        score2.text = "2� " + sc2;
        score3.text = "3� " + sc3;
        bestScore.text = "" + best;

        rank.enviarPuntuacion(best);
    }

}
