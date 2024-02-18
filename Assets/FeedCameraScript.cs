using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedCameraScript : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;
    // Start is called before the first frame update
    private void Start()
    {
        // Set fallback background texture if camera feed is not available
        defaultBackground = background.texture;

        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }
        for(int i = 0; i < devices.Length; i++)
        {

            backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);

        }
        // if(backCam == null)
        // {
        //     Debug.Log("Unable to find back camera");
        //     return;
        // }
        // backCam.Play();
        // background.texture = backCam;

        // camAvailable = true;

        // Select the first available webcam (usually the built-in webcam)
        // webcamTexture = new WebCamTexture(devices[0].name, Screen.width, Screen.height);

        backCam.Play();
        background.texture = backCam;

        camAvailable = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(!camAvailable)
        {
            return;
        }
        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
