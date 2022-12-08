using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public Animator pinAnimator;
    public bool pinRemoved = false;
    public FireController fireController;

    // Start is called before the first frame update
    void Start()
    {
        pinAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Unparent()
    {
        pinAnimator.Play("BlinkOut");
        pinRemoved = true;
        fireController.pinRemoved = true;
        fireController.RemovePin();
    }

    public void CumGuzzler()
    {
        if (pinRemoved == true)
        {

        }
    }
}