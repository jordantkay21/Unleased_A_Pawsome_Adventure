using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Tooltip("List of all bones within the scene that is available to be spawned")]
    [SerializeField]
    private List<GameObject> _bonesToSpawn = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        SpawnBones(5);
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
}
