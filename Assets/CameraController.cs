using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static bool camCanMove = true;

    public float camMoveSpeedX;
    public float camMoveSpeedY;
    public float borderMovePercentX;
    public float borderMovePercentY;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (camCanMove)
        {
            Vector2 mousPos = Input.mousePosition;
            if (mousPos.x <= Screen.width * borderMovePercentX)
            {
                gameObject.transform.position += new Vector3(0,0,camMoveSpeedX * Time.deltaTime);
            }
        }
	}
}
