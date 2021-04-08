using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleChanger : MonoBehaviour
{

    public static TitleChanger instance;

    public Sprite persianTitle, englishTitle;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetString("language") == "Persion")
            {
                GetComponent<Image>().sprite = persianTitle;
            }
            else if (PlayerPrefs.GetString("language") == "English")
            {
                GetComponent<Image>().sprite = englishTitle;

            }
        }
    }

           

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetString("language") == "Persion")
            {
                GetComponent<Image>().sprite = persianTitle;


            }
            else if (PlayerPrefs.GetString("language") == "English")
            {
                GetComponent<Image>().sprite = englishTitle;
            }
        }
    }
}
