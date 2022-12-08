using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingScript : MonoBehaviour
{
    public FireController shittyCylinder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GrabCollider")
        {
            shittyCylinder.FireExtinguisherGrabbed();
        }
    }
}
