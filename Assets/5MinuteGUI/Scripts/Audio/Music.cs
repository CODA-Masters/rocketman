using UnityEngine;
using System.Collections;


namespace FMG {

	/// <summary>
	/// Music.
	/// </summary>
	public class Music : MonoBehaviour {
		private static GameObject K_MUSIC = null;
		private static AudioSource K_AUDIO = null;
		/// <summary>
		/// The music clip.
		/// </summary>
		public AudioClip musicClip;
		
		public void Awake()
		{
			createMusic();
			if(K_AUDIO!=null)
			{

				if(musicClip!=K_AUDIO.clip)
				{
					K_AUDIO.clip = musicClip;
					K_AUDIO.Play();
				}
			}
			if(!K_MUSIC.GetComponent<AudioSource>().isPlaying)
				K_MUSIC.GetComponent<AudioSource> ().Play ();
		}
		
		void createMusic()
		{
			if(K_AUDIO==null && K_MUSIC==null)
			{
				K_MUSIC = new GameObject();
				if(K_MUSIC)
				{
					K_AUDIO = K_MUSIC.AddComponent<AudioSource>();
					K_AUDIO.loop = true;
					 K_MUSIC.AddComponent<AudioVolume>();
					K_MUSIC.GetComponent<AudioSource>().volume = 0.30f;
				}
				DontDestroyOnLoad(K_MUSIC);
			}
		}

	}
}