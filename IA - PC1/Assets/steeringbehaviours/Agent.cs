using UnityEngine;
using AI;

public class Agent : BaseAgent
{
	float FLEE_RANGE = 5;

    void Start()
	{
		maxForce = 2;
		maxSteer = 0.8f;
	}

	void Update()
	{
		Vector3 mousePosition = GameObject.Find("Mouse").transform.position;
		//Vector3 randomPosition = GameObject.Find("Random").transform.position;
        
        //addSeek(mousePosition);
        //addArrive(mousePosition, 2, 3);
        addFlee(mousePosition, FLEE_RANGE);
        addRandom(Random.Range(1,2));
        calculate(gameObject);
	}
}
