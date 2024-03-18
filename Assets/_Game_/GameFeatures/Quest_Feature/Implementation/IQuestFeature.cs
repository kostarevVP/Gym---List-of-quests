using Assets.Game.Services.ProgressService.api;
using System.Collections.Generic;
using WKosArch.Domain.Features;

public interface IQuestFeature : IFeature, ISavedProgress
{
    List<IQuest> Quests { get; }
}