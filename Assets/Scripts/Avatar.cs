using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    public GameObject prefab;

    private AnimationStates currentAnimationState = AnimationStates.Idle;

    private Vector3 scalediff = new Vector3(0.5f,0.5f,0.5f);      

    private AvatarUIController avatarUIController;     

    private Animator prefabAnimator;

    [SerializeField]
    private AnimatorController animatorController;


    public void Initialise()
    {
        avatarUIController = GetComponentInChildren<AvatarUIController>();        
        prefabAnimator = prefab.AddComponent<Animator>();
        prefabAnimator.runtimeAnimatorController = animatorController;      
    }

    void OnMouseOver()
    {
        avatarUIController.ToggleUI(true);           
    }

    void OnMouseExit()
    {
        avatarUIController.ToggleUI(false);
    }

   public void ShrinkAvatarPrefab()
    {
        prefab.transform.localScale = scalediff;
    }

    //Set position of Avatar and contained gameobject
    public void SetAvatarPosition(Vector3 pos)
    {
        prefab.transform.position = pos;
        gameObject.transform.position = pos;
    }

    public void StartAnimation()
    {
        prefabAnimator.SetTrigger("isClicked");   
        currentAnimationState = AnimationStates.Animating;
        avatarUIController.DisableUI();
        avatarUIController.OnSelected();
    }

    public void StopAnimation()
    {
        prefabAnimator.SetTrigger("isClickedAgain");   
        currentAnimationState = AnimationStates.Idle;
        avatarUIController.EnableUI();
        avatarUIController.OnDeSelected(); 
    }   
}

