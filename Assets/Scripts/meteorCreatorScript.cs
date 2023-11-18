using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorCreatorScript : MonoBehaviour {

    public GameObject MeteorObject;
    public float minTimeToCreate = 1f;
    public float maxTimeToCreate = 3f;

    private float timeToNextCreation;
    private float countTime;
    private float leftBound;
    private float rightBound;

    public float speed = 1f;

	void Start () {
        float horizontalExtension = Camera.main.orthographicSize * Screen.width / Screen.height;
        leftBound = -horizontalExtension * 0.8f;
        rightBound = horizontalExtension * 0.8f;
        GenerateNextTime();
	}
	
	// Update is called once per frame
	void Update () {
        countTime += Time.deltaTime;
        if(countTime >= timeToNextCreation)
        {
            countTime = 0;
            GenerateNextTime();

            Vector3 pos = transform.position;
            pos.x = Random.Range(leftBound, rightBound);

            GameObject.Instantiate(MeteorObject, pos, Quaternion.Euler(0, 0, Random.Range(0, 359) ));
        }
	}

    void GenerateNextTime()
    {
        timeToNextCreation = Random.Range(minTimeToCreate, maxTimeToCreate);
    }

    public void addtVelocity()
    {
        maxTimeToCreate -= 0.2f;
        speed += 0.5f;
    }
}
