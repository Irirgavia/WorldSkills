namespace BLL.Services.Interfaces
{
    using System;

    public interface IJudgeService : IDisposable
    {
        void RateAnswer(int answerId, float mark, string notes);
    }
}