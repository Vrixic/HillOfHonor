using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PO_ParticleSystem : PoolableObject
{
    private void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
    }
}
