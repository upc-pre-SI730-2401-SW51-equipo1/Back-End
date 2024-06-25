
using ChromaComics.Comics.Domain.Model.ValueObjects;

namespace ChromaComics.Comics.Domain.Model.Entities;

public partial class Asset : IPublishable
{
    public int Id { get; }
    
    public ChromacomicsAssetIdentifier AssetIdentifier { get; private set; }
    public EPublishingStatus Status { get; protected set; }
    public EAssetType Type { get; private set; }
    public virtual bool Readable => false;
    public virtual bool Viewable => false;
    
    public Asset(EAssetType type)
    {
        Type = type;
        Status = EPublishingStatus.ReadyToEdit;
        AssetIdentifier = new ChromacomicsAssetIdentifier();
    }
    
    public void SendToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    public void SendToApproval()
    {
        Status = EPublishingStatus.ReadyToApproval;
    }

    public void ApproveAndLock()
    {
        Status = EPublishingStatus.ApprovedAndLocked;
    }

    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }
    
    public virtual object GetContent()
    {
        return string.Empty;
    }
}