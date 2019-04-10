using UnityEngine;
using AI;

public class InstantiatePrefabs : BaseAgent
{
    [SerializeField]
    float timer = 0;
    [SerializeField]
    float frequency;

    public GameObject oveja;

    void Start()
    {
        frequency = 3;
    }

    void Update()
    {
        timer += Time.deltaTime;

        Instantiate();
    }

    public void Instantiate()
    {
        if (timer >= frequency)
        {
            timer = 0;
            frequency = Random.Range(2, 3);
            GameObject _oveja = Instantiate(oveja, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);

            _oveja.GetComponent<Agent>().addRandom(Random.Range(1,2));

            //calculate(_oveja);
        }
    }
}
