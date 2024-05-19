# Mehmet Can �nald� Tasklar�

## Sorumluluk
- Category - SubCategory mant��� olmas�, <b>(Mehmet Can �nald�)</b>

## Entity yap�s�
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
	<li>Entity'i olu�tur</li>
	<li>DbContext'e DbSet ile ba�la</li>
	<li>Configuration dosyas�n� olu�tur</li>
	<li>A��klama ile git �zerinden pushla</li>
</ol>