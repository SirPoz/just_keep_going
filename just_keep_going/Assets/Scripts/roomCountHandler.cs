using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class roomCountHandler : MonoBehaviour
{
    [SerializeField]private TMP_Text roomText;
    // Start is called before the first frame update
    void Start()
    {

        //TMP_Text textmeshPro = roomText.GetComponent<TextMeshPro>();
        roomText.text = "Test";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
