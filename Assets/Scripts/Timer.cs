using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float remainingTime;
    // Update is called once per frame
    void Update()
    {
        remainingTime = GameManager.instance.getPlayerTime();
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            //Time.timeScale = 0;
            timerText.color = Color.red;
        }
    }
}
