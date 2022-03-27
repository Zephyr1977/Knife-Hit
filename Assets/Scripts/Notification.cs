using Unity.Notifications.Android;
using UnityEngine;

public class Notification : MonoBehaviour
{

    void Start()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "1",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
        AndroidNotificationCenter.CancelAllNotifications();
        CreateNotification();
    }

    private void CreateNotification() 
    {
        var notification = new AndroidNotification();
        notification.Title = "Clone Knife Hit";
        notification.Text = "Hey,8 hours have passed. Time to sharpen your knives";
        notification.FireTime = System.DateTime.Now.AddHours(8);

        AndroidNotificationCenter.SendNotification(notification, "1");
    }
}
