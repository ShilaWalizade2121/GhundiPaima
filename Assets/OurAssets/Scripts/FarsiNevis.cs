using UnityEngine;
using System.Collections;

public class FarsiNevis : MonoBehaviour {


	void Start () {


		int number = 1234;
		string persianNumber = number.ToString();
		Debug.Log(ToPersianNumber(persianNumber));

	}
	

	void Update () {

	
	}

	public string ToPersianNumber(string input)
	{
		if (input.Trim() == "") return "";

		//۰ ۱ ۲ ۳ ۴ ۵ ۶ ۷ ۸ ۹
		input = input.Replace("0", "۰");
		input = input.Replace("1", "۱");
		input = input.Replace("2", "۲");
		input = input.Replace("3", "۳");
		input = input.Replace("4", "۴");
		input = input.Replace("5", "۵");
		input = input.Replace("6", "۶");
		input = input.Replace("7", "۷");
		input = input.Replace("8", "۸");
		input = input.Replace("9", "۹");
		return input;
	}

}



