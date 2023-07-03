using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    [Tooltip("value used to determine how fast the object rotates")]
    private float _rotationSpeed;
    private Transform _base;

    private void Start()
    {
        _rotationSpeed = Random.Range(50f, 100f);
        _base = transform.Find("Base");
        _base.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotationSpeed) * Time.deltaTime);
    }
}
