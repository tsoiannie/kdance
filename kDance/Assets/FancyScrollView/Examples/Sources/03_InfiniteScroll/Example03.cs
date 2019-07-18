using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

namespace FancyScrollView.Example03
{
    public class Example03 : MonoBehaviour
    {
        [SerializeField] ScrollView scrollView = default;

        private ItemData[] items = new ItemData[3];
        private Sprite[] images = new Sprite[6];

        public string text1;
        public string text2;
        public string text3;

        //pictures
        public Sprite image1;
        public Sprite image2;
        public Sprite image3;
        public Sprite image4;
        public Sprite image5;
        public Sprite image6;
        

        void Start()
        {
            /*var items = Enumerable.Range(0, 20)
                .Select(i => new ItemData($"Song {i}"))
                .ToArray();*/

             items[0] = new ItemData(text1);
            items[1] = new ItemData(text2);
            items[2] = new ItemData(text3);

            images[0] = image1;
            images[1] = image2;
            images[2] = image3;
            images[3] = image4;
            images[4] = image5;
            images[5] = image6;



            scrollView.UpdateData(items, images);
            scrollView.SelectCell(0);
        }
    }
}
