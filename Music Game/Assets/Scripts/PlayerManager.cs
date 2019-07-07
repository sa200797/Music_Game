using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerManager : MonoBehaviour
{
    public GameObject GameOverPannel;
    public GameObject MusicOver;
    public GameObject Collect;
    public GameObject scoreT;

    public  TextMeshProUGUI scoretext;
    public   int score =00;

    public bool AudioStop = false;

    // Start is called before the first frame update
    void Start()
    {
       MusicOver.SetActive(true);
       GameOverPannel.SetActive(false);
        scoreT.SetActive(true);
        scoretext.text = ((int)score).ToString();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OnTriggerEnter2D(Collider2D other)   
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            GameOverPannel.SetActive(true);
            MusicOver.SetActive(false);
            scoreT.SetActive(false);

            AudioStop = true;
        }

        if (other.gameObject.tag == "Collect")
        {
            Debug.Log("score");
            score = score + 10;
            scoretext.text = ((int)score).ToString();
        }

    }
    }

