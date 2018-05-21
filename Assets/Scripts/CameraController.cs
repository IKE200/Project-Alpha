using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static bool camCanMove = true;

    public float camMoveSpeed = 50;
    public float borderMovePercentX;
    public float borderMovePercentY;
    public float sensetivity = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (camCanMove)
        {
            Vector2 mousPos = Input.mousePosition;
            Vector3 camDirection = new Vector3(0, 0, 0);
            if (mousPos.x <= Screen.width * borderMovePercentX)
            {
                camDirection += new Vector3(0, 0, 1);
            }
            else if(mousPos.x >= Screen.width * (1 - borderMovePercentX))
            {
                camDirection += new Vector3(0, 0, -1);
            }

            if (mousPos.y <= Screen.height * borderMovePercentY)
            {
                camDirection += new Vector3(-1, 0, 0);
            }
            else if (mousPos.y >= Screen.height * (1 - borderMovePercentY))
            {
                camDirection += new Vector3(1, 0, 0);
            }
            gameObject.transform.position += camDirection.normalized * camMoveSpeed * Time.deltaTime * sensetivity;
            if (Input.GetAxis("MoveCam") == 1)
            {
                gameObject.transform.position += new Vector3(-Input.GetAxis("Mouse Y") * sensetivity, 0, Input.GetAxis("Mouse X") * sensetivity);
            }
        }
	}
}
