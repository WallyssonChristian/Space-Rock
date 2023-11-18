using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour {

    private Rigidbody2D rb;
    private float Speed = 5f;
    public GameObject laserExplosion;
    [SerializeField] AudioSource laserHit;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        rb.velocity = Vector2.up * Speed;
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "BorderMap") {
            GameObject.Destroy(this.gameObject);
        }

        if(collision.CompareTag("Meteor")) {
            collision.transform.GetComponent<meteorScript>().Hit();
            GameObject.Destroy(this.gameObject);
            GameObject.Instantiate(laserExplosion, transform.position, Quaternion.identity);
        }
    }

}
