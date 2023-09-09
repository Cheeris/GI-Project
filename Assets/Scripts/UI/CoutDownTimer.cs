using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CoutDownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text shownTime;
    private int totalTime = 300;
    private float intervalTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        shownTime.text = string.Format("{0:0}:{1:00}", (int)totalTime / 60, (float)totalTime % 60);
    }

    // Update is called once per frame
    void Update()
    {
        int minute = (int)(totalTime / 60);
        float second = totalTime % 60;
        if (totalTime > 0)
        {
            intervalTime -= Time.deltaTime;
            if (intervalTime <= 0)
            {
                intervalTime += 1;
                totalTime--;
                shownTime.text = string.Format("{0:0}:{1:00}", minute, second);
            }
        }

        if (totalTime <= 0)
        {
            // implement the game over
            Debug.Log("Game Over");
        }
    }
}
