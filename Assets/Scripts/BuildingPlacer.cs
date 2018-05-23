using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlacer : MonoBehaviour {

    public GameObject testBuilding;
    public KeyCode place = KeyCode.Mouse0;
    public KeyCode stop = KeyCode.Mouse1;
    public float maxSteepness = 15;

    private bool buildingPlacerActive = false;
    private GameObject trackingObject;
    private Terrain terrain;

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
            bool hitTerrain = hit.collider is TerrainCollider;
            if (hitTerrain)
            {
                terrain = hit.collider.GetComponent<Terrain>();
                float steepness = terrain.terrainData.GetSteepness((hit.point.x - terrain.transform.position.x) / terrain.terrainData.heightmapWidth, (hit.point.z - terrain.transform.position.z) / terrain.terrainData.heightmapHeight);
                if (steepness <= maxSteepness)
                {
                    trackingObject.transform.position = hit.point;
                }
            }
            if (Input.GetKeyDown(place) && !EventSystem.current.IsPointerOverGameObject())
            {
                GameObject newObject = Instantiate(trackingObject, trackingObject.transform.position, trackingObject.transform.rotation);
            }
            else if (Input.GetKeyDown(stop))
            {
                Deactivate();

            }
        }
	}

    public void Activate(GameObject objToPlace)
    {
        if (trackingObject) { Destroy(trackingObject); }
        buildingPlacerActive = true;
        trackingObject = Instantiate(objToPlace, transform);
    }

    public void Deactivate()
    {
        buildingPlacerActive = false;
        Destroy(trackingObject);
    }
}
