using UnityEngine;
using System.Collections;

public class Screenshotter : MonoBehaviour
{
    public int resWidth = 1280;
    public int resHeight = 720;

    private bool takeShot = false;

    public static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
                             Application.dataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    


    void LateUpdate()
    {
        takeShot |= Input.GetKeyDown("k");
        if (takeShot)
        {
            Camera thisCamera = GetComponent<Camera>();
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            thisCamera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            thisCamera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            thisCamera.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeShot = false;
        }
    }
}
