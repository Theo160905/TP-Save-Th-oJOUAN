using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float CurrentTime;
    public float PreviousTime;

    public TextMeshProUGUI TimerText;


    private IEnumerator Start()
    {
        CurrentTime += PreviousTime;

        while (true)
        {
            CurrentTime += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void Load()
    {
        TimerText.text = CurrentTime.ToString();
    }
}
