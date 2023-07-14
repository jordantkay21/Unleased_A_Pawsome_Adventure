using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationMarker : MonoBehaviour
{
    public bool _isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void ActivateMArker()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SpawnManager.Instance.SpawnBones(GameManager.Instance.BonesNeeded);
            gameObject.SetActive(false);
        }
    }
}
