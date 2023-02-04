using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;


public class PhotoHandler : MonoBehaviour
{
    public Camera Camera;
    public Canvas Canvas;
    public GameObject PolaroidObject;
    public GameObject ScreenshotFlash;
    public GameObject PhotoButton;
    public RenderTexture tex;
    
    private Vector2 CamCenter { get; set; }
    private GameObject Polaroid { get; set; }
    private GameObject ScreenshotObject { get; set; }
    private Texture2D ScreenshotTexture { get; set; }
    
    private Ray Raycaster { get; set; }

    private MenuButtonHelper ButtonHandler => PhotoButton.GetComponent<MenuButtonHelper>();
    
    private bool RaycastHit => Physics.Raycast(Raycaster, out _, Mathf.Infinity, LayerMask.GetMask("RaycastTarget"));

    public void CreateCube()
    {
        if(Polaroid != null && Polaroid.activeSelf)
        {
            Polaroid.SetActive(false);
            //DestroyImmediate(Polaroid, true);
        }
        else if (Polaroid != null && !Polaroid.activeSelf) 
        {
            Polaroid.SetActive(true);
        }
        else if (Polaroid == null)
        {
            int RaycastTarget = LayerMask.NameToLayer("RaycastTarget");
            Polaroid = Instantiate(PolaroidObject);
            Polaroid.layer = RaycastTarget;

            Polaroid.transform.position =
                new Vector3(CamCenter.x - 0.5f, CamCenter.y - 0.5f, Camera.transform.position.z + 4);
        }
        
        
    }

    public void TakeScreenshot()
    {

        if (RaycastHit)
        {
            Debug.Log("Hit");
            ScreenshotTexture = toTexture2D(tex);
            //ScreenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();
            StartCoroutine(ScreenshotFlashing());
            MeshRenderer[] mat = Polaroid.GetComponentsInChildren<MeshRenderer>();
            mat[1].material.mainTexture = ScreenshotTexture;
        }
    }

    public void OpenScreenshot()
    {
        if (ScreenshotObject != null)
        {
            Destroy(ScreenshotObject);
        }

        if (ScreenshotTexture != null)
        {
            ScreenshotObject = Instantiate(new GameObject("Screenshot",typeof(RectTransform),typeof(CanvasRenderer),typeof(Image)),Canvas.transform);
            Sprite sprite = Sprite.Create(ScreenshotTexture, new Rect(0,0, ScreenshotTexture.width,ScreenshotTexture.height), new Vector2(0.5f, 0.5f));
            ScreenshotObject.GetComponent<RectTransform>().sizeDelta =
                new Vector2(ScreenshotTexture.width, ScreenshotTexture.height);
            ScreenshotObject.GetComponent<RectTransform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
            ScreenshotObject.GetComponent<Image>().sprite = sprite; 
        }
    }
    void Update()
    {
        if (!RaycastHit)
        {
            ButtonHandler.DeactivateButton();
            //PhotoButton.SetActive(false);
        }
        else
        {
            ButtonHandler.ActivateButton();
            //PhotoButton.SetActive(true);
        }
        Raycaster = new Ray(Camera.transform.position, Camera.transform.forward);
        CamCenter = Camera.rect.center;
        Debug.DrawRay(Camera.transform.position, Camera.transform.forward, Color.green);

        if (Polaroid != null)
        {
            Polaroid.transform.position =
                new Vector3(CamCenter.x - 0.5f, CamCenter.y - 0.5f, Camera.transform.position.z + 4);
        }
    }

    private IEnumerator ScreenshotFlashing()
    {
        ScreenshotFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ScreenshotFlash.SetActive(false);
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(1440, 1440, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect( 0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
