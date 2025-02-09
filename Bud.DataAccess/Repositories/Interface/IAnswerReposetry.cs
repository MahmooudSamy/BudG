﻿using BudG.Domain;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Interface
{
    public interface IAnswerReposetry
    {
        Task<Answer> GetAsyncById(int questionId,int userId);
        Task<Answer> CheckAnswerAsyncByAnswer(string answer);
        Task SaveAsync();
        bool HasChanges();
        void Add(Answer answer);
        void Remove(Answer answer);
    }
}
