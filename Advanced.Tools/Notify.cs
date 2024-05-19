using System;
using System.Windows;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;
using MessageBoxButton = System.Windows.MessageBoxButton;

namespace Advanced.Tools;

public class Notify
{
    public enum NotificationType
    {
        Error,
        Success,
        Info,
        Warning
    }

    public static TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(3.0);

    public static SymbolIcon ErrorIcon = new(SymbolRegular.ErrorCircle24);
    public static ControlAppearance ErrorAppearance = ControlAppearance.Danger;

    public static SymbolIcon SuccessIcon = new(SymbolRegular.CheckmarkCircle24);
    public static ControlAppearance SuccessAppearance = ControlAppearance.Success;

    public static SymbolIcon InfoIcon = new(SymbolRegular.Info24);
    public static ControlAppearance InfoAppearance = ControlAppearance.Info;

    public static SymbolIcon WarningIcon = new(SymbolRegular.Warning24);
    public static ControlAppearance WarningAppearance = ControlAppearance.Caution;

    private static SnackbarPresenter? _snackbarPresenter;

    public static void SetGlobalSnackbarPresenter(SnackbarPresenter snackbarPresenter)
    {
        _snackbarPresenter = snackbarPresenter;
    }

    public static bool HasGlobalSnackbarPresenter()
    {
        return _snackbarPresenter != null;
    }

    public static void ShowNotification(string text, string title, NotificationType type)
    {
        if (HasGlobalSnackbarPresenter())
        {
            var icon = ErrorIcon;
            var appearance = ErrorAppearance;

            switch (type)
            {
                case NotificationType.Success:
                    icon = SuccessIcon;
                    appearance = SuccessAppearance;
                    break;
                case NotificationType.Info:
                    icon = InfoIcon;
                    appearance = InfoAppearance;
                    break;
                case NotificationType.Warning:
                    icon = WarningIcon;
                    appearance = WarningAppearance;
                    break;
            }

            new Snackbar(_snackbarPresenter!)
            {
                Title = title,
                Content = text,
                Icon = icon,
                Appearance = appearance,
                Timeout = DefaultTimeOut
            }.ShowAsync();
        }
        else
        {
            var icon = MessageBoxImage.Error;

            switch (type)
            {
                case NotificationType.Success:
                    icon = MessageBoxImage.None;
                    break;
                case NotificationType.Info:
                    icon = MessageBoxImage.Information;
                    break;
                case NotificationType.Warning:
                    icon = MessageBoxImage.Warning;
                    break;
            }

            MessageBox.Show(text, title, MessageBoxButton.OK, icon);
        }
    }

    public static void ShowError(string text, string title)
    {
        ShowNotification(text, title, NotificationType.Error);
    }

    public static void ShowSuccess(string text, string title)
    {
        ShowNotification(text, title, NotificationType.Success);
    }

    public static void ShowInfo(string text, string title)
    {
        ShowNotification(text, title, NotificationType.Info);
    }

    public static void ShowWarning(string text, string title)
    {
        ShowNotification(text, title, NotificationType.Warning);
    }
}