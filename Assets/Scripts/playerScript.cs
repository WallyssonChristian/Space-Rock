using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    private Rigidbody2D rb;
    private float shootTimer = 0f;
    public float Speed = 4f;
    public float MinTimeToShoot = 0.2f;

    public GameObject LaserObject;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void Update() {
        if (shootTimer < MinTimeToShoot) {
            shootTimer += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShootLaser();
        }
    }

    void FixedUpdate () {
        Vector2 dir = Vector2.zero;

		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            dir.y = 1;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            dir.y = -1;
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            dir.x = -1;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            dir.x = 1;
        }

        rb.velocity = dir * Speed;
    }

    void ShootLaser () {
        if (MinTimeToShoot > shootTimer)
            return;

        shootTimer = 0;
        if (LaserObject != null) {
            // Armazena posicao
            Vector3 pos = this.transform.position;
            GameObject.Instantiate(LaserObject, pos, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteor")) {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void OnGameStart() {
        foreach (var item in GameObject.FindGameObjectsWithTag("Meteor"))
        {
            GameObject.Destroy(item);
        }
        //points = 0;
        //pointText.text = points.ToString();
        //transform.position = inicialPosition;
        //isAlive = true;
        //rb.velocity = Vector2.zero;
        //isStarted = true;
        //btnStart.gameObject.SetActive(false);
    }
}
