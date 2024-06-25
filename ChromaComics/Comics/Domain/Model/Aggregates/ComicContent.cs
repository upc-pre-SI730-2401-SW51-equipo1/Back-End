
using ChromaComics.Comics.Domain.Model.Entities;
using ChromaComics.Comics.Domain.Model.ValueObjects;

namespace ChromaComics.Comics.Domain.Model.Aggregates;

public partial class Comic : IPublishable
{
     public Comic()
    {
        Title = string.Empty;
        Summary = string.Empty;
        Assets = new List<Asset>();
        Status = EPublishingStatus.Draft;
    }

    public ICollection<Asset> Assets { get; }

    public EPublishingStatus Status { get; protected set; }

    public bool Readable => HasReadableAssets;
    public bool Viewable => HasViewableAssets;

    public bool HasReadableAssets => Assets.Any(asset => asset.Readable);

    public bool HasViewableAssets => Assets.Any(asset => asset.Viewable);

    public void SendToEdit()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToEdit))
            Status = EPublishingStatus.ReadyToEdit;
    }

    public void SendToApproval()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToApproval))
            Status = EPublishingStatus.ReadyToApproval;
    }

    public void ApproveAndLock()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ApprovedAndLocked))
            Status = EPublishingStatus.ApprovedAndLocked;
    }

    public void Reject() => Status = EPublishingStatus.Draft;

    public void ReturnToEdit() => Status = EPublishingStatus.ReadyToEdit;

    public List<ContentItem> GetContent()
    {
        var content = new List<ContentItem>();
        if (Assets.Count > 0)
            content.AddRange(Assets.Select(asset =>
                new ContentItem(asset.Type.ToString(), asset.GetContent() as string ?? string.Empty)));
        return content;
    }

    public void AddImage(string imageUrl)
    {
        if (ExistsImageByUrl(imageUrl)) return;
        Assets.Add(new ImageAsset(imageUrl));
    }

    private bool ExistsImageByUrl(string imageUrl) => Assets.Any(asset => asset.Type == EAssetType.Image && (string)asset.GetContent() == imageUrl);

    private bool ExistsReadableContent(string content) =>
        Assets.Any(
            asset => asset.Type == EAssetType.ReadableContentItem && (string)asset.GetContent() == content);

    private bool HasAllAssetsWithStatus(EPublishingStatus status) => Assets.All(asset => asset.Status == status);

    private bool ExistsVideoByUrl(string videoUrl) => Assets.Any(asset => asset.Type == EAssetType.Video && (string)asset.GetContent() == videoUrl);

    public void AddVideo(string videoUrl)
    {
        if (ExistsVideoByUrl(videoUrl)) return;
        Assets.Add(new VideoAsset(videoUrl));
    }

    public void AddReadableContent(string content)
    {
        if (ExistsReadableContent(content)) return;
        Assets.Add(new ReadableContentAsset(content));
    }

    public void RemoveAsset(ChromacomicsAssetIdentifier identifier)
    {
        var asset = Assets.FirstOrDefault(a => a.AssetIdentifier == identifier);
        if (asset != null) Assets.Remove(asset);
    }

    public void ClearAssets() => Assets.Clear();
}