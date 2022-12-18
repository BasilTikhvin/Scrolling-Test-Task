using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ScrollingTestTaks
{
    public class GUI : MonoBehaviour
    {
        [SerializeField] private GameObject _imagePrefab;

        [SerializeField] private List<GameObject> _images;

        [SerializeField] private int _imagesStartAmount;
        [SerializeField] private int _imagesShown;
        [SerializeField] private int _imagesToDelete;

        private int _imagesAmount;
        private RectTransform _rectTransfrom;

        private void Start()
        {
            _rectTransfrom = GetComponent<RectTransform>();

            SetStartImagesList();
        }

        private void Update()
        {
            if (_images.Count >= _imagesShown)
            {
                for (int i = 0; i < _imagesToDelete; i++)
                {
                    Destroy(_images[i - i]);

                    _images.RemoveAt(i - i);
                }
            }
        }

        private void SetStartImagesList()
        {
            for (int i = 0; i < _imagesStartAmount; i++)
            {
                _images.Add(CreateNewImage(i));

                _imagesAmount++;
            }
        }

        private GameObject CreateNewImage(int index)
        {
            GameObject newImage = Instantiate(_imagePrefab, transform);

            newImage.GetComponentInChildren<Text>().text = _imagesAmount.ToString();

            newImage.transform.GetComponent<RectTransform>().position = new Vector2(GetImagePosition(index), transform.position.y);

            return newImage;
        }

        private float GetImagePosition(int index)
        {
            return _rectTransfrom.position.x + (ImageManager.SQUARE_IMAGE_SIZE * index);
        }

        public void NextImage()
        {
            foreach (var image in _images)
            {
                RectTransform imageRect = image.GetComponent<RectTransform>();

                imageRect.position = new Vector2(imageRect.position.x - ImageManager.SQUARE_IMAGE_SIZE, imageRect.position.y);
            }

            _images.Add(CreateNewImage(_imagesStartAmount - 1));

            _imagesAmount++;
        }
    }
}