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
    [SerializeField]
    private TextMeshProUGUI _gameOverText;

    [Header("Buttons")]
    [SerializeField]
    private Button _quitButton;
    [SerializeField]
    private Button _restartButton;

    private void Update()
    {
        BoneStats();
    }

    public void BoneStats()
    {
        _bonesText.SetText("BONES: " + GameManager.Instance.bonesCollected + "/" + GameManager.Instance.bonesNeeded);
    }

    public void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
        _quitButton.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
    }
}
