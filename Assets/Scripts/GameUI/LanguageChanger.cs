using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class LanguageChanger : MonoBehaviour
{
    public bool setLanguageOnStart = true;
    Dropdown dropdown;
    private void Start()
    {
        dropdown = gameObject.GetComponent<Dropdown>();
        dropdown.value = GamerData.instance.selectedLanguage;
        if(setLanguageOnStart)
        {
            switch (dropdown.value)
            {
                case 0: //English
                    Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.EN);
                    GamerData.instance.selectedLanguage = dropdown.value;
                    break;
                case 1: //Polish
                    Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.PL);
                    GamerData.instance.selectedLanguage = dropdown.value;
                    break;
                case 2: //Espaniol
                    Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.ES);
                    GamerData.instance.selectedLanguage = dropdown.value;
                    break;
                case 3: //Francais
                    Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.FR);
                    GamerData.instance.selectedLanguage = dropdown.value;
                    break;
                case 4: //Japonese
                    Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.JP);
                    GamerData.instance.selectedLanguage = dropdown.value;
                    break;
                case 5: //German
                    Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.DE);
                    GamerData.instance.selectedLanguage = dropdown.value;
                    break;
            }
        }
    }

    public void DropdownLanguageChange(Dropdown change)
    {
        switch(change.value)
        {
            case 0: //English
                Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.EN);
                GamerData.instance.selectedLanguage = dropdown.value;
                break;
            case 1: //Polish
                Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.PL);
                GamerData.instance.selectedLanguage = dropdown.value;
                break;
            case 2: //Espaniol
                Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.ES);
                GamerData.instance.selectedLanguage = dropdown.value;
                break;
            case 3: //Francais
                Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.FR);
                GamerData.instance.selectedLanguage = dropdown.value;
                break;
            case 4: //Japonese
                Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.JP);
                GamerData.instance.selectedLanguage = dropdown.value;
                break;
            case 5: //German
                Debug.Log("Set German");
                Honeti.I18N.instance.setLanguage(Honeti.LanguageCode.DE);
                GamerData.instance.selectedLanguage = dropdown.value;
                break;

        }
    }
}
