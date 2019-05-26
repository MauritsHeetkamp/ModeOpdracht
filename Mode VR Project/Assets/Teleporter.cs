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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teleport.GetState(teleportSource))
        {
            RaycastHit hitObject;
            if(Physics.Raycast(teleportHand.transform.position, teleportHand.transform.forward, out hitObject, 1000, teleportableLayers, QueryTriggerInteraction.Ignore))
            {

            }
        }
    }
    public void Teleport(Vector3 position)
    {

    }
}
