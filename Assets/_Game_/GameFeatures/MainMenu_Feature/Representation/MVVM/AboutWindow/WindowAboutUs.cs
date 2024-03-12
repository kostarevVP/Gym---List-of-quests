using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WKosArch.UIService.Views.Windows;

public class WindowAboutUs : Window<AboutUsWindowModel>
{
    [Space]
    [Header("Add button and link to social platform \nall link need to start from https://")]
    [SerializeField] Button _siteButton;
    [SerializeField] string _siteLink;
    [SerializeField] Button _tikTokButton;
    [SerializeField] string _tikTokLink;
    [SerializeField] Button _youTubeButton;
    [SerializeField] string _youTubeLink;
    [SerializeField] Button _xButton;
    [SerializeField] string _xLink;
    [SerializeField] Button _instagramButton;
    [SerializeField] string _instagramLink;
    [SerializeField] Button _linkedInButton;
    [SerializeField] string _linkedInLink;

    private Dictionary<Button, string> _sociaButtons => new Dictionary<Button, string>()
        {
            {_siteButton, _siteLink},
            {_tikTokButton, _tikTokLink},
            {_youTubeButton, _youTubeLink},
            {_xButton, _xLink},
            {_instagramButton, _instagramLink},
            {_linkedInButton, _linkedInLink}
        };


    public override void Subscribe()
    {
        base.Subscribe();

        foreach (var button in _sociaButtons)
        {
            button.Key.onClick.AddListener(() => ViewModel.OpenLink(button.Value));
        }
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();

        foreach (var button in _sociaButtons)
        {
            button.Key.onClick.RemoveListener(() => ViewModel.OpenLink(button.Value));
        }
    }
}
