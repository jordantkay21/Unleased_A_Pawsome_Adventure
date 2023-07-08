using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationMarker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
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
