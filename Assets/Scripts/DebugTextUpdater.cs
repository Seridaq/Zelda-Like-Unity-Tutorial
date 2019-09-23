using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTextUpdater : MonoBehaviour
{
    public PlayerMovement player;

    private Text textStuff;
    // Start is called before the first frame update
    void Start()
    {
        textStuff = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textStuff.text = "Debug Info\n" +
            "Player Speed: " + player.speed; 
    }
}
