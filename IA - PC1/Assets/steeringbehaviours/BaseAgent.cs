using UnityEngine;

namespace AI
{
	public class BaseAgent : MonoBehaviour
	{
		public Vector3 velocity;
		private Vector3 desired;
		public Vector3 steer;

		public float maxForce = 1;
		public float maxSteer = 1;

        public float radiusRandom = 1;
        public float frequencyRandom = 2;

		public void addSeek(Vector3 targetPosition, float range = 999999)
		{
			Vector3 seek = SteeringBehaviours.seek(this, targetPosition, range);
			desired += seek;
		}

		public void addArrive(Vector3 targetPosition, float arriveRange, float range = 999999)
		{
			Vector3 arrive = SteeringBehaviours.arrive(this, targetPosition, range);
			desired += arrive;
		}

		public void addFlee(Vector3 targetPosition, float range = 999999)
		{
			Vector3 flee = SteeringBehaviours.flee(this, targetPosition, range);
			desired += flee;
		}
        
        public void addRandom(float frequencyRandom)
        {
            Vector3 random = SteeringBehaviours.random(this, frequencyRandom);
            desired += random;
        }

        public void calculate(GameObject objeto)
		{
			steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);
			velocity += steer;
			desired = Vector3.zero;
            objeto.transform.position += velocity * Time.deltaTime;
		}
	}
}