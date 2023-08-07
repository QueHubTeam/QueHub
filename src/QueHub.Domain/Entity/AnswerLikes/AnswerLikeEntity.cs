using QueHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueHub.Domain.Entity.AnswerLikes;

public class AnswerLikeEntity : Auditable
{
    public long AnswerId { get; set; }

    public long UserId { get; set;}

}