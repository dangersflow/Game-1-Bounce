using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    float lives = 4;
    string screenUi;
    TMP_Text screenText;
    // Start is called before the first frame update
    void Start()
    {
        screenText = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
        screenText.text = "Health: " + lives;
        Debug.Log("SCREENUI: " + screenText.text);
    }

    public void loseLife(){
        lives -= 1;
        setText("Health: " + lives);
    }

    void setText(string text){
        screenText = GameObject.Find("PlayerHealth").GetComponent<TMP_Text>();
        screenText.text = text;
    }

    public float health(){
        return lives;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
