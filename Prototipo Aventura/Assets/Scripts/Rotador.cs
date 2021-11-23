using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    public float rotarZ;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotarZ) * Time.deltaTime);
    }
}
