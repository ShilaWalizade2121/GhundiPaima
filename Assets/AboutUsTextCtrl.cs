using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AboutUsTextCtrl : MonoBehaviour
{
   
    private void Awake()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetString("language") == "Persion")
            {
                gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleRight;
                gameObject.GetComponent<Text>().text = Fa.faConvert("شركت افگيمستان جهت ارتقای فرهنگ مدرن گيم سازي و ساخت انيميشن در سال ٨٩٣١ وارد") + "\n" + Fa.faConvert("ميدان گرديد، تيم متخصص و متعهد اين شركت با شعار سه واژه  :  ") + "\n" + Fa.faConvert(" توانمند سازی ، تغییر و کارآفرینی تلاش بر اين دارد تا گامي موثر و ارزنده جهت تغير و ") +"\n"+Fa.faConvert("جهاني شدن بردارد.") + "\n" + Fa.faConvert("اين شركت با گام هاي کوچک اش به دنبال تغيرات بزرگ است و آن رساندن صنعت گيم سازي") + "\n" + Fa.faConvert(" و انيميشن افغانستان در سطح جهاني است. ما شما را به يك پياله قهوه، يك دل گرم و تماشاي") + "\n" + Fa.faConvert(" انيميشن هايي شادي آفرين و گيم هايي هيجاني دعوت ميكنيم.") ;

            }else if (PlayerPrefs.GetString("language") == "English")
            {

                gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
                gameObject.GetComponent<Text>().text = "The Afgamestan company established in 2019 to promote the modern culture of game and animation making.\nThe company with a specialized and dedicated team and slogan of “We have brought you three words; Empowerment, Change and Entrepreneurship”, strives to take an effective step towards globalization.\nThe company is making big strides with its small steps to bring the Afghanistan game and animation industry to a global level.We invite you to a cup of coffee, a warm heart, and to watch cheerful animations and exciting games.";
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetString("language") == "Persion")
            {

                gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleRight;
                gameObject.GetComponent<Text>().text = Fa.faConvert("شركت افگيمستان جهت ارتقای فرهنگ مدرن گيم سازي و ساخت انيميشن در سال ٨٩٣١ وارد") + "\n" + Fa.faConvert("ميدان گرديد، تيم متخصص و متعهد اين شركت با شعار سه واژه  :  ") + "\n" + Fa.faConvert(" توانمند سازی ، تغییر و کارآفرینی تلاش بر اين دارد تا گامي موثر و ارزنده جهت تغير و ") + "\n" + Fa.faConvert("جهاني شدن بردارد.") + "\n" + Fa.faConvert("اين شركت با گام هاي کوچک اش به دنبال تغيرات بزرگ است و آن رساندن صنعت گيم سازي") + "\n" + Fa.faConvert(" و انيميشن افغانستان در سطح جهاني است. ما شما را به يك پياله قهوه، يك دل گرم و تماشاي") + "\n" + Fa.faConvert(" انيميشن هايي شادي آفرين و گيم هايي هيجاني دعوت ميكنيم.");

            }
            else if (PlayerPrefs.GetString("language") == "English")
            {

                gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
                gameObject.GetComponent<Text>().text = "The Afgamestan company established in 2019 to promote the modern culture of game and animation making.\nThe company with a specialized and dedicated team and slogan of “We have brought you three words; Empowerment, Change and Entrepreneurship”, strives to take an effective step towards globalization.\nThe company is making big strides with its small steps to bring the Afghanistan game and animation industry to a global level.We invite you to a cup of coffee, a warm heart, and to watch cheerful animations and exciting games.";
            }
        }
    }
}
