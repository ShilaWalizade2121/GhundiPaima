using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeCar : MonoBehaviour
{

    public Sprite _select, _unSelect;

    public UpgradeItem[] _item;

    public Text priceText, contentText, headText;

    public int _type;

    public GameObject loading;

    int id;

    public Image MainIcon, icon1, icon2, icon3, icon4;

    [HideInInspector] public int Engine, Fuel, Suspension, Speed;

    // Use this for initialization
    void Start()
    {

        SetChooseItem(0);
        LoadUpgrade();
        MainIcon.sprite = icon1.sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetChooseItem(int _index)
    {
        contentText.text = _item[_index]._content;
        _type = _index;
        if (_index == 0)
        {
            if (PlayerPrefs.GetInt("Engine" + id.ToString()) == _item[0].price.Length)
            {
                return;
            }
            MainIcon.sprite = icon1.sprite;
            _item[0]._border.sprite = _select;
            _item[1]._border.sprite = _unSelect;
            _item[2]._border.sprite = _unSelect;
            _item[3]._border.sprite = _unSelect;

            
            if (PlayerPrefs.GetString("language") == "English")
            {
                priceText.text = "Upgrade cost : " + _item[0].price[PlayerPrefs.GetInt("Engine" + id.ToString())].ToString() + " coins";
                headText.text = "Upgrade Engine";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                priceText.text = Fa.faConvert(" سکه ") + Fa.ToPersianNumber(_item[0].price[PlayerPrefs.GetInt("Engine" + id.ToString())].ToString()) + Fa.faConvert("هزينه بهبود کردن : ");
                headText.text = Fa.faConvert("بهبود کردن موتور");
            }
           
        }
        else if (_index == 1)
        {
          
                MainIcon.sprite = icon2.sprite;
            _item[0]._border.sprite = _unSelect;
            _item[1]._border.sprite = _select;
            _item[2]._border.sprite = _unSelect;
            _item[3]._border.sprite = _unSelect;
            if (PlayerPrefs.GetString("language") == "English")
            {
                priceText.text = "Upgrade cost : " + _item[1].price[PlayerPrefs.GetInt("Suspension" + id.ToString())].ToString() + " coins";
                headText.text = "Upgrade Suspension";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                priceText.text = Fa.faConvert(" سکه ") + Fa.ToPersianNumber(_item[1].price[PlayerPrefs.GetInt("Suspension" + id.ToString())].ToString()) + Fa.faConvert("هزينه بهبود کردن : ");
                headText.text = Fa.faConvert("بهبود کردن چرخ آويزى");
            }

        }
        else if (_index == 2)
        {
           
            MainIcon.sprite = icon3.sprite;
            _item[0]._border.sprite = _unSelect;
            _item[1]._border.sprite = _unSelect;
            _item[2]._border.sprite = _select;
            _item[3]._border.sprite = _unSelect;
            if (PlayerPrefs.GetString("language") == "English")
            {
                priceText.text = "Upgrade cost : " + _item[2].price[PlayerPrefs.GetInt("Speed" + id.ToString())].ToString() + " coins";
                headText.text = "Upgrade Tired";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                priceText.text = Fa.faConvert(" سکه ") + Fa.ToPersianNumber(_item[2].price[PlayerPrefs.GetInt("Speed" + id.ToString())].ToString()) + Fa.faConvert("هزينه بهبود کردن : ");
                headText.text = Fa.faConvert("بهبود کردن تایر");
            }

        }
        else if (_index == 3)
        {
           
            MainIcon.sprite = icon4.sprite;
            _item[0]._border.sprite = _unSelect;
            _item[1]._border.sprite = _unSelect;
            _item[2]._border.sprite = _unSelect;
            _item[3]._border.sprite = _select;
            if (PlayerPrefs.GetString("language") == "English")
            {
                priceText.text = "Upgrade cost : " + _item[3].price[PlayerPrefs.GetInt("Fuel" + id.ToString())].ToString() + " coins";
                headText.text = "Upgrade Fuel";
            }
            else if (PlayerPrefs.GetString("language") == "Persion")
            {
                priceText.text = Fa.faConvert(" سکه ") + Fa.ToPersianNumber(_item[3].price[PlayerPrefs.GetInt("Fuel" + id.ToString())].ToString()) + Fa.faConvert("هزينه بهبود کردن : ");
                headText.text = Fa.faConvert("بهبود کردن سوخت");
            }

        }
    }

    public void Upgrade()
    {
        if (_type == 0)
            EngineUpgrade();
        else if (_type == 1)
            SuspensionUpgrade();
        else if (_type == 2)
            SpeedUpgrade();
        else if (_type == 3) 
            FuelUpgrade();
       
    }

    public void LoadUpgrade()
    {


        id = PlayerPrefs.GetInt("SelectedCar");

        Engine = PlayerPrefs.GetInt("Coins" + id.ToString());
        Fuel = PlayerPrefs.GetInt("Fuel" + id.ToString());
        Suspension = PlayerPrefs.GetInt("Suspension" + id.ToString());
        Speed = PlayerPrefs.GetInt("Speed" + id.ToString());


        if (PlayerPrefs.GetString("language") == "English")
        {
            _item[0].levelInfo.text = "Level: " + PlayerPrefs.GetInt("Engine" + id.ToString()).ToString() + " / " + _item[0].price.Length.ToString();
            _item[1].levelInfo.text = "Level: " + PlayerPrefs.GetInt("Suspension" + id.ToString()).ToString() + " / " + _item[1].price.Length.ToString();
            _item[2].levelInfo.text = "Level: " + PlayerPrefs.GetInt("Speed" + id.ToString()).ToString() + " / " + _item[2].price.Length.ToString();
            _item[3].levelInfo.text = "Level: " + PlayerPrefs.GetInt("Fuel" + id.ToString()).ToString() + " / " + _item[3].price.Length.ToString();
        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            _item[0].levelInfo.text = Fa.ToPersianNumber(PlayerPrefs.GetInt("Engine" + id.ToString()).ToString()) + " / " + Fa.ToPersianNumber(_item[0].price.Length.ToString()) + Fa.faConvert("سطح : ");
            _item[1].levelInfo.text = Fa.ToPersianNumber(PlayerPrefs.GetInt("Suspension" + id.ToString()).ToString()) + " / " + Fa.ToPersianNumber(_item[1].price.Length.ToString()) + Fa.faConvert("سطح : ");
            _item[2].levelInfo.text = Fa.ToPersianNumber(PlayerPrefs.GetInt("Speed" + id.ToString()).ToString()) + " / " + Fa.ToPersianNumber(_item[2].price.Length.ToString()) + Fa.faConvert("سطح : ");
            _item[3].levelInfo.text = Fa.ToPersianNumber(PlayerPrefs.GetInt("Fuel" + id.ToString()).ToString()) + " / " + Fa.ToPersianNumber(_item[3].price.Length.ToString()) + Fa.faConvert("سطح : ");
        }


    }




    public void EngineUpgrade()
    {
        if (PlayerPrefs.GetInt("Engine" + id.ToString()) >= _item[0].price.Length)
        {
            return;
        }

        SetChooseItem(0);
      
            if (PlayerPrefs.GetInt("Engine" + id.ToString()) < _item[0].price.Length)
        {

            if (PlayerPrefs.GetInt("Coins") >= _item[0].price[PlayerPrefs.GetInt("Engine" + id.ToString())])
            {
                HomeManager._homeManager.ChangeCoin(_item[0].price[PlayerPrefs.GetInt("Engine" + id.ToString())]);
                PlayerPrefs.SetInt("Engine" + id.ToString(), PlayerPrefs.GetInt("Engine" + id.ToString()) + 1);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    _item[0].levelInfo.text = "Level: " + PlayerPrefs.GetInt("Engine" + id.ToString()).ToString() + " / " + _item[0].price.Length.ToString();

                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    _item[0].levelInfo.text = Fa.ToPersianNumber(PlayerPrefs.GetInt("Engine" + id.ToString()).ToString()) + " / " + Fa.ToPersianNumber(_item[0].price.Length.ToString()) + Fa.faConvert("سطح : ");

                }
              
                    if (PlayerPrefs.GetInt("Engine" + id.ToString()) < _item[0].price.Length)
                {
                    if (PlayerPrefs.GetString("language") == "English")
                    {
                        priceText.text = "Upgrade cost : " + _item[0].price[PlayerPrefs.GetInt("Engine" + id.ToString())].ToString() + " coins";
                    }
                    else if (PlayerPrefs.GetString("language") == "Persion")
                    {
                        priceText.text = Fa.faConvert(" سکه ") + Fa.ToPersianNumber(_item[0].price[PlayerPrefs.GetInt("Engine" + id.ToString())].ToString()) + Fa.faConvert("هزينه بهبود کردن : ");
                    }

                }
                else
                {
                    
                    if (PlayerPrefs.GetString("language") == "English")
                    {
                        priceText.text = "Completed";
                    }
                    else if (PlayerPrefs.GetString("language") == "Persion")
                    {
                        priceText.text = Fa.faConvert("تکمیل شد");
                    }
                }
                return;
            }
            else
            {
                HomeManager._homeManager.OpenPurchase();


            }

        }
    }

    public void SuspensionUpgrade()
    {

        if (PlayerPrefs.GetInt("Suspension" + id.ToString()) >= _item[1].price.Length)
        {
            return;
        }
        SetChooseItem(1);
       
        if (PlayerPrefs.GetInt("Suspension" + id.ToString()) < _item[1].price.Length)
        {

            if (PlayerPrefs.GetInt("Coins") >= _item[1].price[PlayerPrefs.GetInt("Suspension" + id.ToString())])
            {

                HomeManager._homeManager.ChangeCoin(_item[1].price[PlayerPrefs.GetInt("Suspension" + id.ToString())]);
                PlayerPrefs.SetInt("Suspension" + id.ToString(), PlayerPrefs.GetInt("Suspension" + id.ToString()) + 1);

               
                if (PlayerPrefs.GetString("language") == "English")
                {
                    _item[1].levelInfo.text = "Level: " + PlayerPrefs.GetInt("Suspension" + id.ToString()).ToString() + " / " + _item[1].price.Length.ToString();
                    if (PlayerPrefs.GetInt("Suspension" + id.ToString()) < _item[1].price.Length)
                        priceText.text = "Upgrade cost : " + _item[1].price[PlayerPrefs.GetInt("Suspension" + id.ToString())].ToString() + " coins";
                    else
                        priceText.text = "Completed";

                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    _item[1].levelInfo.text = Fa.ToPersianNumber(PlayerPrefs.GetInt("Suspension" + id.ToString()).ToString()) + " / " + Fa.ToPersianNumber(_item[1].price.Length.ToString()) + Fa.faConvert("سطح : ");
                    if (PlayerPrefs.GetInt("Suspension" + id.ToString()) < _item[1].price.Length)
                        priceText.text = Fa.faConvert(" سکه ") + Fa.ToPersianNumber(_item[1].price[PlayerPrefs.GetInt("Suspension" + id.ToString())].ToString()) + Fa.faConvert("هزينه بهبود کردن : ");
                    else
                        priceText.text = Fa.faConvert("تکمیل شد");

                }

            }
            else
            {
                HomeManager._homeManager.OpenPurchase();
            }
        }
    }

    public void SpeedUpgrade()
    {
        if (PlayerPrefs.GetInt("Speed" + id.ToString()) >= _item[2].price.Length)
        {
            return;
        }

        SetChooseItem(2);
        if (PlayerPrefs.GetInt("Speed" + id.ToString()) < _item[2].price.Length)
        {
           
            if (PlayerPrefs.GetInt("Coins") >= _item[2].price[PlayerPrefs.GetInt("Speed" + id.ToString())])
            {

                HomeManager._homeManager.ChangeCoin(_item[2].price[PlayerPrefs.GetInt("Speed" + id.ToString())]);
                PlayerPrefs.SetInt("Speed" + id.ToString(), PlayerPrefs.GetInt("Speed" + id.ToString()) + 1);
                if (PlayerPrefs.GetString("language") == "English")
                {
                    _item[2].levelInfo.text = "Level: " + PlayerPrefs.GetInt("Speed" + id.ToString()).ToString() + " / " + _item[0].price.Length.ToString();

                    if (PlayerPrefs.GetInt("Speed" + id.ToString()) < _item[2].price.Length)
                        priceText.text = "Upgrade cost : " + _item[2].price[PlayerPrefs.GetInt("Speed" + id.ToString())].ToString() + " coins";
                    else
                        priceText.text = "Completed";

                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    _item[2].levelInfo.text = Fa.ToPersianNumber(PlayerPrefs.GetInt("Speed" + id.ToString()).ToString()) + " / " + Fa.ToPersianNumber(_item[2].price.Length.ToString()) + Fa.faConvert("سطح : ");
                    if (PlayerPrefs.GetInt("Speed" + id.ToString()) < _item[2].price.Length)
                        priceText.text = Fa.faConvert(" سکه ") + Fa.ToPersianNumber(_item[2].price[PlayerPrefs.GetInt("Speed" + id.ToString())].ToString()) + Fa.faConvert("هزينه بهبود کردن : ");
                    else
                        priceText.text = Fa.faConvert("تکمیل شد");

                }


            }
            else
            {

                HomeManager._homeManager.OpenPurchase();

            }
        }
    }

     public void FuelUpgrade()
    {

        if (PlayerPrefs.GetInt("Fuel" + id.ToString()) >= _item[3].price.Length)
        {
            return;
        }
        SetChooseItem(3);
        if (PlayerPrefs.GetInt("Fuel" + id.ToString()) < _item[3].price.Length)
        {

            if (PlayerPrefs.GetInt("Coins") >= _item[3].price[PlayerPrefs.GetInt("Fuel" + id.ToString())])
            {

                HomeManager._homeManager.ChangeCoin(_item[3].price[PlayerPrefs.GetInt("Fuel" + id.ToString())]);
                PlayerPrefs.SetInt("Fuel" + id.ToString(), PlayerPrefs.GetInt("Fuel" + id.ToString()) + 1);

                if (PlayerPrefs.GetString("language") == "English")
                {
                    _item[3].levelInfo.text = "Level: " + PlayerPrefs.GetInt("Fuel" + id.ToString()).ToString() + " / " + _item[3].price.Length.ToString();

                    if (PlayerPrefs.GetInt("Fuel" + id.ToString()) < _item[3].price.Length)
                        priceText.text = "Upgrade cost : " + _item[3].price[PlayerPrefs.GetInt("Fuel" + id.ToString())].ToString() + " coins";
                    else
                        priceText.text = "Completed";

                }
                else if (PlayerPrefs.GetString("language") == "Persion")
                {
                    _item[3].levelInfo.text = Fa.ToPersianNumber(PlayerPrefs.GetInt("Fuel" + id.ToString()).ToString()) + " / " + Fa.ToPersianNumber(_item[3].price.Length.ToString()) + Fa.faConvert("سطح : ");
                    if (PlayerPrefs.GetInt("Fuel" + id.ToString()) < _item[3].price.Length)
                        priceText.text = Fa.faConvert(" سکه ") + Fa.ToPersianNumber(_item[3].price[PlayerPrefs.GetInt("Fuel" + id.ToString())].ToString()) + Fa.faConvert("هزينه بهبود کردن : ");
                    else
                        priceText.text = Fa.faConvert("تکمیل شد");

                }
            }
            else
            {
                HomeManager._homeManager.OpenPurchase();

            }
        }
    }



    public void StartGame()
    {

        //Loading.SetActive (true);
        //PlayerPrefs.SetInt ("AllScoreTemp", PlayerPrefs.GetInt ("Coins"));
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Level" + PlayerPrefs.GetInt("SelectedLevel").ToString());

        //sceneLoading.ActivateNextScene();
        if (PlayerPrefs.GetString("language") == "English")
        {
            loading.GetComponentInChildren<Text>().text = "Loading ...";
        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            loading.GetComponentInChildren<Text>().text = Fa.faConvert("بارگیری ... ");

        }
        loading.SetActive(true);

        //gameObject.SetActive (false);

    }

    [System.Serializable]
    public class UpgradeItem
    {
        public Text levelInfo;

        public Image _border;

        public int[] price;

        public string _content;
    }
}
