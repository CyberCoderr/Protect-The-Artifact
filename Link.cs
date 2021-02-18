using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour
{

    public void OpenYoutube()
    {
#if !UNITY_EDITOR
		openWindow("https://www.youtube.com/channel/UCCHo3boDHDe_VyB5_BPvpxg");
#endif
    }
    public void OpenDiscord()
    {
#if !UNITY_EDITOR
		openWindow("https://discord.gg/MV9T3Fw");
#endif
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);

}
