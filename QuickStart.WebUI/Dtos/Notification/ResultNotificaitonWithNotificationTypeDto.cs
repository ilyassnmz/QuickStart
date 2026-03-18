namespace QuickStart.WebUI.Dtos.Notification
{
    public class ResultNotificaitonWithNotificationTypeDto
    {

            public int notificationId { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public bool isRead { get; set; }
            public string notificationTypeName { get; set; }
       

    }
}
