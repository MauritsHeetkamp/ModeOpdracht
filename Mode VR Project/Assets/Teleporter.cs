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
            }
            RaycastHit hitObject;
            if(Physics.Raycast(teleportHand.transform.position, teleportHand.transform.forward, out hitObject, 1000, teleportableLayers, QueryTriggerInteraction.Ignore))
            {
                if(hitObject.transform.tag == teleportableTag)
                {
                    teleportingObject.transform.position = hitObject.point;
                }
            }
        }
        else
        {
            if (teleport.GetStateUp(teleportSource))
            {
                Teleport(teleportingObject.transform.position);
                Destroy(teleportingObject);
            }
        }
    }
    public void Teleport(Vector3 position)
    {
        position.x -= mainCamera.position.x;
        position.z -= mainCamera.position.z;
        transform.position = position;
    }
}
