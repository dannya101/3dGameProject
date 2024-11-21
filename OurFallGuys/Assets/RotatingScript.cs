using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotatingScript: MonoBehaviour
{
    float speed = 20.0f;
    float rSpeed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");
        float yValue = 0;
        Vector3 movementDir = new Vector3(xValue,yValue,zValue);
        movementDir.Normalize();

        transform.Translate(movementDir * speed * Time.deltaTime, Space.World);

        if (movementDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDir, Vector3.up);
            Quaternion combinedRotation = Quaternion.Euler( 0f, 90f, 0f ) * toRotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, combinedRotation, rSpeed * Time.deltaTime);
        }
    }
}