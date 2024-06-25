
using ChromaComics.Comics.Domain.Model.ValueObjects;

namespace ChromaComics.Comics.Domain.Model.Entities;

public class ReadableContentAsset : ChromaComics.Comics.Domain.Model.Entities.Asset
{
    public string ReadableContent { get; set; }

    public override bool Readable => true;
    public override bool Viewable => false;

    public override string GetContent()
    {
        return ReadableContent;
    }

    public ReadableContentAsset() : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = string.Empty;
    }
    
    public ReadableContentAsset(string content) : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = content;
    }
}