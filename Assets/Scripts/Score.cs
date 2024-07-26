using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject goScreen;

    [SerializeField] private Text scoreText2;
    [SerializeField] private GameObject goScreen2;

    private int score1;
    private int score2;

    public bool isThisP;
    public bool isThisAI;


    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Ball>() != null && this.isThisAI)
        {
            score1++;
            scoreText.text = score1.ToString();
            other.gameObject.GetComponent<Ball>().ResetBall();
        }

        if (other.gameObject.GetComponent<Ball>() != null && this.isThisP)
        {
            score2++;
            scoreText2.text = score2.ToString();
            other.gameObject.GetComponent<Ball>().ResetBall();
        }

        if (score1 >= 7)
        {
            other.gameObject.SetActive(false);
            goScreen.gameObject.SetActive(true);
        }

        if (score2 >= 7)
        {
            other.gameObject.SetActive(false);
            goScreen2.gameObject.SetActive(true);
        }



    }
}
