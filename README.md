<div align="center">

# 🤖 Aura AI Chat Application

### Gerçek zamanlı yapay zekâ sohbeti ve sesli iletişim deneyimi

**SignalR** ile anlık akış · **PostgreSQL** ile kalıcı sohbet geçmişi · **Gemini** ile zeka · **ElevenLabs** ile ses

<br/>

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SignalR](https://img.shields.io/badge/SignalR-Realtime-7C3AED?style=for-the-badge)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)
![Gemini](https://img.shields.io/badge/Google%20Gemini-8E75B2?style=for-the-badge&logo=googlegemini&logoColor=white)
![ElevenLabs](https://img.shields.io/badge/ElevenLabs-000000?style=for-the-badge&logo=elevenlabs&logoColor=white)

<br/>

</div>

---

## 📖 Proje Hakkında

**Aura**, yapay zekâ, gerçek zamanlı iletişim ve ses teknolojilerini bir araya getiren modern bir AI sohbet uygulamasıdır.

Kullanıcılar yapay zekâ ile **metin üzerinden sohbet edebilir**, geçmiş konuşmalarına her zaman ulaşabilir ve **sesli sohbet modu** sayesinde AI ile doğrudan konuşarak iletişim kurabilir.

> 💡 **Öne çıkan fikir:** AI cevabı tamamen oluşmasını beklemeden, **SignalR** üzerinden parça parça ekrana akar. Tüm sohbetler ise **PostgreSQL**'de güvenle saklanır.

---

## ✨ Özellikler

| | Özellik | Açıklama |
|---|---|---|
| 🔐 | **Kimlik Doğrulama** | ASP.NET Core Identity ile kayıt ve giriş sistemi |
| 💬 | **Yeni Sohbet** | İstenildiği kadar yeni konuşma başlatma |
| 🗂️ | **Sohbet Geçmişi** | Geçmiş konuşmaları görüntüleme ve devam etme |
| 🤖 | **Gemini AI** | Google Gemini API entegrasyonu |
| ⚡ | **Gerçek Zamanlı Mesajlaşma** | SignalR ile anlık iletişim |
| ✍️ | **Canlı Yanıt Akışı** | AI cevapları oluşurken parça parça gösterilir |
| 📝 | **Markdown Desteği** | Başlık, liste, tablo ve kod blokları düzgün render edilir |
| 📋 | **Kod Kopyalama** | Kod bloklarını tek tıkla kopyalama |
| 🎙️ | **Sesli Mesaj** | Mikrofon ile mesaj gönderme (Speech-to-Text) |
| 🔊 | **Cevabı Dinleme** | AI cevaplarını sesli dinleme (Text-to-Speech) |
| 🗣️ | **Sesli Sohbet Modu** | Yazmadan, tamamen sesle AI ile konuşma |
| 🗄️ | **Kalıcı Depolama** | Sohbet ve mesajlar PostgreSQL'de saklanır |
| 📱 | **Responsive Tasarım** | Modern, pastel renkli, mobil uyumlu arayüz |

---

## 🛠️ Teknoloji Yığını

<table>
<tr>
<td valign="top" width="33%">

### ⚙️ Backend
- C#
- .NET
- ASP.NET Core MVC
- **SignalR**
- Entity Framework Core
- **PostgreSQL**
- ASP.NET Core Identity
- MediatR

</td>
<td valign="top" width="33%">

### 🧠 Yapay Zekâ & Ses
- Google Gemini API
- ElevenLabs Speech-to-Text
- ElevenLabs Text-to-Speech

</td>
<td valign="top" width="33%">

### 🎨 Frontend
- HTML
- CSS
- JavaScript
- SignalR JavaScript Client
- Marked.js
- DOMPurify

</td>
</tr>
</table>

---

## 🗄️ PostgreSQL

Tüm kullanıcı, sohbet ve mesaj verileri **PostgreSQL** veritabanında saklanır ve **Entity Framework Core** ile yönetilir.

Her mesaj ilgili sohbete bağlıdır; böylece geçmiş konuşmalar istenildiği zaman aynı sırayla yeniden yüklenebilir.

---

## 🎙️ Sesli Sohbet

Metin sohbetinin yanında, daha odaklı bir deneyim sunan ayrı bir **sesli sohbet ekranı** bulunur.

Kullanıcı mikrofona konuşur, söyledikleri otomatik olarak metne çevrilir ve AI'ya gönderilir. AI'nın cevabı oluşturulduktan sonra sese dönüştürülüp kullanıcıya oynatılır.

```text
🎙️ Kullanıcı konuşur
        ↓
ElevenLabs Speech-to-Text
        ↓
      Metin
        ↓
    Gemini AI
        ↓
    AI cevabı
        ↓
ElevenLabs Text-to-Speech
        ↓
🔊 Sesli cevap
```

Böylece kullanıcı tek bir mesaj yazmadan, uygulama ile doğrudan **sesli olarak iletişim kurabilir**.

### 🔊 Metin Sohbetinde Sesli Cevaplar

Normal sohbet ekranında da her AI mesajının yanında bir **ses butonu** bulunur. Butona basıldığında cevap ElevenLabs Text-to-Speech servisine gönderilir ve oluşturulan ses oynatılır.

---

## 🎨 Kullanıcı Arayüzü

Sade, modern ve göz yormayan bir **pastel renk paleti** kullanılmıştır.

**💬 Ana sohbet ekranı**

- 🗂️ Sohbet geçmişi paneli
- 💬 Mesajlaşma alanı
- 🤖 Markdown destekli AI mesajları
- ⌨️ Mesaj gönderme alanı
- 🎙️ Mikrofon butonu
- 🔊 Cevabı dinleme butonu

**🗣️ Sesli sohbet ekranı**

- Sadece konuşmaya odaklanan minimal bir arayüz

---


## 🎬 Demo Videosu

Uygulamanın çalışırken nasıl göründüğünü aşağıdaki videodan izleyebilirsiniz.

<div align="center">

[![Aura AI Chat Demo Videosu](https://img.youtube.com/vi/23UWtMJ8fEE/maxresdefault.jpg)](https://youtu.be/23UWtMJ8fEE)

▶️ **[Videoyu YouTube'da izle](https://youtu.be/23UWtMJ8fEE)**

</div>

<br/>

---

<div align="center">

**Yapay zekâ · Gerçek zamanlı iletişim · Ses teknolojileri**

⭐ Projeyi beğendiyseniz bir yıldız bırakmayı unutmayın!

</div>
