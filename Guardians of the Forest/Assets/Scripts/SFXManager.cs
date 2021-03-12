using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource playerHurt;
    public AudioSource playerAttack;
    private static bool sfxmanExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!sfxmanExists)
        {
            //checks to see if the game object already exists
            sfxmanExists = true;
            //stops Game Object from being destroyed when it changes scenes
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            //if the game object exists already, destroy the new one created when the scene loads
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
