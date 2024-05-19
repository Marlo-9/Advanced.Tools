using System;
using System.Windows;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;
using MessageBoxButton = System.Windows.MessageBoxButton;

namespace Advanced.Tools;

/// <summary>
/// A utility class for displaying notifications to the user, such as errors, successes, information, and warnings.
/// </summary>
public class Notify
{
    /// <summary>
    /// Enumeration defining different types of notifications.
    /// </summary>
    public enum NotificationType
    {
        Error,
        Success,
        Info,
        Warning
    }

    /// <summary>
    /// Default timeout for notifications.
    /// </summary>
    public static TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(3.0);

    /// <summary>
    /// Global error icon.
    /// </summary>
    public static SymbolIcon ErrorIcon = new(SymbolRegular.ErrorCircle24);

    /// <summary>
    /// Global appearance for error notifications.
    /// </summary>
    public static ControlAppearance ErrorAppearance = ControlAppearance.Danger;

    /// <summary>
    /// Global success icon.
    /// </summary>
    public static SymbolIcon SuccessIcon = new(SymbolRegular.CheckmarkCircle24);

    /// <summary>
    /// Global appearance for success notifications.
    /// </summary>
    public static ControlAppearance SuccessAppearance = ControlAppearance.Success;

    /// <summary>
    /// Global info icon.
    /// </summary>
    public static SymbolIcon InfoIcon = new(SymbolRegular.Info24);

    /// <summary>
    /// Global appearance for info notifications.
    /// </summary>
    public static ControlAppearance InfoAppearance = ControlAppearance.Info;

    /// <summary>
    /// Global warning icon.
    /// </summary>
    public static SymbolIcon WarningIcon = new(SymbolRegular.Warning24);

    /// <summary>
    /// Global appearance for warning notifications.
    /// </summary>
    public static ControlAppearance WarningAppearance = ControlAppearance.Caution;

    private static SnackbarPresenter? _snackbarPresenter;

    /// <summary>
    /// Sets the global SnackbarPresenter to be used for displaying notifications.
    /// </summary>
    /// <param name="snackbarPresenter">The SnackbarPresenter instance.</param>
    public static void SetGlobalSnackbarPresenter(SnackbarPresenter snackbarPresenter)
    {
        _snackbarPresenter = snackbarPresenter;
    }

    /// <summary>
    /// Checks if a global SnackbarPresenter has been set.
    /// </summary>
    /// <returns><c>True</c> if a global SnackbarPresenter has been set, otherwise <c>False</c>.</returns>
    public static bool HasGlobalSnackbarPresenter()
    {
        return _snackbarPresenter != null;
    }

    /// <summary>
    /// Displays a notification with the specified text, title, and type.
    /// </summary>
    /// <param name="text">The text content of the notification.</param>
    /// <param name="title">The title of the notification.</param>
    /// <param name="type">The type of the notification.</param>
    /// <example>
    /// <code>
    /// Notify.ShowNotification("Text content", "Title", Notify.NotificationType.Success);
    /// </code>
    /// </example>
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

    /// <summary>
    /// Displays an error notification with the specified text and title.
    /// </summary>
    /// <param name="text">The text content of the error notification.</param>
    /// <param name="title">The title of the error notification.</param>
    /// <example>
    /// <code>
    /// Notify.ShowError("An error occurred", "Error");
    /// </code>
    /// </example>
    public static void ShowError(string text, string title)
    {
        ShowNotification(text, title, NotificationType.Error);
    }

    /// <summary>
    /// Displays a success notification with the specified text and title.
    /// </summary>
    /// <param name="text">The text content of the success notification.</param>
    /// <param name="title">The title of the success notification.</param>
    /// <example>
    /// <code>
    /// Notify.ShowSuccess("Operation successful", "Success");
    /// </code>
    /// </example>
    public static void ShowSuccess(string text, string title)
    {
        ShowNotification(text, title, NotificationType.Success);
    }

    /// <summary>
    /// Displays an info notification with the specified text and title.
    /// </summary>
    /// <param name="text">The text content of the info notification.</param>
    /// <param name="title">The title of the info notification.</param>
    /// <example>
    /// <code>
    /// Notify.ShowInfo("Information message", "Info");
    /// </code>
    /// </example>
    public static void ShowInfo(string text, string title)
    {
        ShowNotification(text, title, NotificationType.Info);
    }

    /// <summary>
    /// Displays a warning notification with the specified text and title.
    /// </summary>
    /// <param name="text">The text content of the warning notification.</param>
    /// <param name="title">The title of the warning notification.</param>
    /// <example>
    /// <code>
    /// Notify.ShowWarning("Warning message", "Warning");
    /// </code>
    /// </example>
    public static void ShowWarning(string text, string title)
    {
        ShowNotification(text, title, NotificationType.Warning);
    }
}