using UnityEngine;

public class Progress : MonoBehaviour
{
    private const string MaxLevelKey = "MaxLevel";

    // Simpan level maksimum (dibatasi antara 1-9)
    public void SimpanProgress(int level)
    {
        int currentMax = MuatProgress();
        int clampedLevel = Mathf.Clamp(level, 1, 6);

        if (clampedLevel > currentMax)
        {
            PlayerPrefs.SetInt(MaxLevelKey, clampedLevel);
            PlayerPrefs.Save();
            Debug.Log("Progress disimpan: Level Maks = " + clampedLevel);
        }
        else
        {
            Debug.Log("Level lebih rendah, tidak disimpan.");
        }
    }

    // Muat level maksimum yang tersimpan, default ke 1 jika belum ada
    public int MuatProgress()
    {
        return PlayerPrefs.GetInt(MaxLevelKey, 1);
    }

    // Reset progress ke level 1
    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey(MaxLevelKey);
        PlayerPrefs.Save();
        Debug.Log("Progress direset ke level 1.");
    }
}