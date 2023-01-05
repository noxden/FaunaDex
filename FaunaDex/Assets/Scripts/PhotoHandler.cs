using UnityEngine;
using Image = UnityEngine.UI.Image;


public class PhotoHandler : MonoBehaviour
{
    public Camera Camera;
    public Canvas Canvas;
    
    private Vector2 CamCenter { get; set; }
    private GameObject Polaroid { get; set; }
    private GameObject ScreenshotObject { get; set; }
    private Texture2D ScreenshotTexture { get; set; }
    public void CreateCube()
    {
        if (Polaroid == null)
        {
            Polaroid = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //Instantiate(new GameObject("Polaroid"));

            Polaroid.transform.position =
                new Vector3(CamCenter.x - 0.5f, CamCenter.y - 0.5f, Camera.transform.position.z + 4);
        }
        else
        {
            Destroy(Polaroid);
        }
        
    }

    public async void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("Assets/Resources/Screenshot.png");
    }

    public void OpenScreenshot()
    {
        if (ScreenshotObject != null)
        {
            Destroy(ScreenshotObject);
        }
        ScreenshotTexture = Resources.Load<Texture2D>("Screenshot");

        if (ScreenshotTexture != null)
        {
            ScreenshotObject = Instantiate(new GameObject("Screenshot",typeof(RectTransform),typeof(CanvasRenderer),typeof(Image)),Canvas.transform);
            Sprite sprite = Sprite.Create(ScreenshotTexture, new Rect(0,0, ScreenshotTexture.width,ScreenshotTexture.height), new Vector2(0.5f, 0.5f));
            
            ScreenshotObject.GetComponent<Image>().sprite = sprite; 
        }
    }
    void Update()
    {
        CamCenter = Camera.rect.center;

        if (Polaroid != null)
        {
            Polaroid.transform.position =
                new Vector3(CamCenter.x - 0.5f, CamCenter.y - 0.5f, Camera.transform.position.z + 4);
        }
    }
}
