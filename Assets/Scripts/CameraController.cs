using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool camraExists;

	// Use this for initialization
	void Start () {

        // Her får cameraet besked om at hvis der ikke allerede er at camera så skal gamet ikke ødelægge cameraet, derimod hvis der allerede existere et camera så skal den anden ødelægges
        //----------------------------------------------------------------------------------------------


        if (!camraExists)
        {
            camraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //----------------------------------------------------------------------------------------------


    }

    // Update is called once per frame
    void Update () {

        // Det her for camereaet til at bevæge sig efter spilleren 
        //----------------------------------------------------------------------------------------------


        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        //----------------------------------------------------------------------------------------------

    }
}
