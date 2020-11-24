using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class ButtonPressAudio : MonoBehaviour
{
    [SerializeField] public AudioSource sfx;
    //public ParticleSystem particle;
    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(Feedback);
    }

    private void Feedback()
    {
        sfx.Play(0);
    }
}
