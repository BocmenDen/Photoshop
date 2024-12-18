# Что это?

Этот инструмент позволяет быстро заменить текстовые поля в файлах PSD и экспортировать результат в виде изображения.  Для работы требуется доступ к COM-объекту Photoshop. Т.е в проекте необходимо указать ссылку на COM представление Photoshop.

# Функциональность


Пример сохранения изображение и генерирации файла, содержащий соответствие между именами текстовых полей и именами слоёв в PSD-файле.  Это полезно для понимания структуры файла и сопоставления данных.:
```csharp
Application applicationClass = new();
var doc = applicationClass.OpenTextEditor(@"./Demo.psd");

foreach (var field in doc)
    doc[field] = field;
doc.Export("./FieldNames.jpg");
```

<div id="header" align="center">
  <h1>Результат</h1>
  <img src="https://raw.githubusercontent.com/BocmenDen/Photoshop/refs/heads/main/fieldNames.png" width="500"/>
</div>

Пример замены значений для файла Demo.psd:
```csharp
Application applicationClass = new();
var doc = applicationClass.OpenTextEditor(@"./Demo.psd");

doc["Phone"] = "+7834983289";
doc["Email"] = "Test@email.com";
doc["Site"] = "https://github.com/BocmenDen";
doc["Adress"] = "Москва";
doc["Name"] = "Bocmen";
doc["Role"] = "C# programmer";
doc.Export("./BusinessCardDemo.jpg");
```

<div id="header" align="center">
  <h1>Результат</h1>
  <img src="https://raw.githubusercontent.com/BocmenDen/Photoshop/refs/heads/main/BusinessCardDemo.png" width="500"/>
</div>