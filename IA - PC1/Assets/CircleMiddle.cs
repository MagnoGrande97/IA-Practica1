using UnityEngine.UI;
using UnityEngine;

public class CircleMiddle : MonoBehaviour
{
    float radiusInside = 1;
    public static int puntaje=0;

    void Update()
    {
        transform.position = Vector3.zero;
        Debug.Log("Tu puntaje es: " + puntaje);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusInside);
    }
}
