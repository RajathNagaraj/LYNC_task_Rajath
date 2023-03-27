using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AvatarUIController : MonoBehaviour
{

    [SerializeField] private Image arrowImage;
    [SerializeField] private TMP_Text avatarName;
    [SerializeField] private Button backButton;
    [SerializeField] private Button playButton;

    

    public void ToggleUI(bool toggle)
    {
        arrowImage.enabled = toggle;
        avatarName.enabled = toggle;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        avatarName.text = gameObject.GetComponentInParent<Avatar>().prefab.name;
        backButton.onClick.AddListener(GameController.Instance.BackButtonPressed);
        playButton.onClick.AddListener(GameController.Instance.PlayButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableUI()
    {
        arrowImage.rectTransform.gameObject.SetActive(false);
        avatarName.rectTransform.gameObject.SetActive(false);
    }

    public void EnableUI()
    {
        arrowImage.rectTransform.gameObject.SetActive(true);
        avatarName.rectTransform.gameObject.SetActive(true);
    }

    public void OnSelected()
    {
        backButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
    }

    public void OnDeSelected()
    {
        backButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
    }
}
