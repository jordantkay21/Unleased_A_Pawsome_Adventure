using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

/// <summary>
/// Script to control the function of allowing player to choose their own dog avatar
/// </summary>
public class AvatarManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] _cameras; // 0-Dalmation | 1-GoldenRetriever | 2-GermanShepherd | 3-Greyhound | 4-Husky | 5-Ridgeback | 6-Doberman 

    [SerializeField]
    private int _currentCam;


    // Start is called before the first frame update
    void Start()
    {
        ResetAllCams();
        Debug.Log(_cameras.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            IncreaseCurrentCam();
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            DecreaseCurrentCam();
        }
    }

    /// <summary>
    /// Makes sure that at the start of the game all virtual cameras have a priority of 10.
    /// </summary>
    private void ResetAllCams()
    {
        foreach (var cams in _cameras)
        {
            cams.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        }

        _cameras[0].GetComponent<CinemachineVirtualCamera>().Priority = 11;
    }

    private void IncreaseCurrentCam()
    {
        if(_currentCam < _cameras.Length-1)
        {
            _cameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            _currentCam++;
            _cameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
        else if(_currentCam == _cameras.Length-1)
        {
            _cameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            _currentCam = 0;
            _cameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
    }

    private void DecreaseCurrentCam()
    {
        if (_currentCam > 0)
        {
            _cameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            _currentCam--;
            _cameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
        else if (_currentCam == 0)
        {
            _cameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            _currentCam = 6;
            _cameras[_currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
    }
}
