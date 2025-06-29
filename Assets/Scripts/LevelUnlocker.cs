using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Progress progress;         // Drag objek Progress
    public Transform groupLevel;      // Drag objek "Group Level" (parent dari level-level)

    void Start()
    {
        int maxLevel = progress.MuatProgress(); // Ambil level terakhir yang dibuka

        for (int i = 1; i <= 6; i++)
        {
            Transform levelObj = groupLevel.Find(i.ToString());

            if (levelObj != null)
            {
                // Tetap aktifkan GameObject
                levelObj.gameObject.SetActive(true);

                // Ubah interaksi tombol
                Button btn = levelObj.GetComponent<Button>();
                if (btn != null)
                {
                    btn.interactable = (i <= maxLevel);
                }
                else
                {
                    Debug.LogWarning($"Level {i} tidak punya komponen Button.");
                }
            }
        }
    }
}