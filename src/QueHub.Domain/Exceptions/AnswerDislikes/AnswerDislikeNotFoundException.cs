using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueHub.Domain.Exceptions.AnswerLikes;

public class AnswerDislikeNotFoundException: NotFoundException
{

    public AnswerDislikeNotFoundException()
    {
        TitleMessage = "Answer dislike  not found!";
    }

}