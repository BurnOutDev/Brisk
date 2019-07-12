using Brisk.Domain.Models;

namespace Brisk.Application
{
    public interface IGameService
    {
        GameModel StartNewGame(int userId);
        AnswerResponseModel Answer(AnswerModel answer, int userId);
    }
}