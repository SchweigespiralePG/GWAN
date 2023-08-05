using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    //Reference to the GameObject with the CharacterProfile component
    public GameObject characterObject;

    private CharacterProfile characterProfile;
    
    // Start is called before the first frame update
    void Start()
    {
        characterProfile = characterObject.GetComponent<CharacterProfile>();

        //Modify character attributes
        characterProfile.characterName = "라인하르트";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
