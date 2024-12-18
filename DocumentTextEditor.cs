using System.Collections;

namespace Photoshop
{
    public class DocumentTextEditor: IEnumerable<string>
    {
        private readonly Document? _document;
        private readonly Dictionary<int, ArtLayer> _fields= [];
        public IEnumerable<string> Fields => _fields.Values.Select(x => x.Name).Distinct();
        public IReadOnlyCollection<int> Id => _fields.Keys;

        public string? this[string field]
        {
            set
            {
                foreach (var val in _fields)
                {
                    if (val.Value.Name != field) continue;
                    val.Value.TextItem.Contents = value;
                }
            }
        }

        public string? this[int id]
        {
            get
            {
                if (_fields.TryGetValue(id, out var val))
                    return val.TextItem.Contents;
                return null;
            }
            set
            {
                if (_fields.TryGetValue(id, out var val))
                    val.TextItem.Contents = value;
            }
        }

        public DocumentTextEditor(Document document)
        {
            _document=document??throw new ArgumentNullException(nameof(document));
            LoadFields(_document.Layers);
        }

        private void LoadFields(Layers layers)
        {
            foreach (dynamic layer in layers)
            {
                if (layer.LayerType == (int)PsLayerType.psLayerSet)
                {
                    LoadFields(layer.Layers);
                    continue;
                }
                if (layer.Kind != (int)PsLayerKind.psTextLayer) continue;
                _fields.Add(layer.id, layer);
            }
        }

        public bool Contains(string field) => _fields.Values.Select(x => x.Name).Contains(field);

        public void Export(string path, bool isJPG = false)
        {
            path = Path.GetFullPath(path);
            object saveParametr = isJPG ? new JPEGSaveOptions()
            {
                Quality = 12
            } : new PNGSaveOptions()
            {
                
            };
            _document?.SaveAs(path, saveParametr, true);
        }

        public IEnumerator<string> GetEnumerator() => Fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Fields.GetEnumerator();
    }

    public static class Extensions
    {
        public static DocumentTextEditor OpenTextEditor(this Application app, string path)
            => new(app.Open(Path.GetFullPath(path)));
    }
}