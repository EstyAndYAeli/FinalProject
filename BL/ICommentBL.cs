
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public interface ICommentBL
    {
        Task<bool> AddComment(Comment c);
        Task<List<Comment>> getAllRecommendations();
    }
}
