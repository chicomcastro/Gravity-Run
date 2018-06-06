using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioSource[] musics;

	public AudioSource music;

	void Start () {
		music = musics [Random.Range (0, musics.Length)];
		music.Play();
	}
}
