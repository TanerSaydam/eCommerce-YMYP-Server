﻿# eCommerce YMYP Server Projesi 😊😊
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
- Company <b>(Cuma Köse)</b>
- User <b>(Harun Gündoğdu)</b>
- User'lar Company ile İlişki kurabilmeli (Bir kullanıcı bir şirketi yönetebilmeli) <b>(Harun Gündoğdu)</b>
- Product - Category ile ilişkisi olmalı. (Bir ürün birden fazla category ile ilişkisi olabilmeli) <b>(Enes Demirtaş)</b> 
- Shopping Cart <b>(Emre Can)</b>