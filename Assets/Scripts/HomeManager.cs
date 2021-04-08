using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{

	public GameObject mapPanel, vehiclePanel, upgradeCarPanel;

	public Text coinText;

	public GameObject purchasePanel, IAPPanel, settingPanel ;

	public Image soundImage, musicImage;

	public Sprite soundOn, soundOff, musicOn, musicOff;

	public static HomeManager _homeManager;

	public AudioSource mainMusic;
    public AudioSource coinSound;
    GameManager gamemager;
	// Use this for initialization

	void Awake ()
	{
       // PlayerPrefs.DeleteAll();
        //ChangeCoin(500000);
        _homeManager = this;
	}

	void Start ()
	{
		UpdateCoin ();
		LoadMusicAndSound ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void OpenMapPanel ()
	{
		mapPanel.SetActive (true);
		vehiclePanel.SetActive (false);
		upgradeCarPanel.SetActive (false);
	}

	public void OpenVehiclePanel ()
	{
		mapPanel.SetActive (false);
		vehiclePanel.SetActive (true);
		upgradeCarPanel.SetActive (false);
	}

	public void OpenUpgradeVehiclePanel ()
	{
		mapPanel.SetActive (false);
		vehiclePanel.SetActive (false);
		upgradeCarPanel.SetActive (true);
	}

	public void UpdateCoin ()
	{
		int _coin = PlayerPrefs.GetInt ("Coins");
        if (PlayerPrefs.GetString("language") == "English")
        {
            coinText.text = _coin.ToString();
        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            coinText.text = Fa.ToPersianNumber(_coin.ToString());   
        }
	}

    public void AddCoin(int coinsCount)
    {
       int _coins = PlayerPrefs.GetInt("Coins");
        _coins += coinsCount;
        PlayerPrefs.SetInt("Coins", _coins);

        if (PlayerPrefs.GetString("language") == "English")
        {
            coinText.text = _coins.ToString();
        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            coinText.text = Fa.ToPersianNumber(_coins.ToString());
        }

    }

	public void ChangeCoin (int _value)
	{
		int _coin = PlayerPrefs.GetInt ("Coins");
		_coin -= _value;
		PlayerPrefs.SetInt ("Coins", _coin);
        if (PlayerPrefs.GetString("language") == "English")
        {
            coinText.text = _coin.ToString();
        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            coinText.text = Fa.ToPersianNumber(_coin.ToString());
        }
	}

	public void ClosePurchase ()
	{
		purchasePanel.SetActive (false);
	}

	public void  OpenPurchase ()
	{
		purchasePanel.SetActive (true);
	}

	public void CloseIAP ()
	{
		IAPPanel.SetActive (false);
	}

	public void  OpenIAP ()
	{
		ClosePurchase ();
		CloseSetting ();
		IAPPanel.SetActive (true);
	}

	public void CloseSetting ()
	{
		settingPanel.SetActive (false);
	}

	public void SettingPanel ()
	{
		ClosePurchase ();
		CloseIAP ();
		settingPanel.SetActive (true);
	}

	public void PlayReward()
	{
		CloseIAP ();
        AdsControl.instance.PlayRewardedVideoForFillFuel();
	}
   

	public void ToggleMusic ()
	{
		if (PlayerPrefs.HasKey ("MusicVolume")) {
			if (PlayerPrefs.GetFloat ("MusicVolume") >= 1.0f) {
				PlayerPrefs.SetFloat ("MusicVolume", 0.0f);
				musicImage.sprite = musicOff;
				mainMusic.mute = true;
              //  gamemager.coinSound.mute = true;
            } else {
				PlayerPrefs.SetFloat ("MusicVolume", 1.0f);
				musicImage.sprite = musicOn;
				mainMusic.mute = false;
             //   gamemager.coinSound.mute = false;
            }
		} else {

			PlayerPrefs.SetFloat ("MusicVolume", 1.0f);
			musicImage.sprite = musicOn;
			mainMusic.mute = false;
         //   gamemager.coinSound.mute = false;

        }
    }

	public void ToggleSound ()
	{
		if (PlayerPrefs.HasKey ("EngineVolume")) {
			if (PlayerPrefs.GetFloat ("EngineVolume") >= 1.0f) {
				PlayerPrefs.SetFloat ("EngineVolume", 0.0f);
				soundImage.sprite = soundOff;
               
			} else {
				PlayerPrefs.SetFloat ("EngineVolume", 1.0f);
				soundImage.sprite = soundOn;
			}
		} else {
			PlayerPrefs.SetFloat ("EngineVolume", 1.0f);
			soundImage.sprite = soundOn;
		}
			
	}

	public void LoadMusicAndSound()
	{
		if (PlayerPrefs.HasKey ("MusicVolume")) {
			if (PlayerPrefs.GetFloat ("MusicVolume") >= 1.0f) {
				musicImage.sprite = musicOn;
				mainMusic.mute = false;
			} else {
				musicImage.sprite = musicOff;
				mainMusic.mute = true;
			}
		} else {
			PlayerPrefs.SetFloat ("MusicVolume", 1.0f);
			mainMusic.mute = false;
			musicImage.sprite = musicOn;
		}

		if (PlayerPrefs.HasKey ("EngineVolume")) {
			if (PlayerPrefs.GetFloat ("EngineVolume") >= 1.0f) {
				soundImage.sprite = soundOn;
			} else {
				soundImage.sprite = soundOff;
			}
		} else {
			PlayerPrefs.SetFloat ("EngineVolume", 1.0f);
			soundImage.sprite = soundOn;
		}
	}

    public void SetLanguageToEnglish()
    {
        PlayerPrefs.SetString("language", "English");

    }
    public void SetLanguageToPersion()
    {
        PlayerPrefs.SetString("language", "Persion");


    }
}
