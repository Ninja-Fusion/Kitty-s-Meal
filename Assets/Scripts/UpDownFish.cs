using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDownFish : MonoBehaviour {
    Vector3 fishPos;
    private bool moveUpDown = true;
    void Start()
    {
        fishPos = transform.position;
    }

    void Update()
    {

        if (moveUpDown)
        {
            if (transform.position.y <= fishPos.y + 0.05f)
                transform.position = new Vector3(transform.position.x, transform.position.y + 1 * Time.deltaTime * 0.15f, transform.position.z);
            else
                moveUpDown = false;
        }
        else
        {
            if (transform.position.y >= fishPos.y - 0.05f)
                transform.position = new Vector3(transform.position.x, transform.position.y - 1 * Time.deltaTime * 0.15f, transform.position.z);
            else
                moveUpDown = true;
        }
    }
}
