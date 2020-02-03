using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{   
    int score;
    TMP_Text text;
    GameObject scoreObject;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Score").GetComponent<TMP_Text>();
        scoreObject = GameObject.Find("Score");
        score = 0;   
        text.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        score += (int)(Time.deltaTime * 100);
        text.text = "Score: " + score;
        //Debug.Log("Score: " + score);
    }
}

