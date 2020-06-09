using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float Speed = 20f;
 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, Speed * Time.deltaTime);
    }
}
