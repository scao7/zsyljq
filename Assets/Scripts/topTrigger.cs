using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class topTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    private int score = 0;
    void Start()
    {
        UpdateScoreText();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name=="feather(Clone)"){
            score+=1;
            UpdateScoreText();
        }
        Destroy(collision.gameObject);


    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
