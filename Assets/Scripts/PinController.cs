using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public Animator pinAnimator;

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
    }
}