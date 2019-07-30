using Brisk.Domain.Models;

namespace Brisk.Application
{
    public interface IGameService
    {
        GameModel StartNewGame();
        AnswerResponseModel Answer(AnswerModel answer);
        void UpdatePlayerSettings(SettingsModel settings);
        SettingsModel PlayerSettings();
    }
}