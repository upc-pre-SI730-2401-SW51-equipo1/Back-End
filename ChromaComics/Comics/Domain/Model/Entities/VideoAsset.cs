
using ChromaComics.Comics.Domain.Model.ValueObjects;

namespace ChromaComics.Comics.Domain.Model.Entities;

public class VideoAsset : ChromaComics.Comics.Domain.Model.Entities.Asset
{
    public Uri? VideoUri { get; private set; }
    
    public override bool Readable => false;
    public override bool Viewable => true;
    
    public VideoAsset() : base(EAssetType.Video) { VideoUri = null; }

    public VideoAsset(string videoUrl) : base(EAssetType.Video) => VideoUri = new Uri(videoUrl);

    public override string GetContent() => VideoUri != null ? VideoUri.AbsoluteUri : string.Empty;
}