using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        ResetHud();
    }

    public void ResetHud()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }
}
