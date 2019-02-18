using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
