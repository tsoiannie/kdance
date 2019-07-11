using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

namespace FancyScrollView.Example03
{
    public class Cell : FancyScrollViewCell<ItemData, Context>
    {
        [SerializeField] Animator animator = default;
        [SerializeField] Text message = default;
        [SerializeField] Text messageLarge = default;
        [SerializeField] Image image = default;
        [SerializeField] Image imageLarge = default;
        [SerializeField] Button button = default;


        static class AnimatorHash
        {
            public static readonly int Scroll = Animator.StringToHash("scroll");
        }

        void Start()
        {
            imageLarge = GetComponent<Image>();
            button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));


        }

        public override void UpdateContent(ItemData itemData, Sprite image)
        {
            message.text = itemData.Message;

            //Debug.Log(imageLarge.sprite);
            imageLarge.sprite = image;
            //Debug.Log(image);

            //messageLarge.text = Index.ToString();


            var selected = Context.SelectedIndex == Index;
            //imageLarge.color = selected
                //? new Color32(180, 80, 100, 190)
                //: new Color32(255, 255, 255, 30);
        }

        public override void UpdatePosition(float position)
        {
            currentPosition = position;
            animator.Play(AnimatorHash.Scroll, -1, position);
            animator.speed = 0;
        }

        // GameObject が非アクティブになると Animator がリセットされてしまうため
        // 現在位置を保持しておいて OnEnable のタイミングで現在位置を再設定します
        float currentPosition = 0;

        void OnEnable() => UpdatePosition(currentPosition);
    }
}
