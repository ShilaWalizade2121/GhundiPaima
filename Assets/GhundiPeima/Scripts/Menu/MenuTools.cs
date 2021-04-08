using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuTools : MonoBehaviour {



	// Player starting game in first time score
	public int startScore;

	public Text CoinsTXT;

	[Header("Menu Resolution")]
	public int ResolutionX = 1280;
	public int ResolutionY = 720;

	public GameObject manuMusic;
    public GameObject btnMusic;

    public Image soundImage, musicImage;
    public Sprite soundOn, soundOff, musicOn, musicOff;
    //  public AudioSource mainMusic;

    GameObject title;

    private void Awake()
    {
       // PlayerPrefs.SetString("language", "Persion");
    }


    void Start () {

         title = GameObject.Find("Title") as GameObject;

        LoadMusicAndSound();  

        if (GameObject.Find ("LevelMusic(Clone)"))
			Destroy (GameObject.Find ("LevelMusic(Clone)"));

		if(!GameObject.Find("MenuMusic(Clone)"))
			Instantiate (manuMusic, Vector3.zero, Quaternion.identity);
		
		if (PlayerPrefs.GetString ("FirstRun") != "True") {

			PlayerPrefs.SetString ("FirstRun", "True");
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + startScore);

			PlayerPrefs.SetInt ("Resolution", 2);// 3 => true | 0 => false

			PlayerPrefs.SetFloat ("EngineVolume", 0.74f);
			PlayerPrefs.SetFloat ("MusicVolume", 1f);
			PlayerPrefs.SetInt ("ShowDistance", 3);
			PlayerPrefs.SetInt ("CoinAudio", 3); 

			PlayerPrefs.SetInt ("Car0", 3);// 3 => true | 0 => false
			PlayerPrefs.SetInt ("Level0", 3);// 3 => true | 0 => false


		}



			Screen.SetResolution(ResolutionX,ResolutionY,true);
			Camera.main.aspect  = 16f/9f;



		if(PlayerPrefs.GetInt("Loaded")!=3)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			PlayerPrefs.SetInt("Loaded",3);
		}
		else
			PlayerPrefs.SetInt("Loaded",7);
		
		CoinsTXT.text = PlayerPrefs.GetInt ("Coins").ToString ();
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.H)) {
			PlayerPrefs.DeleteAll ();
			CoinsTXT.text = PlayerPrefs.GetInt ("Coins").ToString ();
            PlayerPrefs.SetString("language", "Persion");
            #if UNITY_EDITOR
            Debug.Log("PlayerPrefs.DeleteAll");
			#endif

		}
		if (Input.GetKeyDown (KeyCode.V)) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + startScore);
			CoinsTXT.text = PlayerPrefs.GetInt ("Coins").ToString ();
			#if UNITY_EDITOR
			Debug.Log(PlayerPrefs.GetInt ("Coins").ToString()); 
			#endif

		}
	}


	public void SetTrue(GameObject target)
	{
		target.SetActive (true);
	}
    public void SetAboutPanelTrue(GameObject target)
    {
        
        FindObjectOfType<TitleChanger>().gameObject.SetActive(false);
        target.SetActive(true);
    }
    public void SetFalse(GameObject target)
	{
		target.SetActive (false);
	}
    public void SetAboutPanelFalse(GameObject target)
    {

        target.SetActive(false);
        title.gameObject.SetActive(true);

    }
    public void ToggleObject(GameObject target)
	{
		target.SetActive (!target.activeSelf);
	}
	public void LoadLevel(string name)
	{
		SceneManager.LoadScene (name);
	}
	public void OpenURL(string url)
	{
		Application.OpenURL (url);
	}
	public void LoadLevelAsync(string name)
	{
		SceneManager.LoadSceneAsync (name);
	}
	public void Exit()
	{
		Application.Quit ();
	}
    public void SetLanguageToEnglish()
    {
        PlayerPrefs.SetString("language", "English");

    }
    public void SetLanguageToPersion()
    {
        PlayerPrefs.SetString("language", "Persion");


    }



    public void ToggleMusic()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            if (PlayerPrefs.GetFloat("MusicVolume") >= 1.0f)
            {
                PlayerPrefs.SetFloat("MusicVolume", 0.0f);
                musicImage.sprite = musicOff;
                manuMusic.GetComponent<AudioSource>().mute = true;
            }
            else
            {
                PlayerPrefs.SetFloat("MusicVolume", 1.0f);
                musicImage.sprite = musicOn;
                manuMusic.GetComponent<AudioSource>().mute = false;
            }
        }
        else
        {

            PlayerPrefs.SetFloat("MusicVolume", 1.0f);
            musicImage.sprite = musicOn;
            manuMusic.GetComponent<AudioSource>().mute = false;
        }
    }
    public void ToggleSound()
    {
        if (PlayerPrefs.HasKey("EngineVolume"))
        {
            if (PlayerPrefs.GetFloat("EngineVolume") >= 1.0f)
            {
                PlayerPrefs.SetFloat("EngineVolume", 0.0f);
                soundImage.sprite = soundOff;
            }
            else
            {
                PlayerPrefs.SetFloat("EngineVolume", 1.0f);
                soundImage.sprite = soundOn;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("EngineVolume", 1.0f);
            soundImage.sprite = soundOn;
        }

    }
    public void LoadMusicAndSound()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            if (PlayerPrefs.GetFloat("MusicVolume") >= 1.0f)
            {
                musicImage.sprite = musicOn;
                manuMusic.GetComponent<AudioSource>().mute = false;
                btnMusic.GetComponent<AudioSource>().mute = false;

            }
            else
            {
                musicImage.sprite = musicOff;
                manuMusic.GetComponent<AudioSource>().mute = true;
                btnMusic.GetComponent<AudioSource>().mute = true;

            }
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", 1.0f);
            manuMusic.GetComponent<AudioSource>().mute = false;
            btnMusic.GetComponent<AudioSource>().mute = false;

            musicImage.sprite = musicOn;
        }

        if (PlayerPrefs.HasKey("EngineVolume"))
        {
            if (PlayerPrefs.GetFloat("EngineVolume") >= 1.0f)
            {
                soundImage.sprite = soundOn;
            }
            else
            {
                soundImage.sprite = soundOff;
            }
        }
        else
        {
            PlayerPrefs.SetFloat("EngineVolume", 1.0f);
            soundImage.sprite = soundOn;
        }
    }
}
	