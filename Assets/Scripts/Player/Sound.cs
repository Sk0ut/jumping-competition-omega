using UnityEngine;

public class Sound : MonoBehaviour {

	public AudioClip BounceSound;
	public AudioClip JumpBoostSound;
	public AudioClip BombSound;

	private AudioSource _sound;

	private void OnEnable()
	{
		GetComponent<Jump2D>().OnPlayerJump += PlayJumpSound;
		GetComponent<PowerUpJump>().OnPowerupPickup += PlayPowerupSound;
		GetComponent<Debuff>().OnDebuffPickup += PlayDebuffSound;
	}

	private void OnDisable()
	{
		GetComponent<Jump2D>().OnPlayerJump -= PlayJumpSound;
		GetComponent<PowerUpJump>().OnPowerupPickup -= PlayPowerupSound;
		GetComponent<Debuff>().OnDebuffPickup -= PlayDebuffSound;
	}

	private void Start () {
		_sound = GetComponent<AudioSource> ();
		_sound.playOnAwake = false;
	}

	private void PlayJumpSound()
	{
		_sound.PlayOneShot(BounceSound, 0.8f);
	}

	private void PlayPowerupSound()
	{
		_sound.PlayOneShot(JumpBoostSound, 0.8f);
	}

	private void PlayDebuffSound()
	{
		_sound.PlayOneShot(BombSound, 0.8f);
	}
}
