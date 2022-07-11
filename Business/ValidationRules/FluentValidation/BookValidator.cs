using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.BookName).NotEmpty();
            RuleFor(b => b.BookName).MinimumLength(2);

            RuleFor(b => b.Price).NotEmpty();
            RuleFor(b => b.Price).GreaterThan(0);

            RuleFor(b => b.PageNumber).NotEmpty();

        }
    }
}
