using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;


    float elapsedSeconds = 0;
    bool running = true;

    void Start()
	{
        scoreText.text = "0";
	}
	
	void Update()
	{
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            scoreText.text = ((int)elapsedSeconds).ToString();
        }
	}

    public void StopGameTimer()
    {
        running = false;
    }
}
