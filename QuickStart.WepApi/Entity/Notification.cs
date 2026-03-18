namespace QuickStart.WepApi.Entity
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public int NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }

    }
}

//1 numaralı sipariş alındı  türü sipariş
//akşam 11 de site günccellenicek bildirim türü güncelleme
//2 numaralı sipariş alındı onay bekliyor türü sipariş