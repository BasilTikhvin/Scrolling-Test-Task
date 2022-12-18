using UnityEngine;
using UnityEngine.UI;

namespace ScrollingTestTaks
{
    public class ImageManager : MonoBehaviour
    {
        public static int SQUARE_IMAGE_SIZE = 100;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        private void Update()
        {
            if (transform.position.x != transform.root.position.x)
            {
                _image.color = new Color(1, 1, 1, 0.5f);
            }  
            else
            {
                _image.color = new Color(1, 1, 1, 1);
            }
        }
    }
}