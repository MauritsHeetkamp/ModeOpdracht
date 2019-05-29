using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Teleporter : MonoBehaviour
{
    [SerializeField]SteamVR_Input_Sources teleportSource;
    [SerializeField] SteamVR_Action_Boolean teleport;
    public GameObject teleportHand;
    public LayerMask teleportableLayers;
    public string teleportableTag;


    public GameObject teleportObject;
    public Transform mainCamera;
    GameObject teleportingObject;
    public bool canTP = false;
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (teleport.GetState(teleportSource))
        {
            if (teleport.GetStateDown(teleportSource))
            {
                teleportingObject = Instantiate(teleportObject);
                lineRenderer.enabled = true;
            }
            RaycastHit hitObject;
            lineRenderer.SetPosition(0, lineRenderer.transform.position);
            if (Physics.Raycast(teleportHand.transform.position, teleportHand.transform.forward, out hitObject, 1000, teleportableLayers, QueryTriggerInteraction.Ignore))
            {
                if (hitObject.transform.tag == teleportableTag)
                {
                    canTP = true;
                    teleportingObject.transform.position = hitObject.point;
                    lineRenderer.SetPosition(1, hitObject.point);
                }
                else
                {
                    canTP = false;
                }
            }
            else
            {
                canTP = false;
            }
        }
        else
        {
            if (teleport.GetStateUp(teleportSource))
            {
                lineRenderer.enabled = false;
                Teleport(teleportingObject.transform.position);
                Destroy(teleportingObject);
            }
        }
    }
    public void Teleport(Vector3 position)
    {
        //position.x -= mainCamera.localPosition.x;
        //position.z -= mainCamera.localPosition.z;
        transform.position = position;
    }
}
