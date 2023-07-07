using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("TEXTS")]
    [SerializeField]
    private TextMeshProUGUI _bonesText;

    private void Update()
    {
        BoneStats();
    }

    private void BoneStats()
    {
        _bonesText.SetText("BONES: " + Player.Instance._bonesCollected + "/" + Player.Instance._bonesNeeded);
    }
}
