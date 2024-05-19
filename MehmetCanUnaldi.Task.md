# Mehmet Can Ünaldý Tasklarý

## Sorumluluk
- Category - SubCategory mantýðý olmasý, <b>(Mehmet Can Ünaldý)</b>

## Entity yapýsý
```csharp
public sealed class Category : Entity
{	
	public string Name { get; set; } = string.Empty;
	public Guid? MainCategoryId { get; set; }
	public Category? MainCategory { get; set; }
}
```

## Task 
<b>19.05.2024</b>
<ol>
	<li>Entity'i oluþtur</li>
	<li>DbContext'e DbSet ile baðla</li>
	<li>Configuration dosyasýný oluþtur</li>
	<li>Açýklama ile git üzerinden pushla</li>
</ol>