using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{

    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - obj.transform.position);
    }
}
