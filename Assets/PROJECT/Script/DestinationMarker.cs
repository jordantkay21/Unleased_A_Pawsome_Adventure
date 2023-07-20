using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationMarker : MonoBehaviour
{
    private Transform _doors;

    private void OnEnable()
    {
        _doors = gameObject.transform.GetChild(4);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        _doors.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.markerActivated = false;
            SpawnManager.Instance.SpawnBones(GameManager.Instance.bonesNeeded);
            _doors.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
