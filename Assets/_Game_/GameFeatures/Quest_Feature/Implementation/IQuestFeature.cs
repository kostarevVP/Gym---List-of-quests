using System.Collections.Generic;
using WKosArch.Domain.Features;

public interface IQuestFeature : IFeature
{
    List<ICollectionQuest> CollectionQuests { get; }
    List<IJourneyQuest> JourneyQuests { get; }
}