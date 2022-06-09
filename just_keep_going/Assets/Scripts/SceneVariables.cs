using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVariables : MonoBehaviour
{
    public static SceneVariables Instance{ get; private set; }
    public int roomCount;
    public int playerMaxHealth;
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Debug.Log(this.gameObject.GetInstanceID());
    }

}
