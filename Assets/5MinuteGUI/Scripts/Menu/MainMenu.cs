using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


namespace FMG
{
	public class MainMenu : MonoBehaviour {
		public GameObject mainMenu;
		public GameObject levelSelectMenu;
		public GameObject optionsMenu;
		public GameObject creditsMenu;

		public bool useLevelSelect = true;
		public bool useExitButton = true;

		public GameObject exitButton;


		public void Awake()
		{
			if(useExitButton==false)
			{
				exitButton.SetActive(false);
			}

			PlayerPrefs.SetInt ("watched_tutorial", 0);

			// recommended for debugging:
			PlayGamesPlatform.DebugLogEnabled = true;
			// Activate the Google Play Games platform
			PlayGamesPlatform.Activate();
		}

		public void Start(){
			((PlayGamesPlatform)Social.Active).Authenticate ((bool success) => {}, true);
			Social.localUser.Authenticate((bool success) => {});
		}

		public void onCommand(string str)
		{
			if(str.Equals("LevelSelect"))
			{
				Application.LoadLevel(1);
			}

			if(str.Equals("LevelSelectBack"))
			{
				Constants.fadeInFadeOut(mainMenu,levelSelectMenu);

			}
			if(str.Equals("Exit"))
			{
				Application.Quit();
			}
			if(str.Equals("Credits"))
			{
				Constants.fadeInFadeOut(creditsMenu,mainMenu);

			}
			if(str.Equals("CreditsBack"))
			{
				Constants.fadeInFadeOut(mainMenu,creditsMenu);
			}

			
			if(str.Equals("OptionsBack"))
			{
				Constants.fadeInFadeOut(mainMenu,optionsMenu);

			}
			if(str.Equals("Options"))
			{
				Constants.fadeInFadeOut(optionsMenu,mainMenu);
			}

			if(str.Equals("Store"))
			{
				Application.LoadLevel(2);
			}

			if(str.Equals("Menu"))
			{
				Application.LoadLevel(0);
			}

			if (str.Equals ("Ranking")) {
				if(Social.localUser.authenticated){
					((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkIh-a8y9sQEAIQAA");
				} else {
					Social.localUser.Authenticate((bool success) => {});
				}
			}
			if (str.Equals ("Achievements")) {
				if(Social.localUser.authenticated){
					((PlayGamesPlatform)Social.Active).ShowAchievementsUI();
				} else {
					Social.localUser.Authenticate((bool success) => {});
				}
			}

		}
	}
}
