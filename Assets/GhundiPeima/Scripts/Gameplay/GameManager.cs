//-----------------------------------------------
//
//This is  Game Manager that is responsible for manage Coins,Distance,Records and fuel
//Orginally writed for My game In Summer 2016   ALIyerEdon Unity 5.3.6f1234
//-----------------------------------------------/
using UnityEngine;
using System.Collections;


//include this for UI usage
using UnityEngine.UI;

//-----------------------------------------------
using UnityEngine.SceneManagement;


//Game Manager is responsible for Coins,Distance,Fuel...
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header ("Informations")]
	// UI-----------------------------------------------
	// For display Coins,Fuel , Record and distance
	public Text DistanceTXT;
	public Text RecordTXT;
	public Text CoinTXT;
	public Text FuelTXT;
	public Text LastRecord;

	[Header ("Sliders")]
	// SHow fuel amount
	public Slider FuelSlider;
	// Show passed distance on down of the screen
	public Slider DitanceSlider;
	//-----------------------------------------------

	//Manager-----------------------------------------------
	//player transform to read position as distance
    Transform player;
	//is game started?
	bool Started, Finished;

	//----------------------------------------------------

	[Header ("Fuel")]
	//fuel-----------------------------------------------
	// Total fuel
	public float TotalFuel = 100f;
	// Fuel reducing time step (delay in coroutine)
	public float FuelTime = .17f;
	// Fuel reduced amount by time
	float FuelVal = .3f;
	//-----------------------------------------------

	//Coin Manager-----------------------------------------------
	// Game total coins
	int Coins;
	//-----------------------------------------------

	[Header ("Coins And Awards")]
	//Get Coin Audio Source-----------------------------------------------
	//Receiving coind sound effect
	public AudioSource coinSound;



	// Awarded coin box (award based on distance)
	public GameObject coinAwardedBox;

	// Award text
	public Text awardedText;

	// Award box animator
	public Animator awardAnimator;


	[Header ("Complete Level")]
	// Win and lose windows
	public GameObject youWinMenu;
	public GameObject youLostMenu;

    public GameObject fuelAdsMenu;

	// How much coins give to player when finish the level?
	public int winnerAwardedCoins = 30000;

	public int targetDistance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    //Start-----------------------------------------------
    IEnumerator Start ()
	{
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
        if (PlayerPrefs.GetString("language") == "English")
        {
            DistanceTXT.text = "0";
        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            DistanceTXT.text = Fa.ToPersianNumber("0");
        }
        DitanceSlider.gameObject.SetActive (true);
		DitanceSlider.maxValue = targetDistance;
        if (PlayerPrefs.GetString("language") == "English")
        {
            //Coins Initialization-----------------------------------------------
            Coins = PlayerPrefs.GetInt("Coins");   //read total scrore from saved Coins
            CoinTXT.text = Coins.ToString();   // Display total coins on Start
                                               //-----------------------------------------------
        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            //Coins Initialization-----------------------------------------------
            Coins = PlayerPrefs.GetInt("Coins");   //read total scrore from saved Coins
            CoinTXT.text = Fa.ToPersianNumber(Coins.ToString());   // Display total coins on Start

            //-----------------------------------------------
        }

        //Start Main Game   -----------------------------------------------
        yield return new WaitForEndOfFrame ();   //Player is Spawned afer milisecond. we wait .3 and then find it
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		Started = true;   // The game is now started. you can run your codes on update function
		Finished = false;
		//-----------------------------------------------
		////-----------------------------------------------
		/// 
		// Read if distance based award is already gived for current level, Set it to gived
		if (PlayerPrefs.GetInt ("c500" + PlayerPrefs.GetInt ("SelectedLevel").ToString ()) == 3) {
			c500 = true;
            if (PlayerPrefs.GetString("language") == "English")
            {
                LastRecord.text = "Record:500";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                LastRecord.text = Fa.ToPersianNumber("500") + Fa.faConvert("رکورد :");
            }

        }
		if (PlayerPrefs.GetInt ("c1000" + PlayerPrefs.GetInt ("SelectedLevel").ToString ()) == 3) {
			c1000 = true;
            if (PlayerPrefs.GetString("language") == "English")
            {
                LastRecord.text = "Record:1000";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                LastRecord.text = Fa.ToPersianNumber("1000") + Fa.faConvert("رکورد :");
            }
		}
		if (PlayerPrefs.GetInt ("c1500" + PlayerPrefs.GetInt ("SelectedLevel").ToString ()) == 3) {
			c1500 = true;
            if (PlayerPrefs.GetString("language") == "English")
            {
                LastRecord.text = "Record:1500";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                LastRecord.text = Fa.ToPersianNumber("1500") + Fa.faConvert("رکورد :");
            }
        }
		if (PlayerPrefs.GetInt ("c2000" + PlayerPrefs.GetInt ("SelectedLevel").ToString ()) == 3) {
			c2000 = true;
            if (PlayerPrefs.GetString("language") == "English")
            {
                LastRecord.text = "Record:2000";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                LastRecord.text = Fa.ToPersianNumber("2000") + Fa.faConvert("رکورد :");
            }
        }
		if (PlayerPrefs.GetInt ("c2500" + PlayerPrefs.GetInt ("SelectedLevel").ToString ()) == 3) {
			c2500 = true;
            if (PlayerPrefs.GetString("language") == "English")
            {
                LastRecord.text = "Record:2500";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                LastRecord.text = Fa.ToPersianNumber("2500") + Fa.faConvert("رکورد :");
            }
        }
		if (PlayerPrefs.GetInt ("c3000" + PlayerPrefs.GetInt ("SelectedLevel").ToString ()) == 3) {
			c3000 = true;
            if (PlayerPrefs.GetString("language") == "English")
            {
                LastRecord.text = "Record:3000";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                LastRecord.text = Fa.ToPersianNumber("3000") + Fa.faConvert("رکورد :");
            }
        }
		if (PlayerPrefs.GetInt ("c3500" + PlayerPrefs.GetInt ("SelectedLevel").ToString ()) == 3) {
			c3500 = true;
            if (PlayerPrefs.GetString("language") == "English")
            {
                LastRecord.text = "Record:3500";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                LastRecord.text = Fa.ToPersianNumber("3500") + Fa.faConvert("رکورد :");
            }
        }
		if (PlayerPrefs.GetInt ("c4000" + PlayerPrefs.GetInt ("SelectedLevel").ToString ()) == 3) {
			c4000 = true;
            if (PlayerPrefs.GetString("language") == "English")
            {
                LastRecord.text = "Record:4000";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                LastRecord.text = Fa.ToPersianNumber("4000") + Fa.faConvert("رکورد :");
            }
        }




		//Fuel Decreso  r//-----------------------------------------------
		while (!Finished) {//responsible to decrese fuel amount by   time and value read from upgrade   menu
			yield return new WaitForSeconds (FuelTime);
			TotalFuel -= FuelVal;
			FuelSlider.value = TotalFuel;
			if (TotalFuel >= 0)
            {
                if (PlayerPrefs.GetString("language") == "English")
                {
                    FuelTXT.text = Mathf.Floor(TotalFuel).ToString();
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    FuelTXT.text = Fa.ToPersianNumber(Mathf.Floor(TotalFuel).ToString());
                    
                }
               

            }
            if (TotalFuel < 0) {
				//youLostMenu.SetActive (true);
				//Time.timeScale = 0;
				fuelFinished = true;
				StartFuelFinish ();

			}
		}

	}
	//-----------------------------------------------


	// Update -----------------------------------------------
	float DistanceTemp;

	void Update ()
	{
		
		if (Started) {
			CoinDistance ();
			if (player.position.x >= DistanceTemp) {

                if (PlayerPrefs.GetString("language") == "English")
                {
                    DistanceTXT.text = Mathf.Floor(player.position.x).ToString();
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                     DistanceTXT.text = Fa.ToPersianNumber(Mathf.Floor(player.position.x).ToString());
                }
                DistanceTemp = player.position.x;
				DitanceSlider.value = player.position.x;
			}

		}
	}
	//-----------------------------------------------

	//Add Coin-----------------------------------------------
	public void AddCoin (int value)
	{//add Coin called from coins trigger
		
		StartCoroutine (TakeCoins ());

		CoinTXT.transform.localScale = new Vector3 (CoinTXT.transform.localScale.x, CoinTXT.transform.localScale.y + 0.7f,
			CoinTXT.transform.localScale.z);

		if (coinSound)
			coinSound.Play ();
		Coins += value;
        if (PlayerPrefs.GetString("language") == "English")
        {
            
            CoinTXT.text = Coins.ToString(); 
        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            CoinTXT.text = Fa.ToPersianNumber(Coins.ToString());  
        }
		PlayerPrefs.SetInt ("Coins", Coins);
	}
	//-----------------------------------------------

	IEnumerator TakeCoins ()
	{
		yield return new WaitForSeconds (0.03f);
		CoinTXT.transform.localScale = new Vector3 (CoinTXT.transform.localScale.x, CoinTXT.transform.localScale.y - 0.7f,
			CoinTXT.transform.localScale.z);
	}

	//Add Fuel-----------------------------------------------
	public void AddFuel (int value)
	{//add fuel called from Fuel Trigger  s
		if (coinSound)
			coinSound.Play ();
		TotalFuel = value;
		//CoinTXT.text = Coins.ToString ();
		//PlayerPrefs.SetInt ("Coins", Coins);
	}
    //-----------------------------------------------

    //Add Fuel After Ads-----------------------------
    public void FillFuelAfterAds(int value)
    {
        TotalFuel = value;
        fuelAdsMenu.SetActive(false);
        
        Time.timeScale = 1f;
       
    }
    //-----------------------------------------------


    bool c500, c1000, c1500, c2000, c2500, c3000, c3500, c4000;

	// Distance based award
	void CoinDistance ()
	{
		if (!c500) {
			if (player.transform.position.x >= 500 && player.transform.position.x < 1000) {
				AddCoin (50);
				coinAwardedBox.SetActive (true);
				awardAnimator.SetBool ("Award", true);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    awardedText.text = "50 Coins Awarded";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    awardedText.text = Fa.faConvert(" سکه جایزه داده شد  ") + Fa.ToPersianNumber("50") ;
                }
                StartCoroutine (Awardfalse ());
				c500 = true;
				PlayerPrefs.SetInt ("c500" + PlayerPrefs.GetInt ("SelectedLevel").ToString (), 3);// 3 => true | 0 => false
                if (PlayerPrefs.GetString("language") == "English")
                {
                    LastRecord.text = "Record:500";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    LastRecord.text = Fa.ToPersianNumber("500") + Fa.faConvert("رکورد :");
                }
            }
		}
		if (!c1000 && c500) {
			if (player.transform.position.x >= 1000 && player.transform.position.x < 1500) {
				AddCoin (100);
				coinAwardedBox.SetActive (true);
				awardAnimator.SetBool ("Award", true);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    awardedText.text = "100 Coins Awarded";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    awardedText.text = Fa.faConvert(" سکه جایزه داده شد") + Fa.ToPersianNumber("100");
                }
				StartCoroutine (Awardfalse ());
				c1000 = true;
				PlayerPrefs.SetInt ("c1000" + PlayerPrefs.GetInt ("SelectedLevel").ToString (), 3);// 3 => true | 0 => false
                if (PlayerPrefs.GetString("language") == "English")
                {
                    LastRecord.text = "Record:1000";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    LastRecord.text = Fa.ToPersianNumber("1000") + Fa.faConvert("رکورد :");
                }
            }
		}
		if (!c1500 && c1000) {
			if (player.transform.position.x >= 1500 && player.transform.position.x < 2000) {
				AddCoin (150);
				coinAwardedBox.SetActive (true);
				awardAnimator.SetBool ("Award", true);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    awardedText.text = "150 Coins Awarded";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    awardedText.text = Fa.faConvert(" سکه جایزه داده شد  ") + Fa.ToPersianNumber("150");
                }
				StartCoroutine (Awardfalse ());
				c1500 = true;
				PlayerPrefs.SetInt ("c1500" + PlayerPrefs.GetInt ("SelectedLevel").ToString (), 3);// 3 => true | 0 => false
                if (PlayerPrefs.GetString("language") == "English")
                {
                    LastRecord.text = "Record:1500";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    LastRecord.text = Fa.ToPersianNumber("1500") + Fa.faConvert("رکورد :");
                }
            }
		}
		if (!c2000 && c1500) {
			if (player.transform.position.x >= 2000 && player.transform.position.x < 2500) {
				AddCoin (200);
				coinAwardedBox.SetActive (true);
				awardAnimator.SetBool ("Award", true);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    awardedText.text = "200 Coins Awarded";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    awardedText.text = Fa.faConvert("سکه جایزه داده شد  ") + Fa.ToPersianNumber("200");
                }
				StartCoroutine (Awardfalse ());
				c2000 = true;
				PlayerPrefs.SetInt ("c2000" + PlayerPrefs.GetInt ("SelectedLevel").ToString (), 3);// 3 => true | 0 => false
                if (PlayerPrefs.GetString("language") == "English")
                {
                    LastRecord.text = "Record:2000";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    LastRecord.text = Fa.ToPersianNumber("2000") + Fa.faConvert("رکورد :");
                }
            }
		}
		if (!c2500 && c2000) {
			if (player.transform.position.x >= 2500 && player.transform.position.x < 3000) {
				AddCoin (250);
				coinAwardedBox.SetActive (true);
				awardAnimator.SetBool ("Award", true);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    awardedText.text = "250 Coins Awarded";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    awardedText.text = Fa.faConvert("سکه جایزه داده شد  ") + Fa.ToPersianNumber("250");
                }
				StartCoroutine (Awardfalse ());
				c2500 = true;
				PlayerPrefs.SetInt ("c2500" + PlayerPrefs.GetInt ("SelectedLevel").ToString (), 3);// 3 => true | 0 => false
                if (PlayerPrefs.GetString("language") == "English")
                {
                    LastRecord.text = "Record:2500";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    LastRecord.text = Fa.ToPersianNumber("2500") + Fa.faConvert("رکورد :");
                }
            }
		}
		if (!c3000 && c2500) {
			if (player.transform.position.x >= 3000 && player.transform.position.x < 3500) {
				AddCoin (300);
				coinAwardedBox.SetActive (true);
				awardAnimator.SetBool ("Award", true);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    awardedText.text = "300 Coins Awarded";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    awardedText.text = Fa.faConvert("سکه جایزه داده شد  ") + Fa.ToPersianNumber("300");
                }
				StartCoroutine (Awardfalse ());
				c3000 = true;
				PlayerPrefs.SetInt ("c3000" + PlayerPrefs.GetInt ("SelectedLevel").ToString (), 3);// 3 => true | 0 => false
                if (PlayerPrefs.GetString("language") == "English")
                {
                    LastRecord.text = "Record:3000";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    LastRecord.text = Fa.ToPersianNumber("3000") + Fa.faConvert("رکورد :");
                }
            }
		}
		if (!c3500 && c3000) {
			if (player.transform.position.x >= 3500 && player.transform.position.x < 4000) {
				AddCoin (350);
				coinAwardedBox.SetActive (true);
				awardAnimator.SetBool ("Award", true);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    awardedText.text = "350 Coins Awarded";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    awardedText.text = Fa.faConvert("سکه جایزه داده شد  ") + Fa.ToPersianNumber("350");
                }
				StartCoroutine (Awardfalse ());
				c3500 = true;
				PlayerPrefs.SetInt ("c3500" + PlayerPrefs.GetInt ("SelectedLevel").ToString (), 3);// 3 => true | 0 => false
                if (PlayerPrefs.GetString("language") == "English")
                {
                    LastRecord.text = "Record:3500";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    LastRecord.text = Fa.ToPersianNumber("3500") + Fa.faConvert("رکورد :");
                }
            }
		}
		if (!c4000 && c3500) {
			if (player.transform.position.x >= 4000 && player.transform.position.x < 4500) {
				AddCoin (400);
				coinAwardedBox.SetActive (true);
				awardAnimator.SetBool ("Award", true);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    awardedText.text = "400 Coins Awarded";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    awardedText.text = Fa.faConvert("سکه جایزه داده شد  ") + Fa.ToPersianNumber("400");
                }
				StartCoroutine (Awardfalse ());
				c4000 = true;
				PlayerPrefs.SetInt ("c4000" + PlayerPrefs.GetInt ("SelectedLevel").ToString (), 3);// 3 => true | 0 => false
                if (PlayerPrefs.GetString("language") == "English")
                {
                    LastRecord.text = "Record:4000";
                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    LastRecord.text = Fa.ToPersianNumber("4000") + Fa.faConvert("رکورد :");
                }               //youWinMenu.SetActive (true);
                                //AddCoin (winnerAwardedCoins);
                                //GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().isKinematic = true;
            }
		}
		//Debug.Log ("Distance " + player.transform.position.x);
		if (player.transform.position.x >= targetDistance && !Finished) {
			Finished = true;
			//AdsControl.Instance.showAds ();

            // deprecated one:
            //PlayerPrefs.SetInt ("BestDistance" + (Application.loadedLevel - 1).ToString (), Mathf.CeilToInt (player.position.x));

            //new one:
            PlayerPrefs.SetInt("BestDistance" + (SceneManager.GetActiveScene().buildIndex - 1).ToString(), Mathf.CeilToInt(player.position.x));

            youWinMenu.SetActive (true);
            Time.timeScale = 0;
        
            AddCoin(winnerAwardedCoins);
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().isKinematic = true;
		}

	}



	IEnumerator Awardfalse ()
	{
		
		yield return new WaitForSeconds (3f);
		awardAnimator.SetBool ("Award", false);
		yield return new WaitForSeconds (3f);
		coinAwardedBox.SetActive (false);
	}

	[HideInInspector]
	public bool isDead;

	public void StartDead ()
	{
		StartCoroutine (Dead ()); 
	}

	IEnumerator Dead ()
	{
		yield return new WaitForSeconds (3f);
		if (isDead) {
            print("show ads before Dead");
            //AdsControl.Instance.showAds ();
            //AdsControl.Instance.ShowRewardVideo();

            PlayerPrefs.SetInt("BestDistance" + (SceneManager.GetActiveScene().buildIndex - 1).ToString(), Mathf.CeilToInt(player.position.x));
            youLostMenu.SetActive (true);
			Time.timeScale = 0;
		}

	}

	[HideInInspector]
	public bool fuelFinished;


	public void StartFuelFinish ()
	{
		//StartCoroutine (DeadFuel ());
        ActivateFuelAdsMenu();

    }

	IEnumerator DeadFuel ()
	{
		yield return new WaitForSeconds (1f);
		if (fuelFinished) {
			youLostMenu.SetActive (true);
			Time.timeScale = 0;
		}

	}

    public void ActivateFuelAdsMenu()
    {
        if (fuelFinished)
        {
            fuelAdsMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ActivateYouLostMenu()
    {
       // Time.timeScale = 1f;
        fuelAdsMenu.SetActive(false);

        youLostMenu.SetActive(true);
        Time.timeScale = 0;
    }

}