using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserExplosionScript : MonoBehaviour {

    private float lifeTime = 0f;

	void Update () {
        lifeTime += Time.deltaTime;
        if (lifeTime >= 0.8f)
        {
            Destroy(this.gameObject);
        }
	}
}
