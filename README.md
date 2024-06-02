# eCommerce YMYP Server Projesi 😊😊
<b>YMYP öğrencilerimle</b> beraber kodlamaya başladığımız bir projedir.
Bu projede, detaylı bir <b>eTicaret</b> uygulamasının backend kısmını, en iyi uygulama yöntemlerini ve bilinen güçlü mimari yaklaşımları kullanarak, test edilebilir bir şekilde yazmaya başladık.

## Proje başlangıç tarihi: 19.05.2024

## Projede kodlama yapan öğrencilerim:
<ul>
	<li>
		<b>Cuma Köse</b> 💪
		<br>
		https://www.linkedin.com/in/turkmvc/
	</li>
	<li>
		<b>Emre Can Topaloğlu</b> 💪
		<br>
		https://www.linkedin.com/in/emre-can-topalo%C4%9Flu-83a2b5119/
	</li>
	<li>
		<b>Çağla Tunç Savaş</b> 💪
		<br>
		https://www.linkedin.com/in/%C3%A7a%C4%9Fla-tun%C3%A7-sava%C5%9F/
	</li>
	<li>
		<b>Harun Gündoğmuş</b> 💪
		<br>
		https://www.linkedin.com/in/harun-g%C3%BCndo%C4%9Fmu%C5%9F-98a796170/
	</li>
	<li>
		<b>Enes Demirtaş</b> 💪
		<br>
		https://www.linkedin.com/in/enesdemirtas4/
	</li>
	<li>
		<b>Mehmet Can Ünaldı</b> 💪
		<br>
		https://www.linkedin.com/in/mcunaldi/
	</li>
	<li>
		<b>Muhammet Furkan Ayhan</b> 💪
		<br>
		https://www.linkedin.com/in/mfurkanayhan/
	</li>
	<li>
		<b>Abdulmelik Öztunç</b> 💪
		<br>
		https://www.linkedin.com/in/abdulmelik-oztunc/
	</li>
	<li>
		<b>Bünyamin Toparlı</b> 💪
		<br>
		https://www.linkedin.com/in/b%C3%BCnyamin-toparli-089346280/
	</li>
</ul>

## Aşağıdaki teknoloji, kütüphane, pattern ve yaklaşımları kullanacağız:
**Mimari**
- Clean Architecture (with CQRS Pattern)

**Approach**
- (Domain-Driven Design yaklaşımından) Entity, Value Object, Domain Event

**Patterns**
- Result Pattern
- Generic Repository Pattern
- Unit Of Work Pattern
- Options Pattern
- Factory Pattern

**Yapılar**
- Smart Enum
- Unit Test

**Ek Konular**
- Sonar Qube ile kod kalitesi kontrolü

**Kütüphaneler**
- MediatR
- EntityFramework Core
- Automapper
- FluentValidation
- Ardalis.SmartEnum
- TS.Result
- TS.EntityFrameworkCore.GenericRepository
- Scrutor
- FluentAssertions (for Unit Test)
- NSubstitute (for Unit Test)

## Projenin genel yapısı
- Proje eTicaret projesi olacak
- Şirket bazlı ürün yüklenip satış yapılabileceği bir sistemimiz olmalı
- Database olarak PostgreSQL kullanacağız


## Projede olması gereken tablolar
- Category - SubCategory mantığı olması, <b>(Mehmet Can Ünaldı)</b>
- Company <b>(Cuma Köse) & (Harun Gündoğdu)</b>
- User <b>(Harun Gündoğdu)</b>
- User'lar Company ile İlişki kurabilmeli (Bir kullanıcı bir şirketi yönetebilmeli) <b>(Harun Gündoğdu)</b>
- Product - Category ile ilişkisi olmalı. (Bir ürün birden fazla category ile ilişkisi olabilmeli) <b>(Enes Demirtaş)</b> 
- Shopping Cart <b>(Emre Can)</b>
- Order <b>(Çağla)</b>
- Ödeme Entegrasyonu <b>Muhammet Furkan Ayhan</b>
- <b>Abdulmelik Öztunç'a Task Atanacak</b>
- <b>Bünyamin Toparlı'ya Task Atanacak</b>

## Kurulum notları
- PostgreSQL Docker Kurulum Kodu:
```powershell
docker run --name ecommercedb-postgres -e POSTGRES_PASSWORD=1 -e POSTGRES_DB=ecommercedb -d -p 5432:5432 postgres
```

# Mehmet Can Ünaldı Taskları

## Sorumluluk
- Category - SubCategory mantığı olması, <b>(Mehmet Can Ünaldı)</b>

## Entity yapısı
```csharp
public sealed class Category : Entity
{	
	public string Name { get; set; } = string.Empty;
	public Guid? MainCategoryId { get; set; }
	public Category? MainCategory { get; set; }
}
```

## Task 
<p><b>19.05.2024</b></p>
<ol>
    <li>
        <del>Entity'i oluştur</del>
		<br>
		Tamamlandı - 19.05.2024
		<br> 
		Kontrol Edildi - 19.05.2024
    </li>
    <li>
        <del>DbContext'e DbSet ile bağla</del> 
		<br>
		Tamamlandı - 19.05.2024
		<br> 
		Kontrol Edildi - 19.05.2024
    </li>
    <li>
        <del>Configuration dosyasını oluştur</del> 
		<br>
		Tamamlandı - 19.05.2024
		<br> 
		Kontrol Edildi - 19.05.2024
    </li>
    <li>
        <del>Açıklama ile git üzerinden pushla</del> 
		<br>
		Tamamlandı - 19.05.2024
		<br> 
		Kontrol Edildi - 19.05.2024
    </li>
</ol>

<p><b>21.05.2024</b></p>
<ol>
	<li>
		<del>Category için Create metodu yaz</del>
		<br>
		Tamamlandı - 21.05.2024
		<br> 
		Kontrol Edildi - 21.05.2024
		<ol>
			<li>
				<del>Validation kontrolü olsun</del>
				<br>
				Tamamlandı - 21.05.2024
				<br> 
				Kontrol Edildi - 21.05.2024
			</li>
			<li>
				<del>Unique check olsun</del>
				<br>
				Tamamlandı - 21.05.2024
				<br> 
				Kontrol Edildi - 21.05.2024
			</li>			
		</ol>
	</li>
	<li>
		<del>Category Create için endpoint yaz</del>
		<br>
		Tamamlandı - 21.05.2024
		<br> 
		Kontrol Edildi - 21.05.2024
	</li>
	<li>
		<del>Category Create için Unit Testler yaz</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
	</li>
	<li>
		<del>Açıklama ile git üzerinden pushla</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
	</li>
	<li>
		<del>Category için Update metodu yaz</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
		<ol>
			<li>
				<del>Validation kontrolü olsun</del>
				<br>
				Tamamlandı - 23.05.2024
				<br> 
				Kontrol Edildi - 23.05.2024
			</li>
			<li>
				<del>Eğer isim değiştiyse Unique check olsun</del>
				<br>
				Tamamlandı - 23.05.2024
				<br> 
				Kontrol Edildi - 23.05.2024
			</li>
		</ol>
	</li>
	<li>
		<del>Category Update için endpoint yaz</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
	</li>
	<li>
		<del>Category Update için Unit Testler yaz</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
	</li>
	<li>
		<del>Açıklama ile git üzerinden pushla</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
	</li>
	<li>
		<del>Category için Delete metodu yaz</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
		<ol>
			<li>
				<del>Direkt delete edilmesin IsDeleted seçeneği true olsun</del>
				<br>
				Tamamlandı - 23.05.2024
				<br> 
				Kontrol Edildi - 23.05.2024
			</li>
		</ol>
	</li>
	<li>
		<del>Category Delete için endpoint yaz</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
	</li>
	<li>
		<del>Category Delete için Unit Testler yaz</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
	</li>
	<li>
		<del>Açıklama ile git üzerinden pushla</del>
		<br>
		Tamamlandı - 23.05.2024
		<br> 
		Kontrol Edildi - 23.05.2024
	</li>
	<li>
		<del>Category için GetAll metodu yaz</del>	
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
	<li>
		<del>Category GetAll için endpoint yaz</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
	<li>
		<del>Category GetAll için Unit Testler yaz</del>	
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
	<li>
		<del>Açıklama ile git üzerinden pushla</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
</ol>


# Cuma Köse Taskları

## Sorumluluk
- Company <b>(Cuma Köse)</b>

## Entity yapısı
```csharp
public sealed class Company : Entity
{	
	public string Name { get; set; } = string.Empty;
	public string TaxDepartment { get; set; } = string.Empty;
	public string TaxNumber { get; set; } = string.Empty;
	public string City { get; set; } = string.Empty;
	public string Town { get; set; } = string.Empty;
	public string Street { get; set; } = string.Empty;
	public string FullAddress { get; set; } = string.Empty;	
}
```

## Task 
<p><b>21.05.2024</b></p>
<ol>
	<li>
		<del>Entity oluştur</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
		<ol>
			<li>
				Tax kısmı Value object olsun
			</li>
			<li>
				Tax Department bir SmartEnum'dan gelsin
			</li>
			<li>
				Tax Number 10-11 karakter arasında olsun
			</li>
		</ol>
	</li>
	<li>
		<del>DbContext'e DbSet ile bağla</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
	<li>
		<del>Configuration dosyasını oluştur</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
		<ol>
			<li>
				<del>Tax Number unique olmalı ve 10-11 karakter arasında olmalı</del>
				<br>
				Tamamlandı - 26.05.2024
				<br> 
				Kontrol Edildi - 26.05.2024
			</li>
		</ol>
	</li>
	<li>
		<del>Açıklama ile git üzerinden pushla</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
	<li>
		<del>Company Create metodu yaz</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
		<ol>
			<li>
				<del>Validation kontrolü yaz</del>
				<br>
				Tamamlandı - 26.05.2024
				<br> 
				Kontrol Edildi - 26.05.2024
			</li>
			<li>
				<del>TaxNumber için Unique check yap</del>
				<br>
				Tamamlandı - 26.05.2024
				<br> 
				Kontrol Edildi - 26.05.2024
			</li>
		</ol>
	</li>
	<li>
		<del>Company Create endpointi yaz</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
	<li>
		<del>Açıklama ile git üzerinden pushla</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>	
	<li>
		<del>Company Create için Unit Test yaz</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
	<li>
		<del>Açıklama ile git üzerinden pushla</del>
		<br>
		Tamamlandı - 26.05.2024
		<br> 
		Kontrol Edildi - 26.05.2024
	</li>
</ol>

# Harun Gündoğmuş

## Sorumluluk
- Company <b>(Harun Gündoğmuş)</b>

## Task 
<p><b>21.05.2024</b></p>
<ol>	
	<li>
		<del>Company Update metodu yaz</del>
		<br>
		Tamamlandı - 02.06.2024
		<br> 
		Kontrol Edildi - 02.06.2024
		<ol>
			<li>
				<del>Validation kontrolü yaz</del>
				<br>
				Tamamlandı - 02.06.2024
				<br> 
				Kontrol Edildi - 02.06.2024
			</li>
			<li>
				<del>TaxNumber değiştirilemesin, sadece yönetici bu kısmı updat edebilsin</del>
				<br>
				Tamamlandı - 02.06.2024
				<br> 
				Kontrol Edildi - 02.06.2024
			</li>
		</ol>
	</li>
	<li>
		<del>Company Update endpointi yaz</del>
		<br>
		Tamamlandı - 02.06.2024
		<br> 
		Kontrol Edildi - 02.06.2024
	</li>
	<li>
		<del>Company Update için Unit Test yaz</del>
		<br>
		Tamamlandı - 02.06.2024
		<br> 
		Kontrol Edildi - 02.06.2024
	</li>
	<li>
		<del>Açıklama ile git üzerinden pushla</del>
		<br>
		Tamamlandı - 02.06.2024
		<br> 
		Kontrol Edildi - 02.06.2024
	</li>
	<li>
		Company Delete metodu yaz
		<ol>
			<li>
				Direkt delete edilmesin IsDeleted seçeneği true olsun
			</li>
		</ol>
	</li>	
	<li>
		Company Delete için endpoint yaz
	</li>
	<li>
		Company Delete için Unit Test yaz
	</li>
	<li>
		Açıklama ile git üzerinden pushla
	</li>
	<li>
		Company için GetAll metodu yaz		
	</li>
	<li>
		Company GetAll için endpoint yaz
	</li>
	<li>
		Company GetAll için Unit Test yaz
	</li>
	<li>
		Company ile git üzerinden pushla
	</li>
</ol>