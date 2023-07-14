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
            Debug.Log("Spawning " +_bonesToSpawn[randomBone].name + " to be collected");
            _bonesToSpawn[randomBone].SetActive(true);
            Debug.Log("Removing " + _bonesToSpawn[randomBone].name + " from _bonesToSpawn list");
            _bonesToSpawn.RemoveAt(randomBone);
        }
    }

    public void SpawnDestinationMarker()
    {
        int randomMarker = Random.Range(0, _destinationMarkers.Count - 1);
        Debug.Log(randomMarker + " destination was chosen");
        _destinationMarkers[randomMarker].SetActive(true);
        _destinationMarkers.RemoveAt(randomMarker);

        switch (_destinationMarkers[randomMarker].name)
        {
            case "DestinationMarker (0)":
                foreach (GameObject bone in _index0)
                {
                    Debug.Log("Adding Bone " + bone.name + " to _bonesToSpawn List");
                    _bonesToSpawn.Add(bone);
                }
                break;
            case "DestinationMarker (1)":
                foreach (GameObject bone in _index1)
                {
                    Debug.Log("Adding Bone " + bone.name + " to _bonesToSpawn List");
                    _bonesToSpawn.Add(bone);
                }
                break;
            case "DestinationMarker (2)":
                foreach (GameObject bone in _index2)
                {
                    Debug.Log("Adding Bone " + bone.name + " to _bonesToSpawn List");
                    _bonesToSpawn.Add(bone);
                }
                break;
            case "DestinationMarker (3)":
                foreach (GameObject bone in _index3)
                {
                    Debug.Log("Adding Bone " + bone.name + " to _bonesToSpawn List");
                    _bonesToSpawn.Add(bone);
                }
                break;
        }
    }
}
