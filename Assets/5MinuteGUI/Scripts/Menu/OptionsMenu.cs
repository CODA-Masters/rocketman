using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FMG
{
	public class OptionsMenu : MonoBehaviour {
		public Text graphicsText;
		public string graphicsPrefix = "Graphics: ";


		public Text audioText;
		public string audioPrefix = "Audio: ";
		public string audioOff = "Off";

		public string audioOn = "On";

		public GameObject exp1, exp2, exp3, exp4;
		public GameObject buttonNext, buttonBack;

		public void Awake()
		{
			graphicsText.text = graphicsPrefix + QualitySettings.names[QualitySettings.GetQualityLevel()];
			updateAudioText();
			buttonBack.transform.localScale = new Vector3(0,0,0);
		}

		void updateAudioText()
		{
			float currentVol = Constants.getAudioVolume();
			if(currentVol==0)
			{
				audioText.text = audioPrefix  + audioOff;
			}else{
				audioText.text = audioPrefix  + audioOn;
				
			}

		}
		public void onCommand(string str)
		{
			if(str.Equals("DeleteData"))
			{
				PlayerPrefs.DeleteAll();
			}
			if(str.Equals("QualityNext"))
			{
				QualitySettings.IncreaseLevel();
				graphicsText.text = graphicsPrefix + QualitySettings.names[QualitySettings.GetQualityLevel()];
			}
			if(str.Equals("QualityPrev"))
			{
				QualitySettings.DecreaseLevel();
				graphicsText.text = graphicsPrefix + QualitySettings.names[QualitySettings.GetQualityLevel()];
			}
			if(str.Equals("AudioToggle"))
			{
				float currentVol =  Constants.getAudioVolume();
				if(currentVol==0)
				{
					Constants.setAudioVolume(1);
					AudioListener.volume = 1;
				}else{
					Constants.setAudioVolume(0);
					AudioListener.volume = 0;
				}
				AudioVolume[] audioVolumes = (AudioVolume[])GameObject.FindObjectsOfType(typeof(AudioVolume));
				for(int i=0; i<audioVolumes.Length; i++)
				{
					audioVolumes[i].updateVolume();
				}

				updateAudioText();
			}

			if(str.Equals("HelpNext"))
			{
				exp3.SetActive(true);
				exp4.SetActive(true);
				buttonBack.transform.localScale = new Vector3(1,1,1);
				exp1.SetActive(false);
				exp2.SetActive(false);
				buttonNext.transform.localScale = new Vector3(0,0,0);
			}

			if(str.Equals("HelpBack"))
			{
				exp1.SetActive(true);
				exp2.SetActive(true);
				buttonNext.transform.localScale = new Vector3(1,1,1);
				exp3.SetActive(false);
				exp4.SetActive(false);
				buttonBack.transform.localScale = new Vector3(0,0,0);
			}
		}
	}
}