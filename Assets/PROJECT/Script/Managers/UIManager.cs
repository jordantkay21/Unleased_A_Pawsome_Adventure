using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("TEXTS")]
    [SerializeField]
    private TextMeshProUGUI _bonesText;

    private void Update()
    {
        BoneStats();
    }

    public void BoneStats()
    {
            _bonesText.SetText("BONES: " + GameManager.Instance.BonesCollected + "/" + GameManager.Instance.BonesNeeded);
    }
}
