using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace DL
{
    public class CommentDL : ICommentDL
    {
        const int MIN_AVAILABLE = 5;
        private auto_parkingContext _context;
        public CommentDL(auto_parkingContext context)
        {
            _context = context;
        }


        public async Task<bool> AddComment(Comment c)
        {
            _context.Comment.Add(c);
            int n = await _context.SaveChangesAsync();
            if (n > 0)
                return true;
            return false;
        }

        public async Task<List<Comment>> getAllRecommendations()
        {
            return await _context.Comment.Where(c => c.ForManager == false).ToListAsync();
        }

        //    public async Task addCostumer(Costumer c)
        //    {

        //        _context.Costumer.Add(c);
        //        await _context.SaveChangesAsync();
        //    }

    }
}
