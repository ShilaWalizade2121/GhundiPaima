using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LanguageChanger : MonoBehaviour
{
    public enum words { SOUND, MUSIC, SETTINGS, START, ABOUTUS, CHOOSE_MAP, Herat_ARG, DESERT, ICE_LAND, DARK_FOREST, FARM, CITY_STREET, BEST_100M,PAUSED, RESUME, RETRY, HOME,DISTANCE_AWARD, NEWRECORD, YOU_ARE_LOST,WIN,NOT_ENOUGH_COIN, WANT_MORE_COINS,VIEW_ADS_EARN_COIN,LOADING,CHOOSE_CAR,CAR_1,CAR_2,CAR_3,CAR_4,CAR_5,CAR_6,CAR_7,CAR_8,CAR_9,UPGRADE_CAR,PERSION,ENGLISH,COST_FREE, COST_500, COST_1000, COST_1500, COST_2000, COST_3000, COST_5000, COST_6000, COST_7000, COST_10000, COST_4000, COST_15000,FUEL_ADS,EXIT,INTERNET_CONNECTION,ADS_NOT_READY,OK,NEXT,MENU,IAP_FIRST_PRICE, IAP_FIRST_COIN, IAP_SECOND_PRICE, IAP_SECOND_COIN, IAP_THIRD_PRICE, IAP_THIRD_COIN,NAME, Cost, BestScore }
    public words setWord;
 
    string[] english = new string[] { "Sound", "Music", "Settings", "Start", "About Us", "CHOOSE MAP", "Herat ARG", "DESERT", "ICE LAND", "DARK FOREST", "FARM", "CITY STREET", "Best : 100 m","Paused", "RESUME", "RETRY", "HOME", "Distance Award","New Record !!!","YOU ARE LOST","You Win","Not enough coins!", "Do you want to get some coins?", "View reward video to earn 100 coins", "Loading ...","Choose Car","CAR_1","CAR_2","CAR_3","CAR_4","CAR_5","CAR_6","CAR_7","CAR_8","CAR_9","Upgrade Car","Fa","En", "Cost: Free", "Cost: 500 coins", "Cost: 1000 coins", "Cost: 1500 coins", "Cost: 2000 coins", "Cost: 3000 coins", "Cost: 5000 coins", "Cost: 6000 coins", "Cost: 7000 coins", "Cost: 10000 coins", "Cost: 4000 coins", "Cost: 15000 coins", "Do you want watch ads to fill fuel?", "Exit" , "No Internet Connection!!!","Ads not ready!\n Please try again latter.", "Ok","Next","Menu", "0.99$", "5000 coins", "1.99$", "20000 coins", "2.99$", "50000 coins","Ghondi Peima" };
    string[] persion = new string[] { "صدا", "موزیک", "تنظیمات", "شروع", "درباره ما","انتخاب نقشه", "ارگ هرات", "صحرا", "سرزمین یخی", "جنگل ","مزرعه"," شهر", "بهترین امتیاز : ۰۰۱ متر", "توقف", "ادامه","تلاش دوباره","صفحه اصلی", "جایزه فاصله", "رکورد جدید !!! ", "  بازی را باختید !!!","برنده شدید !!!","سکه کافی ندارید!"," آیا به سکه های بیشتر نیاز دارید؟","تبلیغات را نگاه کنید تا 100 سکه دریافت کنید "," بارگیری ... ","انتخاب موتر", "موتر اول", "موتر دوم ", "موتر سوم ", "موتر چهارم ", "موتر پنجم ", "موتر ششم ", "موتر هفتم ", "موتر هشتم ", "موتر نهم ", "بهبود كردن موتر", "فارسی","انگلیسی", "قیمت : ۰۰۰۱رایگان", "قیمت : ۰۰۵سکه", "قیمت : ۰۰۰۱ سکه", "قیمت : ۰۰۵۱ سکه", "قیمت : ۰۰۰۲ سکه", "قیمت : ۰۰۰۳ سکه", "قیمت : ۰۰۰۵ سکه", "قیمت : ۰۰۰۶ سکه", "قیمت : ۰۰۰۷ سکه", "قیمت : ۰۰۰۰۱ سکه", "قیمت : ۰۰۰۴ سکه", "قیمت : ۰۰۰۵۱ سکه", "ایا میخواهید با تماشای تبلیغ مخزن تیل موتر را پر کنید؟ ‍‍", "خروج", "عدم اتصال به اینترنت !!!","تبلیغات آماده نیست لطفابعدا تلاش کنید.","بله","بعدی","منو", " $  ۹۹.۰  ", "۰۰۰۵ سکه", " $  ۹۹.۱  ", "۰۰۰۰۲ سکه" ," $  ۹۹.۲  ", "۰۰۰۰۵ سکه","غوندی پیما" };

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.SetString("language", "Persion");
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       
        if (PlayerPrefs.GetString("language") == "English")
        {
            this.GetComponent<Text>().text = english[(int)setWord];

        }
        else if (PlayerPrefs.GetString("language") == "Persion")
        {
            this.GetComponent<Text>().text = Fa.faConvert(persion[(int)setWord]);

        }

    }
   
  
}
