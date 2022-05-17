using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteManager : MonoBehaviour
{
    [SerializeField] Image sounOnIcon;
    [SerializeField] Image sounOffIcon;
    private bool isMuted;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("isMuted"))
        {
            PlayerPrefs.SetInt("isMuted", 0);
            Load();
        }
        else
        {
            Load();
        }

        updateButtonIcon();
        AudioListener.pause = isMuted;


    }

    // Update is called once per frame
    public void onButtonPressed()
    {
        if (isMuted == false)
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = false;
        }

        Save();
        updateButtonIcon();
    }

    public void Load()
    {
        isMuted = PlayerPrefs.GetInt("isMuted") == 1;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
    }

    public void updateButtonIcon()
    {
        if(isMuted == false)
        {
            sounOnIcon.enabled = true;
            sounOffIcon.enabled = false;
        }
        else
        {
            sounOnIcon.enabled = false;
            sounOffIcon.enabled = true;
        }
    }
}
