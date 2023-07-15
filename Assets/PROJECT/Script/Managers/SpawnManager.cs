using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    [Tooltip("List of all bones within the scene that is available to be spawned")]
    [SerializeField]
    private List<GameObject> _bonesToSpawn = new List<GameObject>();
    [SerializeField]
    public List<Destination> destinationList;



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

        foreach(Destination store in destinationList)
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
            int listIndex = Random.Range(0, destinationList.Count - 1);
            Destination chosenDestination = destinationList[listIndex];

            GameManager.Instance.markerActivated = true;
            chosenDestination.destinationMarker.SetActive(true);
            chosenDestination.doors.SetActive(false);

            Debug.Log("bone list count is: " + chosenDestination.boneList.Count);

            for (int i = 0; i <= destinationList[listIndex].boneList.Count - 1; i++)
            {
                Debug.Log("For loop through Bone List is running and is on index: " + i);
                _bonesToSpawn.Add(destinationList[listIndex].boneList[i]);
            }

            destinationList.RemoveAt(listIndex);

        }
        catch (System.ArgumentOutOfRangeException)
        {
            UIManager.Instance.GameOver();
        }


    }
}
