using UnityEngine;
using System.Collections;
using System;
using System.Web;

public class DrawGoogleMap : MonoBehaviour {
	public float initLatitude = 40.714728f;
	public float initLongitude = -73.998672f;
	public string key = null;

	GeoLocation calculator;

	string Url = @"https://maps.googleapis.com/maps/api/staticmap?size=500x500&maptype=terrain&center=40.714728,-73.998672&zoom=17&sensor=false";

	void Start(){
		if (calculator == null) {
			calculator = new GeoLocation (initLatitude, initLongitude);
			Build ();
		}
	}

	public GeoLocation Geo {
		get {
			return calculator;
		}
		set {
			calculator = value;
			Build ();
		}
	}

	public void SetGeo(GeoLocation geo){
		Geo = geo;
	}

	// Use this for initialization
	public void Draw (GeoLocation calc) {
		calculator = calc;
		Build ();
	}

	public void Build(){
		Url = string.Format (@"https://maps.googleapis.com/maps/api/staticmap?size=500x500&maptype=terrain&center={0},{1}&zoom=17&scale=2language=jp&style=element:labels|visibility:off&sensor=false", calculator.lat, calculator.lon);
		if (key != null && key.Length != 0) {
			Url += "&key=" + key;
		}
		Url = Uri.EscapeUriString(Url);
		StartCoroutine(Download(this.Url, tex => addSplatPrototype(tex)));
	}

	/// 
	/// GoogleMapsAPIから地図画像をダウンロードする
	/// 

	/// ダウンロード元
	/// ダウンロード後に実行されるコールバック関数
	IEnumerator Download(string url, Action<Texture2D> callback) {
		var www = new WWW(url);
		yield return www; // Wait for download to complete

		callback(www.texture);
	}

	/// 
	/// Planeにテクスチャを貼り付ける
	/// 

	/// 
	public void addSplatPrototype(Texture2D tex) {
		GetComponent<Renderer>().material.mainTexture = tex;
	}
}