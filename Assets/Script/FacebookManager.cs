using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System.Collections.Generic;
public class FacebookManager : MonoBehaviour {

	[TextArea (3,10)]
	public string MessageToShare;
	public Text userIdText;
	void Awake(){
		if (!FB.IsInitialized) {
			FB.Init ();
		} else {
			FB.ActivateApp ();
		}
	}

	public void login(){
		FB.LogInWithReadPermissions (callback:OnLogin);

	}

	void OnLogin(ILoginResult result){
		if (FB.IsLoggedIn) {
			AccessToken token = AccessToken.CurrentAccessToken;
			userIdText.text = "Hi!";
			//userIdText.text = token.UserId;
		} else {
			Debug.Log ("Login Canceled");
		}
	}

	public void share(){
		FB.ShareLink (contentTitle:MessageToShare + InfoCCG.infoccg.Puntuation.ToString(),contentURL:new System.Uri("https://zion-soft.info/"),contentDescription:"Developer Team's Website",callback:OnShare);
	}
	void OnShare(IShareResult result){
		if (result.Cancelled || string.IsNullOrEmpty (result.Error)) {
			Debug.Log ("ShareLink error: " + result.Error);
		} else if (!string.IsNullOrEmpty (result.PostId)) {
			Debug.Log (result.PostId);
		} else {
			Debug.Log ("Shared Complete");
		}
	}
}
