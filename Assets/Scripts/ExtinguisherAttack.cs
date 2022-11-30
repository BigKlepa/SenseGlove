using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherAttack : MonoBehaviour
{
    [SerializeField] ParticleSystem extinguisher;
    [SerializeField] FireController fire;
    [SerializeField] bool includeChildren = true;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleTrigger()
    {
        print("beenis :DD");
        fire.ReduceHealth(1);
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
    }
}
