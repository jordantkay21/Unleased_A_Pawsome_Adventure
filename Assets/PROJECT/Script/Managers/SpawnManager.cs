using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    [Tooltip("List of all bones within the scene that is available to be spawned")]
    [SerializeField]
    private List<GameObject> _bonesToSpawn = new List<GameObject>();
    [SerializeField]
    private List<Destination> _destinationList;



    // Start is called before the first frame update
    void Start()
    {
        ResetAllObjects();
        SpawnBones(5);
    }

    private void ResetAllObjects()
    {
        foreach (GameObject defaultBone in _bonesToSpawn)
            defaultBone.SetActive(false);

        foreach(Destination store in _destinationList)
        {
            foreach (GameObject bone in store.boneList)
                bone.SetActive(false);
            store.destinationMarker.SetActive(false);
            store.doors.SetActive(true);
        }
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
        try
        {
            int listIndex = Random.Range(0, _destinationList.Count - 1);
            Destination chosenDestination = _destinationList[listIndex];

            GameManager.Instance.markerActivated = true;
            chosenDestination.destinationMarker.SetActive(true);
            chosenDestination.doors.SetActive(false);

            for (int i = 0; i <= _destinationList[listIndex].boneList.Count - 1; i++)
            {
                _bonesToSpawn.Add(_destinationList[listIndex].boneList[i]);
            }

            _destinationList.RemoveAt(listIndex);

        }
        catch (System.ArgumentOutOfRangeException)
        {
            UIManager.Instance.GameOver();
        }
    }
}
