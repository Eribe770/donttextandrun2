using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour {

    public int screenChangeTime = 2;
    public Texture2D[] frames;
    private Renderer mat;
    private int currentScreen;
    private float counter;

    // Use this for initialization
    void Start () {
        counter = 0;
        mat = GetComponent<Renderer>();
        mat.material.mainTexture = frames[0];
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
		if (counter > screenChangeTime)
        {
            counter = 0;
            currentScreen++;

            currentScreen = currentScreen % frames.Length;

            mat.material.mainTexture = frames[currentScreen];

        }
	}

    void UpdateChatScreen()
    {
        if (currentScreen < frames.Length)
            currentScreen++;

        mat.material.mainTexture = frames[currentScreen];
    }

}
