using UnityEngine;
[System.Serializable]
public class Sound
{
    [SerializeField] string m_Name;
    [SerializeField] AudioClip m_Clip;

    public string GetName() { return m_Name; }


    [Range(0f,1f)]
    [SerializeField] float m_Volume = 0.7f;
    [Range(0.5f,1f)]
    [SerializeField] float m_Pitch = 1f;

    [Range(0f,0.5f)]
    [SerializeField] float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    [SerializeField] float randomPitch = 0.1f;

    AudioSource m_AudioSource;

    public bool randomise = false;

    public void SetSource(AudioSource source)
    {
        m_AudioSource = source;
        m_AudioSource.clip = m_Clip;
    }

    public void Play()
    {


        if ( randomise )
        {
            m_AudioSource.volume = m_Volume * ( 1 + Random.Range(-randomVolume / 2f, randomVolume / 2f) );
            m_AudioSource.pitch = m_Pitch * ( 1 + Random.Range(-randomPitch / 2f, randomPitch / 2f) );

        }
        else
        {
            m_AudioSource.volume = m_Volume;
            m_AudioSource.pitch = m_Pitch;
        }

        m_AudioSource.Play();
    }

}




public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private void Awake()
    {
        if ( instance != null && instance != this )
        {
            Destroy(this);
            Debug.LogError("More than one AudioManager in the scene");
        }
        else
        {
            instance = this;
        }

    }

    [SerializeField]
    Sound[] m_Sounds;

    private void Start()
    {
        for ( int i = 0; i < m_Sounds.Length; i++ )
        {
            GameObject gameObject = new GameObject("Sound_" + i + "_" + m_Sounds[i].GetName());
            gameObject.transform.SetParent(this.transform);
            m_Sounds[i].SetSource(gameObject.AddComponent<AudioSource>());
        }
    }


    public void PlaySound(string name)
    {
        for ( int i = 0; i < m_Sounds.Length; i++ )
        {
            if ( m_Sounds[i].GetName() == name )
            {
                m_Sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound not found on list, " + name);

    }

}
