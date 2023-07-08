using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private int _level = 1;

    #region properties
    public int BonesCollected { get; private set; }
    public int BonesNeeded { get; private set; }
    #endregion

    private void Start()
    {
        SetBoneAmount(5);
    }

    private void Update()
    {
            UnlockDestination();
    }
    private void UnlockDestination()
    {
        

        if (BonesNeeded != 0 && BonesCollected == BonesNeeded)
        {
            _level++;
            SpawnManager.Instance.SpawnDestinationMarker();

            switch (_level)
            {
                case 2:
                    SetBoneAmount(6);
                    break;
                case 3:
                    SetBoneAmount(7);
                    break;
                case 4:
                    SetBoneAmount(8);
                    break;
                case 5:
                    SetBoneAmount(9);
                    break;
            }
        }
    }

    #region Bones

    public void SetBoneAmount(int boneAmount)
    {
        BonesCollected = 0;
        BonesNeeded = boneAmount;
    }

    public void BoneCollected()
    {
        BonesCollected++;
    }

    #endregion
}
