using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private UnityEngine.Object[] gameObjects;

    [SerializeField]
    private Avatar avatarPrefab;    

    private Avatar[] avatars;   

    private List<Avatar> activeAvatars;  

    private Avatar currentAvatar;

    private int currentAvatarIndex;  

    private List<ScreenObject> screenPartitions;  
    
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(Instance);
            return;
        }
           
        
        gameObjects = Resources.LoadAll("Prefabs");
        avatars = new Avatar[gameObjects.Length];   
        Debug.Log("gameobjects length "+ gameObjects.Length);   
        Debug.Log("avatars length "+avatars.Length);           
    }

    // Start is called before the first frame update
    void Start()
    {
        //Number of partitions the screen is being divided into, one for each prefab, horizontally
        screenPartitions = new List<ScreenObject>();
        int horizontalWidthOfEachScreenObject = ScreenUtils.ScreenDivisor(gameObjects.Length);
        Debug.Log(" "+ horizontalWidthOfEachScreenObject);
        screenPartitions = ScreenUtils.PartitionScreen(horizontalWidthOfEachScreenObject);
        InstantiatePrefabs();       
    }

    

    private void InstantiatePrefabs()
    {
        for(int i = 0; i < gameObjects.Length; i++)
       {
            //Instantiate the prefab outline
            avatars[i] = Instantiate(avatarPrefab);

            //Instantiate the gameobject and place it in the newly created avatar
            avatars[i].prefab = Instantiate((GameObject) gameObjects[i]);

            //Initialise the Avatar
            avatars[i].Initialise();

            Vector3 pos = new Vector3(screenPartitions[i].MidPoint.X, screenPartitions[i].MidPoint.Y, 3f);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);   

            //Set the gameobject and its avatar to the position of the waypoint
            avatars[i].SetAvatarPosition(worldPos);

            //Set the Avatar as the parent of the gameobject
            avatars[i].prefab.transform.SetParent(avatars[i].transform);           
            //Shrink the gameobject prefab a little
            //avatars[i].ShrinkAvatarPrefab();

            

       }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);            
            if(Physics.Raycast(ray, out hit))
            {                              
                currentAvatar = (Avatar)hit.transform.gameObject.GetComponent<Avatar>(); 
                if(currentAvatar != null)
                {
                    currentAvatarIndex = Array.IndexOf(avatars,currentAvatar);  
                    Debug.Log(currentAvatarIndex);   
                }
                ToggleAllAvatarPrefabs(false);
                avatars[currentAvatarIndex].gameObject.SetActive(true);
                avatars[currentAvatarIndex].StartAnimation();
                                           
            }
            
            
        }
    }

    void ToggleAllAvatarPrefabs(bool param)
    {
        foreach(Avatar avatar in avatars)
        {
            avatar.gameObject.SetActive(param);
        }
    }

    public void BackButtonPressed()
    {
        avatars[currentAvatarIndex].StopAnimation();
        ToggleAllAvatarPrefabs(true);
    }

    public void PlayButtonPressed()
    {
        Debug.Log("Loading Scene with Selected Player");
    }

    
}
