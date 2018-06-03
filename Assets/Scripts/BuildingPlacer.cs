using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlacer : MonoBehaviour {

    public float maxSteepness = 15;
    public float rotationSteps = 90;
    public Material redMat;
    public Material greenMat;

    private bool buildingPlacerActive = false;
    private GameObject trackingObject;
    private GameObject placingObject;
    private Terrain terrain;
    private MeshRenderer[] meshes;
    private Material matColor;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (buildingPlacerActive)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            bool hitCorr = hit.collider is TerrainCollider;
            if (hitCorr)
            {
                trackingObject.transform.position = hit.point;
                terrain = hit.collider.GetComponent<Terrain>();
                float steepness = terrain.terrainData.GetSteepness((hit.point.x - terrain.transform.position.x) / terrain.terrainData.heightmapWidth, (hit.point.z - terrain.transform.position.z) / terrain.terrainData.heightmapHeight);
                if (steepness <= maxSteepness)
                {
                    matColor = greenMat;
                }
                else
                {
                    hitCorr = false;
                    matColor = redMat;
                }
            }
            else
            {
                matColor = redMat;
            }
            foreach (MeshRenderer mesh in meshes)
            {
                mesh.material = matColor;
            }
            if (Input.GetButtonDown("Select") && !EventSystem.current.IsPointerOverGameObject() && hitCorr)
            {
                GameObject newObject = Instantiate(placingObject, trackingObject.transform.position, trackingObject.transform.rotation);
            }
            else if (Input.GetButtonDown("Rotate"))
            {
                trackingObject.transform.Rotate(Vector3.up * rotationSteps);
            }
            else if (Input.GetButtonDown("Deselect"))
            {
                Deactivate();

            }
        }
	}

    public void Activate(GameObject objToPlace)
    {
        if (trackingObject) { Destroy(trackingObject); }
        buildingPlacerActive = true;
        placingObject = objToPlace;
        trackingObject = Instantiate(objToPlace, transform);
        meshes = trackingObject.GetComponentsInChildren<MeshRenderer>();
    }

    public void Deactivate()
    {
        buildingPlacerActive = false;
        Destroy(trackingObject);
    }
}
