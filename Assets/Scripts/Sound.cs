using UnityEngine;

public class Sound : MonoBehaviour {

	public AudioClip BounceSound;
	public AudioClip JumpBoostSound;

	AudioSource _sound;

    private void OnEnable()
    {
        Jump2D.OnPlayerJump += PlayJumpSound;
        PowerUpJump.OnPowerupPickup += PlayPowerupSound;
    }

    private void OnDisable()
    {
        Jump2D.OnPlayerJump -= PlayJumpSound;
        PowerUpJump.OnPowerupPickup -= PlayPowerupSound;
    }

    void Start () {
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

}
