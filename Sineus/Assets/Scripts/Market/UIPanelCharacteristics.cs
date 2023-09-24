using TMPro;
using UnityEngine;
using UnityEngine.UI;

public  enum TypeChar
{
    
    Speed,
    Agility,
    Hill,
    Adaptic

}

public class UIPanelCharacteristics : MonoBehaviour
{

    [SerializeField] private Button buttonUp;
    [SerializeField] private Image imageUp;
    [SerializeField] private Image imageDown;
    [SerializeField] private Button buttonDown;
    [SerializeField] private TMP_Text numTextChar;

    [SerializeField] private TypeChar typeChar;

    private int numChar;

    private void Start()
    {
        switch (typeChar)
        { 
            case TypeChar.Speed:
                numChar = —haracterizationEcomorf.Instance.SpeedChar;
                break;
                case TypeChar.Agility:
                numChar = —haracterizationEcomorf.Instance.AgilityChar;
                break;
                case TypeChar.Hill:
                numChar = —haracterizationEcomorf.Instance.HillChar;
                break;
                case TypeChar.Adaptic:
                numChar = —haracterizationEcomorf.Instance.AdapticChar;
                break;

        }
            
        numTextChar.text = numChar.ToString();
    }

    public void ClickButtonUp()
    {
        if (—haracterizationEcomorf.Instance.AddSpeedChar())
        {
            numChar++;
            numTextChar.text = numChar.ToString();
        }          
    }

    public void ClickButtonDown()
    {
        if (—haracterizationEcomorf.Instance.DrawSpeedChar(numChar))
        {
            numChar --;
            numTextChar.text = numChar.ToString();
        }
    }

    //“‡ÍÓÂ Ò‚ËÌÒÚ‚Ó ‰Îˇ UI ˇ Â˘Â ÌÂ ‰ÂÎ‡Î....
    private void Update()
    {
        if (—haracterizationEcomorf.Instance.Score <= 0)
        {
            buttonUp.enabled = false;
            //imageUp.color = new Color(0,0,0, 100);
        }
        else
        {
            buttonUp.enabled = true;
        }

        if (numChar == 5)
        {
            buttonDown.enabled = false;
            //imageUp.color = new Color(0, 0, 0, 100);
        }
        else
        {
            buttonDown.enabled = true;
        }
    }
}
