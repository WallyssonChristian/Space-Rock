using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorParticleScript : MonoBehaviour {

    private float lifeTime = 0f;
    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    void Update () {
        lifeTime += Time.deltaTime;
        if (lifeTime >= ps.main.duration)
        {
            Destroy(this.gameObject);
        }
	}
}
