namespace ERDS.Domain.Enums;

public enum ResourceState
{
    New,
    InUse,
    Aging,
    DueForReplacement,
    Lost,
    Returned,
    Reassigned
}
