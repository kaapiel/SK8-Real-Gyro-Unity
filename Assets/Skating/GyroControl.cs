using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{

    private bool isGyroEnable;
    private Gyroscope gyro;

    // Start is called before the first frame update
    void Start()
    {
        isGyroEnable = EnableGyro();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation  = gyro.attitude;
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }
}
