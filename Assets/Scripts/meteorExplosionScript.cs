using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorExplosionScript : MonoBehaviour {

    private float lifeTime = 0f;
	void Update () {
        lifeTime += Time.deltaTime;
        if (lifeTime >= 1f)
        {
            Destroy(this.gameObject);
        }
	}
}
