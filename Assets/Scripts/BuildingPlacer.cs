﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour {

    public static bool buildingPlacerActive = true;

    public GameObject testBuilding;
    public KeyCode place = KeyCode.Mouse0;
    public KeyCode stop = KeyCode.Mouse1;

    private GameObject trackingObject;

	// Use this for initialization
	void Start () {
        if (buildingPlacerActive)
        {
            trackingObject = Instantiate(testBuilding, transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (buildingPlacerActive)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.collider is TerrainCollider)
            {
                trackingObject.transform.position = hit.point;
            }
            if (Input.GetKeyUp(place))
            {
                GameObject newObject = Instantiate(testBuilding, trackingObject.transform.position, trackingObject.transform.rotation);
            }
            else if (Input.GetKeyUp(stop))
            {
                buildingPlacerActive = false;
                Destroy(trackingObject);
            }
        }
	}
}
