using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarretPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = player.position;
        vec.x = 0;
        vec.y = 8.3f;
        vec.z = -5.1f;

        transform.position = vec;
    }
}
