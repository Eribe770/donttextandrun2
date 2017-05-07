using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10.0f;

    void Update()
    {
        timeRemaining -= Time.deltaTime;
    }

    void OnGUI()
    {
        if (timeRemaining > 0)
        {
            GUI.Label(new Rect(0, 0, 200, 100),
                        "Time Remaining : " + (int)timeRemaining);
        }
        else
        {
            GUI.Label(new Rect(00, 00, 200, 100), "Time's Up");

            SceneManager.LoadScene("Scene1");
        }
    }
}