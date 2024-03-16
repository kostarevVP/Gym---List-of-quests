using System.Collections.Generic;
using WKosArch.Domain.Features;

public interface IQuestFeature : IFeature
{
    List<IQuest> Quests { get; }
}