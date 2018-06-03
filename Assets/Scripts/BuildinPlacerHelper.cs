using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildinPlacerHelper : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponentInChildren<Building>())
        {
            print("test");
        }
    }
}
