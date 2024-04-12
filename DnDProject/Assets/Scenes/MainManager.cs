using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainManager : MonoBehaviour
{
    
    public static MainManager Instance;
    public string race = "";
    public string @class = "";
    public string background = "";
    public PlayerCharacter player;


    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
    }


}
