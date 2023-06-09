using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

/// <summary>
/// Script to control the function of allowing player to choose their own dog avatar
/// </summary>
public class AvatarManager : MonoSingleton<AvatarManager>
{
    [SerializeField] 
    private GameObject[] _selectionCameras; // 0-Dalmation | 1-GoldenRetriever | 2-GermanShepherd | 3-Greyhound | 4-Husky | 5-Ridgeback | 6-Doberman 
    
    [SerializeField]
    private GameObject[] _followCameras; // 0-Dalmation | 1-GoldenRetriever | 2-GermanShepherd | 3-Greyhound | 4-Husky | 5-Ridgeback | 6-Doberman 

    [SerializeField]
    private GameObject[] _DogAvatars; // 0-Dalmation | 1-GoldenRetriever | 2-GermanShepherd | 3-Greyhound | 4-Husky | 5-Ridgeback | 6-Doberman 

    [SerializeField]
    private int _currentCam;


    // Start is called before the first frame update
    void Start()
    {
        ResetAllCams();
    }


    /// <summary>
    /// Makes sure that at the start of the game all virtual cameras have a priority of 10.
    /// </summary>
    private void ResetAllCams()
    {
        foreach (var cams in _selectionCameras)
        {
            cams.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        }

        foreach (var cams in _followCameras)
        {
            cams.SetActive(false);
        }

        _selectionCameras[0].GetComponent<CinemachineVirtualCamera>().Priority = 11;
    }

    /// <summary>
    /// Method to increase the current camera index which moves the camera to the right.
    /// If the current camera is at the end of the array list then it pushes back to the begining
    /// </summary>
    public void IncreaseCurrentCam()
    {
        if(_currentCam < _selectionCameras.Length-1)
        {
            _selectionCameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            _currentCam++;
            _selectionCameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
        else if(_currentCam == _selectionCameras.Length-1)
        {
            _selectionCameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            _currentCam = 0;
            _selectionCameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
    }

    /// <summary>
    /// Method to decrease the current camera index which moves the camera to the left.
    /// If the current camera is at the begining of the array list then it pushes back to the end
    /// </summary>
    public void DecreaseCurrentCam()
    {
        if (_currentCam > 0)
        {
            _selectionCameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            _currentCam--;
            _selectionCameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
        else if (_currentCam == 0)
        {
            _selectionCameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            _currentCam = _selectionCameras.Length-1;
            _selectionCameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
    }

    public void SetCharacterCam()
    {
        foreach (var cams in _selectionCameras)
        {
            cams.SetActive(false);
        }
        _followCameras[_currentCam].SetActive(true);
        _DogAvatars[_currentCam].AddComponent<Player>();
    }
}
