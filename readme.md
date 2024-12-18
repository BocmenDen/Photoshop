# ��� ���?

���� ���������� ��������� ������ �������� ��������� ���� � ������ PSD � �������������� ��������� � ���� �����������.  ��� ������ ��������� ������ � COM-������� Photoshop. �.� � ������� ���������� ������� ������ �� COM ������������� Photoshop.

# ����������������


������ ���������� ����������� � ����������� �����, ���������� ������������ ����� ������� ��������� ����� � ������� ���� � PSD-�����.  ��� ������� ��� ��������� ��������� ����� � ������������� ������.:
```csharp
Application applicationClass = new();
var doc = applicationClass.OpenTextEditor(@"./Demo.psd");

foreach (var field in doc)
    doc[field] = field;
doc.Export("./FieldNames.jpg");
```

<div id="header" align="center">
  <h1>���������</h1>
  <img src="https://raw.githubusercontent.com/BocmenDen/Photoshop/refs/heads/main/fieldNames.png" width="500"/>
</div>

������ ������ �������� ��� ����� Demo.psd:
```csharp
Application applicationClass = new();
var doc = applicationClass.OpenTextEditor(@"./Demo.psd");

doc["Phone"] = "+7834983289";
doc["Email"] = "Test@email.com";
doc["Site"] = "https://github.com/BocmenDen";
doc["Adress"] = "������";
doc["Name"] = "Bocmen";
doc["Role"] = "C# programmer";
doc.Export("./BusinessCardDemo.jpg");
```

<div id="header" align="center">
  <h1>���������</h1>
  <img src="https://raw.githubusercontent.com/BocmenDen/Photoshop/refs/heads/main/BusinessCardDemo.png" width="500"/>
</div>