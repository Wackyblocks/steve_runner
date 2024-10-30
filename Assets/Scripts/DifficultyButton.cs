using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;


public class DifficultyButton : MonoBehaviour
{

    private Button button;
    private TitleManager titleManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        titleManager = GameObject.Find("Title Manager").GetComponent<TitleManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    //difficulty function
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");

    }
}
