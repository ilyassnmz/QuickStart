### QuickStart – Baker Case Web API & MVC Projesi

Bu proje, **M&Y Yazılım Akademi QuickStart/Baker Case**’ine uygun olarak geliştirilmiş, **.NET 6 Web API + ASP.NET Core MVC** mimarili dinamik bir fırın/kurumsal web sitesi ve admin panelidir.  
Tüm içerik **Web API üzerinden** yönetilir, **MVC WebUI** HttpClient ile API’yi tüketir ve **ViewComponent** tabanlı modüler bir arayüz kullanır.

---

### 🔧 Kullanılan Teknolojiler

- **Backend (API)**
  - .NET 6 Web API (`QuickStart.WepApi`)
  - Entity Framework Core (SQL Server)
  - Migration + Code First (DbQuickStartAkademiq)
  - DTO tabanlı veri transferi (Create/Update/Result DTO’lar)

- **Frontend (WebUI)**
  - ASP.NET Core MVC (`QuickStart.WebUI`)
  - HttpClient + `ApiClient` wrapper (BaseUrl üzerinden)
  - ViewComponent mimarisi (ana sayfa + admin layout)
  - Bootstrap bazlı admin teması (Breeze)

---

### 🗄 Veritabanı & Entity’ler

Projede **10’dan fazla tablo** bulunmaktadır ve her birinde **tam CRUD** uygulanmıştır:

- `Service`
- `Testimonial`
- `Notification`
- `NotificationType`
- `About`
- `ContactInfo`
- `FAQ`
- `Feature`
- `Message`
- `Slider`
- `Client`
- `Gallery`
- `Subscribe`
- `Chef`

Tüm entity’ler `QuickStart.WepApi/Entities/` altında, `QuickStartContext` ise `Context/QuickStartContext.cs` içindedir.

---

### 🧱 Mimari Özeti

```mermaid
flowchart LR
  WebUI[QuickStart.WebUI (MVC)] -->|ApiClient + HttpClient| API[QuickStart.WepApi (WebAPI)]
  API -->|EF Core| DB[(SQL Server)]
  WebUI --> VC[ViewComponents]
  WebUI --> Admin[Admin Panel CRUD]
```

- **API katmanı** domain + veri erişimden sorumlu, UI ile **sadece DTO** üzerinden konuşur.
- **WebUI** tarafında hiçbir yerde EF/Context yok, tüm veriler HttpClient ile API’den çekilir.

---

### 📦 Proje Yapısı (Kısaca)

- `QuickStart.WepApi`
  - `Context/QuickStartContext.cs`
  - `Entities/` (Service, Testimonial, Notification, …, Client, Gallery, Subscribe, Chef)
  - `Controllers/` (ServiceController, TestimonialController, NotificationController, …)
  - `Dto/` (her entity için `Create/Update/Result` DTO klasörleri)
  - `Migrations/` (EF Core migration’lar)

- `QuickStart.WebUI`
  - `Controllers/` (Default, Dashboard, Service, Testimonial, Notification, NotificationType, About, Feature, Slider, FAQ, ContactInfo, Message, Client, Gallery, Chef, Subscribe, _AdminLayout)
  - `ViewComponents/`  
    - Front: `_DefaultHeadComponentPartial`, `_DefaultNavbarComponentPartial`, `_DefaultSliderComponentPartial`, `_DefaultFeatureServiceComponentPartial`, `_DefaultFeatureComponentPartial`, `_DefaultAboutComponentPartial`, `_DefaultServiceComponentPartial`, `_DefaultClientComponentPartial`, `_DefaultGalleryComponentPartial`, `_DefaultChefComponentPartial`, `_DefaultTestimonialComponentPartial`, `_DefaultFooterComponentPartial`, `_DefaultScriptComponentPartial`
    - Admin: `_AdminLayoutHeadComponentPartial`, `_AdminLayoutNavbarComponentPartial`, `_AdminLayoutSidebarComponentPartial`, `_AdminLayoutFooterComponentPartial`, `_AdminLayoutScriptComponentPartial`
  - `Views/Default/Index.cshtml` (tamamen ViewComponent çağrılarından oluşan ana sayfa)
  - `Views/*/` (her tablo için `Index/Create/Update` admin ekranları)
  - `Services/ApiClient.cs` (tek noktadan API erişimi)
  - `appsettings.json` ( `ApiSettings:BaseUrl` ile API adresi)

---

### ✅ Case Gereksinimleri ile Eşleşme

- **En az 10 tablo**: 10+ entity mevcut (Service, Testimonial, Notification, NotificationType, About, ContactInfo, FAQ, Feature, Message, Slider, Client, Gallery, Subscribe, Chef).
- **Her tabloda CRUD**:
  - API: her entity için `GET`, `GET /{id}`, `POST`, `PUT`, `DELETE`.
  - UI: admin panelde her modül için `Index` (liste), `Create`, `Update`, `Delete` akışları.
- **DTO kullanımı zorunlu**:
  - API tarafında **her entity** için `CreateDto`, `UpdateDto`, `ResultDto`.
  - UI tarafında ayrıca WebUI DTO’ları (özellikle admin formlarında).
- **ViewComponent mimarisi**:
  - Ana sayfa Pricing hariç tüm bölümler ViewComponent ile parçalandı.
- **API + UI ayrımı**:
  - API tamamen bağımsız (`QuickStart.WepApi`), UI sadece HttpClient ile konuşur (`ApiClient`).

---

### 🚀 Çalıştırma Adımları

#### 1. Veritabanı

- SQL Server’da `DbQuickStartAkademiq` isimli bir veritabanı oluştur (ya da `QuickStart.WepApi/appsettings.json` içindeki connection string’i kendi DB’ne göre güncelle).
- Migration’lar projeye eklendi; DB’yi ayağa kaldırmak için (gerekirse):

```bash
cd "c:\Users\lunap\OneDrive\Masaüstü\MyProjects\QuickStart"
dotnet tool run dotnet-ef database update --project QuickStart.WepApi/QuickStart.WepApi.csproj --startup-project QuickStart.WepApi/QuickStart.WepApi.csproj
```

#### 2. API’yi çalıştır

```bash
cd "c:\Users\lunap\OneDrive\Masaüstü\MyProjects\QuickStart\QuickStart.WepApi"
dotnet run
```

> Çalıştıktan sonra tarayıcıdan API’yi (örneğin) `https://localhost:7051/swagger` veya API base adresinden test edebilirsin.

#### 3. WebUI’yi çalıştır

`QuickStart.WebUI/appsettings.json` içindeki:

```json
"ApiSettings": {
  "BaseUrl": "https://localhost:7051"
}
```

değerinin API’nin gerçek adresiyle aynı olduğundan emin ol.

Sonra:

```bash
cd "c:\Users\lunap\OneDrive\Masaüstü\MyProjects\QuickStart\QuickStart.WebUI"
dotnet run
```

- Ana sayfa: `DefaultController.Index`
- Admin panel: `/Dashboard/Index` ve sol menü üzerinden tüm CRUD modülleri.

---

### 🧭 Admin Panel Özellikleri

- **Dashboard**:  
  - Toplam testimonial sayısı, service sayısı gibi istatistikler.
- **Yönetim Modülleri (tam CRUD)**:
  - Bildirimler (`Notification`, `NotificationType`)
  - Müşteriler / Referanslar (`Testimonial`)
  - Servisler (`Service`)
  - Hakkımızda (`About`)
  - Özellikler (`Feature`)
  - Slider
  - SSS / FAQ
  - İletişim Bilgileri (`ContactInfo`)
  - Mesajlar (`Message`)
  - Clients
  - Galeri (`Gallery`)
  - Abonelikler (`Subscribe`)
  - Şefler (`Chef`)

---

### Notlar

- Proje **.NET 6** üzerinde çalışıyor (case gereği korunmuştur).
- CSS/tasarım, arkadaş projesinden farklı tutulmuştur; istenirse tema ve stil tarafı rahatça değiştirilebilir.