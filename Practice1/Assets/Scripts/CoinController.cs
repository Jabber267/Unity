using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float rotationSpeed = 200;

    // Update is called once per frame
    void Update()
    {
        float rotationAngle = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationAngle, Space.World);
    }
}
