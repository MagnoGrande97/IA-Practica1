using UnityEngine;
using AI;

public class RandomMotion : BaseAgent
{
	Vector3 velocity = new Vector3(3, 0, 0);
	Vector3 desired;
	Vector3 steer;
	float MAX_FORCE = 2.5f;
	float MAX_STEER = 0.3f;
    [SerializeField]
	Vector3 target;
	float timer = 0;
    [SerializeField]
    float FLEE_RANGE = 5;
    [SerializeField]
    float radius = 2;
    int puntaje = 10;

    void Start()
	{
		randomizeTarget();
        maxForce = 2;
        maxSteer = 0.8f;
    }

	void Update()
	{
        Vector3 difference = (transform.position - Vector3.zero);
        desired = (target - transform.position).normalized * MAX_FORCE;
		steer = Vector3.ClampMagnitude(desired - velocity, MAX_STEER) * MAX_STEER;
		velocity += steer;
		transform.position += velocity * Time.deltaTime;

        timer += Time.deltaTime;

		if (timer >= 10)
		{
			timer = 0;
			randomizeTarget();
		}

        if (difference.magnitude < 5)
        {
            Vector3 mousePosition = GameObject.Find("Mouse").transform.position;
            addFlee(mousePosition, FLEE_RANGE);

            addRandom(Random.Range(1, 2));
            calculate(gameObject);
        }
        else
        {
            desired = -difference;
            steer = Vector3.ClampMagnitude(desired - velocity, MAX_STEER);
            velocity += steer;
            transform.position += velocity * Time.deltaTime * 2;
            calculate(gameObject);
        }

        float radiusBolaAdentro = 1.5f;
        Vector3 centerPosition = Vector3.zero;
        float distanceBolaCentro = Vector3.Distance(transform.position, centerPosition);

        if (distanceBolaCentro < radiusBolaAdentro)
        {
            CircleMiddle.puntaje++;
            Destroy(this.gameObject);
        }
    }

	void randomizeTarget()
	{
		float x = Random.Range(-5, 5);
		float y = Random.Range(-5, 5);

		target = new Vector3(x, y, 0);
	}
}
