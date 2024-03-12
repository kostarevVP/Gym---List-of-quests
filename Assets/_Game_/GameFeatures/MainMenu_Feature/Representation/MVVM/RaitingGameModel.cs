using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaitingGameModel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Sprite _emptyStarImage;
    [SerializeField] private Sprite _fullStarImage;
    [Space]
    [SerializeField] private Image[] _starImages; 
    [Space]
    [SerializeField] private string _gameLinkPlayMarket = "https://google.com";
    private int _selectedStars = 0;
    private float _delayTime = 1f;

    // Коли гравець клікає на зірку
    public void OnPointerClick(PointerEventData eventData)
    {
        // Отримуємо індекс зірки, яку клікнули
        int clickedStarIndex = System.Array.IndexOf(_starImages, eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>());

        // Змінюємо зображення зірок залежно від обраної кількості
        if (_selectedStars == clickedStarIndex + 1)
        {
            // Якщо клікнута зірка була вже обрана, знімаємо вибір
            _selectedStars--;
        }
        else
        {
            // Інакше вибираємо зірку та змінюємо її зображення на заповнену зірку
            _selectedStars = clickedStarIndex + 1;
        }

        // Змінюємо зображення всіх зірок
        for (int i = 0; i < _starImages.Length; i++)
        {
            if (i < _selectedStars)
            {
                // Якщо індекс зірки менший за вибрану кількість, встановлюємо заповнену зірку
                _starImages[i].sprite = _fullStarImage;
            }
            else
            {
                // Інакше встановлюємо незаповнену зірку
                _starImages[i].sprite = _emptyStarImage;
            }
        }
        StartCoroutine(DelayedSendRating());
    }
    private IEnumerator DelayedSendRating()
    {
        yield return new WaitForSeconds(_delayTime);
        SendRating(); 
    }

    private void SendRating()
    {
        if (_selectedStars <= 3)
        {
            // need 25$ to by
            //https://assetstore.unity.com/packages/tools/integration/utmail-email-composition-and-sending-plugin-90545
            //Then add to send email
            //SendEmail();
            Application.OpenURL(_gameLinkPlayMarket);
        }
        else if (_selectedStars >= 4)
        {
            Application.OpenURL(_gameLinkPlayMarket);
        }
    }

    private void SendEmail()
    {
        // Відправляємо листа з рейтингом на вказану адресу
        string subject = $"Raiting {Application.productName}";
        string body = "My raiting is " + _selectedStars + " stars.";

        // Створюємо текстовий файл з інформацією про додаток
        string filePath = Application.persistentDataPath + "/AppInfo.txt";
        System.IO.File.WriteAllText(filePath, $"Version app: {Application.version}\n" +
            $"Platform: {Application.platform}\n" +
            $"VersionOS: {SystemInfo.operatingSystem}");

        // Відкриваємо поштовий клієнт і додаємо файл з інформацією про додаток
        string mailto = $"mailto:wkosstudio@gmail.com?subject={subject}&body={body}&attachment={filePath}";
        Process.Start(mailto);
    }
}
