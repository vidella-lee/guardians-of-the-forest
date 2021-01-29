using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool cameraExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!cameraExists)
        {
            //checks to see if the game object already exists
            cameraExists = true;
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
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
