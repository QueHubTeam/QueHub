﻿using QueHub.Domain.Commons;
using QueHub.Domain.Entity.Answers;
using QueHub.Domain.Entity.User;

namespace QueHub.Domain.Entity.AnswerDislikes;

public class AnswerDislikeEntity : Auditable
{
    public long AnswerId { get; set; }
    public AnswerEntity Answer { get; set; }

    public long UserId { get; set;}
    public UserEntity User { get; set;}
}