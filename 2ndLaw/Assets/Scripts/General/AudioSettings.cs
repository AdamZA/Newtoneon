using UnityEngine;

public static class AudioSettings
{
    public static bool SoundMuted { get; private set; }
    public static bool MusicMuted { get; private set; }

    static AudioSettings()
    {
        SoundMuted = PlayerPrefs.GetInt("sounds", 0) == 1;
        MusicMuted = PlayerPrefs.GetInt("music", 0) == 1;
    }

    public static void SetSoundMuted(bool muted)
    {
        SoundMuted = muted;
        PlayerPrefs.SetInt("sounds", muted ? 1 : 0);
    }

    public static void SetMusicMuted(bool muted)
    {
        MusicMuted = muted;
        PlayerPrefs.SetInt("music", muted ? 1 : 0);
    }
}
