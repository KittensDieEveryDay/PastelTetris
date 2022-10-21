using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOveScreen : MonoBehaviour
{
    public Text finalScore;
    public GameObject finalScoreGO;
    // Start is called before the first frame update
    void Start()
    {
        finalScore.text = PlayerPrefs.GetString("Your score: ");
        //finalScore.text = "Your score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
