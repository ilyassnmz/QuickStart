namespace QuickStart.WepApi.Entity
{
    public class NotificationType
    {
        public int NotificationTypeId { get; set; }
        public string Name { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}

//Sipariş, Mesaj, Kampanya,Güncelleme