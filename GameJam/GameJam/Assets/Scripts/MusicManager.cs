using System;
using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI MusicText;
    [SerializeField] public AudioClip[] MusicTracks;
    [SerializeField] public bool Paused;

    [SerializeField] public AudioClip DefaultMusicTrack;

    [SerializeField] private AudioClip m_CurrentClip;

    [SerializeField] private AudioSource m_AudioSource;

    [SerializeField] public UnityEvent OnClipStart;
    [SerializeField] public UnityEvent OnClipEnd;

    private int m_PreviousTrackIndex = -1;

    /// <summary>
    /// Initializes all the events.
    /// </summary>
    private void Awake()
    {
        if (!m_AudioSource)
            m_AudioSource = this.GetComponent<AudioSource>();

        if (OnClipStart == null)
            OnClipStart = new UnityEvent();
        if (OnClipEnd == null)
            OnClipEnd = new UnityEvent();
    }

    /// <summary>
    /// Adds the listeners to the events.
    /// </summary>
    private void Start()
    {
        OnClipStart.AddListener(Play);
        OnClipStart?.Invoke();
    }

    /// <summary>
    /// Does time related stuff.
    /// </summary>
    private void Update()
    {
        if (m_AudioSource.time >= m_CurrentClip.length)
        {
            OnTimeReset();
        }
    }

    /// <summary>
    /// Only updated the ui on render passes.
    /// </summary>
    private void OnRenderObject()
    {
        if (MusicText)
        {
            TimeSpan currentTime = TimeSpan.FromSeconds(m_AudioSource.time);
            TimeSpan clipLength = TimeSpan.FromSeconds(m_CurrentClip.length);
            MusicText.text = $"{m_CurrentClip.name}\n{currentTime.Minutes:D2}:{currentTime.Seconds:D2} / {clipLength.Minutes:D2}:{clipLength.Seconds:D2}";
        }
    }

    /// <summary>
    /// Resets the time.
    /// </summary>
    private void OnTimeReset()
    {
        OnClipEnd?.Invoke();

        OnClipStart?.Invoke();
    }

    /// <summary>
    /// Skips the song.
    /// </summary>
    public void Skip()
    {
        m_AudioSource.Stop();

        OnTimeReset();
    }

    /// <summary>
    /// Plays the song.
    /// </summary>
    private void Play()
    {
        m_AudioSource.clip = m_CurrentClip = Get();
        m_AudioSource.Play();
    }

    /// <summary>
    /// Gets a truly random number.
    /// </summary>
    /// <returns></returns>
    private AudioClip Get()
    {
        if (MusicTracks.Length > 1)
            return MusicTracks[EnsureRandomNumber.Get(ref m_PreviousTrackIndex, 0, MusicTracks.Length)];
        return MusicTracks.Length == 1 ? MusicTracks[0] : DefaultMusicTrack;
    }
}