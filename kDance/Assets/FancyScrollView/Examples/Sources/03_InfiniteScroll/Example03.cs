using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

namespace FancyScrollView.Example03
{
    public class Example03 : MonoBehaviour
    {
        [SerializeField] ScrollView scrollView = default;

        private ItemData[] items = new ItemData[6];
        private Sprite[] images = new Sprite[6];

        public string group1;

        //pictures
        public Sprite bts;
        public Sprite blackpink;
        public Sprite monstaX;
        public Sprite izone;
        public Sprite loona;
        public Sprite gIdle;
        

        void Start()
        {
            /*var items = Enumerable.Range(0, 20)
                .Select(i => new ItemData($"Song {i}"))
                .ToArray();*/

             items[0] = new ItemData(group1);
             items[1] = new ItemData($"BLACKPINK");
             items[2] = new ItemData($"MONSTA X");
             items[3] = new ItemData($"LOONA");
             items[4] = new ItemData($"IZ*ONE");
            items[5] = new ItemData($"(G)I-dle");

            images[0] = bts;
            images[1] = blackpink;
            images[2] = monstaX;
            images[3] = loona;
            images[4] = izone;
            images[5] = gIdle;



            scrollView.UpdateData(items, images);
            scrollView.SelectCell(0);
        }
    }
}
