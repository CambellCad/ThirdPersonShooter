using System;

using UnityEngine;
using UnityEngine.Audio;

namespace ThirdPersonShooter
{
	public class SettingsManager : MonoBehaviour
	{
		[SerializeField] private AudioMixer mixer;
		[SerializeField] private string[] parameters;

		public string this[int _paramIndex] => parameters[_paramIndex];

		private void Start()
		{
			foreach(string paramater in parameters)
			{
				if(paramater.Contains("Volume"))
					SetVolume(paramater, PlayerPrefs.GetFloat(paramater, 100));
			}
		}

		private void OnApplicationQuit()
		{
			PlayerPrefs.Save();
		}

		public void SetVolume(string _id, float _value)
		{
			// 0.0001 - 1 = Correct Volume Slider
			mixer.SetFloat(_id, Mathf.Log10(_value) * 20);
			PlayerPrefs.SetFloat(_id, _value);
		}
	}
}