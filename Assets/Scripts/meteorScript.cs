using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorScript : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer rend;

    private float Speed;
    public int Health = 3;

    public GameObject meteorExplosion;
    public GameObject meteorParticle;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

        Speed = GameObject.Find("meteorCreator").GetComponent<meteorCreatorScript>().speed;
	}
	
	void FixedUpdate () {
        rb.velocity = Vector2.down * Speed;	
	}

    public void Hit() {
        Health -= 1;

        switch (Health) {
            case 2:
                rend.color = Color.yellow;
                break;
            case 1:
                rend.color = Color.red;
                break;
            default:
                rend.color = new Color(0, 0, 0);
                break;
        }

        if (Health <= 0) {
            GameObject.Destroy(this.gameObject);
            GameObject.Instantiate(meteorExplosion, transform.position, Quaternion.identity);
            GameObject.Instantiate(meteorParticle, transform.position, Quaternion.identity);
            GameObject.Find("Hud").GetComponent<hudScript>().addPoints(i: 100);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "MeteorDestroyer") {
            Destroy(this.gameObject);
        }
    }
}
