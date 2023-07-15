using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private int _level = 1;

    public bool markerActivated = false;

    #region properties
    public int bonesCollected { get; private set; }
    public int bonesNeeded { get; private set; }

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
        

        if (bonesNeeded != 0 && bonesCollected == bonesNeeded)
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    #region Bones

    public void SetBoneAmount(int boneAmount)
    {
        bonesCollected = 0;
        bonesNeeded = boneAmount;
    }

    public void BoneCollected()
    {
        bonesCollected++;
    }

    #endregion
}
