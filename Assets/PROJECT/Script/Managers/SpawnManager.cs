using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    [Tooltip("List of all bones within the scene that is available to be spawned")]
    [SerializeField]
    private List<GameObject> _bonesToSpawn = new List<GameObject>();

    [Header("New Bones List")]
    [SerializeField]
    private List<GameObject> _index0;
    [SerializeField]
    private List<GameObject> _index1;
    [SerializeField]
    private List<GameObject> _index2;
    [SerializeField]
    private List<GameObject> _index3;


    [Tooltip("List of all Destination Markers within the scene that are avaiable to be spawned")]
    [SerializeField]
    private List<GameObject> _destinationMarkers = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        DeactivateAllObjects();
        SpawnBones(5);
    }

    private void DeactivateAllObjects()
    {
        foreach (GameObject bone in _bonesToSpawn)
            bone.SetActive(false);

        foreach (GameObject marker in _destinationMarkers)
            marker.SetActive(false);

        foreach (GameObject bone in _index0)
            bone.SetActive(false);
        
        foreach (GameObject bone in _index1)
            bone.SetActive(false);
        
        foreach (GameObject bone in _index2)
            bone.SetActive(false);
        
        foreach (GameObject bone in _index3)
            bone.SetActive(false);
        
    }

    public void SpawnBones(int boneAmount)
    {
        for (int i=0; i<boneAmount; i++)
        {
            int randomBone = Random.Range(0, _bonesToSpawn.Count - 1);
            _bonesToSpawn[randomBone].SetActive(true);
            _bonesToSpawn.RemoveAt(randomBone);
        }
    }

    public void SpawnDestinationMarker()
    {
        int randomMarker = Random.Range(0, _destinationMarkers.Count - 1);
        _destinationMarkers[randomMarker].SetActive(true);
        _destinationMarkers.RemoveAt(randomMarker);

        switch (randomMarker)
        {
            case 0:
                foreach(GameObject bone in _index0)
                {
                    _bonesToSpawn.Add(bone);
                }
                break;
            case 1:
                foreach (GameObject bone in _index1)
                {
                    _bonesToSpawn.Add(bone);
                }
                break;
            case 2:
                foreach (GameObject bone in _index2)
                {
                    _bonesToSpawn.Add(bone);
                }
                break;
            case 3:
                foreach (GameObject bone in _index3)
                {
                    _bonesToSpawn.Add(bone);
                }
                break;
        }
    }
}
