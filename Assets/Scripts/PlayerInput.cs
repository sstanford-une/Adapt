using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    MasterScript masterScript;

    private void Start()
    {
        masterScript = FindObjectOfType<MasterScript>();
    }

    public void Choose1()
    {
        masterScript.PlayerChoice(1);
        Debug.Log("Player Chose 1");
    }
    public void Choose2()
    {
        masterScript.PlayerChoice(2);
        Debug.Log("Player Chose 2");
    }
    public void Choose3()
    {
        masterScript.PlayerChoice(3);
        Debug.Log("Player Chose 3");
    }

    public void BeginStory()
    {
        masterScript.ProgressStory();
        Debug.Log("BeginStory Clicked");
    }
}
